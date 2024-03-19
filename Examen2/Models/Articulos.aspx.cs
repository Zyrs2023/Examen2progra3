using System;
using System.Collections.Generic;
using System.Web.UI;
using Examen2.Controllers;

namespace Examen2.Models
{
    public class Articulo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }

    public partial class articulos : System.Web.UI.Page
    {
        private static Articulos articulosManager = new Articulos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView();
            }
        }

        private void CargarGridView()
        {
            List<Articulo> articulosList = new List<Articulo>();
            Articulos articulosManager = GetArticulosManager();

            for (int i = 0; i < articulosManager.contador; i++)
            {
                Articulo articulo = new Articulo();
                articulo.Codigo = articulosManager.Codigo[i];
                articulo.Nombre = articulosManager.Nombre[i];
                articulo.Precio = articulosManager.Precio[i];
                articulo.Cantidad = articulosManager.Cantidad[i];

                articulosList.Add(articulo);
            }

            GridViewArticulos.DataSource = articulosList;
            GridViewArticulos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            double precio;
            int cantidad;
            if (!double.TryParse(txtPrecio.Text, out precio) || !int.TryParse(txtCantidad.Text, out cantidad))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa un precio y una cantidad válidos.');", true);
                return;
            }

            Articulos articulosManager = GetArticulosManager();
            string resultado = articulosManager.AgregarArticulo(codigo, nombre, precio, cantidad);

            SetArticulosManager(articulosManager);

            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{resultado}');", true);

            LimpiarCampos();
            CargarGridView();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Articulos articulosManager = GetArticulosManager();

            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            if (double.TryParse(txtPrecio.Text, out double precio) && int.TryParse(txtCantidad.Text, out int cantidad))
            {
                articulosManager.ModificarArticulo(codigo, nombre, precio, cantidad);
                SetArticulosManager(articulosManager);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Artículo modificado correctamente.');", true);

                LimpiarCampos();
                CargarGridView();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa un precio y una cantidad válidos.');", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulos articulosManager = GetArticulosManager();

            string codigo = txtCodigo.Text;
            articulosManager.BorrarArticulo(codigo);
            SetArticulosManager(articulosManager);

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Artículo eliminado correctamente.');", true);

            LimpiarCampos();
            CargarGridView();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Articulos articulosManager = GetArticulosManager();

            string codigo = txtCodigo.Text;
            int indice = articulosManager.ObtenerIndiceArticulo(codigo);

            if (indice != -1)
            {
                List<Articulo> articulosList = new List<Articulo>();
                Articulo articulo = new Articulo
                {
                    Codigo = articulosManager.Codigo[indice],
                    Nombre = articulosManager.Nombre[indice],
                    Precio = articulosManager.Precio[indice],
                    Cantidad = articulosManager.Cantidad[indice]
                };
                articulosList.Add(articulo);

                GridViewArticulos.DataSource = articulosList;
                GridViewArticulos.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Artículo no encontrado.');", true);
            }

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }

        protected Articulos GetArticulosManager()
        {
            if (Session["ArticulosManager"] == null)
            {
                Session["ArticulosManager"] = new Articulos();
            }
            return (Articulos)Session["ArticulosManager"];
        }

        protected void SetArticulosManager(Articulos articulos)
        {
            Session["ArticulosManager"] = articulos;
        }
    }
}
