using System.Collections.Generic;
using System.IO;

namespace MVC_E_Players.Models
{
    public class EPlayersBase
    {
        public void CreateFolderAndFile(string path)
        {
            string folder = path.Split("/")[0];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        public List<string> ReadAllLinesCSV(string path)
        {
            List<string> linhas = new List<string>();

           using (StreamReader file = new StreamReader(path))
           {
               string linha;
               while ((linha = file.ReadLine())!= null)
               {
                   linhas.Add(linha);
               }
           }


            return linhas;
        }

        public void RewriteCSV(string path, List<string> linhas){
          
          //Método para a escrita de arquivos
          using (StreamWriter ouput = new StreamWriter(path))
            {
                foreach (var item in linhas)
                {
                    ouput.Write(item + '\n');
                }
                //ouput.Write("");
            }
        }
    }
}