using System;
using System.Data;
using clientes_produtos_vendas.Models;
using Npgsql;

namespace clientes_produtos_vendas.DAOs
{
    public class ProdutoDAO
    {
        private string cn = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConnection"].ConnectionString;

        public void InserirProduto(Produto produto)
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
    }
}
