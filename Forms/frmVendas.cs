using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using clientes_produtos_vendas.DAOs;
using clientes_produtos_vendas.Models;

namespace clientes_produtos_vendas.Forms
{
    public partial class frmVendas : Form
    {
        private readonly string cn = ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;
        private readonly VendaDAO vendaDAO = new VendaDAO();
        private readonly ClienteDAO clienteDAO = new ClienteDAO();
        private readonly ProdutoDAO produtoDAO = new ProdutoDAO();

        public frmVendas()
        {
            InitializeComponent();
            dgvItensVenda.CellContentClick += dgvItensVenda_CellContentClick;
        }

        private void frmVenda_Load(object sender, EventArgs e)
        {
            LoadClientes();
            LoadProdutos();
        }

        private void LoadClientes(string searchQuery = "")
        {
            try
            {
                // Para o combo de clientes, queremos todos os clientes (sem paginação)
                var dt = clienteDAO.BuscarClientes(searchQuery);
                cboClientes.DataSource = dt;
                cboClientes.DisplayMember = "nome";
                cboClientes.ValueMember = "clienteid";
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

        private void LoadProdutos(string searchQuery = "")
        {
            try
            {
                // Para o combo de clientes, queremos todos os clientes (sem paginação)
                var dt = produtoDAO.BuscarProdutos(searchQuery);
                cboProdutos.DataSource = dt;
                cboProdutos.DisplayMember = "descricao";
                cboProdutos.ValueMember = "produtoid";
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

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            // Verifica se há colunas no DataGridView
            if (dgvItensVenda.Columns.Count == 0)
            {
                // Adiciona colunas se elas ainda não estiverem definidas
                dgvItensVenda.Columns.Add("ProdutoId", "ID");
                dgvItensVenda.Columns.Add("NomeProduto", "Nome");
                dgvItensVenda.Columns.Add("Quantidade", "Quantidade");
                dgvItensVenda.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Excluir",
                    Text = "Excluir",
                    UseColumnTextForButtonValue = true,
                });
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

        private void dgvItensVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvItensVenda.Columns["Excluir"].Index && e.RowIndex >= 0)
            {
                dgvItensVenda.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnSalvarVenda_Click(object sender, EventArgs e)
        {
            // Verifica se um cliente foi selecionado
            if (cboClientes.SelectedValue == null)
            {
                MessageBox.Show("Selecione um cliente para continuar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se há itens na venda
            if (dgvItensVenda.Rows.Count == 0 || dgvItensVenda.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
            {
                MessageBox.Show("Adicione pelo menos um produto à venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int clienteId = (int)cboClientes.SelectedValue;
            DateTime dataVenda = DateTime.Now;

            try
            {
                List<ItemVenda> itensVenda = new List<ItemVenda>();

                // Percorre os itens da DataGridView para criar a lista de itens de venda
                foreach (DataGridViewRow row in dgvItensVenda.Rows)
                {
                    if (row.IsNewRow) continue;

                    int produtoId = (int)row.Cells["ProdutoId"].Value;
                    int quantidade = (int)row.Cells["Quantidade"].Value;

                    itensVenda.Add(new ItemVenda { ProdutoID = produtoId, Quantidade = quantidade });
                }

                // Verifica se há itens na venda
                if (itensVenda.Count == 0)
                {
                    MessageBox.Show("Adicione pelo menos um produto à venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                VendaDAO vendaDAO = new VendaDAO();

                // Criar uma instância de Venda
                Venda venda = new Venda
                {
                    ClienteID = clienteId,
                    DataVenda = dataVenda
                };

                // Registrar a venda, os itens da venda e atualizar o estoque
                vendaDAO.RegistrarVenda(venda, itensVenda);

                MessageBox.Show("Venda registrada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpar campos e recarregar produtos
                ClearFields();
                LoadProdutos();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Erro de banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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