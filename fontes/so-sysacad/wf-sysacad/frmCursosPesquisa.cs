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
    public partial class frmCursosPesquisa : Form
    {
        public frmCursosPesquisa()
        {
            InitializeComponent();
        }

        public clsCursos curso = new clsCursos();
        private clsCursosRegras _cursosRegras;

        private void carregarDadosGrid()
        {
            try
            {
                _cursosRegras = new clsCursosRegras();

                dgDados.AutoGenerateColumns = true;
                dgDados.DataSource = _cursosRegras.ListarTodos();
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao carregar registros: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void selecionarDadoGrid()
        {
            try
            {
                Int32 vI = 0;

                vI = dgDados.CurrentRow.Index;

                curso.Codigo = Int32.Parse(dgDados[0, vI].Value.ToString());
                curso.Nome = dgDados[1, vI].Value.ToString();
                curso.Sigla = dgDados[2, vI].Value.ToString();
                curso.Observacao = dgDados[3, vI].Value.ToString();
                curso.CodigoPeriodo = Int32.Parse(dgDados[4, vI].Value.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao selecionar registros: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void formatarGrid()
        {
            try
            {
                dgDados.ReadOnly = true;
                dgDados.MultiSelect = false;

                dgDados.Columns[0].HeaderText = "CÓD.";
                dgDados.Columns[1].HeaderText = "NOME";
                dgDados.Columns[2].HeaderText = "SIGLA";
                dgDados.Columns[3].HeaderText = "OBS";
                dgDados.Columns[4].HeaderText = "PERÍODO";

                dgDados.Columns[0].Width = 50;
                dgDados.Columns[1].Width = 210;
                dgDados.Columns[2].Width = 50;
                dgDados.Columns[3].Width = 100;
                dgDados.Columns[4].Width = 60;

                dgDados.Columns[3].Visible = false;
                dgDados.Columns[4].Visible = false;

                dgDados.ScrollBars = ScrollBars.Vertical;
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao formatar o grid: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            carregarDadosGrid();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            selecionarDadoGrid();
            this.Close();
        }

        private void dgDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCursosPesquisa_Load(object sender, EventArgs e)
        {
            curso.Codigo = -1;
            carregarDadosGrid();
            formatarGrid();
        }
    }
}
