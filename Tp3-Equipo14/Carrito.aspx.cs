using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp3_Equipo14
{
    public partial class Carrito1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            dgvCarrito.DataSource = Session["vecIds"];
            dgvCarrito.DataBind();

        }
    }
}