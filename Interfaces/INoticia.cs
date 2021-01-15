namespace MVC_E_Players.Interfaces
{
    public interface INoticia
    {
         void Create(Noticia n);

         List<Noticia> ReadAll();

         void Update(Noticia n);

         void Delete(int id);
    }
}