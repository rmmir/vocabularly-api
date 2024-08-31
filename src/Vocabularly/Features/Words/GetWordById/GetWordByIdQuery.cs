using MediatR;
using Vocabularly.Domain;

namespace Vocabularly.Features.Words.GetWordById;

public sealed record GetWordByIdQuery(Guid Id) : IRequest<Word>;
