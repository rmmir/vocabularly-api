using Microsoft.AspNetCore.Mvc;
using Vocabularly.Domain;
using Vocabularly.Services;

namespace Vocabularly.Controllers;

[ApiController]
[Route("[controller]")]
public class WordsController(WordsService wordsService) : ControllerBase
{
    private readonly WordsService _wordsService = wordsService;

    [HttpPost]
    public IActionResult Create(CreateWordRequest request)
    {
        var word = request.ToDomain();

        _wordsService.Create(word);

        return CreatedAtAction(
            nameof(Get),
            new { WordId = word.Id },
            WordResponse.FromDomain(word));
    }

    [HttpGet("{wordId:guid}")]
    public IActionResult Get(Guid wordId)
    {
        var wordResponse = _wordsService.Get(wordId);

        return wordResponse is null
            ? Problem(
                statusCode: StatusCodes.Status404NotFound,
                detail: $"Word with id '{wordId}' could not be found.")
            : Ok(WordResponse.FromDomain(wordResponse));
    }

    public record CreateWordRequest(
        string EnglishWord,
        string ForeignWord,
        string? EnglishExample = null,
        string? ForeignExample = null)
    {
        public Word ToDomain()
        {
            return new Word
            {
                EnglishWord = EnglishWord,
                ForeignWord = ForeignWord,
                EnglishExample = EnglishExample,
                ForeignExample = ForeignExample,
            };
        }
    }

    // public enum WordType 
    // {
    //     Substantive,
    //     Verb,
    //     Adjective,
    //     Pronoun,
    //     Adverbs,
    //     Preposition,
    //     Conjunction,
    //     Interjection,
    // }

    public record WordResponse(
        Guid Id,
        string EnglishWord,
        string ForeignWord,
        string? EnglishExample = null,
        string? ForeignExample = null)
        // WordType Type)
    {
        public static WordResponse FromDomain(Word word)
        {
            return new WordResponse(
                word.Id,
                word.EnglishWord,
                word.ForeignWord,
                word.EnglishExample,
                word.ForeignExample);
        }
    }
}