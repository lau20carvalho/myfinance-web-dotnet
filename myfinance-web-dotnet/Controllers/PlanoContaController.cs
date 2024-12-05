using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers
{
    [Route("PlanoConta")]
    public class PlanoContaController(IPlanoContaService planoContaService) : Controller
    {

        [Route("Index")]
        public ActionResult Index()
        {
            ViewBag.Lista = planoContaService.ListarRegistros();
            return View();
        }

        [HttpGet]
        [HttpPost]
        [Route("Cadastro")]
        public ActionResult Cadastro(PlanoContaModel? model)
        {
            if (model != null && ModelState.IsValid)
            {
                var planoConta = new PlanoConta
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Tipo = model.Tipo
                };

                planoContaService.Salvar(planoConta);
            }
            return View();
        }
    }
}
