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
    public class clsCursosDal
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
                _Comando.CommandText = " select isnull(max(curid), 0) + 1 as codigo " +
                                        " from tblcursos;";
                vCodigo = Int32.Parse(_Comando.ExecuteScalar().ToString());

                Conexao.FecharConexao();
                return vCodigo;
            }
            catch (Exception err)
            {
                throw new Exception("clsCursosDal: " + err.Message);
            }
            
        }


        public void Salvar(clsCursos parCurso)
        {
            try
            {
                //aqui temos o INSERT
                //abrindo a conexao
                _Conexao = Conexao.ObterConexao();

                //criando objeto para executar comando SQL
                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "insert into tblcursos VALUES(@codigo, @nome, @sigla, @observacoes, @codPeriodo);";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parCurso.Codigo;
                _Comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = parCurso.Nome;
                _Comando.Parameters.Add("@sigla", SqlDbType.VarChar).Value = parCurso.Sigla;
                _Comando.Parameters.Add("@observacoes", SqlDbType.VarChar).Value = parCurso.Observacao;
                _Comando.Parameters.Add("@codPeriodo", SqlDbType.Int).Value = parCurso.CodigoPeriodo;

                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsCursosDal: " + err.Message);
            }
            
        }

        public void Atualizar(clsCursos parCurso)
        {
            try
            {
                //aqui tamos o UPDATE
                //abrindo a conexao
                _Conexao = Conexao.ObterConexao();

                //criando objeto para executar comando SQL
                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "UPDATE tblcursos SET curnome = @nome, cursigla = @sigla, curobservacoes = @observacoes, perid = @codPeriodo WHERE curid = @codigo; ";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parCurso.Codigo;
                _Comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = parCurso.Nome;
                _Comando.Parameters.Add("@sigla", SqlDbType.VarChar).Value = parCurso.Sigla;
                _Comando.Parameters.Add("@observacoes", SqlDbType.VarChar).Value = parCurso.Observacao;
                _Comando.Parameters.Add("@codPeriodo", SqlDbType.Int).Value = parCurso.CodigoPeriodo;

                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsCursosDal: " + err.Message);
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
                _Comando.CommandText = "delete from tblcursos where curid = @codigo;";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parCodigo;

                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsCursosDal: " + err.Message);
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
                _Comando.CommandText = "select curid, curnome, cursigla, curobservacoes, perid " +
                                       "  from tblcursos " +
                                       " order by curnome asc ";
                _Tabela = new DataTable();
                _Adaptador = new SqlDataAdapter(_Comando);
                _Adaptador.Fill(_Tabela);

                /*Conexao.FecharConexao();

                return _Tabela;*/
            }
            catch (Exception err)
            {
                throw new Exception("clsCursosDal: " + err.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return _Tabela;
            
        }

        public List<clsCursos> ListarTodosArray()
        {
            return null;
        }
    }
}
