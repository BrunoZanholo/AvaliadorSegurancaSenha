using Dominio;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [RoutePrefix("senha")]
    public class SenhaController : BaseController
    {
        [Route("~/")]
        [HttpGet]
        public ActionResult Index()
        {
            var senha = new Senha(string.Empty);

            return View(new SenhaViewModel { Valor = senha.Valor, Score = senha.Score, Complexidade = senha.Complexidade });
        }

        [Route("~/")]
        [HttpPost]
        public ActionResult Index(SenhaViewModel model)
        {
            var senha = new Senha(string.IsNullOrEmpty(model.Valor) ? string.Empty : model.Valor);

            return Json(new SenhaViewModel { Valor = senha.Valor, Score = senha.Score, Complexidade = senha.Complexidade });
        }
    }
}