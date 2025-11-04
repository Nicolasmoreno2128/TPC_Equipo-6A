using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }       
        public AccesoDatos()
        {
            try
            {
                // Primer intento: conexión local
                conexion = new SqlConnection("server=localhost\\SQLEXPRESS; database=ComercioColchones; integrated security=true");
                conexion.Open();
            }
            catch
            {
                // Si falla, intenta con la conexión remota
                conexion = new SqlConnection("server=.\\localhost,1433; database=ComercioColchones; integrated security=false; user=sa; password=Passw0rd2025!");
                conexion.Open();
            }
            // Cierra enseguida si se abrió solo para probar
            conexion.Close();
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
    }
}
