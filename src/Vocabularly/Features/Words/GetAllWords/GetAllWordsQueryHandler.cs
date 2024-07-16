
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vocabularly.Domain;
using Vocabularly.Persistence;

namespace Vocabularly.Features.Words.GetAllWords;

internal sealed class GetAllWordsQueryHandler(ApplicationDbContext dbContext) : IRequestHandler<GetAllWordsQuery, IEnumerable<Word>>
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Word>> Handle(GetAllWordsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Word> word = await _dbContext.Words.ToListAsync(cancellationToken) ?? [];
    
        return word;
    }
}