using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capa.Datos.SQL
{
    class Conexion
    {
        public static SqlConnection obtenerConexion()
        {
            SqlConnection objConexion = new SqlConnection(Properties.Settings.Default.MyConnectionString);
            if (objConexion.State != System.Data.ConnectionState.Open)
            {
                objConexion.Open();
            }
            return objConexion;
        }
    }
}
