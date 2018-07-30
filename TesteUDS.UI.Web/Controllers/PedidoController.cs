using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteUDS.Aplicacao;

namespace TesteUDS.UI.Web.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult NovoPedido()
        {
            return View();
        }

        public ActionResult ListarClientes() {
            var appPessoa = new PessoaAplicacao();
            return PartialView(appPessoa.listarPessoas());
        }

        public ActionResult ListarProdutos() {
            var appProduto = new ProdutoAplicacao();
            return PartialView(appProduto.listarProdutos());
        }
    }
}