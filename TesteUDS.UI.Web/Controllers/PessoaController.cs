using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteUDS.Aplicacao;
using TesteUDS.Dominio;

namespace TesteUDS.UI.Web.Controllers {
    public class PessoaController : Controller {
        public ActionResult Pessoa() {
            var appPessoa = new PessoaAplicacao();
            var listaDePessoas = appPessoa.listarPessoas();
            return View(listaDePessoas);
        }

        public ActionResult Cadastrar() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Pessoa pessoa) {
            if (ModelState.IsValid) {
                var appPessoa = new PessoaAplicacao();
                appPessoa.salvar(pessoa);
                return RedirectToAction("Pessoa");
            }

            return View(pessoa);
        }



        public ActionResult Editar(Guid id) {
            var appPessoa = new PessoaAplicacao();
            var pessoa = appPessoa.buscarPessoaId(id);

            if (pessoa == null)
                return HttpNotFound();

            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Pessoa pessoa) {
                var appPessoa = new PessoaAplicacao();
                appPessoa.salvar(pessoa);
                return RedirectToAction("Pessoa");
        }

        public ActionResult Detalhes(Guid id) {
            var appPessoa = new PessoaAplicacao();
            var pessoa = appPessoa.buscarPessoaId(id);

            if (pessoa == null)
                return HttpNotFound();

            return View(pessoa);
        }

        public ActionResult Excluir(Guid id) {
            var appPessoa = new PessoaAplicacao();
            var pessoa = appPessoa.buscarPessoaId(id);

            if (pessoa == null)
                return HttpNotFound();

            return View(pessoa);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(Guid id) {
            var appPessoa = new PessoaAplicacao();
            appPessoa.excluir(id);

            return RedirectToAction("Pessoa");
        }

        public ActionResult NomeUnico(String nome) {
            var appPessoa = new PessoaAplicacao();
            var pessoas = appPessoa.listarPessoas();
            var nomes = new List<String>();

            foreach (var item in pessoas) {
                nomes.Add(item.nome);
            }
            return Json(nomes.All(x => x.ToLower() != nome.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}