using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta(@"
            SELECT 
                P.IdProducto,
                P.NombreProducto,
                P.DescripcionProducto,
                P.UrlImagen,
                P.PrecioProducto,
                P.Stock,
                P.IdMarca      AS IdMarcaFk,
                P.IdCategoria  AS IdCategoriaFk,
                M.NombreMarca,
                C.NombreCategoria
            FROM Producto P
            INNER JOIN Marcas     M ON M.IdMarca = P.IdMarca
            INNER JOIN Categorias C ON C.IdCategoria = P.IdCategoria
            WHERE P.Estado = 1;");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.IdMarcaFk = (int)datos.Lector["IdMarcaFk"];
                    aux.IdCategoriaFk = (int)datos.Lector["IdCategoriaFk"];
                    aux.NombreProducto = (string)datos.Lector["NombreProducto"];
                    aux.DescripcionProducto = (string)datos.Lector["DescripcionProducto"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.PrecioProducto = (decimal)datos.Lector["PrecioProducto"];
                    aux.IdMarca = new Marca { NombreMarca = (string)datos.Lector["NombreMarca"] };
                    aux.IdCategoria = new Categoria { NombreCategoria = (string)datos.Lector["NombreCategoria"] };
                    aux.Stock = (int)datos.Lector["Stock"];


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
