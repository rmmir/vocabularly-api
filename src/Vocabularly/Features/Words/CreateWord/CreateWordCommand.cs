using MediatR;
using Vocabularly.Domain;

namespace Vocabularly.Features.Words.CreateWord;

public sealed record CreateWordCommand(
    string EnglishWord,
    string ForeignWord,
    string EnglishExample = null,
    string ForeignExample = null) : IRequest<Word>;
