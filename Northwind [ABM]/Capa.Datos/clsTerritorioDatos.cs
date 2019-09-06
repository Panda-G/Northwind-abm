using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Capa.Datos.SQL;

namespace Capa.Datos
{
    public class clsTerritorioDatos : absTerritorio
    {
        private string sqlError = null;

        //Realiza un conexion con la base de datos y hace un [SELECT * FROM Territories] y retorna un [List<clsTerritorio>]
        public List<clsTerritorio> ListarTerritorio()
        {
            List<clsTerritorio> lstTerritorio = null;

            SqlConnection objConnection = Conexion.obtenerConexion();
            SqlCommand objSqlCommand = new SqlCommand("SELECT te.TerritoryID, te.TerritoryDescription, te.RegionID FROM Territories te", objConnection);
            SqlDataReader objReader = objSqlCommand.ExecuteReader();

            if (objReader.HasRows)
                lstTerritorio = new List<clsTerritorio>();

            while (objReader.Read())
            {
                clsTerritorio objTerritorio = new clsTerritorio();
                objTerritorio.TerritoryID = objReader["TerritoryID"].ToString();
                objTerritorio.TerritoryDescription = objReader["TerritoryDescription"].ToString();
                objTerritorio.RegionID = (int)objReader["RegionID"];
                lstTerritorio.Add(objTerritorio);
            }
            objConnection.Close();
            return lstTerritorio;
        }

        #region Metodos correspondiendes[ >Agregar >Modificar >Eliminar ]
        //Recibe una variable de tipo [clsTerritorio] para agregar a la base de datos
        public void AgregarTerritorio(clsTerritorio inTerritorio)
        {
            SqlConnection miConnection = Conexion.obtenerConexion();
            try
            {
                SqlCommand sqlComm = new SqlCommand("INSERT INTO Territories VALUES (@TerritoryID, @TerritoryDescription, @RegionID)", miConnection);
                sqlComm.Parameters.AddWithValue("@TerritoryID", inTerritorio.TerritoryID);
                sqlComm.Parameters.AddWithValue("@TerritoryDescription", inTerritorio.TerritoryDescription);
                sqlComm.Parameters.AddWithValue("@RegionID", inTerritorio.RegionID);
                sqlComm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                DisplaySqlErrors(ex.Message);
            }
            finally
            {
                if (miConnection.State != System.Data.ConnectionState.Closed)
                    miConnection.Close();
            }
        }
        
        //Recibe una variable de tipo [clsTerritorio], para ser modificado
        public void ModificarTerritorio(clsTerritorio inTerritorio)
        {
            SqlConnection miConnection = Conexion.obtenerConexion();
            try
            {
                SqlCommand sqlComm = new SqlCommand("UPDATE Territories SET TerritoryDescription = @TerritoryDescription, RegionID = @RegionID WHERE TerritoryID = @TerritoryID", miConnection);
                sqlComm.Parameters.AddWithValue("@TerritoryID", inTerritorio.TerritoryID);
                sqlComm.Parameters.AddWithValue("@TerritoryDescription", inTerritorio.TerritoryDescription);
                sqlComm.Parameters.AddWithValue("@RegionID", inTerritorio.RegionID);
                sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DisplaySqlErrors(ex.Message);
            }
            finally
            {
                if (miConnection.State != System.Data.ConnectionState.Closed)
                    miConnection.Close();
            }
        }

        //Recibe una variable de tipo [clsTerritorio], para luego ser agregar en la consulta de eliminacion del mismo
        public void EliminarTerritorio(clsTerritorio inTerritorio)
        {
            SqlConnection miConnection = Conexion.obtenerConexion();
            SqlCommand sqlComm = new SqlCommand("DELETE FROM Territories WHERE TerritoryID = @TerritoryID", miConnection);
            sqlComm.Parameters.AddWithValue("@TerritoryID", inTerritorio.TerritoryID);
            sqlComm.ExecuteNonQuery();
            miConnection.Close();
        }
        #endregion

        // Devuele en una [List<int>] con [RegioID] para ser utilizados en el DropDownList
        public List<int> getRegionID()
        {
            List<int> lstRegion = null;
            SqlConnection miConnection = Conexion.obtenerConexion();
            SqlCommand sqlComm = new SqlCommand("SELECT RegionID FROM REGION", miConnection);

            SqlDataReader dataReader = sqlComm.ExecuteReader();

            if (dataReader.HasRows)
                lstRegion = new List<int>();

            while (dataReader.Read())
            {
                int n = Convert.ToInt32(dataReader[0]);
                lstRegion.Add(n);
            }
            miConnection.Close();
            return lstRegion;
        }

        //Captura el mensaje de la [Exception] de SQL
        private void DisplaySqlErrors(string inMensaje)
        {
            sqlError = inMensaje;
        }


    }
}
