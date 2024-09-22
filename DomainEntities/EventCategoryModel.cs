namespace TicketingSample.DomainEntities;

public class EventCategoryModel : EntityBaseModel
{
    public EventCategoryModel(int id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; set; } = string.Empty;    
}