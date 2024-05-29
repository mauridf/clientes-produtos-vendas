namespace clientes_produtos_vendas.Forms
{
    partial class frmRelatorioEstoque
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
            rpvRelatorioEstoque = new Microsoft.Reporting.WinForms.ReportViewer();
            btnGerarRelatorio = new Button();
            SuspendLayout();
            // 
            // rpvRelatorioEstoque
            // 
            rpvRelatorioEstoque.Location = new Point(0, 0);
            rpvRelatorioEstoque.Name = "ReportViewer";
            rpvRelatorioEstoque.ServerReport.BearerToken = null;
            rpvRelatorioEstoque.Size = new Size(396, 246);
            rpvRelatorioEstoque.TabIndex = 0;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.Location = new Point(30, 52);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.Size = new Size(169, 29);
            btnGerarRelatorio.TabIndex = 0;
            btnGerarRelatorio.Text = "Gerar Relatório";
            btnGerarRelatorio.UseVisualStyleBackColor = true;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
            // 
            // frmRelatorioEstoque
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 267);
            Controls.Add(btnGerarRelatorio);
            MinimizeBox = false;
            Name = "frmRelatorioEstoque";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RELATÓRIO DE ESTOQUE";
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvRelatorioEstoque;
        private Button btnGerarRelatorio;
    }
}