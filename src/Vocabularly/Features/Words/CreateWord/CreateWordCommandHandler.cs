
using MediatR;

using Vocabularly.Domain;

namespace Vocabularly.Features.Words.CreateWord;

public class CreateWordCommandHandler : IRequestHandler<CreateWordCommand, Word>
{
    private static readonly List<Word> WordsRepository = [];

    public async Task<Word> Handle(CreateWordCommand request, CancellationToken cancellationToken)
    {
        var word = new Word 
        {
            EnglishWord = request.EnglishWord,
            ForeignWord = request.ForeignWord,
            EnglishExample =  request.EnglishExample,
            ForeignExample =  request.ForeignExample,
        };

        WordsRepository.Add(word);

        return word;
    }
}