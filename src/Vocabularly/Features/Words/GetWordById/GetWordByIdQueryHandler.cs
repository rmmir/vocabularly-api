
using MediatR;
using Vocabularly.Domain;

namespace Vocabularly.Features.Words.GetWordById;

public class GetWordByIdQueryHandler : IRequestHandler<GetWordByIdQuery, Word?>
{
    private static readonly List<Word> WordsRepository = [];

    public async Task<Word?> Handle(GetWordByIdQuery request, CancellationToken cancellationToken)
    {
        var word = WordsRepository.Find(x => x.Id == request.Id);
    
        return word;
    }
}