using System.Collections.Generic;
using MVC_E_Players.Models;

namespace MVC_E_Players.Interfaces
{
    public interface IPartida
    {
         void Create(Partida p);

         List<Partida> ReadAll();

         void Delete(int id);
    }
}