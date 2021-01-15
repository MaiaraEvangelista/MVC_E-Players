using System.Collections.Generic;
using MVC_E_Players.Models;

namespace MVC_E_Players.Interfaces
{
    public interface IJogador
    {
         void Create(Equipe e);

         List<Jogador> ReadAll();

         void Update(Jogador j);

            //Observar se vai ser realmente necessário o delete
         //void Delete();
    }
}