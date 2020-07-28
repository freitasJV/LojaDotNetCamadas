using System;
using System.Windows.Forms;

namespace Loja
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Cadastro_usuario();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}
