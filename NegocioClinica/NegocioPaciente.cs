﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosClinica;

namespace NegocioClinica
{
    
    public class NegocioPaciente
    {
        DatosPaciente Paciente = new DatosPaciente();
     public void Insertar(Paciente pc)
        {
            Paciente.InsertarPaciente(pc);

        }
     public int IdDePaciente(string Nombre, string Apellido)
        {
            return Paciente.BuscarPaciente(Nombre,Apellido).IdPaciente;
        }
     public List<Paciente> verPacientes()
        {
            
            return Paciente.VerPacientes();
        }
        public List<Paciente> BuscarPacientes(string Nombre)
        {

            return Paciente.BuscarPacientesNombre(Nombre);
        }
        public Paciente CargarPaciente(int Id)
        {
            return Paciente.CargarPaciente(Id);   
        }
        public byte[] CargarFotoPaciente(int Id)
        {
            return Paciente.CargarFotoPaciente(Id);
        }
        public void ActualizarPaciente(Paciente Pac)
        {
            Paciente.ActualizarPaciente(Pac);
        }
        public int EdadPaciente(int Id)
        {
            Paciente Pac= Paciente.CargarFechaPaciente(Id);
            DateTime Nacimiento = (DateTime)Pac.FechaDeNacimiento;
            DateTime Hoy = DateTime.Now;
            int Edad = Hoy.Year - Nacimiento.Year;
            return Edad;
        }

    }
}
