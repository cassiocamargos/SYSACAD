using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl_modelos
{
    public class clsModelo
    {
        private int _codigo;
        private string _nome;
        private string _sigla;

        public int Codigo
        {
            get { return _codigo; }

            set 
            {
                _codigo = value;
            }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Sigla
        {
            get { return _sigla; }

            set
            {
                try
                {
                    if (value.Trim().Length < 1)
                    {
                        throw new Exception("O campo sigla deve conter pelo menos 2 caracteres!");
                    }
                    else
                    {
                        _sigla = value;
                    }
                }
                catch (Exception err)
                {
                    throw new Exception("clsModelo: " + err.Message);
                }
            }
        }

    }
}
