using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> ListarProductos(bool mostrarInactivos = false)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();


            try
            {

                string consulta = @"
                                SELECT 
                                    P.IdProducto,
                                    P.NombreProducto,
                                    P.DescripcionProducto,
                                    P.UrlImagen,
                                    P.PrecioProducto,
                                    P.Stock,
                                    P.IdMarca      AS IdMarcaFk,
                                    P.IdCategoria  AS IdCategoriaFk,
                                    P.Estado,
                                    M.NombreMarca,
                                    C.NombreCategoria
                                FROM Producto P
                                INNER JOIN Marcas     M ON M.IdMarca = P.IdMarca
                                INNER JOIN Categorias C ON C.IdCategoria = P.IdCategoria 
                                ";
                
                if (!mostrarInactivos)
                {
                    consulta += "WHERE P.Estado = 1";
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.IdMarcaFk = (int)datos.Lector["IdMarcaFk"];
                    aux.IdCategoriaFk = (int)datos.Lector["IdCategoriaFk"];
                    aux.NombreProducto = (string)datos.Lector["NombreProducto"];
                    aux.DescripcionProducto = (string)datos.Lector["DescripcionProducto"];
                    aux.UrlImagen = datos.Lector["UrlImagen"] is DBNull ? null : (string)datos.Lector["UrlImagen"];
                    aux.PrecioProducto = (decimal)datos.Lector["PrecioProducto"];
                    aux.IdMarca = new Marca { NombreMarca = (string)datos.Lector["NombreMarca"] };
                    aux.IdCategoria = new Categoria { NombreCategoria = (string)datos.Lector["NombreCategoria"] };
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Estado = (bool)datos.Lector["Estado"];


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


        public void AgregarProducto(Producto p)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (ExisteProducto(p.NombreProducto))
                    throw new Exception("El Producto ya existe.");

                datos.setearConsulta(@"
                                INSERT INTO Producto
                                (NombreProducto, DescripcionProducto, UrlImagen, PrecioProducto, Stock, IdMarca, IdCategoria, Estado)
                                VALUES
                                (@nombre, @descripcion, @urlImg, @precio, @stock, @idMarca, @idCategoria, 1);
                                SELECT SCOPE_IDENTITY();");

                datos.setearParametro("@nombre", p.NombreProducto);
                datos.setearParametro("@descripcion", (object)p.DescripcionProducto ?? DBNull.Value);
                datos.setearParametro("@urlImg", (object)p.UrlImagen ?? DBNull.Value);
                datos.setearParametro("@precio", p.PrecioProducto);
                datos.setearParametro("@stock", p.Stock);
                datos.setearParametro("@idMarca", p.IdMarcaFk);
                datos.setearParametro("@idCategoria", p.IdCategoriaFk);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Producto ObtenerPorId(int id)
        {
            var datos = new AccesoDatos();
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
                                    P.Estado
                                FROM Producto P
                                WHERE P.IdProducto = @id;");

                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Producto
                    {
                        IdProducto = (int)datos.Lector["IdProducto"],
                        NombreProducto = (string)datos.Lector["NombreProducto"],
                        DescripcionProducto = datos.Lector["DescripcionProducto"] as string,
                        UrlImagen = datos.Lector["UrlImagen"] as string,
                        PrecioProducto = (decimal)datos.Lector["PrecioProducto"],
                        Stock = (int)datos.Lector["Stock"],
                        IdMarcaFk = (int)datos.Lector["IdMarcaFk"],
                        IdCategoriaFk = (int)datos.Lector["IdCategoriaFk"],
                        Estado = (bool)datos.Lector["Estado"]
                    };
                }
                return null;
            }
            finally { datos.cerrarConexion(); }
        }
        public void Modificar(Producto p)
        {
            var datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"
                                    UPDATE Producto SET
                                        NombreProducto = @nombre,
                                        DescripcionProducto = @desc,
                                        UrlImagen = @url,
                                        PrecioProducto = @precio,
                                        Stock = @stock,
                                        IdMarca = @idMarca,
                                        IdCategoria = @idCategoria,
                                        Estado = @estado
                                    WHERE IdProducto = @id;");

                datos.setearParametro("@nombre", p.NombreProducto);
                datos.setearParametro("@desc", (object)p.DescripcionProducto ?? DBNull.Value);
                datos.setearParametro("@url", (object)p.UrlImagen ?? DBNull.Value);
                datos.setearParametro("@precio", p.PrecioProducto);
                datos.setearParametro("@stock", p.Stock);
                datos.setearParametro("@idMarca", p.IdMarcaFk);
                datos.setearParametro("@idCategoria", p.IdCategoriaFk);
                datos.setearParametro("@id", p.IdProducto);
                datos.setearParametro("@estado", p.Estado);

                datos.ejecutarAccion();
            }
            finally { datos.cerrarConexion(); }
        }

        public void eliminarProductoLogico(int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update PRODUCTO set Estado = @activo Where IdProducto = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ExisteProducto(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM PRODUCTO WHERE NombreProducto = @nombre");
                datos.setearParametro("@nombre", nombre);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    int cantidad = (int)datos.Lector[0];
                    return cantidad > 0;
                }

                return false;
            }
            catch
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}

