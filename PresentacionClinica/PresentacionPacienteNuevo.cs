using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NegocioClinica;
using DatosClinica;

namespace PresentacionClinica
{
    public partial class PresentacionPacienteNuevo : Form
    {
        NegocioPaciente Paciente = new NegocioPaciente();
        NegocioAlergias alergia = new NegocioAlergias();
        Paciente pc = new Paciente();
        Alergias al = new Alergias();
        public PresentacionPacienteNuevo()
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
            dgBuscar.DataSource = 
                Paciente.verPacientes();
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumento.SelectedIndex==0)
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
            if (txtNombre.Text != ""&&txtApellido.Text != ""&&txtApellido.Text != ""&& mtxtDoc.Text != ""&& txtDireccion.Text != "" && mtxtTelefono.Text != ""&&mtxtTelefono2.Text != ""&&mtxtCorreo.Text != "")
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
    }
}
