using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl_modelos
{
    public class clsCursos: clsModelo2
    {
        private int _codigoPeriodo;

        public int CodigoPeriodo
        {
            get { return _codigoPeriodo; }
            set { _codigoPeriodo = value; }
        }
    }
}
