using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosClinica;

namespace NegocioClinica
{
    public class NegocioAlergias
    {
        DatosAlergias al = new DatosAlergias();

        public void AgregarAlergias(Alergias aler)
        {
            al.AgregarAlergias(aler);
        }
        public List<Alergias> listarAlergias(int ID)
        {
            return al.ListarAlergias(ID);
        }
    }
}
