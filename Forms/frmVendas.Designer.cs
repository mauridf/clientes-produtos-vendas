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
            SuspendLayout();
            // 
            // frmVendas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 642);
            Name = "frmVendas";
            Text = "EFETUAR VENDAS";
            ResumeLayout(false);

            this.lblCliente = new System.Windows.Forms.Label();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.cboProdutos = new System.Windows.Forms.ComboBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.btnAddProduto = new System.Windows.Forms.Button();
            this.dgvItensVenda = new System.Windows.Forms.DataGridView();
            this.btnSalvarVenda = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 15);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(56, 20);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboClientes
            // 
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(74, 12);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(300, 28);
            this.cboClientes.TabIndex = 1;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(12, 53);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(64, 20);
            this.lblProduto.TabIndex = 2;
            this.lblProduto.Text = "Produto:";
            // 
            // cboProdutos
            // 
            this.cboProdutos.FormattingEnabled = true;
            this.cboProdutos.Location = new System.Drawing.Point(74, 50);
            this.cboProdutos.Name = "cboProdutos";
            this.cboProdutos.Size = new System.Drawing.Size(300, 28);
            this.cboProdutos.TabIndex = 3;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(12, 91);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(89, 20);
            this.lblQuantidade.TabIndex = 4;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(107, 88);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(100, 27);
            this.txtQuantidade.TabIndex = 5;
            // 
            // btnAddProduto
            // 
            this.btnAddProduto.Location = new System.Drawing.Point(213, 87);
            this.btnAddProduto.Name = "btnAddProduto";
            this.btnAddProduto.Size = new System.Drawing.Size(161, 29);
            this.btnAddProduto.TabIndex = 6;
            this.btnAddProduto.Text = "Adicionar Produto";
            this.btnAddProduto.UseVisualStyleBackColor = true;
            this.btnAddProduto.Click += new System.EventHandler(this.btnAddProduto_Click);
            // 
            // dgvItensVenda
            // 
            this.dgvItensVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensVenda.Location = new System.Drawing.Point(12, 130);
            this.dgvItensVenda.Name = "dgvItensVenda";
            this.dgvItensVenda.RowHeadersWidth = 51;
            this.dgvItensVenda.RowTemplate.Height = 29;
            this.dgvItensVenda.Size = new System.Drawing.Size(776, 250);
            this.dgvItensVenda.TabIndex = 7;
            // 
            // btnSalvarVenda
            // 
            this.btnSalvarVenda.Location = new System.Drawing.Point(12, 396);
            this.btnSalvarVenda.Name = "btnSalvarVenda";
            this.btnSalvarVenda.Size = new System.Drawing.Size(125, 29);
            this.btnSalvarVenda.TabIndex = 8;
            this.btnSalvarVenda.Text = "Salvar Venda";
            this.btnSalvarVenda.UseVisualStyleBackColor = true;
            this.btnSalvarVenda.Click += new System.EventHandler(this.btnSalvarVenda_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(143, 396);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 29);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmVenda
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvarVenda);
            this.Controls.Add(this.dgvItensVenda);
            this.Controls.Add(this.btnAddProduto);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.cboProdutos);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.cboClientes);
            this.Controls.Add(this.lblCliente);
            this.Name = "frmVenda";
            this.Text = "Registrar Venda";
            this.Load += new System.EventHandler(this.frmVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.ComboBox cboProdutos;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Button btnAddProduto;
        private System.Windows.Forms.DataGridView dgvItensVenda;
        private System.Windows.Forms.Button btnSalvarVenda;
        private System.Windows.Forms.Button btnCancelar;
    }
}