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
    public class clsCursosRegras: clsRegrasAbstract
    {
        clsCursosDal _cursosDal = new clsCursosDal();

        public Int32 ObterProximoID()
        {
            return _cursosDal.ObterProximoID();
        }
        
        public override void Salvar(Object parObjeto)
        {
            try
            {
                if (((clsCursos)parObjeto).Sigla.Length < 2)
                {
                    throw new Exception("Sigla deve conter pelo menos 2 caracteres.");
                }
                else
                {
                    if (((clsCursos)parObjeto).Nome.Length < 2)
                    {
                        throw new Exception("Nome deve conter pelo menos 2 caracteres.");
                    }
                    else
                    {
                        _cursosDal.Salvar((clsCursos)parObjeto);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("clsCursosRegras: " + err.Message);
            }
        }

        public override void Atualizar(Object parObjeto)
        {
            try
            {
                if (((clsCursos)parObjeto).Sigla.Length < 2)
                {
                    throw new Exception("Sigla deve conter pelo menos 2 caracteres.");
                }
                else
                {
                    if (((clsCursos)parObjeto).Nome.Length < 2)
                    {
                        throw new Exception("Nome deve conter pelo menos 2 caracteres.");
                    }
                    else
                    {
                        _cursosDal.Atualizar((clsCursos)parObjeto);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("clsCursosRegras: " + err.Message);
            }            
        }

        public override void Excluir(int parCodigo)
        {
            try
            {
                if (parCodigo <= 0)
                {
                    throw new Exception("O código deve ser um valor maior que zero.");
                }
                else
                {
                    _cursosDal.Excluir(parCodigo);
                }
            }
            catch (Exception err)
            {
                throw new Exception("clsCursosRegras: " + err.Message);
            }            
        }

        public override DataTable ListarTodos()
        {
            try
            {
                return _cursosDal.ListarTodos();
            }
            catch (Exception err)
            {
                return null;
                throw new Exception("clsCursosRegras: " + err.Message);
            }
        }
    }
}
