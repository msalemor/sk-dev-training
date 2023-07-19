record Message([property: JsonPropertyName("role")] string Role,
    [property: JsonPropertyName("content")] string Content);

record Prompt([property: JsonPropertyName("messages")] List<Message> Messages,
    [property: JsonPropertyName("max_tokens")] int Max_tokens,
    [property: JsonPropertyName("temperature")] double temperature,
    [property: JsonPropertyName("n")] int N = 1,
    [property: JsonPropertyName("stop")] string? Stop = null
    );

record Choice([property: JsonPropertyName("role")] int Index,
    [property: JsonPropertyName("finish_reason")] string FinishReason,
    [property: JsonPropertyName("message")] Message Message);

record Usage([property: JsonPropertyName("completion_tokens")] int CompletionTokens,
    [property: JsonPropertyName("prompt_tokens")] int PromptTokens,
    [property: JsonPropertyName("total_tokens")] int TotalTokens);

record Completion(
    [property: JsonPropertyName("role")] string Id,
    [property: JsonPropertyName("object")] string Object,
    [property: JsonPropertyName("created")] long Created,
    [property: JsonPropertyName("model")] string Model,
    [property: JsonPropertyName("choices")] List<Choice> Choices,
    [property: JsonPropertyName("usage")] Usage Usage);

enum Role
{
    system,
    user
}