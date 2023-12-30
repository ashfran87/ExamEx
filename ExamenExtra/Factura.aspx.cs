using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenExtra
{
    public partial class Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int codigoFactura = int.Parse(TextBox1.Text);
            int codigoArticulo = int.Parse(TextBox2.Text);
            DateTime fechaTransaccion = DateTime.Parse(TextBox3.Text);
            decimal montoTotal = decimal.Parse(TextBox4.Text);
            decimal descuento = decimal.Parse(TextBox5.Text);
            decimal impuesto = decimal.Parse(TextBox6.Text);
            decimal subtotal = decimal.Parse(TextBox7.Text);
            int codigoUsuario = int.Parse(TextBox8.Text);



        }
    }
}
