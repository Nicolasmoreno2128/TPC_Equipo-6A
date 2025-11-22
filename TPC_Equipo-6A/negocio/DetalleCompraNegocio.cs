using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DetalleCompraNegocio
    {
        public void AgregarDetalleCompra(DetalleCompra detalle)
        {
            var datos = new AccesoDatos();

            datos.setearConsulta(@"
            INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, Cantidad, PrecioUnitario)
            VALUES (@idCompra, @idProd, @cant, @precio)");

            datos.setearParametro("@idCompra", detalle.IdCompra);
            datos.setearParametro("@idProd", detalle.IdProducto);
            datos.setearParametro("@cant", detalle.Cantidad);
            datos.setearParametro("@precio", detalle.PrecioUnitario);
            
            datos.ejecutarAccion();
        }
    }
}
