using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica.BL
{
    public class clsPosiblesClientes
    {
        SqlConnection _sqlConnection = null; // nos permite establecer la conexin con la base datos 
        SqlCommand _sqlCommand = null; // me permite ejecutar comandos sql
        SqlDataAdapter _sqlDataAdapter = null; // me permite adaptar conjunto de datos sql
        string stConexion = string.Empty; // cadena de conexion 

        SqlParameter _sqlParameter = null;

        public clsPosiblesClientes()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }

        /// <summary>
        /// CONSULTA DE POSIBLES CLIENTES
        /// </summary>
        /// <param name="obclsPosiblesClientes"></param>
        /// <returns> REGISTROS POSIBLES CLIENTES</returns>
        public DataSet getConsultarPosiblesClientes()
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _sqlConnection = new SqlConnection(stConexion);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand("spConsultarPosiblesClientes", _sqlConnection);
                _sqlCommand.CommandType = CommandType.StoredProcedure;

                _sqlCommand.ExecuteNonQuery();

                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(dsConsulta);

                return dsConsulta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }



        /// <summary>
        /// ADMINISTRAR POSIBLES CLIENTES
        /// </summary>
        /// <param name="obclsPosiblesClientes">OBJETO</param>
        /// <param name="inOpcion">OBCION DE LA EJECUCION</param>
        /// <returns>MENSAJE DE LA OPERACION</returns>
        public string setAdministrarPosiblesClientes(Models.clsPosiblesClientes obclsPosiblesClientes, int inOpcion) // aca para no pasar los valores de a uno llamamos al objeto que esta en modelos ya definidos con todos los campos
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _sqlConnection = new SqlConnection(stConexion);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand("spAdministrarPosiblesClientes", _sqlConnection);
                _sqlCommand.CommandType = CommandType.StoredProcedure;

                _sqlCommand.Parameters.Add(new SqlParameter("@nIdentificacion", obclsPosiblesClientes.inIndentificacion));
                _sqlCommand.Parameters.Add(new SqlParameter("@cEmpresa", obclsPosiblesClientes.stEmpresa));
                _sqlCommand.Parameters.Add(new SqlParameter("@cPrimerNombre", obclsPosiblesClientes.stPrimerNombre));
                _sqlCommand.Parameters.Add(new SqlParameter("@cSegundoNombre", obclsPosiblesClientes.stSegundoNombre));
                _sqlCommand.Parameters.Add(new SqlParameter("@cPrimerApellido", obclsPosiblesClientes.stPrimerApellido));
                _sqlCommand.Parameters.Add(new SqlParameter("@cSegundoApellido", obclsPosiblesClientes.stSegundoApellido));
                _sqlCommand.Parameters.Add(new SqlParameter("@cDireccion", obclsPosiblesClientes.stDireccion));
                _sqlCommand.Parameters.Add(new SqlParameter("@cTelefono", obclsPosiblesClientes.stTelefono));
                _sqlCommand.Parameters.Add(new SqlParameter("@cCorreo", obclsPosiblesClientes.stCorreo));
                _sqlCommand.Parameters.Add(new SqlParameter("@nOpcion", inOpcion));
               
                _sqlParameter = new SqlParameter();
                _sqlParameter.ParameterName = "@cMensaje";
                _sqlParameter.Direction = ParameterDirection.Output;
                _sqlParameter.SqlDbType = SqlDbType.VarChar;
                _sqlParameter.Size = 50;

                _sqlCommand.Parameters.Add(_sqlParameter);
                _sqlCommand.ExecuteNonQuery();


                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(dsConsulta);

                return _sqlParameter.Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
