using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TesteUDS.Aplicacao;
using TesteUDS.Dominio;

namespace UI.Dos {
    class Program {
        static void Main(string[] args) {
            var dados = new AlunoAplicacao().listarProdutos();
            foreach (Produto produto in dados) {
                Console.WriteLine("Id:{0}, Codigo:{1}, Nome:{2}, Preco:{3}", produto.id, produto.codigo, produto.nome, produto.precoUnitario);
            }
        }
    }
}
