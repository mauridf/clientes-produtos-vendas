namespace clientes_produtos_vendas.Forms
{
    partial class frmVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCliente = new Label();
            cboClientes = new ComboBox();
            lblProduto = new Label();
            cboProdutos = new ComboBox();
            lblQuantidade = new Label();
            txtQuantidade = new TextBox();
            btnAddProduto = new Button();
            dgvItensVenda = new DataGridView();
            btnSalvarVenda = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvItensVenda).BeginInit();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(12, 15);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(58, 20);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // cboClientes
            // 
            cboClientes.FormattingEnabled = true;
            cboClientes.Location = new Point(74, 12);
            cboClientes.Name = "cboClientes";
            cboClientes.Size = new Size(300, 28);
            cboClientes.TabIndex = 1;
            // 
            // lblProduto
            // 
            lblProduto.AutoSize = true;
            lblProduto.Location = new Point(12, 53);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(65, 20);
            lblProduto.TabIndex = 2;
            lblProduto.Text = "Produto:";
            // 
            // cboProdutos
            // 
            cboProdutos.FormattingEnabled = true;
            cboProdutos.Location = new Point(74, 50);
            cboProdutos.Name = "cboProdutos";
            cboProdutos.Size = new Size(300, 28);
            cboProdutos.TabIndex = 3;
            // 
            // lblQuantidade
            // 
            lblQuantidade.AutoSize = true;
            lblQuantidade.Location = new Point(12, 91);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(90, 20);
            lblQuantidade.TabIndex = 4;
            lblQuantidade.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new Point(107, 88);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(100, 27);
            txtQuantidade.TabIndex = 5;
            // 
            // btnAddProduto
            // 
            btnAddProduto.BackColor = Color.LightGreen;
            btnAddProduto.Location = new Point(213, 87);
            btnAddProduto.Name = "btnAddProduto";
            btnAddProduto.Size = new Size(161, 29);
            btnAddProduto.TabIndex = 6;
            btnAddProduto.Text = "Adicionar Produto";
            btnAddProduto.UseVisualStyleBackColor = false;
            btnAddProduto.Click += btnAddProduto_Click;
            // 
            // dgvItensVenda
            // 
            dgvItensVenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItensVenda.Location = new Point(12, 130);
            dgvItensVenda.Name = "dgvItensVenda";
            dgvItensVenda.RowHeadersWidth = 51;
            dgvItensVenda.RowTemplate.Height = 29;
            dgvItensVenda.Size = new Size(776, 250);
            dgvItensVenda.TabIndex = 7;
            // 
            // btnSalvarVenda
            // 
            btnSalvarVenda.BackColor = Color.LightGreen;
            btnSalvarVenda.Location = new Point(12, 396);
            btnSalvarVenda.Name = "btnSalvarVenda";
            btnSalvarVenda.Size = new Size(125, 29);
            btnSalvarVenda.TabIndex = 8;
            btnSalvarVenda.Text = "Salvar Venda";
            btnSalvarVenda.UseVisualStyleBackColor = false;
            btnSalvarVenda.Click += btnSalvarVenda_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightSeaGreen;
            btnCancelar.Location = new Point(143, 396);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmVendas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvarVenda);
            Controls.Add(dgvItensVenda);
            Controls.Add(btnAddProduto);
            Controls.Add(txtQuantidade);
            Controls.Add(lblQuantidade);
            Controls.Add(cboProdutos);
            Controls.Add(lblProduto);
            Controls.Add(cboClientes);
            Controls.Add(lblCliente);
            Name = "frmVendas";
            Text = "Registrar Venda";
            Load += frmVenda_Load;
            ((System.ComponentModel.ISupportInitialize)dgvItensVenda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label lblCliente;
        private ComboBox cboClientes;
        private Label lblProduto;
        private ComboBox cboProdutos;
        private Label lblQuantidade;
        private TextBox txtQuantidade;
        private Button btnAddProduto;
        private DataGridView dgvItensVenda;
        private Button btnSalvarVenda;
        private Button btnCancelar;
    }
}