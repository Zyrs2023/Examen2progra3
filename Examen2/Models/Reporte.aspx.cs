using Examen2.Controllers;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Examen2.Models
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Articulos articulos = GetArticulosManager();

               
                Vendedor vendedor = ObtenerInstanciaVendedor();
                Categoria categoria = ObtenerInstanciaCategoria();

                
                GeneradorReporte generadorReporte = new GeneradorReporte();

                generadorReporte.GenerarReporteArticulos(GridViewArticulos, articulos, vendedor, categoria);

                generadorReporte.GenerarReporteCategorias(GridViewCategorias, categoria);

                generadorReporte.GenerarReporteVendedores(GridViewVendedores, vendedor);
            }
        }


        private Vendedor ObtenerInstanciaVendedor()
        {
       
            Vendedor vendedor = new Vendedor(); 

            return vendedor;
        }

      
        private Categoria ObtenerInstanciaCategoria()
        {
 
            Categoria categoria = new Categoria(); 


            return categoria;
        }


        protected Articulos GetArticulosManager()
        {
   
            if (Session["ArticulosManager"] == null)
            {
              
                Session["ArticulosManager"] = new Articulos();
            }

        
            return (Articulos)Session["ArticulosManager"];
        }
    }
}
