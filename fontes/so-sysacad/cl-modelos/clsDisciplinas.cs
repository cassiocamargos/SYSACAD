using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl_modelos
{
    public class clsDisciplinas: clsModelo2
    {
        private int _codigoCurso;

        public int CodigoCurso
        {
            get { return _codigoCurso; }
            set { _codigoCurso = value; }
        }
    }
}
