using System.Runtime.InteropServices;

using Microsoft.AspNetCore.Mvc;
using Vocabularly.Domain;

namespace Vocabularly.Controllers;

[ApiController]
[Route("[controller]")]
public class WordsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(CreateWordRequest request)
    {
        var word = new Word
        {
            EnglishWord = request.EnglishWord,
            ForeignWord = request.ForeignWord,
            EnglishExample = request.EnglishExample,
            ForeignExample = request.ForeignExample,
        };

        // create the word

        //

        var response = new WordResponse(
            word.Id,
            word.EnglishWord,
            word.ForeignWord,
            word.EnglishExample,
            word.ForeignExample
        );

        return CreatedAtAction(
            nameof(Get),
            new { WordId = word.Id },
            response);
    }

    [HttpGet("{wordId:guid}")]
    public IActionResult Get(Guid wordId)
    {
        return Ok();
    }

    public record CreateWordRequest(
        string EnglishWord,
        string ForeignWord,
        string EnglishExample,
        string ForeignExample
        // WordType Type
    );

     public record WordResponse(
        Guid Id,
        string EnglishWord,
        string ForeignWord,
        string EnglishExample,
        string ForeignExample
        // WordType Type
    );

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
}