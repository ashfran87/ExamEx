using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ExamenExtra.CLS.Login;

namespace ExamenExtra
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            LoginWeb.SetNombre(TextBoxUser.Text);
            LoginWeb.SetClave(TextBoxContraseña.Text);
            LoginWeb.ObtenerusuarioID();
            LoginWeb.ObtenerRol();
            LoginWeb.SetNombreRol();
            if (LoginWeb.validarLogin() > 0)
            {
                Response.Redirect("Usuarios.aspx");
            }
        }
    }
}