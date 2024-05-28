using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientes_produtos_vendas.Forms
{
    public partial class frmVendas : Form
    {
        private string cn = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;

        public frmVendas()
        {
            InitializeComponent();
        }

        private void frmVenda_Load(object sender, EventArgs e)
        {
            LoadClientes();
            LoadProdutos();
        }

        private void LoadClientes()
        {
            using (var conn = new NpgsqlConnection(cn))
            {
                conn.Open();
                var query = "SELECT clienteid, nome FROM clientes";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        cboClientes.DataSource = dt;
                        cboClientes.DisplayMember = "nome";
                        cboClientes.ValueMember = "clienteid";
                    }
                }
            }
        }

        private void LoadProdutos()
        {
            using (var conn = new NpgsqlConnection(cn))
            {
                conn.Open();
                var query = "SELECT produtoid, nome, estoque FROM produtos";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        cboProdutos.DataSource = dt;
                        cboProdutos.DisplayMember = "nome";
                        cboProdutos.ValueMember = "produtoid";
                    }
                }
            }
        }

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            // Verifica se há colunas no DataGridView
            if (dgvItensVenda.Columns.Count == 0)
            {
                // Adiciona colunas se elas ainda não estiverem definidas
                dgvItensVenda.Columns.Add("ProdutoId", "ID");
                dgvItensVenda.Columns.Add("NomeProduto", "Nome");
                dgvItensVenda.Columns.Add("Quantidade", "Quantidade");
            }

            if (int.TryParse(txtQuantidade.Text, out int quantidade) && quantidade > 0)
            {
                var produto = (DataRowView)cboProdutos.SelectedItem;
                int produtoId = (int)produto["produtoid"];
                string nomeProduto = (string)produto["nome"];
                int estoque = (int)produto["estoque"];

                if (quantidade <= estoque)
                {
                    // Adiciona a linha com os dados do produto
                    dgvItensVenda.Rows.Add(produtoId, nomeProduto, quantidade);
                }
                else
                {
                    MessageBox.Show("Quantidade maior que o estoque disponível.");
                }
            }
            else
            {
                MessageBox.Show("Quantidade inválida.");
            }
        }

        private void btnSalvarVenda_Click(object sender, EventArgs e)
        {
            int clienteId = (int)cboClientes.SelectedValue;
            DateTime dataVenda = DateTime.Now;

            using (var conn = new NpgsqlConnection(cn))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Inserir a venda
                        var queryVenda = "INSERT INTO vendas (clienteid, datavenda) VALUES (@clienteid, @datavenda) RETURNING vendaid";
                        int vendaId;
                        using (var cmdVenda = new NpgsqlCommand(queryVenda, conn, tran))
                        {
                            cmdVenda.Parameters.AddWithValue("clienteid", clienteId);
                            cmdVenda.Parameters.AddWithValue("datavenda", dataVenda);
                            vendaId = (int)cmdVenda.ExecuteScalar();
                        }

                        // Inserir os itens da venda e atualizar o estoque
                        foreach (DataGridViewRow row in dgvItensVenda.Rows)
                        {
                            if (row.IsNewRow) continue;

                            int produtoId = (int)row.Cells[0].Value;
                            int quantidade = (int)row.Cells[2].Value;

                            // Inserir item da venda
                            var queryItem = "INSERT INTO itensvenda (vendaid, produtoid, quantidade) VALUES (@vendaid, @produtoid, @quantidade)";
                            using (var cmdItem = new NpgsqlCommand(queryItem, conn, tran))
                            {
                                cmdItem.Parameters.AddWithValue("vendaid", vendaId);
                                cmdItem.Parameters.AddWithValue("produtoid", produtoId);
                                cmdItem.Parameters.AddWithValue("quantidade", quantidade);
                                cmdItem.ExecuteNonQuery();
                            }

                            // Atualizar estoque
                            var queryUpdateEstoque = "UPDATE produtos SET estoque = estoque - @quantidade WHERE produtoid = @produtoid";
                            using (var cmdUpdateEstoque = new NpgsqlCommand(queryUpdateEstoque, conn, tran))
                            {
                                cmdUpdateEstoque.Parameters.AddWithValue("quantidade", quantidade);
                                cmdUpdateEstoque.Parameters.AddWithValue("produtoid", produtoId);
                                cmdUpdateEstoque.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        MessageBox.Show("Venda registrada com sucesso.");
                        ClearFields();
                        LoadProdutos(); // Recarregar produtos para atualizar o estoque no comboBox
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Erro ao registrar a venda: " + ex.Message);
                    }
                }
            }
        }

        private void ClearFields()
        {
            cboClientes.SelectedIndex = -1;
            cboProdutos.SelectedIndex = -1;
            txtQuantidade.Clear();
            dgvItensVenda.Rows.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
