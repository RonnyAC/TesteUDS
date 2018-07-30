using System.Web.Mvc;
using TesteUDS.Aplicacao;

namespace TesteUDS.UI.Web.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }
    }
}