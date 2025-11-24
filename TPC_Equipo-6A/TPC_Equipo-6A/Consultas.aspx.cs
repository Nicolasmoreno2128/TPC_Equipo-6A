using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPC_Equipo_6A
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }
            var reporte = new InformeNegocio().TopClientesCompras();
            gvComprasCliente.DataSource = reporte;
            gvComprasCliente.DataBind();

            if (!IsPostBack)
            {
                ddlPeriodos.Items.Clear();

                ddlPeriodos.Items.Add(new ListItem("Enero", "1"));
                ddlPeriodos.Items.Add(new ListItem("Febrero", "2"));
                ddlPeriodos.Items.Add(new ListItem("Marzo", "3"));
                ddlPeriodos.Items.Add(new ListItem("Abril", "4"));
                ddlPeriodos.Items.Add(new ListItem("Mayo", "5"));
                ddlPeriodos.Items.Add(new ListItem("Junio", "6"));
                ddlPeriodos.Items.Add(new ListItem("Julio", "7"));
                ddlPeriodos.Items.Add(new ListItem("Agosto", "8"));
                ddlPeriodos.Items.Add(new ListItem("Septiembre", "9"));
                ddlPeriodos.Items.Add(new ListItem("Octubre", "10"));
                ddlPeriodos.Items.Add(new ListItem("Noviembre", "11"));
                ddlPeriodos.Items.Add(new ListItem("Diciembre", "12"));

                ddlPeriodos.Items.Add(new ListItem("Anual", "Anual"));
            }
        }

        protected void ddlPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            InformeNegocio negocio = new InformeNegocio();

            string opcion = ddlPeriodos.SelectedValue;

            if (opcion == "Anual")
            {
                decimal totalAnual = negocio.ObtenerTotalAnual();
                lblResultado.Text = "Total recaudado en el año: $" + totalAnual.ToString("N2");
            }
            else
            {
                int mes = int.Parse(opcion);
                decimal totalMes = negocio.ObtenerTotalPorMes(mes);
                lblResultado.Text = "Total recaudado en " + ddlPeriodos.SelectedItem.Text + ": $" + totalMes.ToString("N2");
            }
        }

    }
}