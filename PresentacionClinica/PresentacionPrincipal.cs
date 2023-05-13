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

namespace PresentacionClinica
{
    public partial class PresentacionPrincipal : Form
    {
        PresentacionLogin frLogin = new PresentacionLogin();
        mtxtCorreoB PA = new mtxtCorreoB();
        public PresentacionPrincipal(string Username)
        {
            InitializeComponent();
            NegocioUsuario Nuser = new NegocioUsuario();
            string Nombre=Nuser.NombredeUsuario(Username);
            lblUsuer.Text = "Pagina Principal - Bienvenido " + Nombre;
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            
        }
        public PresentacionPrincipal()
        {
        }

        private void PresentacionPrincipal_Load(object sender, EventArgs e)
        {
         
        }

        private void lblUsuer_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();

            // Cerrar todos los formularios de la lista
            foreach (Form form in forms)
            {
                form.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnAdministracion_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
           
            
            frLogin.Show();
            this.Hide();
            
            
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            PA.TopLevel = false;
            pnlPadre.Controls.Add(PA);
            PA.Show(); 
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
