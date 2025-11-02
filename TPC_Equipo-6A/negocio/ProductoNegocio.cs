using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

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
                datos.setearConsulta("select P.IdProducto, P.NombreProducto, P.DescripcionProducto, P.UrlImagen, P.PrecioProducto, M.NombreMarca, C.NombreCategoria, P.Stock FROM PRODUCTO P, Categorias C, Marcas M where C.IdCategoria = P.IdCategoria and M.IdMarca = P.IdMarca and P.Estado = 1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Nombre = (string)datos.Lector["NombreProducto"];
                    aux.Descripcion = (string)datos.Lector["DescripcionProducto"];
                    aux.ImagenUrl = (string)datos.Lector["UrlImagen"];
                    aux.Precio = (decimal)datos.Lector["PrecioProducto"];
                    aux.Marca = new Marca();
                    aux.Marca.NombreMarca = (string)datos.Lector["NombreMarca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.NombreCategoria = (string)datos.Lector["NombreCategoria"];
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
