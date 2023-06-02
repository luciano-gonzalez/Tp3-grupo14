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

        public bool filtroavanzado { get; set; }

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

                filtroavanzado = chkAvanzado.Checked;
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

        public int verificarId(int id)
        {
            int aux = 0;
            ArticulosNegocio articulo = new ArticulosNegocio();
            int[] vectorids = (int[])Session["vecIds"];

            for (int x = 0; x < articulo.contRegistros(); x++)
            {
                if (vectorids[x] == id)
                {
                    aux++;
                }

            }
            return aux;
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
                    if (verificarId(id) == 0)
                    {
                        vectorids[x] = id;
                        contar++;
                    }
                }

            }
            Session.Add("vecIds", vectorids);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            if (IsPostBack) { 
            List<Articulo> lista = (List <Articulo>)Session["ListaArticulos"];
            List<Articulo> listafiltrada = lista.FindAll(x => x._nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            repRepeater.DataSource = listafiltrada;
            repRepeater.DataBind();
            }
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroavanzado = chkAvanzado.Checked;
            txtfiltro.Enabled = !filtroavanzado;
        }

        protected void ddlcampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlcriterio.Items.Clear();
            if (ddlcampo.SelectedItem.ToString()=="Nombre") {
                ddlcriterio.Items.Add("Contiene");
                ddlcriterio.Items.Add("Comienza con");
                ddlcriterio.Items.Add("Termina con");
            }
            else
            {
                ddlcriterio.Items.Add("Contiene");
                ddlcriterio.Items.Add("Comienza con");
                ddlcriterio.Items.Add("Termina con");
            }
        }

       

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                    repRepeater.DataSource=negocio.filtrar(ddlcampo.SelectedItem.ToString(),
                    ddlcriterio.SelectedItem.ToString(),
                    txtfiltroavanzado.Text);
                    repRepeater.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

        }

        protected void btnlimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txtfiltroavanzado.Text = string.Empty;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}