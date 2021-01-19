using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Players.Models;

namespace MVC_E_Players.Controllers
{
    public class PartidaController : Controller
    {
        Partida partidaModel = new Partida();

        //Inicío da listagem
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Partidas = partidaModel.ReadAll();
            return View();
        }

        //Inicio do cadastro (verificar se vai realmente permanecer)
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Partida novaPartida = new Partida();
            novaPartida.IdPartida = int.Parse(form["IdPartida"]);
            novaPartida.IdJogador1 = int.Parse(form["IdJogador1"]);
            novaPartida.IdJogador2 = int.Parse(form["IdJogador2"]);
            //novaPartida.HorarioInicio = form["HorarioInicio"];
            //novaPartida.HorarioTermino = form["HorarioTermino"];

            partidaModel.Create(novaPartida);
            ViewBag.Partidas = partidaModel.ReadAll();

            return LocalRedirect("~/Partida/Listar");   
        }

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            partidaModel.Delete(id);
            ViewBag.Partidas = partidaModel.ReadAll();

            return LocalRedirect("~/Partida/Listar");
        }
    
    }
}