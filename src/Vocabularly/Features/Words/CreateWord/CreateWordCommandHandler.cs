
using MediatR;
using Vocabularly.Domain;
using Vocabularly.Persistence;

namespace Vocabularly.Features.Words.CreateWord;

internal sealed record CreateWordCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateWordCommand, Word>
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Word> Handle(CreateWordCommand request, CancellationToken cancellationToken)
    {
        var word = new Word 
        {
            EnglishWord = request.EnglishWord,
            ForeignWord = request.ForeignWord,
            EnglishExample =  request.EnglishExample,
            ForeignExample =  request.ForeignExample,
        };

        _dbContext.Words.Add(word);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return word;
    }
}
