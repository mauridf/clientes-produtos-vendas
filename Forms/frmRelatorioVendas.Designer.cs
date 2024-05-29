namespace clientes_produtos_vendas.Forms
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
            rpvRelatorioVendas = new Microsoft.Reporting.WinForms.ReportViewer();
            lblDataInicio = new Label();
            lblDataFinal = new Label();
            dtpDataInicio = new DateTimePicker();
            dtpDataFinal = new DateTimePicker();
            btnGerarRelatorio = new Button();
            SuspendLayout();
            // 
            // rpvRelatorioVendas
            // 
            rpvRelatorioVendas.Location = new Point(0, 0);
            rpvRelatorioVendas.Name = "ReportViewer";
            rpvRelatorioVendas.ServerReport.BearerToken = null;
            rpvRelatorioVendas.Size = new Size(396, 246);
            rpvRelatorioVendas.TabIndex = 0;
            // 
            // lblDataInicio
            // 
            lblDataInicio.AutoSize = true;
            lblDataInicio.Location = new Point(12, 9);
            lblDataInicio.Name = "lblDataInicio";
            lblDataInicio.Size = new Size(84, 20);
            lblDataInicio.TabIndex = 0;
            lblDataInicio.Text = "Data Início:";
            // 
            // lblDataFinal
            // 
            lblDataFinal.AutoSize = true;
            lblDataFinal.Location = new Point(12, 58);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(79, 20);
            lblDataFinal.TabIndex = 1;
            lblDataFinal.Text = "Data Final:";
            // 
            // dtpDataInicio
            // 
            dtpDataInicio.Format = DateTimePickerFormat.Short;
            dtpDataInicio.Location = new Point(113, 11);
            dtpDataInicio.Name = "dtpDataInicio";
            dtpDataInicio.Size = new Size(250, 27);
            dtpDataInicio.TabIndex = 2;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Format = DateTimePickerFormat.Short;
            dtpDataFinal.Location = new Point(113, 54);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.Size = new Size(250, 27);
            dtpDataFinal.TabIndex = 3;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.Location = new Point(12, 98);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.Size = new Size(182, 29);
            btnGerarRelatorio.TabIndex = 4;
            btnGerarRelatorio.Text = "Gerar Relatório";
            btnGerarRelatorio.UseVisualStyleBackColor = true;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
            // 
            // frmRelatorioVendas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 235);
            Controls.Add(btnGerarRelatorio);
            Controls.Add(dtpDataFinal);
            Controls.Add(dtpDataInicio);
            Controls.Add(lblDataFinal);
            Controls.Add(lblDataInicio);
            MinimizeBox = false;
            Name = "frmRelatorioVendas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RELATÓRIO DE VENDAS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvRelatorioVendas;
        private Label lblDataInicio;
        private Label lblDataFinal;
        private DateTimePicker dtpDataInicio;
        private DateTimePicker dtpDataFinal;
        private Button btnGerarRelatorio;
    }
}