using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Tp2_Programacion;

namespace Tp3_Equipo14
{
    public partial class _Default : Page
    {
        public List<Articulo> ListaArticulos { get; set; }       
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            ListaArticulos = negocio.listarconSP();

            if (!IsPostBack)
            {
                if (Session["ListaArticulos"] == null) {
                Session.Add("ListaArticulos", negocio.listarconSP());
                
                }
                
                repRepeater.DataSource = Session["ListaArticulos"];
                repRepeater.DataBind();
            }
        }
    }
}