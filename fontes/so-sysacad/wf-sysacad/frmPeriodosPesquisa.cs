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
    public partial class frmPeriodosPesquisa : Form
    {
        public clsPeriodos periodo = new clsPeriodos();
        private clsPeriodosRegras _periodosRegras;

        private void carregarDadosGrid()
        {
            _periodosRegras = new clsPeriodosRegras();

            try
            {
                dgDados.AutoGenerateColumns = true;
                dgDados.DataSource = _periodosRegras.ListarTodos();
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

            periodo.Codigo = Int32.Parse(dgDados[0, vI].Value.ToString());
            periodo.Nome = dgDados[1, vI].Value.ToString();
            periodo.Sigla = dgDados[2, vI].Value.ToString();
        }

        private void formatarGrid()
        {
            dgDados.ReadOnly = true;
            dgDados.MultiSelect = false;

            dgDados.Columns[0].HeaderText = "CÓD.";
            dgDados.Columns[1].HeaderText = "NOME";
            dgDados.Columns[2].HeaderText = "SIGLA";

            dgDados.Columns[0].Width = 50;
            dgDados.Columns[1].Width = 210;
            dgDados.Columns[2].Width = 50;

            /*dgPeriodos.Columns[3].Visible = false;
            dgPeriodos.Columns[4].Visible = false;
            dgPeriodos.Columns[5].Visible = false;
            dgPeriodos.Columns[6].Visible = false;*/

            dgDados.ScrollBars = ScrollBars.Vertical;
        }

        public frmPeriodosPesquisa()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            carregarDadosGrid();
            formatarGrid();
        }

        private void frmPeriodosPesquisa_Load(object sender, EventArgs e)
        {
            periodo.Codigo = -1;
            carregarDadosGrid();
            formatarGrid();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            selecionarDadoGrid();
            this.Close();
        }

        private void dgDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
