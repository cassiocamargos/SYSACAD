using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace cl_regras
{
    public abstract class clsRegrasAbstract
    {
        public abstract void Salvar(Object parObjeto);
        public abstract void Atualizar(Object parPeriodo);
        public abstract void Excluir(int parCodigo);
        public abstract DataTable ListarTodos();
    }
}
