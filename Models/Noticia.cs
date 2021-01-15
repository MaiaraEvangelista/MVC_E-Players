using System.Collections.Generic;
using MVC_E_Players.Interfaces;

namespace MVC_E_Players.Models
{
    public class Noticia : EPlayersBase , INoticia
    {
        public int IdNoticia { get; set; }
    
        public string Titulo { get; set; }
    
        public string Texto { get; set; }
    
        public string Imagem { get; set; }

        private const string PATH = "Database/Noticia.csv";

        public Noticia(){
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Noticia n){
            return $"{n.}";
        }

        public void Create(Noticia n)
        {
            throw new System.NotImplementedException();
        }

        public List<Noticia> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Noticia n)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}