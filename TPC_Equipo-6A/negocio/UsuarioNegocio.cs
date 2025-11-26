using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdUsuario, NombreUsuario, Nombre, Apellido, Rol, Email, Telefono, Estado FROM USUARIO where Estado = 1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];

                    aux.NombreUsuario = datos.Lector["NombreUsuario"] != DBNull.Value
                        ? (string)datos.Lector["NombreUsuario"]
                        : string.Empty;

                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    // Rol: convierto primero a int y luego valido
                    int rolVal = datos.Lector["Rol"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Rol"]) : 1; // default Vendedor
                    if (Enum.IsDefined(typeof(Rol), rolVal))
                        aux.Rol = (Rol)rolVal;
                    else
                        aux.Rol = Rol.Vendedor;

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void agregarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM USUARIO WHERE NombreUsuario = @NombreUsuario");
                datos.setearParametro("@NombreUsuario", nuevo.NombreUsuario);
                datos.ejecutarLectura();

                int count = 0;
                if (datos.Lector.Read())
                    count = (int)datos.Lector[0];
                datos.cerrarConexion();

                if (count > 0)
                    throw new Exception("El nombre de usuario ya existe.");
                datos = new AccesoDatos();
                datos.setearConsulta("INSERT INTO USUARIO (NombreUsuario, Contrasena, Nombre, Apellido, Rol, Email, Telefono, Estado)values(@NombreUsuario, @Contrasena, @Nombre, @Apellido, @Rol, @Email, @Telefono, 1)");
                datos.setearParametro("@NombreUsuario", nuevo.NombreUsuario);
                datos.setearParametro("@Contrasena", nuevo.Contrasena);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Rol", nuevo.Rol);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Telefono", nuevo.Telefono);
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

        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdUsuario, NombreUsuario, Contrasena, Nombre, Apellido, Rol, Email, Telefono, Estado " +
                                     "FROM USUARIO " +
                                     "WHERE NombreUsuario = @user AND Estado = 1");
                datos.setearParametro("@user", usuario.NombreUsuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    string passDb = datos.Lector["Contrasena"].ToString();

                    if (passDb.Equals(usuario.Contrasena, StringComparison.Ordinal))
                    {
                        usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                        usuario.NombreUsuario = datos.Lector["NombreUsuario"].ToString();
                        usuario.Nombre = datos.Lector["Nombre"].ToString();
                        usuario.Apellido = datos.Lector["Apellido"].ToString();
                        usuario.Rol = (Rol)datos.Lector["Rol"];
                        usuario.Email = datos.Lector["Email"].ToString();
                        usuario.Telefono = datos.Lector["Telefono"].ToString();
                        usuario.Estado = (bool)datos.Lector["Estado"];

                        return true;
                    }
                }
                return false;
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
        public Usuario ObtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = null;

            try
            {
                datos.setearConsulta("SELECT IdUsuario, NombreUsuario, Nombre, Apellido, Rol, Email, Telefono, Estado FROM USUARIO WHERE IdUsuario = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario = new Usuario
                    {
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        NombreUsuario = (string)datos.Lector["NombreUsuario"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Email = (string)datos.Lector["Email"],
                        Telefono = (string)datos.Lector["Telefono"],
                        Estado = (bool)datos.Lector["Estado"],
                        Rol = (Rol)Convert.ToInt32(datos.Lector["Rol"])
                    };
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"UPDATE USUARIO 
                            SET Nombre = @Nombre, 
                                Apellido = @Apellido, 
                                Rol = @Rol, 
                                Email = @Email, 
                                Telefono = @Telefono,
                                Estado = @Estado";

                if (!string.IsNullOrEmpty(usuario.Contrasena))
                    consulta += ", Contrasena = @Contrasena";

                consulta += " WHERE IdUsuario = @IdUsuario";

                datos.setearConsulta(consulta);

                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Rol", usuario.Rol);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@Estado", usuario.Estado);
                datos.setearParametro("@IdUsuario", usuario.IdUsuario);

                if (!string.IsNullOrEmpty(usuario.Contrasena))
                    datos.setearParametro("@Contrasena", usuario.Contrasena);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarUsuarioLogico(int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update USUARIO set Estado = @activo Where IdUsuario = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
