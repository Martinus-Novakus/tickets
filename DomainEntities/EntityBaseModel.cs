namespace TicketingSample.DomainEntities;

///<summary>
///Base model, vdaka ktoremu vieme definovat genericke sluzby pre pracu s core modelmi (IStorageService, ICookieService)
///</summary>
public abstract class EntityBaseModel
{
    protected EntityBaseModel(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}