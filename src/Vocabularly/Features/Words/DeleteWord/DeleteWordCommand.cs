using MediatR;

namespace Vocabularly.Features.Words.DeleteWord;

public record DeleteWordCommand(Guid Id) : IRequest<Guid>;