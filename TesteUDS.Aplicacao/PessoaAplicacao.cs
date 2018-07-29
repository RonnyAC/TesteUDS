using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUDS.Dominio;
using TesteUDS.Repositorio;

namespace TesteUDS.Aplicacao {
    class PessoaAplicacao {
        private Contexto contexto;

        private void inserir(Pessoa pessoa) {
            pessoa.id = Guid.NewGuid();

            string strQuery = string.Format("INSERT INTO pessoa (id, nome, data_nascimento)" +
                                            " VALUES ('{0}', '{1}', '{2}')",
                                              pessoa.id, pessoa.nome, pessoa.dataNascimento);

            using (contexto = new Contexto()) {
                contexto.executaComando(strQuery);
            }
        }

        private void alterar(Pessoa pessoa) {
            var strQuery = "";
            strQuery += " UPDATE pessoa SET ";
            strQuery += string.Format("nome = '{0}', ", pessoa.nome);
            strQuery += string.Format("data_nascimento = '{0}' ", pessoa.dataNascimento);
            strQuery += string.Format("WHERE id = '{0}' ", pessoa.id);

            using (contexto = new Contexto()) {
                contexto.executaComando(strQuery);
            }

        }

        public void salvar(Pessoa pessoa) {
            if (pessoa.id != Guid.Empty) {
                alterar(pessoa);
            } else {
                inserir(pessoa);
            }
        }

        public void excluir(Guid id) {
            using (contexto = new Contexto()) {
                var strQuery = string.Format("DELETE FROM pessoa WHERE id = '{0}'", id);
                contexto.executaComando(strQuery);
            }
        }

        public List<Pessoa> listarPessoas() {
            using (contexto = new Contexto()) {
                var strQuery = "SELECT * FROM pessoa";
                var sqlDataReader = contexto.executaComandoRetorno(strQuery);
                return transformaReaderEmLista(sqlDataReader);
            }


        }

        private List<Pessoa> transformaReaderEmLista(SqlDataReader reader) {
            var pessoas = new List<Pessoa>();

            while (reader.Read()) {
                var pessoa = new Pessoa(){
                    id = Guid.Parse(reader["id"].ToString()),
                    nome = reader["nome"].ToString(),
                    dataNascimento = DateTime.Parse(reader["data_nascimento"].ToString())
                };
                pessoas.Add(pessoa);
            }
            reader.Close();
            return pessoas;
        }

        public Pessoa buscarPessoaId(Guid id) {
            using (contexto = new Contexto()) {
                var strQuery = string.Concat("SELECT * FROM pessoa WHERE id = '{0}'", id);
                var reader = contexto.executaComandoRetorno(strQuery);

                Pessoa pessoa = new Pessoa(){
                    id = Guid.Parse(reader["id"].ToString()),
                    nome = reader["nome"].ToString(),
                    dataNascimento = DateTime.Parse(reader["data_nascimento"].ToString())
                };
                return pessoa;
            }
        }
    }
}
