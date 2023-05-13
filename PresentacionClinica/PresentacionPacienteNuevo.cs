using DatosClinica;
using NegocioClinica;
using System;
using System.Windows.Forms;

namespace PresentacionClinica
{
    public partial class PresentacionPaciente : Form
    {
        NegocioPaciente Paciente = new NegocioPaciente();
        NegocioAlergias alergia = new NegocioAlergias();
        Paciente pc = new Paciente();
        Alergias al = new Alergias();
        public PresentacionPaciente()
        {
            InitializeComponent();
            mtxtDoc.Enabled = false;
            txtFechaIngreso.Enabled = false;
            txtId.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            cmbDocumento.Enabled = false;
            txtDireccion.Enabled = false;
            mtxtTelefono.Enabled = false;
            mtxtTelefono2.Enabled = false;
            mtxtCorreo.Enabled = false;
            txtAlergias.Enabled = false;
            txtEnfermedades.Enabled = false;
            btnHistoria.Enabled = false;
            btnPaciente.Enabled = false;
            btnAlergias.Enabled = false;
            btnEnfermedades.Enabled = false;
            txtNombre.Text = "";

            //dgBuscar.DataSource = Paciente.verPacientes();

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumento.SelectedIndex == 0)
            {
                mtxtDoc.Enabled = true;
                mtxtDoc.Mask = "0000000000";
                mtxtDoc.Width = 110;
            }
            if (cmbDocumento.SelectedIndex == 1)
            {
                mtxtDoc.Enabled = true;
                mtxtDoc.Mask = "0000000000000";
                mtxtDoc.Width = 140;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtApellido.Text = "";
            mtxtDoc.Text = "";
            txtDireccion.Text = "";
            mtxtTelefono.Text = "";
            mtxtTelefono2.Text = "";
            mtxtCorreo.Text = "";
            txtFechaIngreso.Text = DateTime.Now.ToString("d");
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            cmbDocumento.Enabled = true;
            txtDireccion.Enabled = true;
            mtxtTelefono.Enabled = true;
            mtxtTelefono2.Enabled = true;
            mtxtCorreo.Enabled = true;
            btnPaciente.Enabled = true;
        }
        private void PresentacionPacienteNuevo_Load(object sender, EventArgs e)
        {
        }
        private void btnPaciente_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtApellido.Text != "" && mtxtDoc.Text != "" && txtDireccion.Text != "" && mtxtTelefono.Text != "" && mtxtTelefono2.Text != "" && mtxtCorreo.Text != "")
            {
                pc.FechaIngreso = Convert.ToDateTime(txtFechaIngreso.Text);
                pc.Nombre = txtNombre.Text;
                pc.Apellido = txtApellido.Text;
                pc.Direccion = txtDireccion.Text;
                pc.Cedula = Convert.ToInt32(mtxtDoc.Text);
                pc.Telefono1 = Convert.ToInt32(mtxtTelefono.Text);
                pc.Telefono2 = Convert.ToInt32(mtxtTelefono2.Text);
                pc.Correo = mtxtCorreo.Text;
                txtAlergias.Enabled = true;
                txtEnfermedades.Enabled = true;
                btnEnfermedades.Enabled = true;
                btnAlergias.Enabled = true;
                Paciente.Insertar(pc);
                mtxtDoc.Enabled = false;
                txtFechaIngreso.Enabled = false;
                txtId.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                cmbDocumento.Enabled = false;
                txtDireccion.Enabled = false;
                mtxtTelefono.Enabled = false;
                mtxtTelefono2.Enabled = false;
                mtxtCorreo.Enabled = false;
                btnHistoria.Enabled = true;
            }
            else
            {
                MessageBox.Show("HAY CAMPOS VACIOS");
            }
        }
        private void btnHistoria_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtApellido.Text = "";
            mtxtDoc.Text = "";
            txtDireccion.Text = "";
            mtxtTelefono.Text = "";
            mtxtTelefono2.Text = "";
            mtxtCorreo.Text = "";
        }
        private void btnAlergias_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            int ID = Paciente.IdDePaciente(Nombre, Apellido);
            al.IdPaciente = ID;
            al.Alergia = txtAlergias.Text;
            alergia.AgregarAlergias(al);
            lbAlergias.Items.Add(txtAlergias.Text);
            txtAlergias.Text = "";
        }
        private void btnEnfermedades_Click(object sender, EventArgs e)
        {
            lbEnfermedades.Items.Add(txtEnfermedades.Text);
            txtEnfermedades.Text = "";
        }
        private void dgBuscar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgBuscar.DataSource = Paciente.BuscarPacientes(txtBuscar.Text);

                foreach (DataGridViewColumn col in dgBuscar.Columns)
                {
                    if (col.DataPropertyName != "Nombre" && col.DataPropertyName != "Apellido" && col.DataPropertyName != "Cedula")
                    {
                        col.Visible = false;
                    }
                    else
                    {
                        col.Visible = true;
                    }
                }

            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgBuscar.DataSource = Paciente.BuscarPacientes(txtBuscar.Text);

             foreach (DataGridViewColumn col in dgBuscar.Columns)
 {
     if (col.DataPropertyName != "Nombre" && col.DataPropertyName!="Apellido" && col.DataPropertyName != "Cedula")
     {
         col.Visible = false;
     }
     else
     {
         col.Visible = true;
     }
 }
        }

        private void dgBuscar_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgBuscar.Rows.Count) // Verifica que se haya hecho clic en una fila válida
            {
                DataGridViewRow row = dgBuscar.Rows[e.RowIndex];
                // Carga los datos de la fila en el TextBox
                int Id = (int)row.Cells[0].Value;
                lblId.Text = Convert.ToString(Id);
                Paciente Pac= Paciente.CargarPaciente(Id);
                txtNombreB.Text=Pac.Nombre;
                txtApellidoB.Text = Pac.Apellido;
                mtxtDocB.Text = Convert.ToString(Pac.Cedula);
                txtDireccionB.Text = Convert.ToString(Pac.Direccion);
                mtxtTelefono1B.Text = Convert.ToString(Pac.Telefono1);
                mtxtTelefono2B.Text = Convert.ToString(Pac.Telefono2);
                txtCorreoB.Text = Pac.Correo;


                


            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            pc.IdPaciente = Convert.ToInt32(lblId.Text);
            pc.Nombre = txtNombreB.Text;
            pc.Apellido = txtApellidoB.Text;
            pc.Cedula = Convert.ToInt32(mtxtDocB.Text);
            pc.Direccion = txtDireccionB.Text;
            pc.Telefono1 = Convert.ToInt32(mtxtTelefono1B.Text);
            pc.Telefono2 = Convert.ToInt32(mtxtTelefono2B.Text);
            pc.Correo = txtCorreoB.Text;
            Paciente.Actualizarpaciente(pc);
            MessageBox.Show("Datos Actualizados");
            txtNombreB.Text = "";
            txtApellidoB.Text = "";
            mtxtDocB.Text = "";
            txtDireccionB.Text = "";
            mtxtTelefono1B.Text = "";
            mtxtTelefono2B.Text = "";
            txtCorreoB.Text = "";
        }
    }
}