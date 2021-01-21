using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_E_Players.Models;

namespace MVC_E_Players.Controllers
{
  [Route("Login")]
  public class LoginController : Controller
  {

    [TempData]
    public string Mensagem {get; set;}
      Jogador jogadorModel = new Jogador();

    public IActionResult Index()
    {
        return View();
    }  

   [Route("Logar")]
    public IActionResult Logar(IFormCollection form)
    {
      List<string> csv = jogadorModel.ReadAllLinesCSV("Database/Jogador.csv");
      
        var logado= csv.Find
        (x => x.Split(";")[2] == form["Email"] &&
          x.Split(";")[3] == form["Senha"]);

        if (logado != null)
        {
          HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
           return LocalRedirect("~/");
        }

        Mensagem = "Dados incorretos, tente novamente";
        return LocalRedirect("~/Login");
    }
  }
}