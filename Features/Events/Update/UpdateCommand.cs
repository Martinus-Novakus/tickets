using MediatR;

namespace TicketingSample.Features.Events.Update;

public record UpdateCommand(
    UpdateEventRequestDTO EventRequestDto,
    UpdateEventSectorRequestDTO? EventSectorRequestDto = null
) : IRequest;