using System;
using System.Windows.Forms;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmVista_ProveedorIngreso : Form
    {
        public FrmVista_ProveedorIngreso()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                DgvListado.DataSource = NPersona.ListarProveedores();
                this.Formato();
                LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Buscar()
        {
            try
            {
                DgvListado.DataSource = NPersona.BuscarProveedores(TxtBuscar.Text);
                this.Formato();
                LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato()
        {
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[1].Width = 50;
            DgvListado.Columns[2].Width = 100;
            DgvListado.Columns[2].HeaderText = "Tipo Persona";
            DgvListado.Columns[3].Width = 170;
            DgvListado.Columns[4].Width = 100;
            DgvListado.Columns[4].HeaderText = "Documento";
            DgvListado.Columns[5].Width = 100;
            DgvListado.Columns[5].HeaderText = "Número Doc.";
            DgvListado.Columns[6].Width = 120;
            DgvListado.Columns[6].HeaderText = "Dirección";
            DgvListado.Columns[7].Width = 100;
            DgvListado.Columns[7].HeaderText = "Teléfono";
            DgvListado.Columns[8].Width = 120;
        }

        private void FrmVista_ProveedorIngreso_Load(object sender, EventArgs e)
        {
            //this.Listar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Variables.IdProveedor = Convert.ToInt32(DgvListado.CurrentRow.Cells["ID"].Value);
            Variables.NombreProveedor = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
            this.Close();
        }
    }
}
