using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace cl_dal
{
    public class Conexao
    {
        private static SqlConnection _Conexao;
        private static SqlCommand _Comando;
        private static SqlDataAdapter _Adaptador;
        private static DataTable _Tabela;
        private static String _StringConexao = "Data Source = LAPTOP-27L5VSMC; " +
                                                "Initial Catalog=dbacademico; " +
                                                "Integrated Security=True;";

        public static SqlConnection ObterConexao()
        {
            try
            {
                _Conexao = new SqlConnection(_StringConexao);
                _Conexao.Open();
                return _Conexao;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public static void FecharConexao()
        {
            if (_Conexao.State == ConnectionState.Open)
            {
                _Conexao.Close();
            }
        }

    }
}
