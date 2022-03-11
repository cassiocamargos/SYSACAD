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
    public partial class frmperiodos : Form
    {
        private clsPeriodosRegras periodoRegras = new clsPeriodosRegras();
        private clsPeriodos periodo = new clsPeriodos();

        private void limparTela()
        {
            try
            {
                txtCodigo.Clear();
                txtNome.Clear();
                txtSigla.Clear();
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao limpar a tela: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        public frmperiodos()
        {
            InitializeComponent();
        }

        private void frmperiodos_Load(object sender, EventArgs e)
        {

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
                        txtCodigo.Text = periodoRegras.ObterProximoID().ToString();

                        periodo.Codigo = Int16.Parse(txtCodigo.Text);
                        periodo.Nome = txtNome.Text;
                        periodo.Sigla = txtSigla.Text;

                        periodoRegras.Salvar(periodo);
                        MessageBox.Show("Cadastro realizado com sucesso!", "Cadastrar");
                    }
                    else
                    {
                        periodo.Codigo = Int16.Parse(txtCodigo.Text);
                        periodo.Nome = txtNome.Text;
                        periodo.Sigla = txtSigla.Text;

                        periodoRegras.Atualizar(periodo);
                        MessageBox.Show("Cadastro atualizado com sucesso!", "Atualizar");
                    }
                }                
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao inserir registro: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    periodoRegras.Excluir(Int32.Parse(txtCodigo.Text));
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
                frmPeriodosPesquisa frmPesquisa = new frmPeriodosPesquisa();
                frmPesquisa.ShowDialog();

                if (frmPesquisa.periodo.Codigo >= 0)
                {
                    txtCodigo.Text = frmPesquisa.periodo.Codigo.ToString();
                    txtNome.Text = frmPesquisa.periodo.Nome.ToString();
                    txtSigla.Text = frmPesquisa.periodo.Sigla.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao pesquisar registros: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}