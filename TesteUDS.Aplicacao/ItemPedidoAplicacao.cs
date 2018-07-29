using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TesteUDS.Dominio;
using TesteUDS.Repositorio;

namespace TesteUDS.Aplicacao {
    class ItemPedidoAplicacao {
        private Contexto contexto;

        private void inserir(ItemPedido itemPedido) {
            itemPedido.id = Guid.NewGuid();

            string strQuery = string.Format("INSERT INTO item_pedido (id, id_pedido, produto, quantidade, preco_unitario, percentual_desconto, total)" +
                                            " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                              itemPedido.id, itemPedido.idPedido, itemPedido.produto.id, itemPedido.quantidade, itemPedido.precoUnitario, itemPedido.percentualDesconto, itemPedido.total);

            using (contexto = new Contexto()) {
                contexto.executaComando(strQuery);
            }
        }

        private void alterar(ItemPedido itemPedido) {
            var strQuery = "";
            strQuery += " UPDATE item_pedido SET ";
            strQuery += string.Format("id_pedido = '{0}', ", itemPedido.idPedido);
            strQuery += string.Format("produto = '{0}', ", itemPedido.produto.id);
            strQuery += string.Format("quantidade = '{0}', ", itemPedido.quantidade);
            strQuery += string.Format("preco_unitario = '{0}', ", itemPedido.precoUnitario);
            strQuery += string.Format("percentual_desconto = '{0}', ", itemPedido.percentualDesconto);
            strQuery += string.Format("total = '{0}', ", itemPedido.total);
            strQuery += string.Format("WHERE id = '{0}' ", itemPedido.id);

            using (contexto = new Contexto()) {
                contexto.executaComando(strQuery);
            }

        }

        public void salvar(ItemPedido itemPedido) {
            if (itemPedido.id != Guid.Empty) {
                alterar(itemPedido);
            } else {
                inserir(itemPedido);
            }
        }

        public void excluir(Guid id) {
            using (contexto = new Contexto()) {
                var strQuery = string.Format("DELETE FROM item_pedido WHERE id = '{0}'", id);
                contexto.executaComando(strQuery);
            }
        }

        public List<ItemPedido> listarItensPedido(Guid id_pedido) {
            using (contexto = new Contexto()) {
                var strQuery =string.Concat("SELECT * FROM item_pedido WHERE id_Produto = '{0}' ", id_pedido);
                var sqlDataReader = contexto.executaComandoRetorno(strQuery);
                return transformaReaderEmLista(sqlDataReader);
            }


        }

        private List<ItemPedido> transformaReaderEmLista(SqlDataReader reader) {
            ProdutoAplicacao appProduto = new ProdutoAplicacao();
            var itensPedido = new List<ItemPedido>();

            while (reader.Read()) {
                Produto produto = new Produto();

                var itemPedido = new ItemPedido(){
                    id = Guid.Parse(reader["id"].ToString()),
                    idPedido = Guid.Parse(reader["id_pedido"].ToString()),
                    produto = appProduto.buscarProdutoId(Guid.Parse(reader["produto"].ToString())),
                    quantidade = Double.Parse(reader["nome"].ToString()),
                    precoUnitario = Double.Parse(reader["nome"].ToString()),
                    percentualDesconto  = Double.Parse(reader["nome"].ToString()),
                    total  = Double.Parse(reader["preco_unitario"].ToString())
                };
                itensPedido.Add(itemPedido);
            }
            reader.Close();
            return itensPedido;
        }
    }
}
