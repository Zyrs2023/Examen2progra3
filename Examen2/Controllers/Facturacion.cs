using System;

namespace Examen2.Controllers
{
    public partial class Facturacion
    {
       
        private static Articulos articulosManager = new Articulos();

     
        public string Facturar(Categoria categoriaManager, Vendedor vendedorManager, string codigo, int codigoCategoria, string codigoVendedor, int cantidad)
        {
            try
            {
                
                int indice = articulosManager.ObtenerIndiceArticulo(codigo);
                if (indice != -1) 
                {
                   
                    string nombreArticulo = articulosManager.Nombre[indice];
                    double precioArticulo = articulosManager.Precio[indice];
                    int cantidadDisponible = articulosManager.Cantidad[indice];

                    
                    if (cantidad > cantidadDisponible)
                    {
                        return "La cantidad solicitada excede la cantidad disponible en inventario.";
                    }

                    
                    if (!categoriaManager.ExisteCategoria(codigoCategoria))
                    {
                        return "La categoría ingresada no existe.";
                    }

                    
                    if (!vendedorManager.ListadoVendedores().ContainsKey(codigoVendedor))
                    {
                        return "El código de vendedor ingresado no existe.";
                    }

                   
                    double descuento = categoriaManager.AplicarDescuento(precioArticulo);
                    double precioConDescuento = precioArticulo - descuento;

                    
                    double totalVenta = precioConDescuento * cantidad;

                 
                    return $"Total de la venta con descuento: {totalVenta:C}";
                }
                else
                {
                    return "El código de artículo ingresado no existe.";
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

    }
}
