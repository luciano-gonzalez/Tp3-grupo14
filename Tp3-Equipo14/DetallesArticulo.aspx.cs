using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tp2_Programacion;

namespace Tp3_Equipo14
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public int urlImagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {

                    ArticulosNegocio negocio = new ArticulosNegocio();
                    int id = int.Parse(Request.QueryString["id"].ToString());

                    List<Articulo> listaCompleta = negocio.listarconSP(); 

                    
                    List<Articulo> listaFiltrada = listaCompleta.Where(a => a.ID == id).ToList();
                    Articulo temporal = listaFiltrada[0];
                    lblNombre.Text = temporal._nombre.ToString();
                    lblCodigo.Text = temporal._codArticulo.ToString();
                    lblMarca.Text = temporal._marca.ToString();
                    lblPrecio.Text ="$" + temporal._precio.ToString();
                    lblDescripcion.Text = temporal._descripcion.ToString();
                    imgImagen.ImageUrl = temporal.urlImagen.ToString();


                    //dgvArticulo.DataSource = listaFiltrada;
                    //dgvArticulo.DataBind();
                }
            }


            /*

            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                List<Articulo> Temporal = (List<Articulo>)Session["ListaArticulos"];
                Articulo seleccionado = Temporal.Find(x => x.ID == id);
                Txtid.Text = seleccionado.ID.ToString();
                Txtnombre.Text = seleccionado._nombre;
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
            */
        }
    }
}