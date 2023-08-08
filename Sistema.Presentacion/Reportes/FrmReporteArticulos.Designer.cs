namespace Sistema.Presentacion.Reportes
{
    partial class FrmReporteArticulos
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
            this.articulo_listarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsSistema = new Sistema.Presentacion.Reportes.DsSistema();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.articulo_listarTableAdapter = new Sistema.Presentacion.Reportes.DsSistemaTableAdapters.articulo_listarTableAdapter();
            this.articulolistarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSistemaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.articulolistarBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.articulo_listarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulolistarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSistemaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulolistarBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // articulo_listarBindingSource
            // 
            this.articulo_listarBindingSource.DataMember = "articulo_listar";
            this.articulo_listarBindingSource.DataSource = this.DsSistema;
            // 
            // DsSistema
            // 
            this.DsSistema.DataSetName = "DsSistema";
            this.DsSistema.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DtsArticulo";
            reportDataSource1.Value = this.articulolistarBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema.Presentacion.Reportes.RptArticulos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(926, 609);
            this.reportViewer1.TabIndex = 0;
            // 
            // articulo_listarTableAdapter
            // 
            this.articulo_listarTableAdapter.ClearBeforeFill = true;
            // 
            // articulolistarBindingSource
            // 
            this.articulolistarBindingSource.DataMember = "articulo_listar";
            this.articulolistarBindingSource.DataSource = this.DsSistema;
            // 
            // dsSistemaBindingSource
            // 
            this.dsSistemaBindingSource.DataSource = this.DsSistema;
            this.dsSistemaBindingSource.Position = 0;
            // 
            // articulolistarBindingSource1
            // 
            this.articulolistarBindingSource1.DataMember = "articulo_listar";
            this.articulolistarBindingSource1.DataSource = this.DsSistema;
            // 
            // FrmReporteArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 609);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmReporteArticulos";
            this.Text = "Reporte de artículos";
            this.Load += new System.EventHandler(this.FrmReporteArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.articulo_listarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulolistarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSistemaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulolistarBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource articulo_listarBindingSource;
        private DsSistema DsSistema;
        private DsSistemaTableAdapters.articulo_listarTableAdapter articulo_listarTableAdapter;
        private System.Windows.Forms.BindingSource articulolistarBindingSource1;
        private System.Windows.Forms.BindingSource articulolistarBindingSource;
        private System.Windows.Forms.BindingSource dsSistemaBindingSource;
    }
}