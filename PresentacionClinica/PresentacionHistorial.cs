﻿using System;
using System.Windows.Forms;
using NegocioClinica;
using DatosClinica;

namespace PresentacionClinica
{
    public partial class PresentacionHistorial : Form
    {
        NegocioPaciente Paciente = new NegocioPaciente();
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
                Paciente Pac = Paciente.CargarPaciente(Id);
                string Nombre = Pac.Nombre;
                string Apellido = Pac.Apellido;
                lblUsuario.Text = Nombre + " " + Apellido;
            }
            }

        private void btnHistoria_Click(object sender, EventArgs e)
        {

        }

        private void btnEnfermedades_Click(object sender, EventArgs e)
        {

        }

        private void btnAlergias_Click(object sender, EventArgs e)
        {

        }

        private void PresentacionTratamiento_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
