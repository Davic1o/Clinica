using System;
using System.Windows.Forms;
using NegocioClinica;
using DatosClinica;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PresentacionClinica
{
    public partial class PresentacionHistorial : Form
    {
        NegocioPaciente Paciente = new NegocioPaciente();
        NegocioAlergias alerg = new NegocioAlergias();
        NegocioEnfermedad enf = new NegocioEnfermedad();
        int Dato = 0;
        public PresentacionHistorial()
        {
            InitializeComponent();
            txtAlergias.Enabled = false;
            txtEnfermedades.Enabled = false;
            btnHistoria.Enabled = false;
            btnAlergias.Enabled = false;
            btnEnfermedades.Enabled = false;
            lblUsuario.Text = "SIN USUARIO";
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgBuscar.DataSource = Paciente.BuscarPacientes(txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgBuscar.DataSource = Paciente.BuscarPacientes(txtBuscar.Text);
            }
        }

        private void dgBuscar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgBuscar.Rows.Count) // Verifica que se haya hecho clic en una fila válida
            {
                DataGridViewRow row = dgBuscar.Rows[e.RowIndex];
                // Carga los datos de la fila en el TextBox
                int Id = (int)row.Cells[0].Value;
                Dato = Id;
                Paciente Pac = Paciente.CargarPaciente(Id);
                string Nombre = Pac.Nombre;
                string Apellido = Pac.Apellido;
                lblUsuario.Text = Nombre + " " + Apellido;
                txtAlergias.Enabled = true;
                txtEnfermedades.Enabled = true;
                btnHistoria.Enabled = true;
                btnAlergias.Enabled = true;
                btnEnfermedades.Enabled = true;
                lbAlergias.DataSource = alerg.listarAlergias(Dato);
                lbAlergias.DisplayMember = "Alergia";
                lbEnfermedades.DataSource = enf.ListarEnferemdades(Dato);
                lbEnfermedades.DisplayMember = "Enfermedad";
                  byte[] image =Paciente.CargarFotoPaciente(Id);
                if (image.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(image))
                {
                    Image images = Image.FromStream(ms);
                    pbFotoPerfil.Image = images;
                }
                }
                else
                {
                    pbFotoPerfil.Image = null;
                }
            }
            }

        private void btnAlergias_Click_1(object sender, EventArgs e)
        {

            if (txtAlergias.Text != "")
            {
            Alergias alergias = new Alergias();
            alergias.IdPaciente = Dato;
            alergias.Alergia= txtAlergias.Text;
            txtAlergias.Text = "";
            alerg.AgregarAlergias(alergias);
            lbAlergias.DataSource = alerg.listarAlergias(Dato);
            lbAlergias.Refresh();
            }
            else
            {
                MessageBox.Show("No has agregado Alergia");
            }

        }

        private void btnEnfermedades_Click_1(object sender, EventArgs e)
        {
            if (txtEnfermedades.Text != "")
            {
                Enfermedades enfermedades = new Enfermedades();
                enfermedades.IdPaciente = Dato;
                enfermedades.Enfermedad = txtEnfermedades.Text;
                txtEnfermedades.Text = "";
                enf.AgregarEnferemdad(enfermedades);
                lbEnfermedades.DataSource = enf.ListarEnferemdades(Dato);
                lbEnfermedades.Refresh();
            }
            else
            {
                MessageBox.Show("No has agregado Enfermedad");
            }
        }

        private void pbFotoPerfil_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, pbFotoPerfil.Width - 1, pbFotoPerfil.Height - 1);
                pbFotoPerfil.Region = new Region(path);
            }
        }

        private void btnHistoria_Click_1(object sender, EventArgs e)
        {

        }
    }
}
