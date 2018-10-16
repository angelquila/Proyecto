using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Web.Views.PosiblesClientes
{
    public partial class PosiblesClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getClientesClientes();
            }

        }

        /// <summary>
        /// OBTIENE CONSULTA POSIBLES CLIENTES
        /// </summary>
        void getClientesClientes()
        {
            try
            {
                Controllers.PosiblesClientesController obPosiblesClientesController = new Controllers.PosiblesClientesController();
                DataSet dsConsulta = obPosiblesClientesController.getConsultarPosiblesClientesController();

                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    gvwDatos.DataSource = dsConsulta; //origen de datos es lo que quiere decir esto       
                }
                else
                {
                    gvwDatos.DataSource = null;
                }

                gvwDatos.DataBind();
            }
            catch (Exception ex)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error!', '" + ex.Message + "!', 'error') </script>");
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> alert( '" + ex.Message + "') </script>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtIndentificacion.Text)) stMensaje += "Ingrese Indentificacion";

                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(',')); //aca forzamos la excepcion

                Logica.Models.clsPosiblesClientes obclsPosiblesClientes = new Logica.Models.clsPosiblesClientes
                {
                    inIndentificacion = Convert.ToInt64(txtIndentificacion.Text),
                    stEmpresa = txtEmpresa.Text,
                    stPrimerNombre = txtPrimerNombre.Text,
                    stSegundoNombre = txtSegundoNombre.Text,
                    stPrimerApellido = txtPrimerApellido.Text,
                    stSegundoApellido = txtPrimerApellido.Text,
                    stTelefono = txtTelefono.Text,
                    stDireccion = txtDireccion.Text,
                    stCorreo = txtCorreo.Text
                };

                if (string.IsNullOrEmpty(lblOpcion.Text)) lblOpcion.Text = "1";

                Controllers.PosiblesClientesController obposiblesClientesController = new Controllers.PosiblesClientesController();
                
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> alert( '" + obposiblesClientesController.setAdministrarPosiblesClientes(obclsPosiblesClientes, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                lblOpcion.Text = txtIndentificacion.Text = txtEmpresa.Text = txtPrimerNombre.Text = txtSegundoNombre.Text = txtPrimerApellido.Text = txtSegundoApellido.Text = txtTelefono.Text = txtTelefono.Text = txtCorreo.Text = string.Empty;
                getClientesClientes();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> alert('" + ex.Message + "') </script>");
            }
        }

        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int inIndice = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName.Equals("Editar"))
                {
                    lblOpcion.Text = "2"; // esto es para editar la opcion en el procedimiento almacenado
                    //lo de aca es para tomar la linea de datos que esta en la lista de grid view 
                    txtIndentificacion.Text = ((Label)gvwDatos.Rows[inIndice].FindControl("lblIndentificacion")).Text; //esto es para aceder a un control web dentro de un grid

                    //txtCorreo.Text = gvwDatos.Rows[inIndice].Cells[8].Text; // asi  es valido pero se leanadio esto adicional para validr los que no retorne espacios en blanco ==: string.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[8].Text) ? string.Empty :

                    //txtEmpresa.Text = string.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[1].Text) ? string.Empty : gvwDatos.Rows[inIndice].Cells[1].Text; // aca es para tener acceso a un dato del grid de
                    //txtPrimerNombre.Text = string.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[2].Text) ? string.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    //txtSegundoNombre.Text = string.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[3].Text) ? string.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    //txtPrimerApellido.Text = string.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[4].Text) ? string.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    //txtSegundoApellido.Text = string.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[5].Text) ? string.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    //txtDireccion.Text = string.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[6].Text) ? string.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    //txtTelefono.Text = string.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[7].Text) ? string.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;
                    //txtCorreo.Text = string.IsNullOrEmpty(gvwDatos.Rows[inIndice].Cells[8].Text) ? string.Empty : gvwDatos.Rows[inIndice].Cells[8].Text;

                    txtEmpresa.Text = gvwDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp") ? string.Empty : gvwDatos.Rows[inIndice].Cells[1].Text; // aca es para tener acceso a un dato del grid de
                    txtPrimerNombre.Text = gvwDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp") ? string.Empty : gvwDatos.Rows[inIndice].Cells[2].Text;
                    txtSegundoNombre.Text = gvwDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp") ? string.Empty : gvwDatos.Rows[inIndice].Cells[3].Text;
                    txtPrimerApellido.Text = gvwDatos.Rows[inIndice].Cells[4].Text.Equals("&nbsp") ? string.Empty : gvwDatos.Rows[inIndice].Cells[4].Text;
                    txtSegundoApellido.Text = gvwDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp") ? string.Empty : gvwDatos.Rows[inIndice].Cells[5].Text;
                    txtDireccion.Text = gvwDatos.Rows[inIndice].Cells[6].Text.Equals("&nbsp") ? string.Empty : gvwDatos.Rows[inIndice].Cells[6].Text;
                    txtTelefono.Text = gvwDatos.Rows[inIndice].Cells[7].Text.Equals("&nbsp") ? string.Empty : gvwDatos.Rows[inIndice].Cells[7].Text;
                    txtCorreo.Text = gvwDatos.Rows[inIndice].Cells[8].Text.Equals("&nbsp") ? string.Empty : gvwDatos.Rows[inIndice].Cells[8].Text;
                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lblOpcion.Text = "3"; // esta es para el eliminar en el procedimiento almecenado

                    Logica.Models.clsPosiblesClientes obclsPosiblesClientes = new Logica.Models.clsPosiblesClientes
                    {
                        inIndentificacion = Convert.ToInt64(((Label)gvwDatos.Rows[inIndice].FindControl("lblIndentificacion")).Text),
                        stEmpresa = string.Empty,
                        stPrimerNombre = string.Empty,
                        stSegundoNombre = string.Empty,
                        stPrimerApellido = string.Empty,
                        stSegundoApellido = string.Empty,
                        stTelefono = string.Empty,
                        stDireccion = string.Empty,
                        stCorreo = txtCorreo.Text
                    };

                    Controllers.PosiblesClientesController obposiblesClientesController = new Controllers.PosiblesClientesController();
                    
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> alert( '" + obposiblesClientesController.setAdministrarPosiblesClientes(obclsPosiblesClientes, Convert.ToInt32(lblOpcion.Text)) + "') </script>");
                    lblOpcion.Text = string.Empty;
                    getClientesClientes();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> alert( '" + ex.Message + "') </script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblOpcion.Text = txtIndentificacion.Text = txtEmpresa.Text = txtPrimerNombre.Text = txtSegundoNombre.Text = txtPrimerApellido.Text = txtSegundoApellido.Text = txtTelefono.Text = txtTelefono.Text = txtCorreo.Text = string.Empty;
        }
    }
}