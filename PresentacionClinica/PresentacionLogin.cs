using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatosClinica;
using NegocioClinica;

namespace PresentacionClinica
{
    public partial class PresentacionLogin : Form
    {
        string Username;
        string Password;
        
        public PresentacionLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void PresentacionLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Username = txtUserName.Text;
            Password = txtPassword.Text;
            NegocioUsuario Nuser = new NegocioUsuario();
            
            if (Nuser.ValidarLogin(Username, Password))
            {
                PresentacionPrincipal Principal = new PresentacionPrincipal(Username);
                Principal.ShowDialog();
                this.Hide();

            }
            else
            {
                lblError.Text = "Usuario o clave Incorrecta";
                txtPassword.Text = "";
                txtUserName.Text = "";
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Username = txtUserName.Text;
                Password = txtPassword.Text;
                NegocioUsuario Nuser = new NegocioUsuario();

                if (Nuser.ValidarLogin(Username, Password))
                {

                    PresentacionPrincipal Principal = new PresentacionPrincipal(Username);
                    Principal.ShowDialog();
                    this.Hide();

                }
                else
                {
                    lblError.Text = "Usuario o clave Incorrecta";
                    txtPassword.Text = "";
                    txtUserName.Text = "";
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
