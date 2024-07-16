
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vocabularly.Features.Words.UpdateWord;
using Vocabularly.Persistence;

namespace Vocabularly.Features.Words.CreateWord;

internal sealed class UpdateWordCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<UpdateWordCommand, Guid>
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Guid> Handle(UpdateWordCommand request, CancellationToken cancellationToken)
    {
        var word = await _dbContext.Words.SingleOrDefaultAsync(w => w.Id == request.Id, cancellationToken);

        if (word is null) throw new KeyNotFoundException($"Word with id: ${request.Id} not found");

        word.EnglishWord = request.EnglishWord;
        word.EnglishExample = request.EnglishExample;
        word.ForeignWord = request.ForeignWord;
        word.ForeignExample = request.ForeignExample;

        await _dbContext.SaveChangesAsync();

        return word.Id;
    }
}