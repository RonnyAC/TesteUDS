using System.Web.Mvc;
using TesteUDS.Aplicacao;

namespace TesteUDS.UI.Web.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            var appAluno = new ProdutoAplicacao();
            var listaDeAlunos = appAluno.listarProdutos();
            return View(listaDeAlunos);
        }
    }
}