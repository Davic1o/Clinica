using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PresentacionClinica
{
    public partial class PresentacionPaciente : Form
    {
        public PresentacionPaciente()
        {
            InitializeComponent();
            lbl001.Text = "";
            mtxtCedula.Enabled = false;
            txtFechaIngreso.Text = DateTime.Now.ToString("d");
            txtFechaIngreso.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumento.SelectedIndex==0)
            {
                mtxtCedula.Enabled = true;
            }
            if (cmbDocumento.SelectedIndex == 1)
            {
                mtxtCedula.Enabled = true;
                lbl001.Text = "001";
            }
           
        }

        private void PresentacionPaciente_Load(object sender, EventArgs e)
        {

        }
    }
}
