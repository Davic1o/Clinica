using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosClinica;

namespace NegocioClinica
{
    public class NegocioEnfermedad
    {
        DatosEnfermedad enfer = new DatosEnfermedad();
        public void AgregarEnferemdad(Enfermedades enf)
        {
            enfer.AgregarEnfermedad(enf);
        }
        public List<Enfermedades> ListarEnferemdades(int ID)
        {
            return enfer.ListarEnfermedades(ID);
        }
    }
}
