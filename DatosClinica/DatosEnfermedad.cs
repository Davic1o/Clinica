using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosClinica
{
    public class DatosEnfermedad
    {
        DataClasses1DataContext Db = new DataClasses1DataContext();
        public void AgregarEnfermedad(Enfermedades enf)
        {
            Db.Enfermedades.InsertOnSubmit(enf);
            Db.SubmitChanges();
        }

        public List<Enfermedades> ListarEnfermedades(int ID)
        {
            List<Enfermedades> lista = (from x in Db.Enfermedades where x.IdPaciente == ID select x).ToList();
            return lista;
        }
    }
}
