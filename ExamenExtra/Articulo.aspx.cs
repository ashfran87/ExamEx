using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenExtra
{
    public partial class Articulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }

        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Articulo"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagridUsuarios.DataSource = dt;
                            datagridUsuarios.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CLS.Articulo.agregarCompra(TextBoxDesc.Text, TextBoxPrecio.Text, TextBoxCat.Text) > 0)
            {
                LlenarGrid();
            }
            else
            {
                alertas("Datos ingresados incorrectamente");
            }
            TextBoxDesc.Text = "";
            TextBoxPrecio.Text = "";
            TextBoxCat.Text = "";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CLS.Articulo.BorrarUsuario(TextBoxID.Text) > 0)
            {
                LlenarGrid();
            }
            else
            {
                alertas("Datos ingresados incorrectamente");
            }
            TextBoxDesc.Text = "";
            TextBoxPrecio.Text = "";
            TextBoxCat.Text = "";

        }


    }
}
    
