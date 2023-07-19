async Task<Tuple<string?, int, int>> GetGptCompletionAsync(HttpClient client, string uri, List<Message> history)
{
    var prompt = new Prompt(history, 1000, 0.3d);
    var json = JsonSerializer.Serialize(prompt);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    // Note: We could add retry logic here
    var response = await client.PostAsync(new Uri(uri), content);

    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine($"Error: {response.StatusCode} {response.ReasonPhrase}");
        return new Tuple<string?, int, int>(null, 0, 0);
    }

    Console.WriteLine("made it.");

    var completion = await response.Content.ReadAsStringAsync();
    var completionObject = JsonSerializer.Deserialize<Completion>(completion);

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