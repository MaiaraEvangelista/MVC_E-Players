using System.Collections.Generic;
using System.IO;
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
            return $"{n.IdNoticia}; {n.Imagem};";
        }

        public void Create(Noticia n)
        {
            string[] linhas = {Prepare(n)};
            File.AppendAllLines(PATH, linhas);
        }

        public List<Noticia> ReadAll()
        {
            List<Noticia> noticias = new List<Noticia>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Noticia noticia = new Noticia();

                noticia.IdNoticia =  int.Parse(linha [0]);
                noticia.Imagem = linha[2];
                
                noticias.Add(noticia);
            }
            return noticias;
        }

        public void Update(Noticia n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add(Prepare(n));

            RewriteCSV(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }

       
       

    }
}