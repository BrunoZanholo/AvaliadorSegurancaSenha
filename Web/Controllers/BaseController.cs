using System.Web.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.Web = "AVALIADOR DE SEGURANÇA DE SENHA";
        }
    }
}