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

namespace _01_Mi_Primera_Vez.Presentacion
{
    public partial class CUUsuarios : UserControl
    {
        public CUUsuarios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuarios.FrmUsuarios user = new Usuarios.FrmUsuarios(true);
            user.ShowDialog(); CargarUsuarios();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que se haya seleccionado una fila válida
            {
                int idUsuario = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells[0].Value); // Supongamos que el ID está en la primera columna

                cls_usuarios clsUsuarios = new cls_usuarios();
                dto_usuarios usuarioSeleccionado = clsUsuarios.ObtenerUsuarioPorId(idUsuario);

                if (usuarioSeleccionado != null)
                {
                    // Abre el formulario en modo "Editar" (con el parámetro false) y pasa el dto_usuarios
                    Usuarios.FrmUsuarios user = new Usuarios.FrmUsuarios(false, usuarioSeleccionado);
                    user.ShowDialog(); CargarUsuarios();
                }
            }
        }
        private void CargarUsuarios()
        {
            try
            {
                cls_usuarios clsUsuarios = new cls_usuarios();
                List<dto_usuarios> listaUsuarios = clsUsuarios.ObtenerUsuarios();
                dgvDatos.DataSource = listaUsuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CUUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
    }
}
