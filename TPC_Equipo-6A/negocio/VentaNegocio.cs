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
                    "C.IdCliente, C.Nombre, " +
                    "U.IdUsuario, U.NombreUsuario " +
                    "FROM VENTA V " +
                    "INNER JOIN CLIENTE C ON V.IdCliente = C.IdCliente " +
                    "INNER JOIN USUARIO U ON V.IdUsuario = U.IdUsuario"
                );

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.idVenta = (int)datos.Lector["IdVenta"];
                    aux.FechaVenta = (DateTime)datos.Lector["FechaVenta"];
                    aux.TotalVenta = (decimal)datos.Lector["TotalVenta"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Cliente.Nombre = (string)datos.Lector["Nombre"];

                    aux.Vendedor = new Usuario();
                    aux.Vendedor.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Vendedor.NombreUsuario = (string)datos.Lector["NombreUsuario"];

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

    }
}
