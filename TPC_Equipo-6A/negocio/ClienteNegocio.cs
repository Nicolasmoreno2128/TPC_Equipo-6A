using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select IdCliente, Nombre, Cuit, Descripcion, Telefono, Email, Estado from Cliente");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Cuit = (string)datos.Lector["Cuit"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
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

        public void agregarCliente(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO CLIENTE (Nombre, Cuit, Descripcion, Telefono, Email, Estado)values(@Nombre, @Cuit, @Descripcion, @Telefono, @Email, 1)");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Cuit", nuevo.Cuit);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@Email", nuevo.Email);
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

        public void ModificarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update CLIENTE set Nombre = @Nombre, Cuit = @Cuit, Descripcion = @Descripcion, Telefono = @Telefono, Email = @Email where IdCliente = @Id");
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Cuit", cliente.Cuit);
                datos.setearParametro("@Descripcion", cliente.Descripcion);
                datos.setearParametro("@Telefono", cliente.Telefono);
                datos.setearParametro("@Email", cliente.Email);
                datos.setearParametro("@Id", cliente.IdCliente);


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

        public Cliente ObtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdCliente, Nombre, Cuit, Descripcion, Telefono, Email  FROM CLIENTE WHERE IdCliente = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Cuit = (string)datos.Lector["Cuit"];
                    cliente.Descripcion = (string)datos.Lector["Descripcion"];
                    cliente.Telefono = (string)datos.Lector["Telefono"];
                    cliente.Email = (string)datos.Lector["Email"];


                    return cliente;
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

