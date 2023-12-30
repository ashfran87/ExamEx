using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ExamenExtra.CLS
{
    public class Articulo
    {
        public int CodigoArticulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }

        public Articulo(int codigoArticulo, string descripcion, decimal precio, string categoria)
        {
            CodigoArticulo = codigoArticulo;
            Descripcion = descripcion;
            Precio = precio;
            Categoria = categoria;
        }
        public static int agregarCompra(string Descripcion, decimal Precio, string Categoria)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = BDConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarCompra", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Dec", Descripcion));

                    cmd.Parameters.Add(new SqlParameter("@PRECIO", Precio));
                    cmd.Parameters.Add(new SqlParameter("@CATEGORIA ", Categoria));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int BorrarUsuario(string codigoUsuario)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = BDConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("borrarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigoUsuario));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }




    }

}