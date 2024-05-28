using clientes_produtos_vendas.Forms;
using clientes_produtos_vendas.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientes_produtos_vendas
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {
            childForm.MdiParent = this;
            childForm.StartPosition = FormStartPosition.Manual;

            // Centralizar o formulário filho
            childForm.Location = new Point(
                (this.ClientSize.Width - childForm.Width) / 2,
                (this.ClientSize.Height - childForm.Height) / 2
            );

            childForm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar se o formulário já está aberto
            Form clientesForm = Application.OpenForms["frmClientes"];
            if (clientesForm == null)
            {
                clientesForm = new frmClientes();
                OpenChildForm(clientesForm);
            }
            else
            {
                clientesForm.BringToFront();
            }
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Verificar se o formulário já está aberto
            Form produtosForm = Application.OpenForms["frmProduto"];
            if (produtosForm == null)
            {
                produtosForm = new frmProduto();
                OpenChildForm(produtosForm);
            }
            else
            {
                produtosForm.BringToFront();
            }
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Verificar se o formulário já está aberto
            Form vendasForm = Application.OpenForms["frmVendas"];
            if (vendasForm == null)
            {
                vendasForm = new frmVendas();
                OpenChildForm(vendasForm);
            }
            else
            {
                vendasForm.BringToFront();
            }
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Verificar se o formulário já está aberto
            Form relatoriosForm = Application.OpenForms["frmRelatorios"];
            if (relatoriosForm == null)
            {
                relatoriosForm = new frmRelatorioVendas();
                OpenChildForm(relatoriosForm);
            }
            else
            {
                relatoriosForm.BringToFront();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
