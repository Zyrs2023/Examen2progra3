using System;

namespace Examen2.Controllers
{
    public partial class Facturacion
    {
        // Campo estático para la instancia de Articulos
        private static Articulos articulosManager = new Articulos();

        // Método para realizar la facturación
        public string Facturar(Categoria categoriaManager, Vendedor vendedorManager, string codigo, int codigoCategoria, string codigoVendedor, int cantidad)
        {
            try
            {
                // Verificar si el artículo existe utilizando el campo estático articulosManager
                int indice = articulosManager.ObtenerIndiceArticulo(codigo);
                if (indice != -1) // Si se encontró el artículo
                {
                    // Obtener el nombre, precio y cantidad del artículo utilizando el campo estático
                    string nombreArticulo = articulosManager.Nombre[indice];
                    double precioArticulo = articulosManager.Precio[indice];
                    int cantidadDisponible = articulosManager.Cantidad[indice];

                    // Verificar si la cantidad solicitada está disponible en inventario
                    if (cantidad > cantidadDisponible)
                    {
                        return "La cantidad solicitada excede la cantidad disponible en inventario.";
                    }

                    // Verificar si la categoría asignada está en la lista de categorías existentes
                    if (!categoriaManager.ExisteCategoria(codigoCategoria))
                    {
                        return "La categoría ingresada no existe.";
                    }

                    // Verificar si el vendedor existe
                    if (!vendedorManager.ListadoVendedores().ContainsKey(codigoVendedor))
                    {
                        return "El código de vendedor ingresado no existe.";
                    }

                    // Aplicar la promoción según la categoría del artículo
                    double descuento = categoriaManager.AplicarDescuento(precioArticulo);
                    double precioConDescuento = precioArticulo - descuento;

                    // Calcular el total de la venta con descuento
                    double totalVenta = precioConDescuento * cantidad;

                    // Retornar el total de la venta formateado
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
