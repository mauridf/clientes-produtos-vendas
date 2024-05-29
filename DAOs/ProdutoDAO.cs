using System;
using System.Data;
using clientes_produtos_vendas.Models;
using Npgsql;

namespace clientes_produtos_vendas.DAOs
{
    public class ProdutoDAO
    {
        private string cn = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;

        public DataTable BuscarProdutos(string searchQuery = null, int currentPage = 0, int pageSize = 0)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(cn))
                {
                    conn.Open();

                    string query = @"
                    SELECT * 
                    FROM produtos";

                        // Adiciona a condição de pesquisa se o parâmetro searchQuery não for nulo nem vazio
                        if (!string.IsNullOrWhiteSpace(searchQuery))
                        {
                            query += @"
                        WHERE nome ILIKE @searchQuery";
                        }

                        // Adiciona a ordenação e a limitação apenas se currentPage e pageSize forem fornecidos
                        if (currentPage > 0 && pageSize > 0)
                        {
                            query += @"
                            ORDER BY produtoid 
                            LIMIT @pageSize 
                            OFFSET @offset";
                        }

                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            if (!string.IsNullOrWhiteSpace(searchQuery))
                            {
                                cmd.Parameters.AddWithValue("@searchQuery", $"%{searchQuery}%");
                            }

                            if (currentPage > 0 && pageSize > 0)
                            {
                                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                                cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                            }

                            using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                return dt;
                            }
                        }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Erro de banco de dados: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao pesquisar produto: {ex.Message}");
                throw;
            }
        }

        public void InserirProduto(Produto produto)
        {
            try
            {
                using (var connection = new NpgsqlConnection(cn))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("INSERT INTO produtos (nome, descricao, preco, estoque) VALUES (@Nome, @Descricao, @Preco, @Estoque)", connection))
                    {
                        command.Parameters.AddWithValue("@Nome", produto.Nome);
                        command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                        command.Parameters.AddWithValue("@Preco", produto.Preco);
                        command.Parameters.AddWithValue("@Estoque", produto.Estoque);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Erro de banco de dados: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir produto: {ex.Message}");
                throw; 
            }
        }

        public void AlterarProduto(Produto produto)
        {
            try
            {
                using (var connection = new NpgsqlConnection(cn))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("UPDATE produtos SET nome = @Nome, descricao = @Descricao, preco = @Preco, estoque = @Estoque WHERE produtoid = @ProdutoId", connection))
                    {
                        command.Parameters.AddWithValue("@Nome", produto.Nome);
                        command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                        command.Parameters.AddWithValue("@Preco", produto.Preco);
                        command.Parameters.AddWithValue("@Estoque", produto.Estoque);
                        command.Parameters.AddWithValue("@ProdutoId", produto.ProdutoID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Erro de banco de dados: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao alterar produto: {ex.Message}");
                throw; 
            }
        }

        public void ExcluirProduto(int produtoId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(cn))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("DELETE FROM produtos WHERE produtoid = @ProdutoId", connection))
                    {
                        command.Parameters.AddWithValue("@ProdutoId", produtoId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Erro de banco de dados: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir produto: {ex.Message}");
                throw; 
            }
        }
    }
}