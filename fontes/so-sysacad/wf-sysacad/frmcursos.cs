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
    public partial class frmcursos : Form
    {
        private clsPeriodosRegras periodosRegras;

        private void frmcursos_Load(object sender, EventArgs e)
        {
            try
            {
                periodosRegras = new clsPeriodosRegras();
                carregarComboPeriodos();
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao carregar tela: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void carregarComboPeriodos()
        {
            try
            {
                clsPeriodosRegras _periodosRegras = new clsPeriodosRegras();

                cbPeriodos.DataSource = _periodosRegras.ListarTodos();
                cbPeriodos.DisplayMember = "persigla";
                cbPeriodos.ValueMember = "perid";
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao carregar períodos: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void limparTela()
        {
            try
            {
                txtCodigo.Clear();
                txtNome.Clear();
                txtSigla.Clear();
                txtObs.Clear();
                cbPeriodos.Text = String.Empty;
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao limpar a tela: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public frmcursos()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparTela();
            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtNome.Text.Trim() == String.Empty) || (txtSigla.Text.Trim() == String.Empty))
                {
                    MessageBox.Show("Os campos Nome e Sigla são obrigatórios!",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtNome.Focus();
                }
                else
                {
                    if (txtCodigo.Text == String.Empty)
                    {
                        clsCursosRegras _cursosRegras = new clsCursosRegras();
                        clsCursos curso = new clsCursos();

                        txtCodigo.Text = _cursosRegras.ObterProximoID().ToString();

                        curso.Codigo = Int16.Parse(txtCodigo.Text);
                        curso.Nome = txtNome.Text;
                        curso.Sigla = txtSigla.Text;
                        curso.Observacao = txtObs.Text;
                        curso.CodigoPeriodo = Int16.Parse(cbPeriodos.SelectedValue.ToString());

                        _cursosRegras.Salvar(curso);
                        MessageBox.Show("Cadastro realizado com sucesso!", "Cadastrar");
                    }
                    else
                    {
                        clsCursosRegras _cursosRegras = new clsCursosRegras();
                        clsCursos curso = new clsCursos();

                        curso.Codigo = Int16.Parse(txtCodigo.Text);
                        curso.Nome = txtNome.Text;
                        curso.Sigla = txtSigla.Text;
                        curso.Observacao = txtObs.Text;
                        curso.CodigoPeriodo = Int16.Parse(cbPeriodos.SelectedValue.ToString());

                        _cursosRegras.Atualizar(curso);
                        MessageBox.Show("Cadastro atualizado com sucesso!", "Atualizar");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao inserir registro: " + err, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtCodigo.Text == String.Empty) || (txtCodigo.Text.Trim() == String.Empty))
                {
                    MessageBox.Show("Para excluir é necessário informar o código.",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    clsCursosRegras _cursosRegras = new clsCursosRegras();
                    _cursosRegras.Excluir(Int32.Parse(txtCodigo.Text));
                    MessageBox.Show("Registro excluído com sucesso!", "Excluir");
                    limparTela();
                }
                txtNome.Focus();
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao excluir registro: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCursosPesquisa frmPesquisa = new frmCursosPesquisa();
                frmPesquisa.ShowDialog();

                if (frmPesquisa.curso.Codigo > 0)
                {
                    txtCodigo.Text = frmPesquisa.curso.Codigo.ToString();
                    txtNome.Text = frmPesquisa.curso.Nome.ToString();
                    txtSigla.Text = frmPesquisa.curso.Sigla.ToString();
                    txtObs.Text = frmPesquisa.curso.Observacao;
                    cbPeriodos.SelectedValue = frmPesquisa.curso.CodigoPeriodo;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao pesquisar registros: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSigla_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
