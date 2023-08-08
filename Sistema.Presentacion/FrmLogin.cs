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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla = NUsuario.Login(TxtEmail.Text.Trim(),TxtClave.Text.Trim());
                if (Tabla.Rows.Count<=0)
                {
                    MessageBox.Show("El email o la clave es incorrecta.","Acceso al Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    if (Convert.ToBoolean(Tabla.Rows[0][4])==false)
                    {
                        MessageBox.Show("Este usuario no esta activo.", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        FrmPrincipal Frm = new FrmPrincipal();
                        Variables.IdUsuario= Convert.ToInt32(Tabla.Rows[0][0]);
                        Frm.IdUsuario = Convert.ToInt32(Tabla.Rows[0][0]);
                        Frm.IdRol = Convert.ToInt32(Tabla.Rows[0][1]);
                        Frm.Rol = Convert.ToString(Tabla.Rows[0][2]);
                        Frm.Nombre = Convert.ToString(Tabla.Rows[0][3]);
                        Frm.Estado = Convert.ToBoolean(Tabla.Rows[0][4]);
                        Frm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
