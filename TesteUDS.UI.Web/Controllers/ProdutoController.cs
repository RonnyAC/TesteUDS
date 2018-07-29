using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteUDS.Aplicacao;
using TesteUDS.Dominio;

namespace TesteUDS.UI.Web.Controllers {
    public class ProdutoController : Controller {
        // GET: Produto
        public ActionResult Produtos() {
            var appAluno = new ProdutoAplicacao();
            var listaDeAlunos = appAluno.listarProdutos();
            return View(listaDeAlunos);
        }

        public ActionResult Cadastrar() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Produto produto) {
            if (ModelState.IsValid) {
                var appProduto = new ProdutoAplicacao();
                appProduto.salvar(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }



        public ActionResult Editar(Guid id) {
            var appProduto = new ProdutoAplicacao();
            var produto = appProduto.buscarProdutoId(id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Produto produto) {
            if (ModelState.IsValid) {
                var appProduto = new ProdutoAplicacao();
                appProduto.salvar(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }
    }
}