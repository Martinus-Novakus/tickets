namespace TicketingSample.DomainEntities;

public class EventCategoryModel
{
    public EventCategoryModel()
    {
    }

    public EventCategoryModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;    
}