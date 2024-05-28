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
    public partial class frmProduto : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;

        private string cn = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;

        public frmProduto()
        {
            InitializeComponent();
            LoadProdutos();
        }

        private void LoadProdutos(string searchQuery = "")
        {
            using (var conn = new NpgsqlConnection(cn))
            {
                conn.Open();
                string query = $"SELECT * FROM produtos WHERE nome ILIKE @searchQuery ORDER BY produtoid LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("searchQuery", $"%{searchQuery}%");
                    var dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dgvProdutos.DataSource = dt;
                }
            }
        }

        private void txtPreco_Enter(object sender, EventArgs e)
        {
            // Remove a formatação ao entrar no campo
            if (decimal.TryParse(txtPreco.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal value))
            {
                txtPreco.Text = value.ToString("0.00");
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, vírgulas e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Apenas um único caractere de vírgula é permitido
            var textBox = sender as TextBox;
            if (e.KeyChar == ',' && textBox != null && textBox.Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtPreco_Leave(object sender, EventArgs e)
        {
            // Formatar como moeda ao sair do campo
            if (decimal.TryParse(txtPreco.Text, out decimal value))
            {
                txtPreco.Text = string.Format(CultureInfo.CurrentCulture, "{0:C}", value);
            }
            else
            {
                txtPreco.Text = string.Empty;
            }
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Verifica se a coluna clicada é a coluna de exclusão
                if (dgvProdutos.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dgvProdutos.Columns[e.ColumnIndex].Name == "btnExcluir")
                {
                    var id = dgvProdutos.Rows[e.RowIndex].Cells["produtoid"].Value.ToString();
                    using (var conn = new NpgsqlConnection(cn))
                    {
                        conn.Open();
                        string query = "DELETE FROM produtos WHERE produtoid=@produtoid";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("produtoid", int.Parse(id));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadProdutos(txtPesquisar.Text);
                }
                // Seleção para edição
                else
                {
                    txtId.Text = dgvProdutos.Rows[e.RowIndex].Cells["produtoid"].Value.ToString();
                    txtProduto.Text = dgvProdutos.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                    txtDescricao.Text = dgvProdutos.Rows[e.RowIndex].Cells["descricao"].Value.ToString();
                    txtPreco.Text = dgvProdutos.Rows[e.RowIndex].Cells["preco"].Value.ToString();
                    txtEstoque.Text = dgvProdutos.Rows[e.RowIndex].Cells["estoque"].Value.ToString();
                }
            }
        }

        private void dgvProdutos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvProdutos.Columns["btnExcluir"].Index && e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.ForeColor = Color.White;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                using (var conn = new NpgsqlConnection(cn))
                {
                    conn.Open();
                    string query = txtId.Text == "" ?
                        "INSERT INTO produtos (nome, descricao, preco, estoque) VALUES (@nome, @descricao, @preco, @estoque)" :
                        "UPDATE produtos SET nome=@nome, descricao=@descricao, preco=@preco, estoque=@estoque WHERE produtoid=@produtoid";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (txtId.Text != "")
                        {
                            cmd.Parameters.AddWithValue("produtoid", int.Parse(txtId.Text));
                        }
                        cmd.Parameters.AddWithValue("nome", txtProduto.Text);
                        cmd.Parameters.AddWithValue("descricao", txtDescricao.Text);

                        // Converter o valor do texto do preço para decimal
                        if (decimal.TryParse(txtPreco.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal preco))
                        {
                            cmd.Parameters.AddWithValue("preco", preco);
                        }
                        else
                        {
                            MessageBox.Show("Preço inválido");
                            return;
                        }

                        cmd.Parameters.AddWithValue("estoque", int.Parse(txtEstoque.Text));

                        cmd.ExecuteNonQuery();
                    }
                }
                LoadProdutos();
                ClearFields();
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtProduto.Text))
            {
                MessageBox.Show("O Produto é obrigatório");
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtProduto.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtEstoque.Clear();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadProdutos();
                UpdatePageLabel();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadProdutos();
            UpdatePageLabel();
        }

        private void UpdatePageLabel()
        {
            lblPaginaAtual.Text = $"Página: {currentPage}";
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            LoadProdutos(txtPesquisar.Text);
        }
    }
}
