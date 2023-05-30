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
            int contid = 0;
            ArticulosNegocio negocio = new ArticulosNegocio();
            ListaArticulos = negocio.listarconSP();
            int cantRegistros;
            cantRegistros = negocio.contRegistros();
            int[] vecIds = new int[cantRegistros];
            for (int i = 0; i < cantRegistros; i++)
            {
                vecIds[i] =0;
            }

            if (!IsPostBack)
            {
                if (Session["contid"] == null)
                {
                    Session.Add("contid", contid);
                }


                if (Session["ListaArticulos"] == null) {
                Session.Add("ListaArticulos", negocio.listarconSP());
                }

                if (Session["vecIds"] == null){
                    Session.Add("vecIds",vecIds);
                }

                
                repRepeater.DataSource = Session["ListaArticulos"];
                repRepeater.DataBind();
            }
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
          
            int cont = int.Parse(Session["contid"].ToString());
            int[] vectorids = (int[])Session["vecIds"];
            string valor = ((Button)sender).CommandArgument;
            int id = int.Parse(valor.ToString());
            ArticulosNegocio articulo = new ArticulosNegocio();
            int contar = 0;
            for (int x = 0; x<articulo.contRegistros(); x++)
            {
                if (vectorids[x]==0 && contar==0){
                    vectorids[x] = id;
                    contar++;
                }

            }
            Session.Add("vecIds", vectorids);
        }
    }
}