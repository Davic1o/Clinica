using System;
using System.Windows.Forms;
using NegocioClinica;
using DatosClinica;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;


namespace PresentacionClinica
{
    public partial class PresentacionRecetario : Form
    {
        NegocioPaciente Paciente = new NegocioPaciente();
       
        public PresentacionRecetario()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
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

        private void dgBuscar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgBuscar.Rows.Count) // Verifica que se haya hecho clic en una fila válida
            {
                DataGridViewRow row = dgBuscar.Rows[e.RowIndex];
                // Carga los datos de la fila en el TextBox
                int Id = (int)row.Cells[0].Value;
                Paciente Pac = Paciente.CargarPaciente(Id);
                string Nombre = Pac.Nombre;
                string Apellido = Pac.Apellido;
                lblNombre.Text = Nombre + " " + Apellido;
                lblEdad.Text = Paciente.EdadPaciente(Id).ToString()+" años";
                byte[] image = Paciente.CargarFotoPaciente(Id);
                if (image.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(image))
                    {
                        System.Drawing.Image images = System.Drawing.Image.FromStream(ms);
                        pbFotoperfil.Image = images;
                    }
                }
                else
                {
                    pbFotoperfil.Image = null;
                }
            }
        }

        private void pbFotoperfil_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, pbFotoperfil.Width - 1, pbFotoperfil.Height - 1);
                pbFotoperfil.Region = new Region(path);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
