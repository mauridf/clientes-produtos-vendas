using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace clientes_produtos_vendas.Forms
{
    public partial class frmRelatorioClientes : Form
    {
        private string cn = ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;
        private DataSet reportDataSet;

        public frmRelatorioClientes(DataSet ds)
        {
            InitializeComponent();
            reportDataSet = ds;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
        }

        private void PreencherClientes(DataTable clientesTable)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(cn))
                {
                    conn.Open();
                    string query = "SELECT ClienteId, Nome, Endereco FROM Clientes";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(clientesTable);
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
                MessageBox.Show($"Erro ao preencher clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifique se o DataTable existe no DataSet
                if (!reportDataSet.Tables.Contains("Clientes"))
                {
                    MessageBox.Show("Tabela Clientes não encontrada no DataSet.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable clientesTable = reportDataSet.Tables["Clientes"];
                clientesTable.Clear(); // Limpar dados anteriores
                PreencherClientes(clientesTable);

                // Verifique se o ReportViewer foi inicializado
                if (rpvRelatorioClientes == null)
                {
                    MessageBox.Show("ReportViewer não inicializado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ReportDataSource rds = new ReportDataSource("RelatoriosDataSet", clientesTable);
                rpvRelatorioClientes.LocalReport.DataSources.Clear();
                rpvRelatorioClientes.LocalReport.DataSources.Add(rds);
                rpvRelatorioClientes.LocalReport.ReportEmbeddedResource = "clientes_produtos_vendas.Reports.RelatorioClientes.rdlc";
                rpvRelatorioClientes.RefreshReport();
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