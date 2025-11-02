using dominio;
using negocio;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> ListarMarcas()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select IdMarca, NombreMarca, DescripcionMarca, Estado from MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.NombreMarca = (string)datos.Lector["NombreMarca"];
                    aux.DescripcionMarca = (string)datos.Lector["DescripcionMarca"];
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

        public void agregarMarca(Marca nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO MARCAS (NombreMarca, DescripcionMarca, Estado)values(@Nombre, @Descripcion, 1)");
                datos.setearParametro("@Nombre", nueva.NombreMarca);
                datos.setearParametro("@Descripcion", nueva.DescripcionMarca);
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

        public void EliminarMarca(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from MARCAS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificarMarca(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Marcas SET NombreMarca = @nombre, DescripcionMarca = @descripcion WHERE IdMarca = @id");
                datos.setearParametro("@nombre", marca.NombreMarca);
                datos.setearParametro("@Descripcion", marca.DescripcionMarca);
                datos.setearParametro("@Id", marca.IdMarca);
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

        public Marca ObtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdMarca, NombreMarca, DescripcionMarca  FROM Marcas WHERE IdMarca = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.IdMarca = (int)datos.Lector["IdMarca"];
                    marca.NombreMarca = (string)datos.Lector["NombreMarca"];
                    marca.DescripcionMarca = datos.Lector["DescripcionMarca"] == DBNull.Value
                              ? string.Empty
                              : (string)datos.Lector["DescripcionMarca"];
                    return marca;
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



    }

}
