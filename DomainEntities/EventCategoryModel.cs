namespace TicketingSample.DomainEntities;

///<summary>
///Core model pre kategoriu podujatia - toto som dal zvlast, 
///aby som simulovat samostatny storage pre tento resource pre ucely urcovania kategorie pri vytvarani podujatia
///</summary>
public class EventCategoryModel : EntityBaseModel
{
    public EventCategoryModel(int id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; set; } = string.Empty;    
}