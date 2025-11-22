using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;

namespace negocio
{
    public class CompraNegocio
    {
        public List<Compra> ListarCompras()
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT 
                C.IdCompra,
                C.FechaCompra,
                C.FechaRecepcion,
                C.TotalCompra,
                C.IdProveedor,
                C.Estado
               
            FROM COMPRA C
            
            WHERE C.Estado = 1;
        ");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();

                    aux.idCompra = (int)datos.Lector["IdCompra"];
                    aux.FechaCompra = (DateTime)datos.Lector["FechaCompra"];
                    aux.FechaRecepcion = datos.Lector["FechaRecepcion"] is DBNull ?
                    DateTime.MinValue : (DateTime)datos.Lector["FechaRecepcion"];
                    aux.TotalCompra = (decimal)datos.Lector["TotalCompra"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.IdProveedor = (int)datos.Lector["IdProveedor"];
                 

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int AgregarCompra(Compra compra)
        {
            var datos = new AccesoDatos();

            datos.setearConsulta(@"
            INSERT INTO COMPRA (IdProveedor, FechaCompra, TotalCompra)
            OUTPUT INSERTED.IdCompra
            VALUES (@proveedor, @fecha, @total)");

            datos.setearParametro("@proveedor", compra.IdProveedor);
            datos.setearParametro("@fecha", compra.FechaCompra);
            datos.setearParametro("@total", compra.TotalCompra);

            int idCompra = (int)datos.ejecutarScalar();

            return idCompra;
        }


    }
}
