using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Players.Models;

namespace MVC_E_Players.Controllers
{
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();

        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form){
           
            Jogador novoJogador = new Jogador();
            novoJogador.IdEquipe = int.Parse(form["IdEquipe"]);
            novoJogador.Nome = form["Nome"];

            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();

                if (form.Files.Count >0)
                {
                    var file = form.Files[0];
                    var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Jogadores");


                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    var path = Path.Combine(Directory.GetCurrentDirectory(), folder, file.FileName);
                        
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                }   
            return LocalRedirect("~/Jogador/Listar");
        }

        public IActionResult Excluir(int id)
        {
            jogadorModel.Delete(id);

            ViewBag.Jogadores = jogadorModel.ReadAll();
            return LocalRedirect("~/Jogador/Listar");
        }
    }
}