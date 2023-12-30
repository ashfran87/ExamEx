using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamenExtra.CLS
{
   
        public class Factura
        {
            public int CodigoFactura { get; set; }
            public int CodigoArticulo { get; set; }
            public DateTime FechaTransaccion { get; set; }
            public decimal MontoTotal { get; set; }
            public decimal Descuento { get; set; }
            public decimal Impuesto { get; set; }
            public decimal Subtotal { get; set; }
            public int CodigoUsuario { get; set; }

            public Factura(int codigoFactura, int codigoArticulo, DateTime fechaTransaccion, decimal montoTotal, decimal descuento, decimal impuesto, decimal subtotal, int codigoUsuario)
            {
                CodigoFactura = codigoFactura;
                CodigoArticulo = codigoArticulo;
                FechaTransaccion = fechaTransaccion;
                MontoTotal = montoTotal;
                Descuento = descuento;
                Impuesto = impuesto;
                Subtotal = subtotal;
                CodigoUsuario = codigoUsuario;
            }

            public decimal CalcularSubtotal(decimal precio, int cantidad)
            {
                return precio * cantidad;
            }

            public decimal CalcularImpuesto(decimal subtotal, decimal tasaImpuesto)
            {
                return subtotal * tasaImpuesto;
            }

            public decimal CalcularTotal(decimal subtotal, decimal impuesto)
            {
                return subtotal + impuesto;
            }

     
        }
}

   
