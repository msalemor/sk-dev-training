async Task<Tuple<string?, int, int>> GetGptCompletionAsync(HttpClient client, string uri, List<Message> history)
{
    var payload = new GptPrompt(history, 1000, 0.3d);
    var json = JsonSerializer.Serialize(payload);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    // Note: We could add retry logic here
    var response = await client.PostAsync(new Uri(uri), content);

    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine($"Error: {response.StatusCode} {response.ReasonPhrase}");
        return new Tuple<string?, int, int>(null, 0, 0);
    }

    var completion = await response.Content.ReadAsStringAsync();
    var completionObject = JsonSerializer.Deserialize<GptCompletion>(completion);

    if (completionObject is not null)
    {
        var choice = completionObject.Choices[0];
        if (choice is not null)
        {
            return new Tuple<string?, int, int>(choice.Message.Content,
                completionObject.Usage.CompletionTokens,
                completionObject.Usage.PromptTokens);
        }
    }
    return new Tuple<string?, int, int>(null, 0, 0);
}

HttpContent? CreateJsonContent(object? payload)
{
    HttpContent? content = null;
    if (payload is not null)
    {
        byte[] utf8Bytes = payload is string s ?
            Encoding.UTF8.GetBytes(s) :
            JsonSerializer.SerializeToUtf8Bytes(payload);

        content = new ByteArrayContent(utf8Bytes);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
    }

    return content;
}

async Task<Tuple<string?, int, int>> GetDavinciCompletionAsync(HttpClient client, string uri, string apiKey, string prompt)
{
    int retries = 0;
    int delay = 0;
    var content = CreateJsonContent(new DavinciPrompt(prompt, 1000, 0.3d));

    // Note: We could add retry logic here
    while (true)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, new Uri(uri));
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.Add("api-key", $"{apiKey}");
        request.Headers.Add("accept", "application/json");
        //request.Headers.Add("accept-encoding", "gzip, deflate");
        request.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36 Edg/114.0.1823.86");
        //request.Headers.Add("x-ms-request-id", $"{gid}");
        request.Content = content;

        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var completion = await response.Content.ReadAsStringAsync();
            var completionObject = JsonSerializer.Deserialize<DavinciCompletion>(completion);

            if (completionObject is not null)
            {
                var choice = completionObject.Choices[0];
                if (choice is not null)
                {
                    return new Tuple<string?, int, int>(choice.Text,
                        completionObject.Usage.CompletionTokens,
                        completionObject.Usage.PromptTokens);
                }
            }
            else
            {
                Console.WriteLine($"Error: there was not payload from the server.");
                return new Tuple<string?, int, int>(null, 0, 0);
            }
        }

        retries++;

        if (retries == 5)
        {
            Console.WriteLine($"Failed after 5 retries. Error: {response.StatusCode} {response.ReasonPhrase}");
            return new Tuple<string?, int, int>(null, 0, 0);
        }

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            delay = response.Headers.RetryAfter.Delta?.Seconds ?? 2;
            Console.WriteLine($"Retry: {retries}. Server requesting a {delay}s delay to try again.\n");
            await Task.Delay(delay * 1000);
        }
    }
    return new Tuple<string?, int, int>(null, 0, 0);
}
