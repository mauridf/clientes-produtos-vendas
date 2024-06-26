﻿using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using clientes_produtos_vendas.DAOs;
using clientes_produtos_vendas.Models;

namespace clientes_produtos_vendas.Forms
{
    public partial class frmProduto : Form
    {
        private int currentPage = 1;
        private int pageSize = 5;
        private readonly ProdutoDAO produtoDAO = new ProdutoDAO();

        public frmProduto()
        {
            InitializeComponent();
            LoadProdutos();
        }

        private void LoadProdutos(string searchQuery = "")
        {
            try
            {
                dgvProdutos.DataSource = produtoDAO.BuscarProdutos(searchQuery, currentPage, pageSize);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Erro de banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    try
                    {
                        produtoDAO.ExcluirProduto(int.Parse(id));
                        LoadProdutos(txtPesquisar.Text);
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show($"Erro de banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                try
                {
                    Produto produto = new Produto();
                    produto.ProdutoID = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text);
                    produto.Nome = txtProduto.Text;
                    produto.Descricao = txtDescricao.Text;

                    if (decimal.TryParse(txtPreco.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal preco))
                    {
                        produto.Preco = preco;
                    }
                    else
                    {
                        MessageBox.Show("Preço inválido");
                        return;
                    }

                    produto.Estoque = int.Parse(txtEstoque.Text);

                    if (produto.ProdutoID == 0)
                    {
                        produtoDAO.InserirProduto(produto);
                    }
                    else
                    {
                        produtoDAO.AlterarProduto(produto);
                    }

                    LoadProdutos();
                    ClearFields();
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show($"Erro de banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}