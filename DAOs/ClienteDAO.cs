using System;
using System.Data;
using clientes_produtos_vendas.Models;
using Npgsql;

namespace clientes_produtos_vendas.DAOs
{
    public class ClienteDAO
    {
        private string cn = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;

        public void InserirCliente(Cliente cliente)
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
    }
}
