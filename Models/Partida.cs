using System;
using System.Collections.Generic;
using System.IO;

namespace MVC_E_Players.Models
{
    public class Partida : EPlayersBase
    {
        
        public int IdPartida { get; set; }

        public int IdJogador1 { get; set; }

        public int IdJogador2 { get; set; }

        public DateTime HorarioInicio { get; set; }

        public DateTime HorarioTermino { get; set; }

        private const string PATH = "Database/Partida.csv";

        public Partida(){
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Partida p)
        {
            return $"{p.IdPartida}; {p.IdJogador1}; {p.IdJogador2}; {p.HorarioInicio}; {p.HorarioTermino}";
        }

        public void Create(Partida p)
        {
            string[] linhas = {Prepare(p)};
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Partida> ReadAll()
        {
            List<Partida> partidas = new List<Partida>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Partida partida = new Partida();

                partida.IdPartida = int.Parse(linha[0]);
                //partida.IdJogador1 = form(linha[1]);

                partidas.Add(partida);

            }
            return partidas;
           
        }
    }
}