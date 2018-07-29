using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUDS.Dominio;
using TesteUDS.Repositorio;

namespace TesteUDS.Aplicacao {
    public class ProdutoAplicacao {
        private Contexto contexto;

        private void inserir(Produto produto) {
            produto.id = Guid.NewGuid();

            string strQuery = string.Format("INSERT INTO produto (id, codigo, nome, preco_unitario)" +
                                            " VALUES ('{0}', '{1}', '{2}', '{3}')",
                                              produto.id, produto.codigo, produto.nome, produto.precoUnitario);

            using (contexto = new Contexto()) {
                contexto.executaComando(strQuery);
            }
        }

        private void alterar(Produto produto) {
            var strQuery = "";
            strQuery += " UPDATE produto SET ";
            strQuery += string.Format("codigo = '{0}', ", produto.codigo);
            strQuery += string.Format("nome = '{0}', ", produto.nome);
            strQuery += string.Format("preco_unitario = '{0}' ", produto.precoUnitario);
            strQuery += string.Format("WHERE id = '{0}' ", produto.id);

            using (contexto = new Contexto()) {
                contexto.executaComando(strQuery);
            }

        }

        public void salvar(Produto produto) {
            if (produto.id != Guid.Empty) {
                alterar(produto);
            } else {
                inserir(produto);
            }
        }

        public void excluir(Guid id) {
            using(contexto = new Contexto()) {
                var strQuery = string.Format("DELETE FROM produto WHERE id = '{0}'", id);
                contexto.executaComando(strQuery);
            }
        }

        public List<Produto> listarProdutos() {
            using(contexto = new Contexto()) {
                var strQuery = "SELECT * FROM produto";
                var sqlDataReader = contexto.executaComandoRetorno(strQuery);
                return transformaReaderEmLista(sqlDataReader);
            }
            
            
        }

        private List<Produto> transformaReaderEmLista(SqlDataReader reader) {
            var produtos = new List<Produto>();

            while (reader.Read()) {
                var produto = new Produto(){
                    id = Guid.Parse(reader["id"].ToString()),
                    codigo = reader["codigo"].ToString(),
                    nome = reader["nome"].ToString(),
                    precoUnitario = Double.Parse(reader["preco_unitario"].ToString())
                };
                produtos.Add(produto);
            }
            reader.Close();
            return produtos;
        }

        public Produto buscarProdutoId(Guid id) {
            using (contexto = new Contexto()) {
                var strQuery = string.Concat("SELECT * FROM produto WHERE id = ", "'" + id + "'");
                var reader = contexto.executaComandoRetorno(strQuery);
                return transformaReaderEmLista(reader).FirstOrDefault();
            }
        }
    }
}
