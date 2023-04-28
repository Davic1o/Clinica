using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatosClinica
{
    public class DatosUsuario
    {
        DataClasses1DataContext Db = new DataClasses1DataContext();
        bool R = false;

        public bool ValidacionContrasenia(string Usuario, string Clave)
        {
            try
            {
                Usuario user = Db.Usuario.Single(r => r.UserName == Usuario && r.Clave == Clave);
                if (user.UserName == Usuario && user.Clave == Clave)
                {
                    R = true;

                }

            }
            catch (Exception)
            {

                R = false;
            }
            return R;
        }
        public Usuario ConsultarUsuario(string Usuario)
        {
            Usuario user = Db.Usuario.Single(r => r.UserName == Usuario);
            return user;
        }

        
    }
}
