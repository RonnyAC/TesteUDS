using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUDS.Repositorio {
    public class Contexto:IDisposable {
        private readonly SqlConnection conexao;

        public Contexto() {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["TesteUDSConfig"].ConnectionString);
            conexao.Open();
        }

        public void executaComando(string strQuery) {
            var cmdComando = new SqlCommand{
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };

            cmdComando.ExecuteNonQuery();
        }

        public SqlDataReader executaComandoRetorno(string strQuery) {
            var cmdComando = new SqlCommand(strQuery, conexao);
            return cmdComando.ExecuteReader();
        }

        public void Dispose() {
            if (conexao.State == ConnectionState.Open) {
                conexao.Close();
            }
        }
    }
}
