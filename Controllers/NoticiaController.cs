using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Players.Models;

namespace MVC_E_Players.Controllers
{
    public class NoticiaController : Controller
    {
        Noticia noticiaModel = new Noticia();

        //Aqui começa a parte de listagem
        [Route("Listar")]

        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }

        //Aqui começa a parte de cadastro
        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticia novaNoticia = new Noticia();
            novaNoticia.IdNoticia = int.Parse(form ["IdNoticia"]);
            
            noticiaModel.Create(novaNoticia);
            ViewBag.Noticias = noticiaModel.ReadAll();

            //Inicio de um upload de imagem
            if (form.Files.Count >0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");


                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        file.CopyTo(stream);

                    }

                    novaNoticia.Imagem = file.FileName;
            } else{
                novaNoticia.Imagem = "padrao.png";
            }

            return LocalRedirect("~/Noticia/Listar");
        }

        [Route ("id")]

        public IActionResult Excluir(int id)
        {
            noticiaModel.Delete(id);
            ViewBag.Noticias = noticiaModel.ReadAll();
            
            return LocalRedirect("~/Noticia/ Listar");
        }
    }
}