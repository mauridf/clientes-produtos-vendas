using System;
using System.Data;
using clientes_produtos_vendas.Models;
using Npgsql;

namespace clientes_produtos_vendas.DAOs
{
    public class ClienteDAO
    {
        private string cn = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;

        public DataTable BuscarClientes(string searchQuery = null, int currentPage = 0, int pageSize = 0)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(cn))
                {
                    conn.Open();

                    string query = @"
                SELECT * 
                FROM clientes";

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
                    ORDER BY clienteid 
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
                Console.WriteLine($"Erro ao buscar cliente: {ex.Message}");
                throw;
            }
        }

        public void InserirCliente(Cliente cliente)
        {
            try
            {
                using (var connection = new NpgsqlConnection(cn))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("INSERT INTO clientes (nome, endereco, telefone, email) VALUES (@Nome, @Endereco, @Telefone, @Email)", connection))
                    {
                        command.Parameters.AddWithValue("@Nome", cliente.Nome);
                        command.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                        command.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                        command.Parameters.AddWithValue("@Email", cliente.Email);
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
                Console.WriteLine($"Erro ao inserir cliente: {ex.Message}");
                throw; 
            }
        }

        public void AlterarCliente(Cliente cliente)
        {
            try
            {
                using (var connection = new NpgsqlConnection(cn))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("UPDATE clientes SET nome = @Nome, endereco = @Endereco, telefone = @Telefone, email = @Email WHERE clienteid = @ClienteId", connection))
                    {
                        command.Parameters.AddWithValue("@Nome", cliente.Nome);
                        command.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                        command.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                        command.Parameters.AddWithValue("@Email", cliente.Email);
                        command.Parameters.AddWithValue("@ClienteId", cliente.ClienteID);
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
                Console.WriteLine($"Erro ao alterar cliente: {ex.Message}");
                throw; 
            }
        }

        public void ExcluirCliente(int clienteId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(cn))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("DELETE FROM clientes WHERE clienteid = @ClienteId", connection))
                    {
                        command.Parameters.AddWithValue("@ClienteId", clienteId);
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
                Console.WriteLine($"Erro ao excluir cliente: {ex.Message}");
                throw; 
            }
        }
    }
}