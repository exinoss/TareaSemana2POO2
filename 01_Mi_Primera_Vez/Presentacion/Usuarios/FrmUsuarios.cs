using _01_Mi_Primera_Vez.Datos;
using _01_Mi_Primera_Vez.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion.Usuarios
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios(bool valor)
        {
            InitializeComponent(); CargarPaises();
            if (valor) { btnEditar.Enabled = false; }
            else
            {
                btnEditar.Enabled = false;
            }
        }
        private void CargarPaises()
        {
            try
            {
                cls_pais clsPais = new cls_pais();
                List<dto_pais> listaPaises = clsPais.leer();

                cmbPaises.DataSource = listaPaises; // Asigna la lista al combo
                cmbPaises.DisplayMember = "Detalle"; // Campo a mostrar en el combo
                cmbPaises.ValueMember = "IdPais"; // Valor real asociado al ítem
                cmbPaises.SelectedIndex = -1; // Deja el combo sin selección inicial (opcional)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los países: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public FrmUsuarios(bool valor, dto_usuarios user)
        {
            InitializeComponent(); CargarPaises();
            if (valor) { btnEditar.Enabled = false; }
            else
            {
                btnEditar.Enabled = false;
               
                iduser = user.IdUsuario;
                txtCedula.Text = user.Cedula;
                txtNombres.Text = user.NombresApellidos;
                txtDireccion.Text = user.Direccion;
                chkActivo.Checked = user.Activo;
                cmbCiudad.Text = user.Ciudad;
                cmbPaises.SelectedValue = user.IdPais; 
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                cls_usuarios clsUsuarios = new cls_usuarios();
                dto_usuarios nuevoUsuario = new dto_usuarios
                {
                    Cedula = txtCedula.Text,
                    NombresApellidos = txtNombres.Text,
                    Direccion = txtDireccion.Text,
                    Activo = chkActivo.Checked,
                    Ciudad = cmbCiudad.Text,
                    IdPais = Convert.ToInt32(cmbPaises.SelectedValue)
                };

                clsUsuarios.InsertarUsuario(nuevoUsuario);
                MessageBox.Show("Usuario guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int iduser;
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                cls_usuarios clsUsuarios = new cls_usuarios();
                dto_usuarios usuarioEditado = new dto_usuarios
                {
                    IdUsuario = iduser, 
                    Cedula = txtCedula.Text,
                    NombresApellidos = txtNombres.Text,
                    Direccion = txtDireccion.Text,
                    Activo = chkActivo.Checked,
                    Ciudad = cmbCiudad.Text,
                    IdPais = Convert.ToInt32(cmbPaises.SelectedValue)
                };

                clsUsuarios.ActualizarUsuario(usuarioEditado);
                MessageBox.Show("Usuario actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
