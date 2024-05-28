using System;
using System.Data;
using clientes_produtos_vendas.Models;
using Npgsql;

namespace clientes_produtos_vendas.DAOs
{
    public class VendaDAO
    {
        private string cn = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;

        public void RegistrarVenda(Venda venda, List<ItemVenda> itensVenda)
        {
            using (var connection = new NpgsqlConnection(cn))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new NpgsqlCommand("INSERT INTO vendas (clienteID, datavenda) VALUES (@ClienteID, @DataVenda) RETURNING VendaID", connection))
                        {
                            command.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                            command.Parameters.AddWithValue("@DataVenda", DateTime.Now);
                            venda.VendaID = (int)command.ExecuteScalar();
                        }

                        foreach (var itemVenda in itensVenda)
                        {
                            itemVenda.VendaID = venda.VendaID;
                            using (var command = new NpgsqlCommand("INSERT INTO itensvenda (vendaid, produtoid, quantidade) VALUES (@VendaID, @ProdutoID, @Quantidade)", connection))
                            {
                                command.Parameters.AddWithValue("@VendaID", itemVenda.VendaID);
                                command.Parameters.AddWithValue("@ProdutoID", itemVenda.ProdutoID);
                                command.Parameters.AddWithValue("@Quantidade", itemVenda.Quantidade);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
