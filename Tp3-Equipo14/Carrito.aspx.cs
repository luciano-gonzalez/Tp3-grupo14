﻿using Dominio;
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

            dgvCarrito.DataSource = vecArticulos;
            dgvCarrito.DataBind();


            ///Agregar las imagenes al dgv
            int indiceColumnaPrecio = 1; // Índice de la columna de precios

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

            Label1.Text = totalPrecioFinal.ToString();

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


        protected void gridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int indice = e.RowIndex;
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
}