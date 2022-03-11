using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_sysacad
{
    public partial class frmprincipal : Form
    {
        public frmprincipal()
        {
            InitializeComponent();
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void períodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmperiodos vPeriodos = new frmperiodos();
            vPeriodos.ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcursos vCursos = new frmcursos();
            vCursos.ShowDialog();
        }

        private void disciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdisciplinas vDisciplinas = new frmdisciplinas();
            vDisciplinas.ShowDialog();
        }

        private void timerPrincipal_Tick(object sender, EventArgs e)
        {
            sslDataHora.Text = DateTime.Now.ToString();
        }

        private void sslDtHr_Click(object sender, EventArgs e)
        {

        }

        private void frmprincipal_Load(object sender, EventArgs e)
        {
            frmLogin vLogin = new frmLogin();
            vLogin.ShowDialog();

            if (vLogin.acessoPermitido == false)
            {
                this.Close();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios vUsuarios = new frmUsuarios();
            vUsuarios.ShowDialog();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre sobre = new frmSobre();
            sobre.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
