using clientes_produtos_vendas.Forms;
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
        private DataSet reportDataSet;

        public frmPrincipal()
        {
            InitializeComponent();
            InitializeRelatoriosDataSet();
        }

        private void InitializeRelatoriosDataSet()
        {
            reportDataSet = new DataSet("RelatoriosDataSet");

            DataTable vendasTable = new DataTable("RelatorioVendas");
            vendasTable.Columns.Add("VendaId", typeof(int));
            vendasTable.Columns.Add("ProdutoNome", typeof(string));
            vendasTable.Columns.Add("Quantidade", typeof(int));
            vendasTable.Columns.Add("Preco", typeof(decimal));
            vendasTable.Columns.Add("DataVenda", typeof(DateTime));

            DataTable clientesTable = new DataTable("Clientes");
            clientesTable.Columns.Add("ClienteId", typeof(int));
            clientesTable.Columns.Add("Nome", typeof(string));
            clientesTable.Columns.Add("Endereco", typeof(string));

            DataTable produtosTable = new DataTable("Estoque");
            produtosTable.Columns.Add("ProdutoId", typeof(int));
            produtosTable.Columns.Add("Nome", typeof(string));
            produtosTable.Columns.Add("Preco", typeof(decimal));

            reportDataSet.Tables.Add(vendasTable);
            reportDataSet.Tables.Add(clientesTable);
            reportDataSet.Tables.Add(produtosTable);
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


        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Verificar se o formulário já está aberto
            Form relatorioVendasForm = Application.OpenForms["frmRelatorioVendas"];
            if (relatorioVendasForm == null)
            {
                relatorioVendasForm = new frmRelatorioVendas(reportDataSet);
                OpenChildForm(relatorioVendasForm);
            }
            else
            {
                relatorioVendasForm.BringToFront();
            }
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Verificar se o formulário já está aberto
            Form relatorioClientesForm = Application.OpenForms["frmRelatorioClientes"];
            if (relatorioClientesForm == null)
            {
                relatorioClientesForm = new frmRelatorioClientes(reportDataSet);
                OpenChildForm(relatorioClientesForm);
            }
            else
            {
                relatorioClientesForm.BringToFront();
            }
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar se o formulário já está aberto
            Form relatorioProdutosForm = Application.OpenForms["frmRelatorioEstoque"];
            if (relatorioProdutosForm == null)
            {
                relatorioProdutosForm = new frmRelatorioEstoque(reportDataSet);
                OpenChildForm(relatorioProdutosForm);
            }
            else
            {
                relatorioProdutosForm.BringToFront();
            }
        }
    }
}
