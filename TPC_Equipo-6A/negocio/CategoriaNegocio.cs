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
    public class CategoriaNegocio
    {
        public List<Categoria> ListarCategoria(bool mostrarInactivos = false)
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT IdCategoria, NombreCategoria, DescripcionCategoria, Estado FROM Categorias";

                if (!mostrarInactivos)
                    consulta += " WHERE Estado = 1";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.NombreCategoria = (string)datos.Lector["NombreCategoria"];
                    aux.DescripcionCategoria = (string)datos.Lector["DescripcionCategoria"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    lista.Add(aux);
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarCategoria(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (ExisteCategoria(nueva.NombreCategoria))
                    throw new Exception("La Categoria ya existe.");

                datos.setearConsulta("INSERT INTO CATEGORIAS (NombreCategoria, DescripcionCategoria, Estado)values(@Nombre, @Descripcion, 1)");
                datos.setearParametro("@Nombre", nueva.NombreCategoria);
                datos.setearParametro("@Descripcion", nueva.DescripcionCategoria);
                datos.ejecutarAccion();
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

        public void eliminarCategoriaLogico(int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update CATEGORIAS set Estado = @activo Where IdCategoria = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarCategoria(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update CATEGORIAS set NombreCategoria = @nombre, DescripcionCategoria = @Descripcion where IdCategoria = @Id");
                datos.setearParametro("@nombre", categoria.NombreCategoria);
                datos.setearParametro("@Descripcion", categoria.DescripcionCategoria);
                datos.setearParametro("@Id", categoria.IdCategoria);
                datos.ejecutarAccion();
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
        public Categoria ObtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdCategoria, NombreCategoria, DescripcionCategoria  FROM Categorias WHERE IdCategoria = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    categoria.NombreCategoria = (string)datos.Lector["NombreCategoria"];
                    categoria.DescripcionCategoria = datos.Lector["DescripcionCategoria"] == DBNull.Value
                              ? string.Empty
                              : (string)datos.Lector["DescripcionCategoria"];
                    return categoria;
                }

                return null;
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

        public bool ExisteCategoria(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM CATEGORIAS WHERE NombreCategoria = @nombre");
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
