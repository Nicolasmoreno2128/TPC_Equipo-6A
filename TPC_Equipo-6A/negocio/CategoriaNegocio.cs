using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> ListarCategoria()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select IdCategoria, NombreCategoria, DescripcionCategoria, Estado from CATEGORIAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Nombre = (string)datos.Lector["NombreCategoria"];
                    aux.Descripcion = (string)datos.Lector["DescripcionCategoria"];
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
        public void agregarCategoria(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO CATEGORIAS (NombreCategoria, DescripcionCategoria, Estado)values(@Nombre, @Descripcion, 1)");
                datos.setearParametro("@Nombre", nueva.Nombre);
                datos.setearParametro("@Descripcion", nueva.Descripcion);
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
        public void EliminarCategoria(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from CATEGORIAS where id = @id");
                datos.setearParametro("@id", id);
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
                datos.setearConsulta("update CATEGORIAS set DescripcionCategoria = @Descripcion where Id = @Id");
                datos.setearParametro("@Descripcion", categoria.Descripcion);
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




    }
}
