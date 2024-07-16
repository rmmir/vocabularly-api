using MediatR;
using Microsoft.EntityFrameworkCore;
using Vocabularly.Persistence;

namespace Vocabularly.Features.Words.DeleteWord;

public class DeleteWordCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<DeleteWordCommand, Guid>
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Guid> Handle(DeleteWordCommand request, CancellationToken cancellationToken)
    {
        var word = await _dbContext.Words.SingleOrDefaultAsync(w => w.Id == request.Id, cancellationToken);

        if (word is null) throw new KeyNotFoundException($"Word with id: ${request.Id} not found");

        _dbContext.Words.Remove(word);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return word.Id;
    }
}