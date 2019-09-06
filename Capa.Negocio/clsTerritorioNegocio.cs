using Capa.Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Negocio
{
    public class clsTerritorioNegocio : absTerritorio
    {
        public bool campoVacio { get; set; }

        //Realiza una nueva instancia de [clsTerritorioDatos] para retornar las lista de Territorios [List<clsTerritorio>]
        public List<clsTerritorio> ListarTerritorio()
        {
            return (new clsTerritorioDatos().ListarTerritorio());
        }


        #region Metodos 'AgregarTerritorio' 'ModificarTerritorio' 'EliminarTerritorio'
        /*Reciben una variable de tipo [clsTerritorio] y crea una instancia [clsTerritorioDatos]                            */
        /*pasando como parametro un objeto Territorio                                                                       */
        public void AgregarTerritorio(clsTerritorio inTerritorio)
        {
            if (inTerritorio.TerritoryID == string.Empty || inTerritorio.TerritoryDescription == string.Empty)
            {
                campoVacio = true;
            }
            else
            {
                new clsTerritorioDatos().AgregarTerritorio(inTerritorio);
            }
        }
        public void ModificarTerritorio(clsTerritorio inTerritorio)
        {
            new clsTerritorioDatos().ModificarTerritorio(inTerritorio);
        }
        public void EliminarTerritorio(clsTerritorio inTerritorio)
        {
            new clsTerritorioDatos().EliminarTerritorio(inTerritorio);
        }

        #endregion

        // Devuele en una [List<int>] con [RegioID] para ser utilizados en el DropDownList
        public List<int> getRegion()
        {
            return (new clsTerritorioDatos().getRegionID());
        }
    }
}
