using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vocabularly.Domain;
using Vocabularly.Features.Words.GetAllWords;
using Vocabularly.Features.Words.GetWordById;
using Vocabularly.Features.Words.CreateWord;
using Vocabularly.Features.Words.DeleteWord;
using Vocabularly.Features.Words.UpdateWord;

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

    [HttpPut("{wordId:guid}")]
    public async Task<ActionResult<Word>> Update(Guid wordId, UpdateWordCommand command)
    {
        var sendCommand = command with { Id = wordId };
        
        return Ok(await _sender.Send(sendCommand));
    }

    [HttpDelete("{wordId:guid}")]
    public async Task<ActionResult<Guid>> Delete(Guid wordId)
    {
        return Ok(await _sender.Send(new DeleteWordCommand(wordId)));
    }
}