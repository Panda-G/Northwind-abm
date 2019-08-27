using Capa.Negocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa.Presentacion
{
    public partial class Territorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                cargar_grilla();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnModificar.Enabled = true; btnEliminar.Enabled = true; btnGuardar.Visible = false;

            txtTerritorioID.Text = GridView1.SelectedRow.Cells[1].Text.Trim();
            txtDescripcion.Text = GridView1.SelectedRow.Cells[2].Text.Trim();
            cargar_lista();
            ddlRegionID.SelectedValue = GridView1.SelectedRow.Cells[3].Text.ToString().Trim();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtTerritorioID.Focus();
            txtTerritorioID.Enabled = true;
            btnModificar.Enabled = false; btnEliminar.Enabled = false; btnGuardar.Visible = true;
            limpiar_controles();
            cargar_lista();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            clsTerritorioNegocio objTerritorioNegocio = new clsTerritorioNegocio();
            objTerritorioNegocio.ModificarTerritorio(this.obtenerTerritorio());
            cargar_grilla();
            limpiar_controles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            clsTerritorioNegocio objTerritorio = new clsTerritorioNegocio();
            objTerritorio.EliminarTerritorio(this.obtenerTerritorio());
            cargar_grilla();
            limpiar_controles();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            clsTerritorioNegocio objTerritorioNegocio = new clsTerritorioNegocio();
            if (!objTerritorioNegocio.campoVacio == true)
            {
                objTerritorioNegocio.AgregarTerritorio(this.obtenerTerritorio());
            }
            else
            {

                lblDetalles.Text = ("Complete los campos obligatorios").ToString();
            }
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            cargar_grilla();
            limpiar_controles();
        }

        private clsTerritorio obtenerTerritorio()
        {
            clsTerritorio inTerritorio = new clsTerritorio()
            {
                TerritoryID = txtTerritorioID.Text,
                TerritoryDescription = txtDescripcion.Text,
                RegionID = Convert.ToInt16(ddlRegionID.Text)
            };
            return inTerritorio;
        }
        private void cargar_lista()
        {
            ddlRegionID.Items.Clear();
            List<int> lstRegion = new clsTerritorioNegocio().getRegion();
            foreach (var item in lstRegion)
            {
                ddlRegionID.Items.Add(item.ToString());
            }
        }
        private void cargar_grilla()
        {
            clsTerritorioNegocio objNegocio = new clsTerritorioNegocio();
            this.GridView1.DataSource = objNegocio.ListarTerritorio();
            GridView1.DataBind();
        }
        private void limpiar_controles()
        {
            ddlRegionID.Items.Clear();
            txtDescripcion.Text = string.Empty;
            txtTerritorioID.Text = string.Empty;
        }


    }
}