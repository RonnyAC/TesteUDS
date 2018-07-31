using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteUDS.Aplicacao;
using TesteUDS.Dominio;

namespace TesteUDS.UI.Web.Controllers {
    public class PedidoController : Controller {

        public ActionResult Pedidos() {
            var appPedido = new PedidoAplicacao();
            var listaDePedidos = appPedido.listarPedidos();
            return View(listaDePedidos);
        }

        public ActionResult NovoPedido() {
            var appPessoa = new PessoaAplicacao();
            var listaDePessoas = appPessoa.listarPessoas();
            return View(listaDePessoas);
        }

        public ActionResult Cliente(Guid id) {
            return PartialView();
        }

        [HttpPost]
        public ActionResult NovoPedidoConfirmado() {
            var appPedido = new PedidoAplicacao();
            var pedido = appPedido.criaPedido();
            appPedido.salvar(pedido);
            return View();
        }
        public ActionResult InserirProdutos() {
            return View();
        }



    }
}