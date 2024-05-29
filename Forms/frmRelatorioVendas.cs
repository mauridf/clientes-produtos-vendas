using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace clientes_produtos_vendas.Forms
{
    public partial class frmRelatorioVendas : Form
    {
        private string cn = ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;
        private DataSet reportDataSet;

        public frmRelatorioVendas(DataSet ds)
        {
            InitializeComponent();
            reportDataSet = ds;

            // Carregar dados inicialmente
            CarregarDadosRelatorio();

            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
        }

        private void CarregarDadosRelatorio()
        {
            if (!reportDataSet.Tables.Contains("RelatorioVendas"))
            {
                reportDataSet.Tables.Add(new DataTable("RelatorioVendas"));
            }
        }

        private void PreencherVendas(DateTime dataInicio, DateTime dataFim)
        {
            DataTable vendasTable = reportDataSet.Tables["RelatorioVendas"];
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(cn))
                {
                    conn.Open();
                    string query = @"
                    SELECT v.vendaid, p.nome AS ProdutoNome, iv.quantidade, p.preco, v.datavenda
                    FROM Vendas v
                    JOIN ItensVenda iv ON v.vendaid = iv.vendaid
                    JOIN Produtos p ON iv.produtoid = p.produtoid
                    WHERE v.datavenda BETWEEN @dataInicio AND @dataFim";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                        cmd.Parameters.AddWithValue("@dataFim", dataFim);

                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(vendasTable);
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
                MessageBox.Show($"Erro ao preencher vendas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataInicio = dtpDataInicio.Value;
                DateTime dataFim = dtpDataFinal.Value;

                // Preencher os dados das vendas
                PreencherVendas(dataInicio, dataFim);

                // Verificar se a tabela de vendas contém dados
                if (reportDataSet.Tables["RelatorioVendas"].Rows.Count == 0)
                {
                    MessageBox.Show("Não há vendas para o período selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Verificar se o ReportViewer foi inicializado
                if (rpvRelatorioVendas == null)
                {
                    MessageBox.Show("ReportViewer não inicializado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Configurar e exibir o relatório
                ReportDataSource rds = new ReportDataSource("DataSetRelatorioVendas", reportDataSet.Tables["RelatorioVendas"]);
                rpvRelatorioVendas.LocalReport.DataSources.Clear();
                rpvRelatorioVendas.LocalReport.DataSources.Add(rds);
                rpvRelatorioVendas.LocalReport.ReportEmbeddedResource = "clientes_produtos_vendas.Reports.RelatorioVendas.rdlc";
                rpvRelatorioVendas.RefreshReport();
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