namespace TicketingSample.Features.Events.GetEventCategoryList;

public class EventCategoryResponseDTO
{
    public EventCategoryResponseDTO()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;    
}