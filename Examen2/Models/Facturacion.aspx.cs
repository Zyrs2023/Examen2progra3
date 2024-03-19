using Examen2.Controllers;
using Examen2.Models;
using System;
using System.Text;

namespace Examen2.Controllers
{
    public partial class Facturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ArticulosManager"] == null)
            {
                Session["ArticulosManager"] = new Articulos();
            }
        }

        protected Articulos GetArticulosManager()
        {
            return (Articulos)Session["ArticulosManager"];
        }

        protected void SetArticulosManager(Articulos articulos)
        {
            Session["ArticulosManager"] = articulos;
        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            Articulos articulosManager = GetArticulosManager();

            string codigoArticulo = txtCodigoArticulo.Text.Trim();
            int cantidadSolicitada;
            if (!int.TryParse(txtCantidad.Text, out cantidadSolicitada))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa una cantidad válida.');", true);
                return;
            }

            int indiceArticulo = articulosManager.ObtenerIndiceArticulo(codigoArticulo);

            if (indiceArticulo != -1)
            {
                if (articulosManager.Cantidad[indiceArticulo] >= cantidadSolicitada)
                {
                    double precioArticulo = articulosManager.Precio[indiceArticulo];

                    Categoria categoriaManager;
                    int codigoCategoria;
                    if (!int.TryParse(txtCategoria.Text, out codigoCategoria))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa un código de categoría válido.');", true);
                        return;
                    }

                    switch (codigoCategoria)
                    {
                        case 1:
                            categoriaManager = new Categoria1();
                            break;
                        case 2:
                            categoriaManager = new Categoria2();
                            break;
                        case 3:
                            categoriaManager = new Categoria3();
                            break;
                        default:
                            categoriaManager = new Categoria();
                            break;
                    }

                    double descuento = categoriaManager.AplicarDescuento(precioArticulo);
                    double totalVenta = (precioArticulo - descuento) * cantidadSolicitada;

                    articulosManager.Cantidad[indiceArticulo] -= cantidadSolicitada;

                    SetArticulosManager(articulosManager);

                    Articulo articulo = new Articulo
                    {
                        Codigo = articulosManager.Codigo[indiceArticulo],
                        Nombre = articulosManager.Nombre[indiceArticulo],
                        Precio = articulosManager.Precio[indiceArticulo]
                    };

                    MostrarFactura(totalVenta, articulo, descuento);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No hay suficiente stock disponible.');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Artículo no encontrado.');", true);
            }
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtCodigoArticulo.Text = "";
            txtCategoria.Text = "";
            txtCodigoVendedor.Text = "";
            txtCantidad.Text = "";
            txtNombreArticulo.Text = "";
            txtPrecio.Text = "";
            txtExistencia.Text = "";
        }

        protected void txtCodigoArticulo_TextChanged(object sender, EventArgs e)
        {
            Articulos articulosManager = GetArticulosManager();
            string codigoArticulo = txtCodigoArticulo.Text.Trim();

            int indiceArticulo = articulosManager.ObtenerIndiceArticulo(codigoArticulo);

            if (indiceArticulo != -1)
            {
                txtNombreArticulo.Text = articulosManager.Nombre[indiceArticulo];
                txtPrecio.Text = articulosManager.Precio[indiceArticulo].ToString();
                txtExistencia.Text = articulosManager.Cantidad[indiceArticulo].ToString();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Artículo no encontrado.');", true);
            }
        }

        private void MostrarFactura(double totalVenta, Articulo articulo, double descuento)
        {
            string factura = $"Código: {articulo.Codigo}\n" +
                             $"Nombre: {articulo.Nombre}\n" +
                             $"Precio unitario: ${articulo.Precio:N2}\n" +
                             $"Cantidad: {txtCantidad.Text}\n" +
                             $"Descuento aplicado: ${descuento:N2}\n" +
                             $"Total: ${totalVenta:N2}";

            StringBuilder script = new StringBuilder();
            script.Append("<script type=\"text/javascript\">");
            script.Append("alert(\"" + factura.Replace("\n", "\\n").Replace("\"", "\\\"") + "\");");
            script.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "FacturaScript", script.ToString());
        }


    }
}
