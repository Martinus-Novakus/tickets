namespace TicketingSample.Services;

///<summary>
///Toto mala byt genericka sluzba, ktorej implementacia moze byt obmenena za iny typ storage (DB/FileStorage/...).
///Na nestastie MemoryChache neponuka moznost ziskat vsetky ulozene hodnoty naraz, iba po jednom pomocou kluca,
///takze nie je mozne to spravit abstraktne od implementacie, pretoze pre ziskanie zoznamu musime ulozit cely zoznam pod jednym klucom...
///</summary>
public interface IStorageService
{
    public void Set<T>(string key, T item);
    public T? Get<T>(string key);
}