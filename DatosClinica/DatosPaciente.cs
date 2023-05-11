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
        public Paciente VerPaciente()
        {
            Paciente paciente = Db.Paciente.Single();
            return paciente;
        }

        public void InsertarPaciente(Paciente pc)
        {
            Db.Paciente.InsertOnSubmit(pc);
            //Db.SubmitChanges();
        }
    }
}
