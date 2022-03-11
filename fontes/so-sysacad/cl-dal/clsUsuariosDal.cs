using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cl_modelos;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace cl_dal
{
    public class clsUsuariosDal
    {
        private SqlConnection _Conexao;
        private SqlCommand _Comando;
        private DataTable _Tabela;
        private SqlDataAdapter _Adaptador;

        public Boolean Login(String parEmail, String parSenha)
        {
            try
            {
                Int32 vCodigo = 0;
                _Conexao = Conexao.ObterConexao();

                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText =
                    " select isnull(count(usuid), 0) usuid " +
                    "   from tblusuarios " +
                    "  where usuativo = 'S' " +
                    "    and usuemail = @usuemail " +
                    "    and ususenha = @ususenha ";
                _Comando.Parameters.Add("@usuemail", SqlDbType.VarChar).Value = parEmail;
                _Comando.Parameters.Add("@ususenha", SqlDbType.VarChar).Value = parSenha;

                vCodigo = Int32.Parse(_Comando.ExecuteScalar().ToString());

                Conexao.FecharConexao();

                if (vCodigo > 0) //vCodigo == 1
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("clsUsuariosDal: " + ex.Message);
            }
        }

        public Int32 ObterProximoID()
        {
            try
            {
                Int32 vCodigo = 0;

                _Conexao = Conexao.ObterConexao();

                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = " select isnull(max(usuid), 0) + 1 as codigo " +
                                        " from tblusuarios;";
                vCodigo = Int32.Parse(_Comando.ExecuteScalar().ToString());

                Conexao.FecharConexao();
                return vCodigo;
            }
            catch (Exception err)
            {
                throw new Exception("clsUsuariosDal: " + err.Message);
            }
        }

        public void Salvar(clsUsuarios parUsuarios)
        {
            try
            {
                _Conexao = Conexao.ObterConexao();

                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "INSERT INTO tblusuarios VALUES (@codigo, @nome, @email, @senha, @ativo); ";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parUsuarios.Codigo;
                _Comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = parUsuarios.Nome;
                _Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = parUsuarios.Email;
                _Comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = parUsuarios.Senha;
                _Comando.Parameters.Add("@ativo", SqlDbType.VarChar).Value = parUsuarios.Ativo;
                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsUsuariosDal: " + err.Message);
            }
        }

        public void Atualizar(clsUsuarios parUsuarios)
        {
            try
            {
                _Conexao = Conexao.ObterConexao();

                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "UPDATE tblusuarios SET usunome = @nome, usuemail = @email, ususenha = @senha, usuativo = @ativo WHERE usuid = @codigo; ";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parUsuarios.Codigo;
                _Comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = parUsuarios.Nome;
                _Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = parUsuarios.Email;
                _Comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = parUsuarios.Senha;
                _Comando.Parameters.Add("@ativo", SqlDbType.VarChar).Value = parUsuarios.Ativo;
                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsUsuariosDal: " + err.Message);
            }
        }

        public void Excluir(int parCodigo)
        {
            try
            {
                _Conexao = Conexao.ObterConexao();

                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "DELETE FROM tblusuarios WHERE usuid = @codigo; ";
                _Comando.Parameters.Add("@codigo", SqlDbType.Int).Value = parCodigo;
                _Comando.ExecuteNonQuery();

                Conexao.FecharConexao();
            }
            catch (Exception err)
            {
                throw new Exception("clsUsuariosDal: " + err.Message);
            }
        }

        public DataTable ListarTodos()
        {
            try
            {
                _Conexao = Conexao.ObterConexao();
                _Comando = new SqlCommand();
                _Comando.Connection = _Conexao;
                _Comando.CommandText = "SELECT usuid, usunome, usuemail, ususenha, usuativo " +
                                        " FROM tblusuarios " +
                                        " ORDER BY usunome ";
                _Tabela = new DataTable();
                _Adaptador = new SqlDataAdapter(_Comando);
                _Adaptador.Fill(_Tabela);
            }
            catch (Exception err)
            {
                throw new Exception("clsUsuariosDal: " + err.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return _Tabela;
        }

        public List<clsUsuarios> ListarTodosArray()
        {
            return null;
        }
    }
}
