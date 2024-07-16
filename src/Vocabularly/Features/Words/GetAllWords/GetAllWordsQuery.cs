using MediatR;
using Vocabularly.Domain;

namespace Vocabularly.Features.Words.GetAllWords;

public sealed record GetAllWordsQuery() : IRequest<IEnumerable<Word>>;