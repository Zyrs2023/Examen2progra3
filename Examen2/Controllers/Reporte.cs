using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Examen2.Controllers
{
    public class GeneradorReporte
    {
   
        public class ArticuloReporteItem
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public double Precio { get; set; }
            public int Cantidad { get; set; }
            public string Categoria { get; set; }
            public string Vendedor { get; set; }
        }

      
        public class CategoriaReporteItem
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
        }

       
        public class VendedorReporteItem
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
        }

      
        public void GenerarReporteArticulos(GridView gridView, Articulos articulos, Vendedor vendedor, Categoria categoria)
        {
            List<ArticuloReporteItem> reporteArticulos = new List<ArticuloReporteItem>();

            for (int i = 0; i < articulos.contador; i++)
            {
                string codigo = articulos.GetCodigo(i);
                string nombre = articulos.GetNombre(i);
                double precio = articulos.GetPrecio(i);
                int cantidad = articulos.GetCantidad(i);
                string nombreCategoria = ObtenerCategoriaPorCodigo(codigo, categoria);
                string nombreVendedor = ObtenerNombreVendedorPorCodigo(codigo, vendedor);

                reporteArticulos.Add(new ArticuloReporteItem { Codigo = codigo, Nombre = nombre, Precio = precio, Cantidad = cantidad, Categoria = nombreCategoria, Vendedor = nombreVendedor });
            }

            gridView.DataSource = reporteArticulos;
            gridView.DataBind();
        }

    
        public void GenerarReporteCategorias(GridView gridView, Categoria categoria)
        {
            List<CategoriaReporteItem> reporteCategorias = new List<CategoriaReporteItem>();

            List<int> categorias = categoria.ListadoCategorias();
            foreach (var codigo in categorias)
            {
                string nombre = categoria.ObtenerNombreCategoria(codigo);
                reporteCategorias.Add(new CategoriaReporteItem { Codigo = codigo.ToString(), Nombre = nombre });
            }

            gridView.DataSource = reporteCategorias;
            gridView.DataBind();
        }

        public void GenerarReporteVendedores(GridView gridView, Vendedor vendedor)
        {
            List<VendedorReporteItem> reporteVendedores = new List<VendedorReporteItem>();

            var vendedores = vendedor.ListadoVendedores();
            foreach (var kvp in vendedores)
            {
                reporteVendedores.Add(new VendedorReporteItem { Codigo = kvp.Key, Nombre = kvp.Value });
            }

            gridView.DataSource = reporteVendedores;
            gridView.DataBind();
        }

        private string ObtenerCategoriaPorCodigo(string codigo, Categoria categoria)
        {
            if (int.TryParse(codigo, out int codigoCategoria))
            {
                if (categoria.ExisteCategoria(codigoCategoria))
                {
                    return $"Categoría {codigoCategoria}";
                }
                else
                {
                    return "Categoría no encontrada";
                }
            }
            else
            {
                return "Código de categoría no válido";
            }
        }

     
        private string ObtenerNombreVendedorPorCodigo(string codigo, Vendedor vendedor)
        {
            return vendedor.ObtenerNombreVendedor(codigo);
        }
    }
}
