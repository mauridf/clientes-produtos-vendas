namespace clientes_produtos_vendas.Forms
{
    partial class frmClientes
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtClienteID = new TextBox();
            txtNomeCliente = new TextBox();
            txtEnderecoCliente = new TextBox();
            txtTelefoneCliente = new MaskedTextBox();
            txtEmailCliente = new MaskedTextBox();
            btnSalvar = new Button();
            btnSair = new Button();
            dgvClientes = new DataGridView();
            btnExcluir = new DataGridViewButtonColumn();
            txtPesquisar = new TextBox();
            btnAnterior = new Button();
            btnProximo = new Button();
            lblPaginaAtual = new Label();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(27, 20);
            label1.TabIndex = 0;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 1;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 91);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 2;
            label3.Text = "Endereço:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 132);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 3;
            label4.Text = "Telefone:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(535, 132);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 4;
            label5.Text = "E-mail:";
            // 
            // txtClienteID
            // 
            txtClienteID.Enabled = false;
            txtClienteID.Location = new Point(108, 6);
            txtClienteID.Name = "txtClienteID";
            txtClienteID.Size = new Size(125, 27);
            txtClienteID.TabIndex = 5;
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Location = new Point(108, 46);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(843, 27);
            txtNomeCliente.TabIndex = 1;
            // 
            // txtEnderecoCliente
            // 
            txtEnderecoCliente.Location = new Point(109, 88);
            txtEnderecoCliente.Name = "txtEnderecoCliente";
            txtEnderecoCliente.Size = new Size(842, 27);
            txtEnderecoCliente.TabIndex = 2;
            // 
            // txtTelefoneCliente
            // 
            txtTelefoneCliente.Location = new Point(109, 134);
            txtTelefoneCliente.Mask = "(00) 00000-0000";
            txtTelefoneCliente.Name = "txtTelefoneCliente";
            txtTelefoneCliente.Size = new Size(320, 27);
            txtTelefoneCliente.TabIndex = 3;
            // 
            // txtEmailCliente
            // 
            txtEmailCliente.Location = new Point(596, 134);
            txtEmailCliente.Name = "txtEmailCliente";
            txtEmailCliente.Size = new Size(355, 27);
            txtEmailCliente.TabIndex = 4;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.LightGreen;
            btnSalvar.Location = new Point(12, 191);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "&Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.LightCoral;
            btnSair.Location = new Point(139, 191);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(94, 29);
            btnSair.TabIndex = 6;
            btnSair.Text = "&Fechar";
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToOrderColumns = true;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { btnExcluir });
            dgvClientes.Location = new Point(12, 245);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.RowTemplate.Height = 29;
            dgvClientes.Size = new Size(939, 228);
            dgvClientes.TabIndex = 7;
            dgvClientes.CellClick += dgvClientes_CellClick;
            dgvClientes.CellFormatting += dgvClientes_CellFormatting;
            // 
            // btnExcluir
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = Color.Red;
            btnExcluir.DefaultCellStyle = dataGridViewCellStyle1;
            btnExcluir.HeaderText = "Excluir";
            btnExcluir.MinimumWidth = 6;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Text = "Excluir";
            btnExcluir.UseColumnTextForButtonValue = true;
            btnExcluir.Width = 125;
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(12, 492);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(265, 27);
            txtPesquisar.TabIndex = 8;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(283, 490);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(94, 29);
            btnAnterior.TabIndex = 9;
            btnAnterior.Text = "<<";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnProximo
            // 
            btnProximo.Location = new Point(383, 491);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(94, 29);
            btnProximo.TabIndex = 10;
            btnProximo.Text = ">>";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Click += btnProximo_Click;
            // 
            // lblPaginaAtual
            // 
            lblPaginaAtual.AutoSize = true;
            lblPaginaAtual.Location = new Point(483, 494);
            lblPaginaAtual.Name = "lblPaginaAtual";
            lblPaginaAtual.Size = new Size(68, 20);
            lblPaginaAtual.TabIndex = 16;
            lblPaginaAtual.Text = "Página: 1";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightSeaGreen;
            btnCancelar.Location = new Point(262, 191);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 549);
            Controls.Add(btnCancelar);
            Controls.Add(lblPaginaAtual);
            Controls.Add(btnProximo);
            Controls.Add(btnAnterior);
            Controls.Add(txtPesquisar);
            Controls.Add(dgvClientes);
            Controls.Add(btnSair);
            Controls.Add(btnSalvar);
            Controls.Add(txtEmailCliente);
            Controls.Add(txtTelefoneCliente);
            Controls.Add(txtEnderecoCliente);
            Controls.Add(txtNomeCliente);
            Controls.Add(txtClienteID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmClientes";
            Text = "CLIENTES";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtClienteID;
        private TextBox txtNomeCliente;
        private TextBox txtEnderecoCliente;
        private MaskedTextBox txtTelefoneCliente;
        private MaskedTextBox txtEmailCliente;
        private Button btnSalvar;
        private Button btnSair;
        private DataGridView dgvClientes;
        private TextBox txtPesquisar;
        private Button btnAnterior;
        private Button btnProximo;
        private Label lblPaginaAtual;
        private DataGridViewButtonColumn btnExcluir;
        private Button btnCancelar;
    }
}