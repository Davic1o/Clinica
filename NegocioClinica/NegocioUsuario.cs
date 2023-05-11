using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosClinica;

namespace NegocioClinica
{
    public class NegocioUsuario
    {
    DatosUsuario usuario = new DatosUsuario();

        public bool ValidarLogin(string Nombre,string Clave)
        {
            bool r= usuario.ValidacionContrasenia(Nombre, Clave);
            return r;      
        }

        public string NombredeUsuario(string u)
        {
            return usuario.ConsultarUsuario(u).Nombre;
        }
    }
}
