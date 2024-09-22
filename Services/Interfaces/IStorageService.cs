using TicketingSample.DomainEntities;

namespace TicketingSample.Services;

///<summary>
///Genericka sluzba zastresujuca pracu so storage - povoluje pouzitie s roznymi modelmi.
///Implementacia tejto sluzby sa moze menit podla pozadovaneho uloziska (DB / Local file storage / ...)
///</summary>
public interface IStorageService<T> where T : EntityBaseModel
{
    public void Create(T item);
    public void Update(T item);
    public T? Get(int id);
    public IEnumerable<T> GetList();
}