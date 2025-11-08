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
                datos.setearConsulta("select IdUsuario,Rol from USUARIO WHERE NombreUsuario = @nombreUsuario and Contrasena = @contrasena");
                datos.setearParametro("@nombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@contrasena", usuario.Contrasena);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.Rol = (int)(datos.Lector["Rol"]) == 0 ? Rol.Administrador : Rol.Vendedor;
                    return true;
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

    }
}
