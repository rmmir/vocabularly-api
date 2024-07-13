
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vocabularly.Domain;
using Vocabularly.Persistence;

namespace Vocabularly.Features.Words.GetWordById;

public class GetWordByIdQueryHandler(ApplicationDbContext dbContext) : IRequestHandler<GetWordByIdQuery, Word?>
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Word?> Handle(GetWordByIdQuery request, CancellationToken cancellationToken)
    {
        var word = await _dbContext.Words.SingleOrDefaultAsync(w => w.Id == request.Id, cancellationToken);
    
        return word;
    }
}