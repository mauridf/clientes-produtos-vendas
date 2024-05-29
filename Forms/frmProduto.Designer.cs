using System.Windows.Forms;

namespace clientes_produtos_vendas.Forms
{
    partial class frmProduto
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
            txtId = new TextBox();
            txtProduto = new TextBox();
            txtDescricao = new TextBox();
            txtPreco = new MaskedTextBox();
            txtEstoque = new TextBox();
            btnSalvar = new Button();
            btnFechar = new Button();
            dgvProdutos = new DataGridView();
            btnExcluir = new DataGridViewButtonColumn();
            txtPesquisar = new TextBox();
            btnAnterior = new Button();
            btnProximo = new Button();
            lblPaginaAtual = new Label();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
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
            label3.Location = new Point(12, 90);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 2;
            label3.Text = "Descrição:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 137);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 3;
            label4.Text = "Preço:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(321, 137);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 4;
            label5.Text = "Estoque:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(110, 9);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 5;
            // 
            // txtProduto
            // 
            txtProduto.Location = new Point(111, 51);
            txtProduto.Name = "txtProduto";
            txtProduto.Size = new Size(794, 27);
            txtProduto.TabIndex = 6;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(110, 90);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(795, 27);
            txtDescricao.TabIndex = 7;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(110, 131);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(138, 27);
            txtPreco.TabIndex = 8;
            txtPreco.TextAlign = HorizontalAlignment.Right;
            txtPreco.Enter += txtPreco_Enter;
            txtPreco.KeyPress += txtPreco_KeyPress;
            txtPreco.Leave += txtPreco_Leave;
            // 
            // txtEstoque
            // 
            txtEstoque.Location = new Point(392, 131);
            txtEstoque.Name = "txtEstoque";
            txtEstoque.Size = new Size(125, 27);
            txtEstoque.TabIndex = 9;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.LightGreen;
            btnSalvar.Location = new Point(17, 184);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "&Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.LightCoral;
            btnFechar.Location = new Point(132, 184);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(94, 29);
            btnFechar.TabIndex = 11;
            btnFechar.Text = "&Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // dgvProdutos
            // 
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Columns.AddRange(new DataGridViewColumn[] { btnExcluir });
            dgvProdutos.Location = new Point(17, 233);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.RowHeadersWidth = 51;
            dgvProdutos.RowTemplate.Height = 29;
            dgvProdutos.Size = new Size(888, 188);
            dgvProdutos.TabIndex = 12;
            dgvProdutos.CellClick += dgvProdutos_CellClick;
            dgvProdutos.CellFormatting += dgvProdutos_CellFormatting;
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
            txtPesquisar.Location = new Point(17, 442);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(274, 27);
            txtPesquisar.TabIndex = 13;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(297, 442);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(94, 29);
            btnAnterior.TabIndex = 14;
            btnAnterior.Text = "<<";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnProximo
            // 
            btnProximo.Location = new Point(397, 442);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(94, 29);
            btnProximo.TabIndex = 15;
            btnProximo.Text = ">>";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Click += btnProximo_Click;
            // 
            // lblPaginaAtual
            // 
            lblPaginaAtual.AutoSize = true;
            lblPaginaAtual.Location = new Point(497, 446);
            lblPaginaAtual.Name = "lblPaginaAtual";
            lblPaginaAtual.Size = new Size(68, 20);
            lblPaginaAtual.TabIndex = 16;
            lblPaginaAtual.Text = "Página: 1";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightSeaGreen;
            btnCancelar.Location = new Point(247, 184);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmProduto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 504);
            Controls.Add(btnCancelar);
            Controls.Add(lblPaginaAtual);
            Controls.Add(btnProximo);
            Controls.Add(btnAnterior);
            Controls.Add(txtPesquisar);
            Controls.Add(dgvProdutos);
            Controls.Add(btnFechar);
            Controls.Add(btnSalvar);
            Controls.Add(txtEstoque);
            Controls.Add(txtPreco);
            Controls.Add(txtDescricao);
            Controls.Add(txtProduto);
            Controls.Add(txtId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmProduto";
            Text = "PRODUTOS";
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtId;
        private TextBox txtProduto;
        private TextBox txtDescricao;
        private MaskedTextBox txtPreco;
        private TextBox txtEstoque;
        private Button btnSalvar;
        private Button btnFechar;
        private DataGridView dgvProdutos;
        private TextBox txtPesquisar;
        private Button btnAnterior;
        private Button btnProximo;
        private Label lblPaginaAtual;
        private DataGridViewButtonColumn btnExcluir;
        private Button btnCancelar;
    }
}