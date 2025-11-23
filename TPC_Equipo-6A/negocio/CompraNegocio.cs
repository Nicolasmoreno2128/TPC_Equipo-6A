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
                    aux.FechaRecepcion = datos.Lector["FechaRecepcion"] is DBNull
                     ? (DateTime?)null
                     : (DateTime)datos.Lector["FechaRecepcion"];
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

        public void ActualizarStockProducto(int idProducto, int cantidadSumar)
        {
            var datos = new AccesoDatos();

            datos.setearConsulta("UPDATE PRODUCTO SET Stock = Stock + @cant WHERE IdProducto = @id");
            datos.setearParametro("@cant", cantidadSumar);
            datos.setearParametro("@id", idProducto);

            datos.ejecutarAccion();
        }

        public List<DetalleCompra> ObtenerDetalles(int idCompra)
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();
            var datos = new AccesoDatos();

            datos.setearConsulta("SELECT IdProducto, Cantidad, PrecioUnitario FROM DETALLE_COMPRA WHERE IdCompra = @id");
            datos.setearParametro("@id", idCompra);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                var d = new DetalleCompra
                {
                    IdProducto = (int)datos.Lector["IdProducto"],
                    Cantidad = (int)datos.Lector["Cantidad"],
                    PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"]
                };

                lista.Add(d);
            }

            return lista;
        }
        public void eliminarCompraLogico(int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();

                // 1. Verificar si la compra ya fue recepcionada
                datos.setearConsulta("SELECT FechaRecepcion FROM COMPRA WHERE IdCompra = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    if (!(datos.Lector["FechaRecepcion"] is DBNull))
                    {
                        throw new Exception("No se puede eliminar una compra que ya fue recepcionada.");
                    }
                }

                datos.cerrarConexion();

                // 2. Si no fue recepcionada → eliminar lógicamente
                datos = new AccesoDatos();
                datos.setearConsulta("UPDATE COMPRA SET Estado = @activo WHERE IdCompra = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RegistrarRecepcionYActualizarStock(int idCompra)
        {
            var datos = new AccesoDatos();

            datos.setearConsulta("UPDATE COMPRA SET FechaRecepcion = @fecha WHERE IdCompra = @id");
            datos.setearParametro("@fecha", DateTime.Now);
            datos.setearParametro("@id", idCompra);
            datos.ejecutarAccion();


            List<DetalleCompra> detalles = ObtenerDetalles(idCompra);

            foreach (var d in detalles)
            {
                ActualizarStockProducto(d.IdProducto, d.Cantidad);
            }
        }


    }
}
