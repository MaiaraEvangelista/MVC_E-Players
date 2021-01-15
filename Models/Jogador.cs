using System.Collections.Generic;
using System.IO;
using MVC_E_Players.Interfaces;

namespace MVC_E_Players.Models
{
    public class Jogador : EPlayersBase , IJogador
    {
        public int IdJogador { get; set; }

        public string Nome { get; set; }

        public int IdEquipe { get; set; }

        private const string PATH = "Database/Jogador.csv";

        public Jogador(){
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Jogador j)
        {
            return $"{j.IdJogador}; {j.Nome}; {j.IdEquipe}";
        }

        public void Create(Equipe e)
        {
            string[] linhas = { Prepare(e) }; 
            File.AppendAllLines(PATH, linhas);
        }

        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);

                foreach (var item in linhas)
                {
                    string[] linha = item.Split(";");
                    
                    Jogador jogador = new Jogador();
                    
                    jogador.IdJogador = int.Parse(linha[0]);
                    jogador.Nome = linha[1];
                    jogador.IdEquipe = int.Parse(linha[2]);

                    jogadores.Add(jogador);
                }

            return jogadores;
        }

        public void Update(Jogador j)
        {
            throw new System.NotImplementedException();
        }

       
    }
}