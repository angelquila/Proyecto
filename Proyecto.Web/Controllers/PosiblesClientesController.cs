using System;
using System.Data;

namespace Proyecto.Web.Controllers
{
    public class PosiblesClientesController
    {
        /// <summary>
        /// OBTIENE REGISTROS DE POSBLES CLIENTES
        /// </summary>
        /// <returns> DATA POSIBLES CLIENTES</returns>
        public DataSet getConsultarPosiblesClientesController()
        {
            try
            {
                Logica.BL.clsPosiblesClientes obclsPosiblesClientes = new Logica.BL.clsPosiblesClientes();
                return obclsPosiblesClientes.getConsultarPosiblesClientes();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// ADMINISTRA POSIBLES CLIENTES
        /// </summary>
        /// <param name="obclsPosiblesClientesModels">OBJETO</param>
        /// <param name="inOpcion">OPCION DE EJECUCION</param>
        /// <returns>MENSAJE DEL PROCESO</returns>
        public string setAdministrarPosiblesClientes(Logica.Models.clsPosiblesClientes obclsPosiblesClientesModels, int inOpcion)
        {
            try
            {
                Logica.BL.clsPosiblesClientes obclsPosiblesClientes = new Logica.BL.clsPosiblesClientes();
                return obclsPosiblesClientes.setAdministrarPosiblesClientes(obclsPosiblesClientesModels, inOpcion);

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}