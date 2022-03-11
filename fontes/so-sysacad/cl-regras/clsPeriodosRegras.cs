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
    public class clsPeriodosRegras: clsRegrasAbstract
    {
        clsPeriodosDal _periodosDal = new clsPeriodosDal();

        public Int32 ObterProximoID()
        {
            return _periodosDal.ObterProximoID();
        }

        public override void Salvar(Object parObjeto)
        {
            try
            {
                if (((clsPeriodos)parObjeto).Sigla.Length < 2)
                {
                    throw new Exception("Sigla deve conter pelo menos 2 caracteres.");
                }
                else
                {
                    if (((clsPeriodos)parObjeto).Nome.Length < 2)
                    {
                        throw new Exception("Nome deve conter pelo menos 2 caracteres.");
                    }
                    else
                    {
                        _periodosDal.Salvar((clsPeriodos)parObjeto);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("clsPeriodosRegras: " + err.Message);
            }
        }

        public override void Atualizar(Object parObjeto)
        {
            try
            {
                if (((clsPeriodos)parObjeto).Sigla.Length < 2)
                {
                    throw new Exception("Sigla deve conter pelo menos 2 caracteres.");
                }
                else
                {
                    if (((clsPeriodos)parObjeto).Nome.Length < 2)
                    {
                        throw new Exception("Nome deve conter pelo menos 2 caracteres.");
                    }
                    else
                    {
                        _periodosDal.Atualizar((clsPeriodos)parObjeto);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("clsPeriodosRegras: " + err.Message);
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
                    _periodosDal.Excluir(parCodigo);
                }
            }
            catch (Exception err)
            {
                throw new Exception("clsPeriodosRegras: " + err.Message);
            }
        }

        public override DataTable ListarTodos()
        {
            try
            {
                return _periodosDal.ListarTodos();
            }
            catch (Exception err)
            {
                return null;
                throw new Exception("clsPeriodosRegras: " + err.Message);
            }
        }
    }
}
