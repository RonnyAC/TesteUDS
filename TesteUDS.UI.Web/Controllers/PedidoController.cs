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
            var appPedido = new PedidoAplicacao();
            var pedido = appPedido.criaPedido();
            return View(pedido);
        }

        public ActionResult ListaDeClientes() {
            var appPessoa = new PessoaAplicacao();
            var listaDeClientes = appPessoa.listarPessoas();
            return PartialView(listaDeClientes);
        }

        public ActionResult AdicionarProdutos(Guid id) {
            var appPessoa = new PessoaAplicacao();
            var cliente = appPessoa.buscarPessoaId(id);
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        public ActionResult Produtos() {
            var appProduto = new ProdutoAplicacao();
            var listaDeProdutos = appProduto.listarProdutos();
            return View(listaDeProdutos);
        }

        public ActionResult Cadastrar() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Pedido pedido) {
            if (ModelState.IsValid) {
                var appPedido = new PedidoAplicacao();
                appPedido.salvar(pedido);
                return RedirectToAction("Pedidos");
            }

            return View(pedido);

        }
    }
}