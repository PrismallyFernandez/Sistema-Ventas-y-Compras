using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion.Reportes
{
    public partial class FrmReporteComprobanteVenta : Form
    {
        public FrmReporteComprobanteVenta()
        {
            InitializeComponent();
        }

        private void FrmReporteComprobanteVenta_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsSistema.venta_comprobante' table. You can move, or remove it, as needed.
            this.venta_comprobanteTableAdapter.Fill(this.DsSistema.venta_comprobante,Variables.IdVenta);

            this.reportViewer1.RefreshReport();
        }
    }
}
