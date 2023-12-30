using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ExamenExtra.CLS
{
    public class Usuario
    {
        
            public string CodigoUsuario { get; set; }
            public string Nombre { get; set; }
           
            public string CorreoElectronico { get; set; }
            

            public Usuario( string nombre,  string correoElectronico)
            {
                
                Nombre = nombre;
          
                CorreoElectronico = correoElectronico;
               
            }
        public static int agregarusuarios(string nombre, string correo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = BDConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarusuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                
                    cmd.Parameters.Add(new SqlParameter("@CORREO", correo));
                   

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