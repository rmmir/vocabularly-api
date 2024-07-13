using MediatR;
using Microsoft.EntityFrameworkCore;
using Vocabularly.Domain;
using Vocabularly.Persistence;

namespace Vocabularly.Features.Words.CreateWord;

public class CreateWordValidator(ApplicationDbContext dbContext) : IPipelineBehavior<CreateWordCommand, Word> 
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Word> Handle(CreateWordCommand request, RequestHandlerDelegate<Word> next, CancellationToken cancellationToken)
    {
        var word = await _dbContext.Words.FirstOrDefaultAsync(w =>
            w.EnglishWord.ToLower() == request.EnglishWord.ToLower() &&
            w.ForeignWord.ToLower() == request.ForeignWord.ToLower(),
            cancellationToken);

        return word is not null ? throw new ApplicationException($"Word '{request.EnglishWord}' is already used") : await next();
    }
}