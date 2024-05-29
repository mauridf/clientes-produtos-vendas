# Sistema de Gerenciamento de Clientes e Produtos
Este é um sistema desktop desenvolvido em .NET utilizando Windows Forms para gerenciar clientes, produtos e vendas. 
O sistema permite cadastrar, editar e remover clientes e produtos, realizar vendas e gerar relatórios.
## Funcionalidades:
    • Cadastro de Clientes: Permite cadastrar, editar e remover clientes com informações como nome, endereço, telefone e e-mail.
    • Cadastro de Produtos: Permite cadastrar, editar e remover produtos com informações como nome, descrição, preço e estoque.
    • Vendas: Permite realizar vendas de produtos, registrando o cliente, os produtos e a quantidade de cada item.
    • Relatórios: Geração de relatórios de vendas, clientes e estoque.
## Tecnologias Utilizadas:
    • C#
    • .NET 7.0
    • Windows Forms
    • PostgreSQL
    • Npgsql: Biblioteca ADO.NET para PostgreSQL
    • ReportViewer: Ferramenta para geração de relatórios
    • Microsoft RDLC Report Designer: Extensão para criar e editar relatórios RDLC
## Requisitos para Execução:
    • Sistema Operacional: Windows
    • .NET 6.0 SDK: Necessário para compilar e executar a aplicação
    • PostgreSQL: Banco de dados utilizado para armazenar as informações
    • Npgsql: Biblioteca de acesso ao PostgreSQL
    • Microsoft RDLC Report Designer: Extensão do Visual Studio para criação e edição de relatórios RDLC
# Configuração do Ambiente
## Banco de Dados
    1. Instale o PostgreSQL: Download PostgreSQL
    2. Crie o Banco de Dados e Tabelas:
        ◦ Use o seguinte script SQL para criar as tabelas necessárias:
          
          CREATE DATABASE controle_vendas;
          
          CREATE TABLE clientes (
              id SERIAL PRIMARY KEY,
              nome VARCHAR(100) NOT NULL,
              endereco VARCHAR(255),
              telefone VARCHAR(20),
              email VARCHAR(100)
          );
          
          CREATE TABLE produtos (
              id SERIAL PRIMARY KEY,
              nome VARCHAR(100) NOT NULL,
              descricao TEXT,
              preco DECIMAL(10, 2) NOT NULL,
              estoque INT NOT NULL
          );
          
          CREATE TABLE vendas (
              id SERIAL PRIMARY KEY,
              cliente_id INT REFERENCES clientes(id),
              data_venda TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
          );
          
          CREATE TABLE venda_produtos (
              venda_id INT REFERENCES vendas(id),
              produto_id INT REFERENCES produtos(id),
              quantidade INT NOT NULL,
              PRIMARY KEY (venda_id, produto_id)
          );
          
## Aplicação
    1. Clone o Repositório:
       bash
       Copiar código
       git clone https://github.com/mauridf/clientes-produtos-vendas.git
       cd clientes-produtos-vendas
    2. Configure a String de Conexão:
        ◦ No arquivo app.config ou appsettings.json, configure a string de conexão com seu banco de dados PostgreSQL:
          xml
          Copiar código
          <connectionStrings>
            <add name="PostgreSqlConnection" connectionString="Host=localhost;Username=SEU_USER;Password=SUA_SENHA;Database=controle_vendas" providerName="Npgsql"/>
          </connectionStrings>
    3. Instale a Extensão Microsoft RDLC Report Designer:
        ◦ Abra o Visual Studio.
        ◦ Acesse Extensions > Manage Extensions.
        ◦ Pesquise por "Microsoft RDLC Report Designer".
        ◦ Clique em Download e siga as instruções para instalar a extensão.
        ◦ Reinicie o Visual Studio para concluir a instalação.
    4. Restaure os Pacotes NuGet:
        ◦ No Visual Studio, clique com o botão direito no projeto e selecione Gerenciar Pacotes NuGet. Em seguida, clique em Restaurar.
    5. Compilar e Executar:
        ◦ Compile e execute a aplicação no Visual Studio.
## Uso
    1. Cadastro de Clientes:
        ◦ Acesse o menu Clientes e selecione Novo Cliente.
        ◦ Preencha as informações necessárias e clique em Salvar.
        ◦ Para editar ou remover um cliente, selecione o cliente na lista e clique em Editar ou Excluir.
    2. Cadastro de Produtos:
        ◦ Acesse o menu Produtos e selecione Novo Produto.
        ◦ Preencha as informações necessárias e clique em Salvar.
        ◦ Para editar ou remover um produto, selecione o produto na lista e clique em Editar ou Excluir.
    3. Realização de Vendas:
        ◦ Acesse o menu Vendas e selecione Nova Venda.
        ◦ Selecione o cliente e adicione os produtos desejados com as quantidades.
        ◦ Clique em Finalizar Venda para registrar a venda.
    4. Geração de Relatórios:
        ◦ Acesse o menu Relatórios e selecione o relatório desejado (RelatorioVendas, RelatorioClientes ou RelatorioEstoque).
