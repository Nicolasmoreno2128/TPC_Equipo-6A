using dominio;
using dominio.dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class InformeNegocio
    {
        public List<Informe.ClienteCompraReporte> TopClientesCompras()
        {
            List<Informe.ClienteCompraReporte> lista = new List<Informe.ClienteCompraReporte>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT TOP 10 C.IdCliente, C.Nombre, COUNT(*) AS CantidadCompras FROM VENTA VE INNER JOIN CLIENTE C ON C.IdCliente = VE.IdCliente GROUP BY C.IdCliente, C.Nombre ORDER BY CantidadCompras DESC;");

                datos.ejecutarLectura();
                 
                while (datos.Lector.Read())
                {
                    lista.Add(new Informe.ClienteCompraReporte
                    {
                        IdCliente = (int)datos.Lector["IdCliente"],
                        Nombre = datos.Lector["Nombre"].ToString(),
                        CantidadCompras = (int)datos.Lector["CantidadCompras"]
                    });
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public decimal ObtenerTotalAnual()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT SUM(TotalVenta) AS TotalAnual FROM VENTA WHERE YEAR(FechaVenta) = YEAR(GETDATE())");
                datos.ejecutarLectura();

                if (datos.Lector.Read() && datos.Lector["TotalAnual"] != DBNull.Value)
                    return Convert.ToDecimal(datos.Lector["TotalAnual"]);

                return 0;
            }
            finally { datos.cerrarConexion(); }
        }

        public decimal ObtenerTotalPorMes(int mes)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "SELECT SUM(TotalVenta) AS TotalMes FROM VENTA " +
                    "WHERE MONTH(FechaVenta) = @mes AND YEAR(FechaVenta) = YEAR(GETDATE())"
                );
                datos.setearParametro("@mes", mes);
                datos.ejecutarLectura();

                if (datos.Lector.Read() && datos.Lector["TotalMes"] != DBNull.Value)
                    return Convert.ToDecimal(datos.Lector["TotalMes"]);

                return 0;
            }
            finally { datos.cerrarConexion(); }
        }
        public List<MovimientoProducto> ObtenerMovimientosProducto(int idProducto)
        {
            List<MovimientoProducto> lista = new List<MovimientoProducto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT 
                C.FechaCompra AS Fecha,
                'COMPRA' AS Movimiento,
                DC.Cantidad AS Cantidad
            FROM DETALLE_COMPRA DC
            INNER JOIN COMPRA C ON C.IdCompra = DC.IdCompra
            WHERE DC.IdProducto = @idProducto

            UNION ALL

            SELECT
                V.FechaVenta AS Fecha,
                'VENTA' AS Movimiento,
                -DV.Cantidad AS Cantidad
            FROM DETALLE_VENTA DV
            INNER JOIN VENTA V ON V.IdVenta = DV.IdVenta
            WHERE DV.IdProducto = @idProducto

            ORDER BY Fecha ASC;
        ");

                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MovimientoProducto mov = new MovimientoProducto
                    {
                        Fecha = (DateTime)datos.Lector["Fecha"],
                        Movimiento = datos.Lector["Movimiento"].ToString(),
                        Cantidad = Convert.ToInt32(datos.Lector["Cantidad"])
                    };

                    lista.Add(mov);
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
    }
}
