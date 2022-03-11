using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl_modelos
{
    public class clsUsuarios
    {
        private int _codigo;
        private string _nome;
        private string _email;
        private string _senha;
        private string _ativo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        public string Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }
    }
}
