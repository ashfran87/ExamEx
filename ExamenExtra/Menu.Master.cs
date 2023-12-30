using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ExamenExtra.CLS.Login;

namespace ExamenExtra
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelUsuario.Text = $"Usuario: {LoginWeb.GetNombre()}    Rol: {LoginWeb.GetNombreRol()}";
        }
    }
}