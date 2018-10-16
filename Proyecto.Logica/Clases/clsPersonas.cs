using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.Clases
{
    public class clsPersonas
    {
        //declaramos los parametros globales de conexion sql
        SqlCommand sqlCommand = null;
        SqlConnection sqlConnection = null;
        SqlParameter sqlParameter = null;
        SqlDataAdapter sqlDataAdapter = null;

        string stConexion;

        //aca llamamos al strin conexion de la clase conexion para luego usarlo
        public clsPersonas()
        {
            BL.clsConexion obclsConexion = new BL.clsConexion();
            stConexion = obclsConexion.getConexion();

        }

        //se crea la funcion insertar cliente
        public string stInsertarClientes(string stNombre, string stRut)
        {
            try
            {
                //para abrilr la conxion se utiliza esto
                sqlConnection = new SqlConnection(stConexion);
                sqlConnection.Open();

                sqlCommand = new SqlCommand("SP_Insert_Persona", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@Nombre", stNombre));
                sqlCommand.Parameters.Add(new SqlParameter("@RUT", stRut));


                //para definir el parametro de salida hay que hacer esto
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@cMensaje";
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.Size = 50;
                sqlParameter.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameter);
                //se ejecuta el store procedure
                sqlCommand.ExecuteNonQuery();
                //retonamos el valor

                return sqlParameter.Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
