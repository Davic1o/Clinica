using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosClinica
{
    public class DatosAlergias
    {
        DataClasses1DataContext Db = new DataClasses1DataContext();
        public void AgregarAlergias(Alergias al)
        {
            Db.Alergias.InsertOnSubmit(al);
            Db.SubmitChanges();
        }
    }
}
