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
    public partial class frmUsuariosPesquisa : Form
    {
        public clsUsuarios usuarios = new clsUsuarios();
        private clsUsuariosRegras usuariosRegras = new clsUsuariosRegras();

        public frmUsuariosPesquisa()
        {
            InitializeComponent();
        }

        private void carregarDadosGrid()
        {
            try
            {
                dgDados.AutoGenerateColumns = true;
                dgDados.DataSource = usuariosRegras.ListarTodos();
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao carregar registros: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void selecionarDadoGrid()
        {
            Int32 vI = 0;

            vI = dgDados.CurrentRow.Index;

            usuarios.Codigo = Int32.Parse(dgDados[0, vI].Value.ToString());
            usuarios.Nome = dgDados[1, vI].Value.ToString();
            usuarios.Email = dgDados[2, vI].Value.ToString();
            usuarios.Senha = dgDados[3, vI].Value.ToString();
        }

        private void formatarGrid()
        {
            dgDados.ReadOnly = true;
            dgDados.MultiSelect = false;

            dgDados.Columns[0].HeaderText = "CÓD.";
            dgDados.Columns[1].HeaderText = "NOME";
            dgDados.Columns[2].HeaderText = "E-MAIL";

            dgDados.Columns[0].Width = 40;
            dgDados.Columns[1].Width = 135;
            dgDados.Columns[2].Width = 135;

            dgDados.Columns[3].Visible = false;
            dgDados.Columns[4].Visible = false;

            dgDados.ScrollBars = ScrollBars.Vertical;
        } 

        private void btnSelecionar_Click_1(object sender, EventArgs e)
        {
            selecionarDadoGrid();
            this.Close();
        }

        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            carregarDadosGrid();
            formatarGrid();
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuariosPesquisa_Load(object sender, EventArgs e)
        {
            usuarios.Codigo = -1;
            carregarDadosGrid();
            formatarGrid();
        }

    }
}
