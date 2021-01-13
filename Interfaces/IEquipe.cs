using System.Collections.Generic;
using MVC_E_Players.Models;

namespace MVC_E_Players.Interfaces
{
    public interface IEquipe
    {
         void Create(Equipe e);

         List<Equipe> ReadAll();

         void Update(Equipe e);

         void Delete(int id);
    }
}