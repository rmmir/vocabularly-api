using MediatR;

namespace Vocabularly.Features.Words.UpdateWord;

 public sealed record UpdateWordCommand(
    Guid Id,
    string EnglishWord,
    string ForeignWord,
    string EnglishExample = null,
    string ForeignExample = null) : IRequest<Guid>;