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
            var cliente = appPessoa.listarPessoas();
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoPedido(Pedido pedido) {
            if (ModelState.IsValid) {
                var appPedido = new PedidoAplicacao();
                appPedido.salvar(pedido);
                return RedirectToAction("Pessoa");
            }

            return View(pedido);
        }

        public ActionResult AdicionarProdutos(Pessoa cliente) {
            var appPedido = new PedidoAplicacao();
            var pedido = new Pedido();
            appPedido.salvar(pedido);


            return View(pedido.id);
        }

        public ActionResult Cliente(Guid id) {
            var appCliente = new PessoaAplicacao();
            var pessoa = appCliente.buscarPessoaId(id);
            return View(pessoa);
        }

        public ActionResult ListaDeProdutos() {
            var appProduto = new ProdutoAplicacao();
            var listaDeProdutos = appProduto.listarProdutos();
            return PartialView(listaDeProdutos);
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