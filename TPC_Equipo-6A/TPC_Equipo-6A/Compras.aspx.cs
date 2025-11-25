using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

            if (!IsPostBack)
            {
                CargarCompras();
            }
        }
        private void CargarCompras()
        {
            CompraNegocio negocio = new CompraNegocio();
            DgvCompras.DataSource = negocio.ListarCompras();
            DgvCompras.DataBind();
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCompra");
        }
        protected void DgvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DgvCompras.Rows[index];
            int id = Convert.ToInt32(DgvCompras.DataKeys[index].Value);

            // Controles dentro de la fila
            var lblAccion = (Label)row.FindControl("lblAccion");
            var btnDetalle = (Button)row.FindControl("btnDetalle");
            var btnRecepcionar = (Button)row.FindControl("btnRecepcionar");
            var btnBorrar = (Button)row.FindControl("btnBorrar");
            var btnConfirmar = (Button)row.FindControl("btnConfirmar");
            var btnCancelar = (Button)row.FindControl("btnCancelar");

            switch (e.CommandName)
            {               
                case "Detalle":
                    Response.Redirect("DetalleCompraPage.aspx?IdCompra=" + id);
                    break;
                
                case "Recepcionar":
                    lblAccion.Text = "Recepcionar";
                    lblAccion.Visible = true;

                    btnDetalle.Visible = false;
                    btnRecepcionar.Visible = false;
                    btnBorrar.Visible = false;

                    btnConfirmar.Visible = true;
                    btnCancelar.Visible = true;
                    break;
                
                case "Borrar":
                    lblAccion.Text = "Eliminar";
                    lblAccion.Visible = true;

                    btnDetalle.Visible = false;
                    btnRecepcionar.Visible = false;
                    btnBorrar.Visible = false;

                    btnConfirmar.Visible = true;
                    btnCancelar.Visible = true;
                    break;

                case "Cancelar":
                    CargarCompras();   
                    break;

                case "Confirmar":
                    try
                    {
                        CompraNegocio negocio = new CompraNegocio();

                        if (lblAccion.Text == "Eliminar")
                            negocio.eliminarCompraLogico(id);
                        else if (lblAccion.Text == "Recepcionar")
                            negocio.RegistrarRecepcionYActualizarStock(id);

                        CargarCompras();
                    }
                    catch (Exception ex)
                    {
                        Session["error"] = ex.Message;
                        Response.Redirect("Error.aspx");
                    }
                    break;

            }
        }

        protected void DgvCompras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Compra compra = (Compra)e.Row.DataItem;

                Button btnBorrar = (Button)e.Row.FindControl("btnBorrar");
                Button btnRecepcionar = (Button)e.Row.FindControl("btnRecepcionar");

                // Ocultar botón borrar si ya fue recepcionada
                if (compra.FechaRecepcion != null)
                {
                    btnBorrar.Visible = false;
                }

                // Ocultar botón recepcionar si ya fue recepcionada
                if (compra.FechaRecepcion != null)
                {
                    btnRecepcionar.Visible = false;
                }
            }
        }




    }
}