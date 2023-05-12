using System;
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


    }
}
