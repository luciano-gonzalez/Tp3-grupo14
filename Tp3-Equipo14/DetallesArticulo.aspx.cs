using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp3_Equipo14
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public int urlImagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
        if (Request.QueryString["id"]!=null)
            {
              int id = int.Parse(Request.QueryString["id"].ToString());
                List<Articulo> Temporal = (List<Articulo>)Session["ListaArticulos"];
                Articulo seleccionado = Temporal.Find(x => x.ID == id);
                Txtid.Text = seleccionado.ID.ToString();
                Txtnombre.Text= seleccionado._nombre;
                Txtcodart.Text = seleccionado._codArticulo.ToString();
                Txtcategoria.Text = seleccionado._categoria.ToString();
                Txtprecio.Text = seleccionado._precio.ToString();
                Txtmarca.Text = seleccionado._marca.ToString();
                Txtdescripcion.Text = seleccionado._descripcion.ToString();
                Txtid.ReadOnly = true;
                Txtnombre.ReadOnly = true;
                Txtcodart.ReadOnly = true;
                Txtcategoria.ReadOnly = true;
                Txtprecio.ReadOnly = true;
                Txtmarca.ReadOnly = true;
                Txtdescripcion.ReadOnly = true;
                imgArticulo.ImageUrl = seleccionado.urlImagen.ToString();
            }

        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}