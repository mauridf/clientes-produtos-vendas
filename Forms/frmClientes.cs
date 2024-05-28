using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientes_produtos_vendas.Forms
{
    public partial class frmClientes : Form
    {
        private int currentPage = 1;
        private int pageSize = 10;

        private string cn = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;

        public frmClientes()
        {
            InitializeComponent();
            LoadClientes();
        }

        private void LoadClientes(string searchQuery = "")
        {
            using (var conn = new NpgsqlConnection(cn))
            {
                conn.Open();
                string query = $"SELECT * FROM clientes WHERE nome ILIKE @searchQuery ORDER BY clienteid LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("searchQuery", $"%{searchQuery}%");
                    var dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dgvClientes.DataSource = dt;
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                using (var conn = new NpgsqlConnection(cn))
                {
                    conn.Open();
                    string query = txtClienteID.Text == "" ?
                        "INSERT INTO clientes (nome, endereco, telefone, email) VALUES (@nome, @endereco, @telefone, @email)" :
                        "UPDATE clientes SET nome=@nome, endereco=@endereco, telefone=@telefone, email=@email WHERE clienteid=@clienteid";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (txtClienteID.Text != "")
                        {
                            cmd.Parameters.AddWithValue("clienteid", int.Parse(txtClienteID.Text));
                        }
                        cmd.Parameters.AddWithValue("nome", txtNomeCliente.Text);
                        cmd.Parameters.AddWithValue("endereco", txtEnderecoCliente.Text);
                        cmd.Parameters.AddWithValue("telefone", txtTelefoneCliente.Text);
                        cmd.Parameters.AddWithValue("email", txtEmailCliente.Text);

                        cmd.ExecuteNonQuery();
                    }
                }
                LoadClientes();
                ClearFields();
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                MessageBox.Show("O Nome é obrigatório");
                return false;
            }
            if (!Regex.IsMatch(txtTelefoneCliente.Text, @"^\(\d{2}\) \d{5}-\d{4}$"))
            {
                MessageBox.Show("Telefone inválido. Use o formato (00) 00000-0000");
                return false;
            }
            if (!Regex.IsMatch(txtEmailCliente.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("E-mail inválido.");
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            txtClienteID.Clear();
            txtNomeCliente.Clear();
            txtEnderecoCliente.Clear();
            txtTelefoneCliente.Clear();
            txtEmailCliente.Clear();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadClientes();
            UpdatePageLabel();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadClientes();
                UpdatePageLabel();
            }
        }

        private void UpdatePageLabel()
        {
            lblPaginaAtual.Text = $"Página: {currentPage}";
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            LoadClientes(txtPesquisar.Text);
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Verifica se a coluna clicada é a coluna de exclusão
                if (dgvClientes.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dgvClientes.Columns[e.ColumnIndex].Name == "btnExcluir")
                {
                    var id = dgvClientes.Rows[e.RowIndex].Cells["clienteid"].Value.ToString();
                    using (var conn = new NpgsqlConnection(cn))
                    {
                        conn.Open();
                        string query = "DELETE FROM clientes WHERE clienteid=@clienteid";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("clienteid", int.Parse(id));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadClientes(txtPesquisar.Text);
                }
                // Seleção para edição
                else
                {
                    txtClienteID.Text = dgvClientes.Rows[e.RowIndex].Cells["clienteid"].Value.ToString();
                    txtNomeCliente.Text = dgvClientes.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                    txtEnderecoCliente.Text = dgvClientes.Rows[e.RowIndex].Cells["endereco"].Value.ToString();
                    txtTelefoneCliente.Text = dgvClientes.Rows[e.RowIndex].Cells["telefone"].Value.ToString();
                    txtEmailCliente.Text = dgvClientes.Rows[e.RowIndex].Cells["email"].Value.ToString();
                }
            }
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["btnExcluir"].Index && e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.ForeColor = Color.White;
            }
        }
    }
}
