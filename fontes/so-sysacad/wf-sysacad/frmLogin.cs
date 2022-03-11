using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cl_regras;
using cl_modelos;

namespace wf_sysacad
{
    public partial class frmLogin : Form
    {
        public Boolean acessoPermitido = false;
        private clsUsuariosRegras _usuariosRegras = new clsUsuariosRegras();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            frmprincipal sysacad = new frmprincipal();
            this.Close();
            sysacad.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Informe o e-mail!",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else if (txtSenha.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Informe a senha!",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtSenha.Focus();
                }
                else if (txtEmail.Text.Contains("@") == false)
                {
                    MessageBox.Show("E-mail informado não e válido!",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else if (_usuariosRegras.Login(txtEmail.Text, txtSenha.Text) == false)
                {
                    MessageBox.Show("E-mail e/ou senha informado(s) não são válidos!",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else
                {
                    this.acessoPermitido = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
