using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUDS.Dominio;
using TesteUDS.Repositorio;

namespace TesteUDS.Aplicacao {
    public class PedidoAplicacao {
        private Contexto contexto;

        private void inserir(Pedido pedido) {
            pedido.id = Guid.NewGuid();
            string strQuery = string.Format("INSERT INTO pedido (id, id_pessoa, numero, emissao, total)" +
                                            " VALUES ('{0}', '{1}', '{2}', '{3}', {4})",
                                              pedido.id, pedido.cliente.id, pedido.numero, pedido.emissao, pedido.total);

            using (contexto = new Contexto()) {
                contexto.executaComando(strQuery);
            }
        }

        public Pedido criaPedido() {
            Pedido pedido = new Pedido();
            pedido.numero = 0;
            pedido.total = 0.0;
            return pedido;
        }

        private void alterar(Pedido pedido) {
            var strQuery = "";
            strQuery += " UPDATE pedido SET ";
            strQuery += string.Format("cliente = '{0}', ", pedido.cliente.id);
            strQuery += string.Format("numero = '{0}', ", pedido.numero);
            strQuery += string.Format("emissao = '{0}', ", pedido.emissao);
            strQuery += string.Format("total = '{0}' ", pedido.total);
            strQuery += string.Format("WHERE id = '{0}' ", pedido.id);

            using (contexto = new Contexto()) {
                contexto.executaComando(strQuery);
            }

        }

        public void salvar(Pedido pedido) {
            if (pedido.id != Guid.Empty) {
                alterar(pedido);
            } else {
                inserir(pedido);
            }
        }

        public void excluir(Guid id) {
            using (contexto = new Contexto()) {
                var strQuery = string.Format("DELETE FROM pedido WHERE id = '{0}'", id);
                contexto.executaComando(strQuery);
            }
        }

        public List<Pedido> listarPedidos() {
            using (contexto = new Contexto()) {
                var strQuery = "SELECT * FROM pedido";
                var sqlDataReader = contexto.executaComandoRetorno(strQuery);
                return transformaReaderEmLista(sqlDataReader);
            }


        }

        private List<Pedido> transformaReaderEmLista(SqlDataReader reader) {
            PessoaAplicacao appPessoa = new PessoaAplicacao();
            ItemPedidoAplicacao appItem = new ItemPedidoAplicacao();
            var pedidos = new List<Pedido>();

            while (reader.Read()) {
                Pedido pedido = new Pedido(){
                    id = Guid.Parse(reader["id"].ToString()),
                    cliente = appPessoa.buscarPessoaId(Guid.Parse(reader["cliente"].ToString())),
                    numero = Int32.Parse(reader["nome"].ToString()),
                    emissao = DateTime.Parse(reader["nome"].ToString()),
                    total = Double.Parse(reader["preco_unitario"].ToString()),
                    item = appItem.listarItensPedido(Guid.Parse(reader["id_pedido"].ToString()))

                };
                pedidos.Add(pedido);
            }
            reader.Close();
            return pedidos;
        }
    }
}
