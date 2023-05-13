using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosClinica
{
    public class DatosPaciente
    {
        DataClasses1DataContext Db = new DataClasses1DataContext();
        public Paciente BuscarPaciente(string Nombre, string Apellido)
        {
            Paciente paciente = Db.Paciente.Single(r=>r.Nombre==Nombre && r.Apellido==Apellido);
            return paciente;
        }

        public void InsertarPaciente(Paciente pc)
        {
            Db.Paciente.InsertOnSubmit(pc);
            Db.SubmitChanges();
        }
        public List<Paciente> VerPacientes()
        {
             List <Paciente> Pac = (from x in Db.Paciente  select x).ToList();
           
            return Pac;
        }

        public List<Paciente> BuscarPacientesNombre(string Nombre)
        {
            List<Paciente> Pac = (from x in Db.Paciente where x.Nombre == Nombre || x.Apellido == Nombre select x).ToList();

            return Pac;
        }
        public Paciente CargarPaciente(int Id)
        {
            Paciente Pac = Db.Paciente.Single(r=>r.IdPaciente==Id);
            return Pac;
        }
    }
}
    