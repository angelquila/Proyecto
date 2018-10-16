using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Web.Controllers
{
    public class LoginController
    {

        public bool getValidarUsuariosControlller(Logica.Models.clsUsuarios obclsUsuarios)
        {
            try
            {
                Logica.BL.clsUsuarios obclsUsuario = new Logica.BL.clsUsuarios();
                return obclsUsuario.getValidarUsuario(obclsUsuarios);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}