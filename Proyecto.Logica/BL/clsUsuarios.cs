using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Logica.BL
{
    public class clsUsuarios
    {
        SqlConnection _sqlConnection = null; // nos permite establecer la conexin con la base datos 
        SqlCommand _sqlCommand = null; // me permite ejecutar comandos sql
        SqlDataAdapter _sqlDataAdapter = null; // me permite adaptar conjunto de datos sql
        string stConexion = string.Empty; // cadena de conexion 

        public clsUsuarios()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }

        /// <summary>
        /// VALIDA USUARIO
        /// </summary>
        /// <param name="obclsUsuarios">OBJETO USUARIO</param>
        /// <returns>CONFIRMACION</returns>
        public bool getValidarUsuario(Logica.Models.clsUsuarios obclsUsuarios)
        {
            try
            {
                DataSet dsConsulta = new DataSet();

                _sqlConnection = new SqlConnection(stConexion);
                _sqlConnection.Open();

                _sqlCommand = new SqlCommand("spConsultarUsuario", _sqlConnection);
                _sqlCommand.CommandType = CommandType.StoredProcedure;

                _sqlCommand.Parameters.Add(new SqlParameter("@cLogin", obclsUsuarios.stLogin));
                _sqlCommand.Parameters.Add(new SqlParameter("@cPassword", obclsUsuarios.stPassword));

                _sqlCommand.ExecuteNonQuery();

                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(dsConsulta);

                if (dsConsulta.Tables[0].Rows.Count > 0) return true;
                else return false;               

            }
            catch(Exception ex)
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
