using cl_modelos;
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
    public class clsPeriodosDal
    {
        private SqlConnection _Conexao;
        private SqlCommand _Comando;
        private DataTable _Tabela;
        private SqlDataAdapter _Adaptador;

        public Int32 ObterProximoID()
        {
            try
            {
                Int32 vCodigo = 0;

                _Conexao = Conexao.ObterConexao();

                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = " select isnull(max(perid), 0) + 1 as codigo " +
                                        " from tblperiodos;";
                vCodigo = Int32.Parse(_Comando.ExecuteScalar().ToString());

                Conexao.FecharConexao();
                return vCodigo;
            }
            catch (Exception err)
            {
                throw new Exception("clsPeriodosDal: " + err.Message);
            }
            
        }

        public void Salvar(clsPeriodos parPeriodo)
        {
            try
            {
                //aqui temos o INSERT

                //abrindo a conexao
                _Conexao = Conexao.ObterConexao();

                //criando objeto para executar comando SQL
                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "insert into tblperiodos VALUES(@codigo, @nome, @sigla);";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parPeriodo.Codigo;
                _Comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = parPeriodo.Nome;
                _Comando.Parameters.Add("@sigla", SqlDbType.VarChar).Value = parPeriodo.Sigla;

                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsPeriodosDal: " + err.Message);
            }
            
        }

        public void Atualizar(clsPeriodos parPeriodo)
        {
            try
            {
                //aqui tamos o UPDATE
                //abrindo a conexao
                _Conexao = Conexao.ObterConexao();

                //criando objeto para executar comando SQL
                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "UPDATE tblperiodos SET pernome = @nome, persigla = @sigla WHERE perid = @codigo; ";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parPeriodo.Codigo;
                _Comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = parPeriodo.Nome;
                _Comando.Parameters.Add("@sigla", SqlDbType.VarChar).Value = parPeriodo.Sigla;

                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsPeriodosDal: " + err.Message);
            }
            
        }

        public void Excluir(int parCodigo)
        {
            try
            {
                //aqui temos o EXCLUIR

                //abrindo a conexao
                _Conexao = Conexao.ObterConexao();

                //criando objeto para executar comando SQL
                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "delete from tblperiodos where perid = @codigo;";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parCodigo;

                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsPeriodosDal: " + err.Message);
            }
            
        }

        public DataTable ListarTodos()
        {
            try
            {
                //aqui teremos o SELECT
                _Conexao = Conexao.ObterConexao();

                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "select perid, pernome, persigla" +
                                       "  from tblperiodos " +
                                       " order by pernome asc ";
                _Tabela = new DataTable();
                _Adaptador = new SqlDataAdapter(_Comando);
                _Adaptador.Fill(_Tabela);

                /*Conexao.FecharConexao();

                return _Tabela;*/
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return _Tabela;
            
        }

        public List<clsPeriodos> ListarTodosArray()
        {
            return null;
        }

    }
}
