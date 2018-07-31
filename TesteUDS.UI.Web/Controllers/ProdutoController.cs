using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteUDS.Aplicacao;
using TesteUDS.Dominio;

namespace TesteUDS.UI.Web.Controllers {
    public class ProdutoController : Controller {

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
                var appProduto = new ProdutoAplicacao();
                appProduto.salvar(produto);
                return RedirectToAction("Produtos");
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
            var appProduto = new ProdutoAplicacao();
            appProduto.salvar(produto);
            return RedirectToAction("Produtos");
        }

        public ActionResult Detalhes(Guid id) {
            var appProduto = new ProdutoAplicacao();
            var produto = appProduto.buscarProdutoId(id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        public ActionResult Excluir(Guid id) {
            var appProduto = new ProdutoAplicacao();
            var produto = appProduto.buscarProdutoId(id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(Guid id) {
            var appProduto = new ProdutoAplicacao();
            appProduto.excluir(id);

            return RedirectToAction("Produtos");
        }

        public ActionResult CodigoUnico(String codigo) {
            var appProduto = new ProdutoAplicacao();
            var produtos = appProduto.listarProdutos();
            var codigos = new List<String>();

            foreach (var item in produtos) {
                codigos.Add(item.codigo);
            }
            return Json(codigos.All(x => x.ToLower() != codigo.ToLower()), JsonRequestBehavior.AllowGet);
        }

        public ActionResult NomeUnico(String nome) {
            var appProduto = new ProdutoAplicacao();
            var produtos = appProduto.listarProdutos();
            var nomes = new List<String>();

            foreach (var item in produtos) {
                nomes.Add(item.nome);
            }
            return Json(nomes.All(x => x.ToLower() != nome.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}