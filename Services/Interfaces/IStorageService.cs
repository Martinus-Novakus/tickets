using TicketingSample.DomainEntities;

namespace TicketingSample.Services;

///<summary>
///Toto mala byt genericka sluzba, ktorej implementacia moze byt obmenena za iny typ storage (DB/FileStorage/...).
///</summary>
public interface IStorageService<T> where T : EntityBaseModel
{
    public void Create(T item);
    public void Update(T item);
    public T? Get(int id);
    public IEnumerable<T> GetList();
}