record Message([property: JsonPropertyName("role")] string Role,
    [property: JsonPropertyName("content")] string Content);

record GptPrompt([property: JsonPropertyName("messages")] List<Message> Messages,
    [property: JsonPropertyName("max_tokens")] int Max_tokens,
    [property: JsonPropertyName("temperature")] double temperature,
    [property: JsonPropertyName("n")] int N = 1,
    [property: JsonPropertyName("stop")] string? Stop = null
    );

record DavinciPrompt([property: JsonPropertyName("prompt")] string Prompt,
    [property: JsonPropertyName("max_tokens")] int Max_tokens,
    [property: JsonPropertyName("temperature")] double temperature,
    [property: JsonPropertyName("n")] int N = 1,
    [property: JsonPropertyName("stop")] string? Stop = null
    );

record GptChoice([property: JsonPropertyName("role")] int Index,
    [property: JsonPropertyName("finish_reason")] string FinishReason,
    [property: JsonPropertyName("message")] Message Message);

record Usage([property: JsonPropertyName("completion_tokens")] int CompletionTokens,
    [property: JsonPropertyName("prompt_tokens")] int PromptTokens,
    [property: JsonPropertyName("total_tokens")] int TotalTokens);

record GptCompletion(
    [property: JsonPropertyName("role")] string Id,
    [property: JsonPropertyName("object")] string Object,
    [property: JsonPropertyName("created")] long Created,
    [property: JsonPropertyName("model")] string Model,
    [property: JsonPropertyName("choices")] List<GptChoice> Choices,
    [property: JsonPropertyName("usage")] Usage Usage);

record DavinciChoice([property: JsonPropertyName("role")] int Index,
    [property: JsonPropertyName("finish_reason")] string FinishReason,
    [property: JsonPropertyName("text")] string Text);

record DavinciCompletion(
    [property: JsonPropertyName("role")] string Id,
    [property: JsonPropertyName("object")] string Object,
    [property: JsonPropertyName("created")] long Created,
    [property: JsonPropertyName("model")] string Model,
    [property: JsonPropertyName("choices")] List<DavinciChoice> Choices,
    [property: JsonPropertyName("usage")] Usage Usage);

record Car(string VIN, string Make, string Model, int Year, string Color, string Motor, string Package, int milage, double price)
{
    public sealed override string ToString()
    {
        return $"{Year} {Make} {Model} {Color} {Motor} {Package} with {milage} miles for ${price}";
    }
};
record CarTranslation(string VIN, string En, string ES);

public record Learning(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("content")] string Content);

public record Chunk(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("file")] string File);



public class ChunkInfo
{
    public int Index { get; set; }
    public string? Content { get; set; }
    public string? Summary { get; set; }
    public int Words { get; set; }
    public int Characters { get; set; }
    public int Tokens { get; set; }
}

enum Role
{
    system,
    user
}