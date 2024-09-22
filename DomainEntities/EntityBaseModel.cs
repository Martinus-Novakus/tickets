namespace TicketingSample.DomainEntities;

public abstract class EntityBaseModel
{
    protected EntityBaseModel(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}