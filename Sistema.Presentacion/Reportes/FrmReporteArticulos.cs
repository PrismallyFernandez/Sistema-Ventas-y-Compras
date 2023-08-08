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
    public partial class FrmReporteArticulos : Form
    {
        public FrmReporteArticulos()
        {
            InitializeComponent();
        }

        private void FrmReporteArticulos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsSistema.articulo_listar' table. You can move, or remove it, as needed.
            this.articulo_listarTableAdapter.Fill(this.DsSistema.articulo_listar);

            this.reportViewer1.RefreshReport();
        }
    }
}
