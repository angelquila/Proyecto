using System;

namespace Proyecto.Web.Views.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ctrl + K + c es igual para comentar
            //if (!IsPostBack)
            //    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Buen Trabajo!', 'Se realiso el proeceso con exito', 'success') </script>");

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtEmail.Text)) stMensaje += "Ingrese correo," ;
                if (string.IsNullOrEmpty(txtPassword.Text)) stMensaje += "Ingrese Contraseña,";

                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(',')); //aca forzamos la excepcion

                // defino los objetos con las propiedades -a
                Logica.Models.clsUsuarios obclsUsuarios = new Logica.Models.clsUsuarios
                {
                    stLogin = txtEmail.Text,
                    stPassword = txtPassword.Text
                };

                // intanciamos los controlodares
                Controllers.LoginController obloginController = new Controllers.LoginController();
                bool blBandera = obloginController.getValidarUsuariosControlller(obclsUsuarios); // aca le insertamos el objeto -a

                if(blBandera)
                {
                    Response.Redirect("../Index/Index.aspx"); // si es tru la bandera redireccionamos a  la pagina de inicio (index)
                }
                else
                {
                    throw new Exception("Usuario o clave incorretos");
                }
                    
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error!', '"+ ex.Message +"!', 'error') </script>");
            }
            

        }
    }
}