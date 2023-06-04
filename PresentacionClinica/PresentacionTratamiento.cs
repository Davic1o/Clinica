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
    public partial class PresentacionTratamiento : Form
    {
        NegocioPaciente Paciente = new NegocioPaciente();
        public PresentacionTratamiento()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgBuscar.DataSource = Paciente.BuscarPacientes(txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void chk18_CheckedChanged(object sender, EventArgs e)
        {
                string text = "Pieza Nro 18";
            if (chk18.Checked)
            {
                lbdient1.Items.Add(text);
            } else if (lbdient1.Items.Contains(text))
                {
                    lbdient1.Items.Remove(text);
                }

            }

        private void chk17_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
