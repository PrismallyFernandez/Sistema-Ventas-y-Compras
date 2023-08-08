namespace Sistema.Presentacion.Reportes
{
    partial class FrmReporteComprobanteVenta
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsSistema = new Sistema.Presentacion.Reportes.DsSistema();
            this.venta_comprobanteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.venta_comprobanteTableAdapter = new Sistema.Presentacion.Reportes.DsSistemaTableAdapters.venta_comprobanteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.venta_comprobanteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsComprobanteVenta";
            reportDataSource1.Value = this.venta_comprobanteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema.Presentacion.Reportes.RptComprobanteVenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1232, 825);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsSistema
            // 
            this.DsSistema.DataSetName = "DsSistema";
            this.DsSistema.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // venta_comprobanteBindingSource
            // 
            this.venta_comprobanteBindingSource.DataMember = "venta_comprobante";
            this.venta_comprobanteBindingSource.DataSource = this.DsSistema;
            // 
            // venta_comprobanteTableAdapter
            // 
            this.venta_comprobanteTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteComprobanteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 825);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteComprobanteVenta";
            this.Text = "Reporte Comprobante Venta";
            this.Load += new System.EventHandler(this.FrmReporteComprobanteVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.venta_comprobanteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource venta_comprobanteBindingSource;
        private DsSistema DsSistema;
        private DsSistemaTableAdapters.venta_comprobanteTableAdapter venta_comprobanteTableAdapter;
    }
}