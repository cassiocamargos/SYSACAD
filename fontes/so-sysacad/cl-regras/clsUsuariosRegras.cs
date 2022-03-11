using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using cl_modelos;
using cl_dal;

namespace cl_regras
{
    public class clsUsuariosRegras
    {

        private clsUsuariosDal _usuariosDal = new clsUsuariosDal();

        public Boolean Login(String parEmail, String parSenha)
        {
            try
            {
                if ((parEmail.Trim().Length <= 0) || (parSenha.Trim().Length <= 0))
                {
                    throw new Exception("clsUsuariosRegras: E-mail e/ou senha não informados!");
                }
                else
                {
                    return _usuariosDal.Login(parEmail, parSenha);
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("clsUsuariosRegras: " + ex.Message);
            }
        }
        public Int32 ObterProximoID()
        {
            return _usuariosDal.ObterProximoID();
        }

        public void Salvar(clsUsuarios parUsuarios)
        {
            try
            {
                if (((clsUsuarios)parUsuarios).Nome.Length < 2)
                {
                    throw new Exception("O nome deve conter pelo menos 2 caracteres.");
                }
                else
                {
                    if (((clsUsuarios)parUsuarios).Email.Length < 2)
                    {
                        throw new Exception("O e-mail deve conter pelo menos 2 caracteres.");
                    }
                    else
                    {
                        _usuariosDal.Salvar(parUsuarios);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("clsUsuariosRegras: " + err.Message);
            }            
        }

        public void Atualizar(clsUsuarios parUsuarios)
        {
            try
            {
                if (((clsUsuarios)parUsuarios).Nome.Length < 2)
                {
                    throw new Exception("O nome deve conter pelo menos 2 caracteres.");
                }
                else
                {
                    if (((clsUsuarios)parUsuarios).Email.Length < 2)
                    {
                        throw new Exception("O e-mail deve conter pelo menos 2 caracteres.");
                    }
                    else
                    {
                        _usuariosDal.Atualizar(parUsuarios);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("clsUsuariosRegras: " + err.Message);
            }
        }

        public void Excluir(int parCodigo)
        {
            try
            {
                if (parCodigo <= 0)
                {
                    throw new Exception("O código deve ser um valor maior que zero.");
                }
                else
                {
                    _usuariosDal.Excluir(parCodigo);
                }
            }
            catch (Exception err)
            {
                throw new Exception("clsUsuariosRegras: " + err.Message);
            }            
        }

        public DataTable ListarTodos()
        {
            try
            {
                return _usuariosDal.ListarTodos();
            }
            catch (Exception err)
            {
                return null;
                throw new Exception("clsUsuariosRegras: " + err.Message);
            }            
        }
    }
}
