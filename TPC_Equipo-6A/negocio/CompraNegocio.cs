using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

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
                C.IdProveedor AS IdProveedorFk,
                C.Estado,
                
                P.Nombre        AS NombreProveedor,
                P.Descripcion   AS DescripcionProveedor,
                P.Cuit,
                P.Telefono,
                P.Email
            FROM COMPRA C
            INNER JOIN PROVEEDOR P ON P.IdProveedor = C.IdProveedor
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

                    aux.Proveedor = new Proveedor
                    {
                        IdProveedor = (int)datos.Lector["IdProveedorFk"],
                        Nombre = (string)datos.Lector["NombreProveedor"],
                        Descripcion = (string)datos.Lector["DescripcionProveedor"],
                        Cuit = (string)datos.Lector["Cuit"],
                        Telefono = (string)datos.Lector["Telefono"],
                        Email = (string)datos.Lector["Email"]
                    };

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
