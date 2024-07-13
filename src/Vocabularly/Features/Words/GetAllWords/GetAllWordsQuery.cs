using MediatR;
using Vocabularly.Domain;

namespace Vocabularly.Features.Words.GetAllWords;

public record GetAllWordsQuery() : IRequest<IEnumerable<Word>>;