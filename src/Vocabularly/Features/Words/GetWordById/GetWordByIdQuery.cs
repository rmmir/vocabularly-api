using MediatR;
using Vocabularly.Domain;

namespace Vocabularly.Features.Words.GetWordById;

public record GetWordByIdQuery(Guid Id) : IRequest<Word?>;