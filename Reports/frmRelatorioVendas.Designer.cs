namespace clientes_produtos_vendas.Reports
{
    partial class frmRelatorioVendas
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            label1 = new Label();
            label2 = new Label();
            dtpDataInicio = new DateTimePicker();
            dtpDataFim = new DateTimePicker();
            btnGerarRelatorio = new Button();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 0;
            label1.Text = "Data Início:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(375, 9);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Data Final:";
            // 
            // dtpDataInicio
            // 
            dtpDataInicio.Location = new Point(102, 12);
            dtpDataInicio.Name = "dtpDataInicio";
            dtpDataInicio.Size = new Size(250, 27);
            dtpDataInicio.TabIndex = 2;
            // 
            // dtpDataFim
            // 
            dtpDataFim.Location = new Point(460, 12);
            dtpDataFim.Name = "dtpDataFim";
            dtpDataFim.Size = new Size(250, 27);
            dtpDataFim.TabIndex = 3;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.Location = new Point(12, 66);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.Size = new Size(176, 29);
            btnGerarRelatorio.TabIndex = 4;
            btnGerarRelatorio.Text = "Gerar Relatório";
            btnGerarRelatorio.UseVisualStyleBackColor = true;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
            // 
            // frmRelatorioVendas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 450);
            Controls.Add(btnGerarRelatorio);
            Controls.Add(dtpDataFim);
            Controls.Add(dtpDataInicio);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmRelatorioVendas";
            Text = "RELATÓRIO DE VENDAS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpDataInicio;
        private DateTimePicker dtpDataFim;
        private Button btnGerarRelatorio;
    }
}