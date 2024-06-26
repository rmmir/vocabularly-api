namespace Vocabularly.Domain;

public class Word
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string EnglishWord { get; set; }
    public required string ForeignWord { get; set; }
    public string? EnglishExample { get; set; }
    public string? ForeignExample { get; set; }

}