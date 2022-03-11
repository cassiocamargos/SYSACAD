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
    public partial class frmdisciplinas : Form
    {
        private clsCursosRegras cursosRegras;

        private void frmdisciplinas_Load(object sender, EventArgs e)
        {
            try
            {
                cursosRegras = new clsCursosRegras();
                carregarComboCursos();
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao carregar tela: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void carregarComboCursos()
        {
            try
            {
                clsCursosRegras _cursosRegras = new clsCursosRegras();

                cbCursos.DataSource = _cursosRegras.ListarTodos();
                cbCursos.DisplayMember = "cursigla";
                cbCursos.ValueMember = "curid";
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao carregar cursos: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cbCursos.Text = String.Empty;
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao limpar a tela: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public frmdisciplinas()
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
                clsDisciplinasRegras _disciplinasRegras = new clsDisciplinasRegras();
                clsDisciplinas disciplina = new clsDisciplinas();

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
                        /*clsDisciplinasRegras _disciplinasRegras = new clsDisciplinasRegras();
                        clsDisciplinas disciplina = new clsDisciplinas();*/

                        txtCodigo.Text = _disciplinasRegras.ObterProximoID().ToString();

                        disciplina.Codigo = Int16.Parse(txtCodigo.Text);
                        disciplina.Nome = txtNome.Text;
                        disciplina.Sigla = txtSigla.Text;
                        disciplina.Observacao = txtObs.Text;
                        disciplina.CodigoCurso = Int16.Parse(cbCursos.SelectedValue.ToString());

                        _disciplinasRegras.Salvar(disciplina);
                        MessageBox.Show("Cadastro realizado com sucesso!", "Cadastrar");
                    }
                    else
                    {
                        /*clsDisciplinasRegras _disciplinasRegras = new clsDisciplinasRegras();
                        clsDisciplinas disciplina = new clsDisciplinas();*/

                        disciplina.Codigo = Int16.Parse(txtCodigo.Text);
                        disciplina.Nome = txtNome.Text;
                        disciplina.Sigla = txtSigla.Text;
                        disciplina.Observacao = txtObs.Text;
                        disciplina.CodigoCurso = Int16.Parse(cbCursos.SelectedValue.ToString());

                        _disciplinasRegras.Atualizar(disciplina);
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
                    clsDisciplinasRegras _disciplinasRegras = new clsDisciplinasRegras();
                    _disciplinasRegras.Excluir(Int32.Parse(txtCodigo.Text));
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
                frmDisciplinasPesquisa frmPesquisa = new frmDisciplinasPesquisa();
                frmPesquisa.ShowDialog();

                if (frmPesquisa.disciplina.Codigo > 0)
                {
                    txtCodigo.Text = frmPesquisa.disciplina.Codigo.ToString();
                    txtNome.Text = frmPesquisa.disciplina.Nome.ToString();
                    txtSigla.Text = frmPesquisa.disciplina.Sigla.ToString();
                    txtObs.Text = frmPesquisa.disciplina.Observacao;
                    cbCursos.SelectedValue = frmPesquisa.disciplina.CodigoCurso;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao pesquisar registros: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
