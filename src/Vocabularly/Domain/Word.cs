namespace Vocabularly.Domain;

public class Word
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string EnglishWord { get; set; }
    public required string ForeignWord { get; set; }
    public string? EnglishExample { get; set; } = null;
    public string? ForeignExample { get; set; } = null;
    public int Score { get; set; } = 0;
    public WordType Type { get; set; }
}


public enum WordType 
{
    Substantive,
    Verb,
    Adjective,
    Pronoun,
    Adverbs,
    Preposition,
    Conjunction,
    Interjection,
}