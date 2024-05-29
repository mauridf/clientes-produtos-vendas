using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using clientes_produtos_vendas.DAOs;
using clientes_produtos_vendas.Models;
using Npgsql;

namespace clientes_produtos_vendas.Forms
{
    public partial class frmClientes : Form
    {
        private int currentPage = 1;
        private int pageSize = 5;

        private readonly ClienteDAO clienteDAO = new ClienteDAO();

        public frmClientes()
        {
            InitializeComponent();
            LoadClientes();
        }

        private void LoadClientes(string searchQuery = "")
        {
            try
            {
                dgvClientes.DataSource = clienteDAO.BuscarClientes(searchQuery, currentPage, pageSize);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Erro de banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    Cliente cliente = new Cliente
                    {
                        ClienteID = string.IsNullOrEmpty(txtClienteID.Text) ? 0 : int.Parse(txtClienteID.Text),
                        Nome = txtNomeCliente.Text,
                        Endereco = txtEnderecoCliente.Text,
                        Telefone = txtTelefoneCliente.Text,
                        Email = txtEmailCliente.Text
                    };

                    if (cliente.ClienteID == 0)
                    {
                        clienteDAO.InserirCliente(cliente);
                    }
                    else
                    {
                        clienteDAO.AlterarCliente(cliente);
                    }

                    LoadClientes();
                    ClearFields();
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show($"Erro de banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                MessageBox.Show("O Nome é obrigatório", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Regex.IsMatch(txtTelefoneCliente.Text, @"^\(\d{2}\) \d{5}-\d{4}$"))
            {
                MessageBox.Show("Telefone inválido. Use o formato (00) 00000-0000", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Regex.IsMatch(txtEmailCliente.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("E-mail inválido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    try
                    {
                        clienteDAO.ExcluirCliente(int.Parse(id));
                        LoadClientes(txtPesquisar.Text);
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show($"Erro de banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}