using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Web.Views.Registrar
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
           
            try
            {
                string stMensaje = string.Empty;

                if (string.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre,";
                if (string.IsNullOrEmpty(txtApellido.Text)) stMensaje += "Ingrese Apellido,";
                if (string.IsNullOrEmpty(txtCorreo.Text)) stMensaje += "Ingrese Correo,";
                if (string.IsNullOrEmpty(txtPassword.Text)) stMensaje += "Ingrese la Clave,";
                if (string.IsNullOrEmpty(txtPasswordConfir.Text)) stMensaje += "Ingrese la confirmacion de clave,";

                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(',')); 

            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error!', '" + ex.Message + "!', 'error') </script>");
            }


        }
    }
}