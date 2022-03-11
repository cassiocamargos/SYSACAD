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
    public class clsDisciplinasDal
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
                _Comando.CommandText = " select isnull(max(discid), 0) + 1 as codigo " +
                                        " from tbldisciplinas;";
                vCodigo = Int32.Parse(_Comando.ExecuteScalar().ToString());

                Conexao.FecharConexao();
                return vCodigo;
            }
            catch (Exception err)
            {
                throw new Exception("clsDisciplinasDal: " + err.Message);
            }
            
        }


        public void Salvar(clsDisciplinas parDisciplina)
        {
            try
            {
                //aqui temos o INSERT

                //abrindo a conexao
                _Conexao = Conexao.ObterConexao();

                //criando objeto para executar comando SQL
                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "insert into tbldisciplinas VALUES(@codigo, @nome, @sigla, @observacoes, @codCurso);";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parDisciplina.Codigo;
                _Comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = parDisciplina.Nome;
                _Comando.Parameters.Add("@sigla", SqlDbType.VarChar).Value = parDisciplina.Sigla;
                _Comando.Parameters.Add("@observacoes", SqlDbType.VarChar).Value = parDisciplina.Observacao;
                _Comando.Parameters.Add("@codCurso", SqlDbType.Int).Value = parDisciplina.CodigoCurso;

                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsDisciplinasDal: " + err.Message);
            }
            
        }

        public void Atualizar(clsDisciplinas parDisciplina)
        {
            try
            {
                //aqui tamos o UPDATE
                //abrindo a conexao
                _Conexao = Conexao.ObterConexao();

                //criando objeto para executar comando SQL
                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "UPDATE tbldisciplinas SET discnome = @nome, discsigla = @sigla, discobservacoes = @observacoes, curid = @codCurso WHERE discid = @codigo; ";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parDisciplina.Codigo;
                _Comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = parDisciplina.Nome;
                _Comando.Parameters.Add("@sigla", SqlDbType.VarChar).Value = parDisciplina.Sigla;
                _Comando.Parameters.Add("@observacoes", SqlDbType.VarChar).Value = parDisciplina.Observacao;
                _Comando.Parameters.Add("@codCurso", SqlDbType.Int).Value = parDisciplina.CodigoCurso;

                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsDisciplinasDal: " + err.Message);
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
                _Comando.CommandText = "delete from tbldisciplinas where discid = @codigo;";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parCodigo;

                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsDisciplinasDal: " + err.Message);
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
                _Comando.CommandText = "select discid, discnome, discsigla, discobservacoes, curid " +
                                       "  from tbldisciplinas " +
                                       " order by discnome asc ";
                _Tabela = new DataTable();
                _Adaptador = new SqlDataAdapter(_Comando);
                _Adaptador.Fill(_Tabela);

                /*Conexao.FecharConexao();

                return _Tabela;*/
            }
            catch (Exception err)
            {
                throw new Exception("clsDisciplinasDal: " + err.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return _Tabela;
            
        }

        public List<clsDisciplinas> ListarTodosArray()
        {
            return null;
        }
    }
}
