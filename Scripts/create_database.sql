-- Criar o banco de dados
CREATE DATABASE controle_vendas;

-- Criar tabela de Clientes
CREATE TABLE Clientes (
    ClienteID SERIAL PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Endereco VARCHAR(200),
    Telefone VARCHAR(20),
    Email VARCHAR(100)
);

-- Criar tabela de Produtos
CREATE TABLE Produtos (
    ProdutoID SERIAL PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Descricao TEXT,
    Preco DECIMAL(10, 2) NOT NULL,
    Estoque INT NOT NULL
);

-- Criar tabela de Vendas
CREATE TABLE Vendas (
    VendaID SERIAL PRIMARY KEY,
    ClienteID INT REFERENCES Clientes(ClienteID),
    DataVenda TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Criar tabela de ItensVenda
CREATE TABLE ItensVenda (
    ItemVendaID SERIAL PRIMARY KEY,
    VendaID INT REFERENCES Vendas(VendaID),
    ProdutoID INT REFERENCES Produtos(ProdutoID),
    Quantidade INT NOT NULL
);
