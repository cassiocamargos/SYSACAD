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
    public partial class frmUsuarios : Form
    {
        private clsUsuariosRegras usuariosRegras = new clsUsuariosRegras();
        private clsUsuarios usuarios = new clsUsuarios();

        private void limparTela()
        {
            try
            {
                txtCodigo.Clear();
                txtNome.Clear();
                txtEmail.Clear();
                txtSenha.Clear();
                cbAtivo.Text = String.Empty;
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao limpar a tela: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
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
                if ((txtNome.Text.Trim() == String.Empty) || (txtEmail.Text.Trim() == String.Empty) || (txtSenha.Text.Trim() == String.Empty) || (cbAtivo.Text == string.Empty))
                {
                    MessageBox.Show("Todos campos são obrigatórios! Preencha corretamente.",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtNome.Focus();
                }
                else
                {
                    if (txtCodigo.Text == String.Empty)
                    {
                        txtCodigo.Text = usuariosRegras.ObterProximoID().ToString();

                        usuarios.Codigo = Int16.Parse(txtCodigo.Text);
                        usuarios.Nome = txtNome.Text;
                        usuarios.Email = txtEmail.Text;
                        usuarios.Senha = txtSenha.Text;
                        usuarios.Ativo = cbAtivo.Text;

                        usuariosRegras.Salvar(usuarios);
                        MessageBox.Show("Cadastro realizado com sucesso!", "Cadastrar");
                    }
                    else
                    {
                        usuarios.Codigo = Int16.Parse(txtCodigo.Text);
                        usuarios.Nome = txtNome.Text;
                        usuarios.Email = txtEmail.Text;
                        usuarios.Senha = txtSenha.Text;
                        usuarios.Ativo = cbAtivo.Text;

                        usuariosRegras.Atualizar(usuarios);
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
                    usuariosRegras.Excluir(Int32.Parse(txtCodigo.Text));
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
                frmUsuariosPesquisa frmPesquisa = new frmUsuariosPesquisa();
                frmPesquisa.ShowDialog();

                if (frmPesquisa.usuarios.Codigo >= 0)
                {
                    txtCodigo.Text = frmPesquisa.usuarios.Codigo.ToString();
                    txtNome.Text = frmPesquisa.usuarios.Nome.ToString();
                    txtEmail.Text = frmPesquisa.usuarios.Email.ToString();
                    txtSenha.Text = frmPesquisa.usuarios.Senha.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao pesquisar registros: " + err.Message, ":: Alerta ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
