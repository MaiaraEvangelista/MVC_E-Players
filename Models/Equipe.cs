using System.Collections.Generic;
using System.IO;
using MVC_E_Players.Interfaces;

namespace MVC_E_Players.Models
{
    public class Equipe : EPlayersBase , IEquipe 
    {
        public int IdEquipe { get; set; }

        public string Nome { get; set; }
    
        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";

        public Equipe(){
            CreateFolderAndFile(PATH);
        } 

        public string Prepare(Equipe e){
            return $"{e.IdEquipe}; {e.Nome}; {e.Imagem}";
        }

        public void Create(Equipe e)
        {
            string[] linhas = {Prepare(e)};
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int id)
        {
              List<string> linhas = ReadAllLinesCSV(PATH);

            //Remove a linha que vai ser alterada
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            //Método para reescrever as linhas alteradas
            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();

            //método para ler as linhas
            string[] linhas =  File.ReadAllLines(PATH);

            //método para percorrer as linhas
            foreach (var item in linhas)
            {       //quebra de linhas SPLIT
                    string[] linha = item.Split(";");

                    //Criação da base equipe
                    Equipe equipe = new Equipe();

                    equipe.IdEquipe = int.Parse(linha[0]);
                    equipe.Nome = linha[1];
                    equipe.Imagem = linha[2];
                    
                    //Aicionando a base de equipe na equipes
                    equipes.Add(equipe);
            }

            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            //Remove a linha que vai ser alterada
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());

            //Método para adicionar a linha alterada novamente no arquivo
            linhas.Add(Prepare(e));

            //Método para reescrever as linhas alteradas
            RewriteCSV(PATH, linhas);
        }
    }
}