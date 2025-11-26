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
        public List<Marca> ListarMarcas(bool mostrarInactivos = false)
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = mostrarInactivos
                    ? "SELECT IdMarca, NombreMarca, DescripcionMarca, Estado FROM MARCAS"
                    : "SELECT IdMarca, NombreMarca, DescripcionMarca, Estado FROM MARCAS WHERE Estado = 1";

                datos.setearConsulta(consulta);
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


        public void agregarMarca(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Validación previa
                if (ExisteMarca(marca.NombreMarca))
                    throw new Exception("La marca ya existe.");

                datos.setearConsulta("INSERT INTO MARCAS (NombreMarca, DescripcionMarca) VALUES (@nombre, @descripcion)");
                datos.setearParametro("@nombre", marca.NombreMarca);
                datos.setearParametro("@descripcion", marca.DescripcionMarca);

                datos.ejecutarAccion();
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


        public void eliminarMarcaLogico(int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update MARCAS set Estado = @activo Where IdMarca = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);
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
                datos.setearParametro("@descripcion", marca.DescripcionMarca);
                datos.setearParametro("@id", marca.IdMarca);
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

        public bool ExisteMarca(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM MARCAS WHERE NombreMarca = @nombre");
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
