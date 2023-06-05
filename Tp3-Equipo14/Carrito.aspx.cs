using Dominio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Tp2_Programacion;

namespace Tp3_Equipo14
{
    public partial class Carrito1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //acá modifico
                List<Articulo> lista = new List<Articulo>();
                lista = ((List<Articulo>)Session["carrito"]);
                dgvCarro.DataSource = lista;
                dgvCarro.DataBind();
                //acá modifico
                /*
                ArticulosNegocio negocio = new ArticulosNegocio();
                int[] vectorids = (int[])Session["vecIds"];
                int cantArticulosCarrito = 0;
                for (int i = 0; i < negocio.contRegistros(); i++)
                {
                    if (vectorids[i] != 0)
                    {
                        cantArticulosCarrito++;
                    }
                }
                Articulo[] vecArticulos = new Articulo[cantArticulosCarrito];
                int contArti = 0;
                int id = 0;
                List<Articulo> Temporal = (List<Articulo>)Session["ListaArticulos"];
                for (int i = 0; i < negocio.contRegistros(); i++)
                {
                    if (vectorids[i] != 0)
                    {
                        id = vectorids[i];
                        vecArticulos[contArti] = Temporal.Find(x => x.ID == id);
                        contArti++;
                    }
                }
                */
                ///Agregar las imagenes al dgv
                int indiceColumnaPrecio = 2;

                decimal totalPrecioFinal = 0;

                foreach (GridViewRow fila in dgvCarro.Rows)
                {
                    if (fila.Cells[indiceColumnaPrecio].Text != string.Empty)
                    {
                        if (decimal.TryParse(fila.Cells[indiceColumnaPrecio].Text, out decimal precio))
                        {
                            totalPrecioFinal += precio;
                        }
                    }
                }
                /*
                dgvCarrito.DataSource = vecArticulos;
                dgvCarrito.DataBind();


                ///Agregar las imagenes al dgv
                int indiceColumnaPrecio = 1;

                decimal totalPrecioFinal = 0;

                foreach (GridViewRow fila in dgvCarrito.Rows)
                {
                    if (fila.Cells[indiceColumnaPrecio].Text != string.Empty)
                    {
                        if (decimal.TryParse(fila.Cells[indiceColumnaPrecio].Text, out decimal precio))
                        {
                            totalPrecioFinal += precio;
                        }
                    }
                }
                 */

                lblPrecioFinal.Text = totalPrecioFinal.ToString();
                 
            }
        }

        public Articulo[] ObtenerDatos()
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            int[] vectorids = (int[])Session["vecIds"];
            int cantArticulosCarrito = 0;

            for (int i = 0; i < negocio.contRegistros(); i++)
            {
                if (vectorids[i] != 0)
                {
                    cantArticulosCarrito++;
                }
            }
            Articulo[] vecArticulos = new Articulo[cantArticulosCarrito];
            int contArti = 0;
            int id = 0;
            List<Articulo> Temporal = (List<Articulo>)Session["ListaArticulos"];
            for (int i = 0; i < negocio.contRegistros(); i++)
            {
                if (vectorids[i] != 0)
                {
                    id = vectorids[i];
                    vecArticulos[contArti] = Temporal.Find(x => x.ID == id);
                    contArti++;
                }
            }
            return vecArticulos;
        }

        public int cantReg()
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            int[] vectorids = (int[])Session["vecIds"];
            int cantArticulosCarrito = 0;
            for (int i = 0; i < negocio.contRegistros(); i++)
            {
                if (vectorids[i] != 0)
                {
                    cantArticulosCarrito++;
                }
            }
            Articulo[] vecArticulos = new Articulo[cantArticulosCarrito];
            int contArti = 0;
            int id = 0;
            List<Articulo> Temporal = (List<Articulo>)Session["ListaArticulos"];
            for (int i = 0; i < negocio.contRegistros(); i++)
            {
                if (vectorids[i] != 0)
                {
                    id = vectorids[i];
                    vecArticulos[contArti] = Temporal.Find(x => x.ID == id);
                    contArti++;
                }
            }
            return contArti;
        }
        protected void dgvCarro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {

                int indice = Convert.ToInt32(e.CommandArgument);
                //int id = int.Parse(dgvCarro.DataKeys[indice]["ID"].ToString());
                List<Articulo> aux = (List<Articulo>)Session["carrito"];
                if(aux.Count > 0 && indice >= 0)
                {
                    aux.RemoveAt(indice);
                }

                Session["carrito"] = aux;
                dgvCarro.DataSource = Session["carrito"];
                dgvCarro.DataBind();

                int indiceColumnaPrecio = 2;

                decimal totalPrecioFinal = 0;

                foreach (GridViewRow fila in dgvCarro.Rows)
                {
                    if (fila.Cells[indiceColumnaPrecio].Text != string.Empty)
                    {
                        if (decimal.TryParse(fila.Cells[indiceColumnaPrecio].Text, out decimal precio))
                        {
                            totalPrecioFinal += precio;
                        }
                    }
                }
                lblPrecioFinal.Text = totalPrecioFinal.ToString();
            }
        }
        /*
        protected void dgvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Eliminar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                int id = int.Parse(dgvCarrito.DataKeys[indice]["ID"].ToString());
                Articulo[] vecArticulos = ObtenerDatos();
                Articulo[] NuevosArticulos = new Articulo[cantReg() - 1];
                int cont = 0;
                for (int i = 0; i < cantReg(); i++)
                {
                    if (vecArticulos[i].ID != id)
                    {
                        NuevosArticulos[cont] = vecArticulos[i];
                        cont++;
                    }
                }
                dgvCarrito.DataSource = NuevosArticulos;
                dgvCarrito.DataBind();
            }
        }
         */
    }
}
              