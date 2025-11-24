using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class VentaNegocio
    {
        public List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT V.IdVenta, V.FechaVenta, V.TotalVenta, V.Estado, " +
                    "C.IdCliente, C.Nombre AS NombreCliente, " +
                    "U.IdUsuario, U.NombreUsuario " +
                    "FROM VENTA V " +
                    "INNER JOIN CLIENTE C ON V.IdCliente = C.IdCliente " +
                    "INNER JOIN USUARIO U ON V.IdUsuario = U.IdUsuario " +
                    "WHERE V.Estado = 1"
                );

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.IdVenta = (int)datos.Lector["IdVenta"];
                    aux.FechaVenta = (DateTime)datos.Lector["FechaVenta"];
                    aux.TotalVenta = (decimal)datos.Lector["TotalVenta"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Cliente.Nombre = (string)datos.Lector["NombreCliente"];

                    aux.Usuario = new Usuario();
                    aux.Usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Usuario.NombreUsuario = (string)datos.Lector["NombreUsuario"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int AgregarVenta(Venta venta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO VENTA (IdCliente, FechaVenta, TotalVenta, IdUsuario, Estado) " +
                    "OUTPUT INSERTED.IdVenta " +
                    "VALUES (@IdCliente, @FechaVenta, @TotalVenta, @IdUsuario, @Estado)"
                );

                datos.setearParametro("@IdCliente", venta.Cliente.IdCliente);
                datos.setearParametro("@FechaVenta", venta.FechaVenta);
                datos.setearParametro("@TotalVenta", venta.TotalVenta);
                datos.setearParametro("@IdUsuario", venta.Usuario.IdUsuario);
                datos.setearParametro("@Estado", venta.Estado);

                int idVenta = (int)datos.ejecutarScalar();
                datos.cerrarConexion();

                foreach (var item in venta.Detalles)
                {

                    AccesoDatos datosDetalle = new AccesoDatos();
                    datosDetalle.setearConsulta(
                        "INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario) " +
                        "VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario)"
                    );

                    datosDetalle.setearParametro("@IdVenta", idVenta);
                    datosDetalle.setearParametro("@IdProducto", item.IdProducto);
                    datosDetalle.setearParametro("@Cantidad", item.Cantidad);
                    datosDetalle.setearParametro("@PrecioUnitario", item.PrecioUnitario);

                    datosDetalle.ejecutarAccion();
                    datosDetalle.cerrarConexion();

                    AccesoDatos datosStock = new AccesoDatos();
                    datosStock.setearConsulta(
                        "UPDATE PRODUCTO SET Stock = Stock - @Cantidad WHERE IdProducto = @IdProducto"
                    );

                    datosStock.setearParametro("@Cantidad", item.Cantidad);
                    datosStock.setearParametro("@IdProducto", item.IdProducto);

                    datosStock.ejecutarAccion();
                    datosStock.cerrarConexion();
                }

                return idVenta;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AnularVenta(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Recupero los detalles de la venta
                List<DetalleVenta> detalles = ListarDetallesPorVenta(idVenta);

                // Devuelvo el stock de cada producto
                foreach (var item in detalles)
                {
                    AccesoDatos datosStock = new AccesoDatos();
                    datosStock.setearConsulta(
                        "UPDATE PRODUCTO SET Stock = Stock + @Cantidad WHERE IdProducto = @IdProducto"
                    );

                    datosStock.setearParametro("@Cantidad", item.Cantidad);
                    datosStock.setearParametro("@IdProducto", item.IdProducto);

                    datosStock.ejecutarAccion();
                    datosStock.cerrarConexion();
                }

                // Marco la venta como anulada
                datos.setearConsulta("UPDATE VENTA SET Estado = 0 WHERE IdVenta = @IdVenta");
                datos.setearParametro("@IdVenta", idVenta);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public Venta ObtenerVentaPorId(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT V.IdVenta, V.FechaVenta, V.TotalVenta, V.Estado, " +
                    "C.IdCliente, C.Nombre AS NombreCliente, " +
                    "U.IdUsuario, U.NombreUsuario " +
                    "FROM VENTA V " +
                    "INNER JOIN CLIENTE C ON V.IdCliente = C.IdCliente " +
                    "INNER JOIN USUARIO U ON V.IdUsuario = U.IdUsuario " +
                    "WHERE V.IdVenta = @IdVenta"
                );

                datos.setearParametro("@IdVenta", idVenta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.IdVenta = (int)datos.Lector["IdVenta"];
                    aux.FechaVenta = (DateTime)datos.Lector["FechaVenta"];
                    aux.TotalVenta = (decimal)datos.Lector["TotalVenta"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Cliente.Nombre = (string)datos.Lector["NombreCliente"];

                    aux.Usuario = new Usuario();
                    aux.Usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Usuario.NombreUsuario = (string)datos.Lector["NombreUsuario"];

                    return aux;
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<DetalleVenta> ListarDetallesPorVenta(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT DV.IdDetalleVenta, DV.IdVenta, DV.IdProducto, DV.Cantidad, DV.PrecioUnitario, " +
                    "P.NombreProducto " +
                    "FROM DETALLE_VENTA DV " +
                    "INNER JOIN PRODUCTO P ON DV.IdProducto = P.IdProducto " +
                    "WHERE DV.IdVenta = @IdVenta"
                );

                datos.setearParametro("@IdVenta", idVenta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetalleVenta det = new DetalleVenta();
                    det.IdDetalleVenta = (int)datos.Lector["IdDetalleVenta"];
                    det.IdVenta = (int)datos.Lector["IdVenta"];
                    det.IdProducto = (int)datos.Lector["IdProducto"];
                    det.Cantidad = (int)datos.Lector["Cantidad"];
                    det.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];

                    det.Producto = new Producto();
                    det.Producto.IdProducto = det.IdProducto;
                    det.Producto.NombreProducto = (string)datos.Lector["NombreProducto"];

                    lista.Add(det);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }
}
