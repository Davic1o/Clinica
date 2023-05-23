using DatosClinica;
using NegocioClinica;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace PresentacionClinica
{
    public partial class PresentacionPaciente : Form
    {
        NegocioPaciente Paciente = new NegocioPaciente();
        Paciente pc = new Paciente();
        string imagePath;
        byte[] imageData;
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
            btnPaciente.Enabled = false;
            txtIdact.Enabled = false; 
            cmbGenero.Enabled = false;
            dTNacimiento.Enabled = false;
            btnCargar.Enabled = false;
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
            cmbGenero.Enabled = true;
            dTNacimiento.Enabled = true;
            btnCargar.Enabled = true;
        }
        private void PresentacionPacienteNuevo_Load(object sender, EventArgs e)
        {
        }
        private void btnPaciente_Click(object sender, EventArgs e)
        {
            if (imagePath != null)
            {
                imageData = File.ReadAllBytes(imagePath);
            }
            else
            {
                imageData = null;
            }
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtApellido.Text != "" && mtxtDoc.Text != "" && txtDireccion.Text != "" && mtxtTelefono.Text != "" && mtxtTelefono2.Text != "" && mtxtCorreo.Text != "")
            {
         
                pc.FechaIngreso = Convert.ToDateTime(txtFechaIngreso.Text);
                pc.Nombre = txtNombre.Text;
                pc.Apellido = txtApellido.Text;
                pc.Direccion = txtDireccion.Text;
                pc.Genero = cmbGenero.SelectedItem.ToString();
                pc.Cedula = Convert.ToInt32(mtxtDoc.Text);
                pc.Telefono1 = Convert.ToInt32(mtxtTelefono.Text);
                pc.Telefono2 = Convert.ToInt32(mtxtTelefono2.Text);
                pc.Correo = mtxtCorreo.Text;
                pc.FechaDeNacimiento = dTNacimiento.Value;
                pc.FotoDePerfil = imageData;
                if (cmbGenero.SelectedIndex == 0)
                {
                    pc.Genero = "Masculino";
                }
                else
                {
                    pc.Genero = "Femenino";
                }
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
             
                tcPaciente.SelectTab(1);

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
                txtIdact.Text = Convert.ToString(Id);
                Paciente Pac= Paciente.CargarPaciente(Id);
                txtNombreB.Text=Pac.Nombre;
                txtApellidoB.Text = Pac.Apellido;
                if (Pac.Genero == "Masculino")
                {
                    cmbGeneroA.SelectedIndex = 0;
                    }
                else
                {
                    cmbGeneroA.SelectedIndex = 1;
                }
                dtNacimiento2.Value = (DateTime)Pac.FechaDeNacimiento;
                mtxtDocB.Text = Convert.ToString(Pac.Cedula);
                txtDireccionB.Text = Convert.ToString(Pac.Direccion);
                mtxtTelefono1B.Text = Convert.ToString(Pac.Telefono1);
                mtxtTelefono2B.Text = Convert.ToString(Pac.Telefono2);
                txtCorreoB.Text = Pac.Correo;
                byte[] image =Paciente.CargarFotoPaciente(Id);
                if (image.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(image))
                    {
                        Image images = Image.FromStream(ms);
                        pbFotoperfil2.Image = images;
                    }
                }
                else
                {
                    pbFotoperfil2.Image = null;
                }
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {

            if (imagePath != null)
            {
                imageData = File.ReadAllBytes(imagePath);
            }
            else
            {
                imageData = null;
            }
            pc.IdPaciente = Convert.ToInt32(txtIdact.Text);
            pc.Nombre = txtNombreB.Text;
            pc.Apellido = txtApellidoB.Text;
            pc.Cedula = Convert.ToInt32(mtxtDocB.Text);
            pc.Direccion = txtDireccionB.Text;
            pc.FechaDeNacimiento = dtNacimiento2.Value;
            pc.Telefono1 = Convert.ToInt32(mtxtTelefono1B.Text);
            pc.Telefono2 = Convert.ToInt32(mtxtTelefono2B.Text);
            pc.Correo = txtCorreoB.Text;
            pc.Genero = cmbGeneroA.Text;
            pc.FotoDePerfil = imageData;
            
            Paciente.ActualizarPaciente(pc);
            MessageBox.Show("Datos Actualizados");
            txtNombreB.Text = "";
            txtApellidoB.Text = "";
            mtxtDocB.Text = "";
            txtDireccionB.Text = "";
            mtxtTelefono1B.Text = "";
            mtxtTelefono2B.Text = "";
            txtCorreoB.Text = "";
            cmbGeneroA.Text = "";
            pbFotoperfil2.Image = null;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                imagePath = openfile.FileName;
                pictureBox1.ImageLocation = imagePath;
            }
        }

        private void pbFotoperfil2_Paint(object sender, PaintEventArgs e)
        {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, pbFotoperfil2.Width - 1, pbFotoperfil2.Height - 1);
                    pbFotoperfil2.Region = new Region(path);
                }
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                    pictureBox1.Region = new Region(path);
                }
        }

        private void btnFoto2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                imagePath = openfile.FileName;
                pbFotoperfil2.ImageLocation = imagePath;
            }
        }
    }
}