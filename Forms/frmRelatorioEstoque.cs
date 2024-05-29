using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace clientes_produtos_vendas.Forms
{
    public partial class frmRelatorioEstoque : Form
    {
        private string cn = ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;
        private DataSet reportDataSet;

        public frmRelatorioEstoque(DataSet ds)
        {
            InitializeComponent();
            reportDataSet = ds;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
        }

        private void PreencherProdutos(DataTable produtosTable)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(cn))
                {
                    conn.Open();
                    string query = "SELECT ProdutoId, Nome, Preco FROM Produtos";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(produtosTable);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Erro de banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifique se o DataTable existe no DataSet
                if (!reportDataSet.Tables.Contains("Estoque"))
                {
                    MessageBox.Show("Tabela Estoque não encontrada no DataSet.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable produtosTable = reportDataSet.Tables["Estoque"];
                produtosTable.Clear(); // Limpar dados anteriores
                PreencherProdutos(produtosTable);

                // Verifique se o ReportViewer foi inicializado
                if (rpvRelatorioEstoque == null)
                {
                    MessageBox.Show("ReportViewer não inicializado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ReportDataSource rds = new ReportDataSource("ReportDataSet", produtosTable);
                rpvRelatorioEstoque.LocalReport.DataSources.Clear();
                rpvRelatorioEstoque.LocalReport.DataSources.Add(rds);
                rpvRelatorioEstoque.LocalReport.ReportEmbeddedResource = "clientes_produtos_vendas.Reports.RelatorioEstoque.rdlc";
                rpvRelatorioEstoque.RefreshReport();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Erro de banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Erro na operação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}