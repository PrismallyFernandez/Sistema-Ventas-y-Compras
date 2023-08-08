using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmVenta : Form
    {
        private DataTable DtDetalle = new DataTable();
        public FrmVenta()
        {
            InitializeComponent();
        }
        private void Listar()
        {
            try
            {
                DgvListado.DataSource = NVenta.Listar();
                this.Formato();
                this.Limpiar();
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
                DgvListado.DataSource = NVenta.Buscar(TxtBuscar.Text);
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
            DgvListado.Columns[1].Visible = false;
            DgvListado.Columns[2].Visible = false;
            DgvListado.Columns[0].Width = 100;
            DgvListado.Columns[3].Width = 150;
            DgvListado.Columns[4].Width = 150;
            DgvListado.Columns[5].Width = 100;
            DgvListado.Columns[5].HeaderText = "Documento";
            DgvListado.Columns[6].Width = 70;
            DgvListado.Columns[6].HeaderText = "Serie";
            DgvListado.Columns[7].Width = 70;
            DgvListado.Columns[7].HeaderText = "Número";
            DgvListado.Columns[8].Width = 60;
            DgvListado.Columns[9].Width = 100;
            DgvListado.Columns[10].Width = 100;
            DgvListado.Columns[11].Width = 100;
        }
        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtId.Clear();
            TxtCodigo.Clear();
            TxtIdCliente.Clear();
            TxtNombreCliente.Clear();
            TxtSerieComprobante.Clear();
            TxtNumComprobante.Clear();
            DtDetalle.Clear();
            TxtSubTotal.Text = "0.00";
            TxtTotalImpuesto.Text = "0.00";
            TxtTotal.Text = "0.00";

            DgvListado.Columns[0].Visible = false;
            BtnAnular.Visible = false;
            ChkSeleccionar.Checked = false;
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CrearTabla()
        {
            this.DtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("codigo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("stock", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("precio", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("importe", System.Type.GetType("System.Decimal"));

            DgvDetalle.DataSource = this.DtDetalle;

            DgvDetalle.Columns[0].Visible = false;
            DgvDetalle.Columns[1].HeaderText = "CODIGO";
            DgvDetalle.Columns[1].Width = 100;
            DgvDetalle.Columns[2].HeaderText = "ARTICULO";
            DgvDetalle.Columns[2].Width = 200;
            DgvDetalle.Columns[3].HeaderText = "STOCK";
            DgvDetalle.Columns[3].Width = 50;
            DgvDetalle.Columns[4].HeaderText = "CANTIDAD";
            DgvDetalle.Columns[4].Width = 50;
            DgvDetalle.Columns[5].HeaderText = "PRECIO";
            DgvDetalle.Columns[5].Width = 70;
            DgvDetalle.Columns[6].HeaderText = "DESCUENTO";
            DgvDetalle.Columns[6].Width = 70;
            DgvDetalle.Columns[7].HeaderText = "IMPORTE";
            DgvDetalle.Columns[7].Width = 80;

            DgvDetalle.Columns[1].ReadOnly = true;
            DgvDetalle.Columns[2].ReadOnly = true;
            DgvDetalle.Columns[3].ReadOnly = true;
            DgvDetalle.Columns[7].ReadOnly = true;
        }
        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CrearTabla();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVista_ClienteVenta vista = new FrmVista_ClienteVenta();
            vista.ShowDialog();
            TxtIdCliente.Text = Convert.ToString(Variables.IdCliente);
            TxtNombreCliente.Text = Variables.NombreCliente;
        }

        private void TxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataTable Tabla = new DataTable();
                    Tabla = NArticulo.BuscarCodigoVenta(TxtCodigo.Text.Trim());
                    if (Tabla.Rows.Count <= 0)
                    {
                        this.MensajeError("No existe artículo con ese código de barras o no hay stock de ese artículo.");
                    }
                    else
                    {
                        this.AgregarDetalle(Convert.ToInt32(Tabla.Rows[0][0]), Convert.ToString(Tabla.Rows[0][1]), Convert.ToString(Tabla.Rows[0][2]), Convert.ToInt32(Tabla.Rows[0][4]), Convert.ToDecimal(Tabla.Rows[0][3]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AgregarDetalle(int IdArticulo, string Codigo, string Nombre,int Stock, decimal Precio)
        {
            bool Agregar = true;
            foreach (DataRow FilaTemp in DtDetalle.Rows)
            {
                if (Convert.ToInt32(FilaTemp["idarticulo"]) == IdArticulo)
                {
                    Agregar = false;
                    this.MensajeError("El artículo ya ha sido agregado.");
                }
            }

            if (Agregar)
            {
                DataRow Fila = DtDetalle.NewRow();
                Fila["idarticulo"] = IdArticulo;
                Fila["codigo"] = Codigo;
                Fila["articulo"] = Nombre;
                Fila["stock"] = Stock;
                Fila["cantidad"] = 1;
                Fila["precio"] = Precio;
                Fila["descuento"] = 0;
                Fila["importe"] = Precio;
                this.DtDetalle.Rows.Add(Fila);
                this.CalcularTotales();
            }
        }
        private void CalcularTotales()
        {
            decimal Total = 0;
            decimal SubTotal = 0;
            if (DgvDetalle.Rows.Count == 0)
            {
                Total = 0;
            }
            else
            {
                foreach (DataRow FilaTemp in DtDetalle.Rows)
                {
                    Total = Total + Convert.ToDecimal(FilaTemp["importe"]);
                }
            }

            SubTotal = Total / (1 + Convert.ToDecimal(TxtImpuesto.Text));
            TxtTotal.Text = Total.ToString("#0.00#");
            TxtSubTotal.Text = SubTotal.ToString("#0.00#");
            TxtTotalImpuesto.Text = (Total - SubTotal).ToString("#0.00#");
        }

        private void BtnVerArticulos_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = true;
        }

        private void BtnCerrarArticulos_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = false;
        }

        private void FormatoArticulos()
        {
            DgvArticulos.Columns[1].Visible = false;
            DgvArticulos.Columns[2].Width = 100;
            DgvArticulos.Columns[2].HeaderText = "Categoría";
            DgvArticulos.Columns[3].Width = 100;
            DgvArticulos.Columns[3].HeaderText = "Código";
            DgvArticulos.Columns[4].Width = 150;
            DgvArticulos.Columns[5].Width = 100;
            DgvArticulos.Columns[5].HeaderText = "Precio Venta";
            DgvArticulos.Columns[6].Width = 60;
            DgvArticulos.Columns[7].Width = 200;
            DgvArticulos.Columns[7].HeaderText = "Descripción";
            DgvArticulos.Columns[8].Width = 100;
        }
        private void BtnFiltrarArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                DgvArticulos.DataSource = NArticulo.Buscar(TxtBuscarArticulo.Text.Trim());
                this.FormatoArticulos();
                LblTotalArticulos.Text = "Total Registros: " + Convert.ToString(DgvArticulos.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdArticulo;
            string Codigo, Nombre;
            decimal Precio;
            int Stock;
            IdArticulo = Convert.ToInt32(DgvArticulos.CurrentRow.Cells["ID"].Value);
            Codigo = Convert.ToString(DgvArticulos.CurrentRow.Cells["Codigo"].Value);
            Nombre = Convert.ToString(DgvArticulos.CurrentRow.Cells["Nombre"].Value);
            Stock = Convert.ToInt32(DgvArticulos.CurrentRow.Cells["Stock"].Value);
            Precio = Convert.ToDecimal(DgvArticulos.CurrentRow.Cells["Precio_Venta"].Value);
            this.AgregarDetalle(IdArticulo, Codigo, Nombre,Stock, Precio);
        }

        private void DgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRow Fila = (DataRow)DtDetalle.Rows[e.RowIndex];
            string Articulo = Convert.ToString(Fila["articulo"]);
            int Cantidad = Convert.ToInt32(Fila["cantidad"]);
            int Stock = Convert.ToInt32(Fila["stock"]);
            decimal Precio = Convert.ToDecimal(Fila["precio"]);
            decimal Descuento = Convert.ToDecimal(Fila["descuento"]);
            if (Cantidad>Stock)
            {
                Cantidad = Stock;
                this.MensajeError("La cantidad de venta del artículo " + Articulo + " supera el stock diponible " + Stock);
                Fila["cantidad"] = Cantidad;
            }
            Fila["importe"] = (Precio * Cantidad) - Descuento;
            this.CalcularTotales();
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtIdCliente.Text == string.Empty || TxtImpuesto.Text == string.Empty || TxtNumComprobante.Text == string.Empty || DtDetalle.Rows.Count == 0)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(TxtIdCliente, "Seleccione un cliente.");
                    ErrorIcono.SetError(TxtImpuesto, "Ingrese un impuesto.");
                    ErrorIcono.SetError(TxtNumComprobante, "Ingrese el número del comprobante.");
                    ErrorIcono.SetError(DgvDetalle, "Debe tener al menos un detalle.");
                }
                else
                {
                    Rpta = NVenta.Insertar(Convert.ToInt32(TxtIdCliente.Text), Variables.IdUsuario, CboComprobante.Text, TxtSerieComprobante.Text.Trim(), TxtNumComprobante.Text.Trim(), Convert.ToDecimal(TxtImpuesto.Text), Convert.ToDecimal(TxtTotal.Text), DtDetalle);
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó de forma correcta el registro");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0;
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DgvMostrarDetalle.DataSource = NVenta.ListarDetalle(Convert.ToInt32(DgvListado.CurrentRow.Cells["ID"].Value));
                decimal Total, SubTotal;
                decimal Impuesto = Convert.ToDecimal(DgvListado.CurrentRow.Cells["Impuesto"].Value);
                Total = Convert.ToDecimal(DgvListado.CurrentRow.Cells["Total"].Value);
                SubTotal = Total / (1 + Impuesto);
                TxtSubtotalD.Text = SubTotal.ToString("#0.00#");
                TxtTotalImpuestoD.Text = (Total - SubTotal).ToString("#0.00#");
                TxtTotalD.Text = Total.ToString("#0.00#");
                PanelMostrar.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCerrarDetalle_Click(object sender, EventArgs e)
        {
            PanelMostrar.Visible = false;
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccionar.Checked)
            {
                DgvListado.Columns[0].Visible = true;
                BtnAnular.Visible = true;
            }
            else
            {
                DgvListado.Columns[0].Visible = false;
                BtnAnular.Visible = false;
            }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas anular el(los) registro(s)?", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NVenta.Anular(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se anuló el registro: " + Convert.ToString(row.Cells[6].Value) + "-" + Convert.ToString(row.Cells[7].Value));
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnComprobante_Click(object sender, EventArgs e)
        {
            try
            {
                Variables.IdVenta = Convert.ToInt32(DgvListado.CurrentRow.Cells["ID"].Value);
                Reportes.FrmReporteComprobanteVenta reporte = new Reportes.FrmReporteComprobanteVenta();
                reporte.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
