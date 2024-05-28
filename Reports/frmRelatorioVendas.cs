using clientes_produtos_vendas.Models;
using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace clientes_produtos_vendas.Reports
{
    public partial class frmRelatorioVendas : Form
    {
        private string cn = ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;

        public frmRelatorioVendas()
        {
            InitializeComponent();
            btnGerarRelatorio.Click += btnGerarRelatorio_Click; // Certifique-se de que o evento está vinculado
        }

        private List<RelatorioVenda> ObterVendas(DateTime dataInicio, DateTime dataFim)
        {
            List<RelatorioVenda> vendas = new List<RelatorioVenda>();

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

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendas.Add(new RelatorioVenda
                            {
                                VendaId = reader.GetInt32(0),
                                ProdutoNome = reader.GetString(1),
                                Quantidade = reader.GetInt32(2),
                                Preco = reader.GetDecimal(3) * reader.GetInt32(2), // Preço total (preço unitário x quantidade)
                                DataVenda = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }
            return vendas;
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataInicio = dtpDataInicio.Value;
                DateTime dataFim = dtpDataFim.Value;

                List<RelatorioVenda> vendas = ObterVendas(dataInicio, dataFim);

                if (vendas.Count == 0)
                {
                    MessageBox.Show("Nenhuma venda encontrada para o período selecionado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ReportDataSource rds = new ReportDataSource("DataSetVendas", ToDataTable(vendas));
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "clientes_produtos_vendas.Reports.RelatorioVendas.rdlc"; // Nome do arquivo RDLC

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ToDataTable(List<RelatorioVenda> vendas)
        {
            DataTable table = new DataTable();
            table.Columns.Add("VendaId", typeof(int));
            table.Columns.Add("ProdutoNome", typeof(string));
            table.Columns.Add("Quantidade", typeof(int));
            table.Columns.Add("Preco", typeof(decimal));
            table.Columns.Add("DataVenda", typeof(DateTime));

            foreach (var venda in vendas)
            {
                table.Rows.Add(venda.VendaId, venda.ProdutoNome, venda.Quantidade, venda.Preco, venda.DataVenda);
            }

            return table;
        }
    }
}