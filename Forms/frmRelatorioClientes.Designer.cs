namespace clientes_produtos_vendas.Forms
{
    partial class frmRelatorioClientes
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
            btnGerarRelatorio = new Button();
            rpvRelatorioClientes = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.Location = new Point(33, 12);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.Size = new Size(205, 29);
            btnGerarRelatorio.TabIndex = 0;
            btnGerarRelatorio.Text = "Gerar Relatório";
            btnGerarRelatorio.UseVisualStyleBackColor = true;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
            // 
            // rpvRelatorioClientes
            // 
            rpvRelatorioClientes.Location = new Point(0, 0);
            rpvRelatorioClientes.Name = "ReportViewer";
            rpvRelatorioClientes.ServerReport.BearerToken = null;
            rpvRelatorioClientes.Size = new Size(396, 246);
            rpvRelatorioClientes.TabIndex = 0;
            // 
            // frmRelatorioClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 179);
            Controls.Add(btnGerarRelatorio);
            MinimizeBox = false;
            Name = "frmRelatorioClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RELATÓRIO DE CLIENTES";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGerarRelatorio;
        private Microsoft.Reporting.WinForms.ReportViewer rpvRelatorioClientes;
    }
}