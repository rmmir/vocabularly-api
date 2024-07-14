using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vocabularly.Domain;
using Vocabularly.Features.Words.GetAllWords;
using Vocabularly.Features.Words.GetWordById;
using Vocabularly.Features.Words.CreateWord;
using Vocabularly.Features.Words.DeleteWord;
using Vocabularly.Features.Words.EditWord;

namespace Vocabularly.Controllers;

[ApiController]
[Route("[controller]")]
public class WordsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var words = await _sender.Send(new GetAllWordsQuery());

        return Ok(words);
    }

    [HttpGet("{wordId:guid}")]
    public async Task<IActionResult> GetById(Guid wordId)
    {
        var word = await _sender.Send(new GetWordByIdQuery(wordId));

        return word is null
            ? Problem(
                statusCode: StatusCodes.Status404NotFound,
                detail: $"Word with id '{wordId}' could not be found.")
            : Ok(word);
    }

    [HttpPost]
    public async Task<ActionResult<Word>> Create(CreateWordCommand command)
    {
        var word = await _sender.Send(command);

        return CreatedAtAction(
            nameof(GetById),
            new { WordId = word.Id },
            word);
    }

    [HttpDelete("{wordId:guid}")]
    public async Task<OkResult> Delete(Guid wordId)
    {
        await _sender.Send(new DeleteWordCommand(wordId));

        return Ok();
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
}