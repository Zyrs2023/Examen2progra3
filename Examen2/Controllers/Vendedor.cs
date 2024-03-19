using System.Collections.Generic;

namespace Examen2.Controllers
{
    // Clase base Vendedor
    public class Vendedor
    {
        // Estructura Diccionario con dos vendedores
        protected Dictionary<string, string> vendedores = new Dictionary<string, string>();

        // Constructor en blanco
        public Vendedor()
        {
            // Agregar vendedores de ejemplo
            vendedores.Add("001", "Vendedor1");
            vendedores.Add("002", "Vendedor2");
        }

        // Método ListadoVendedores
        public Dictionary<string, string> ListadoVendedores()
        {
            return vendedores;
        }

        // Función para obtener el nombre del vendedor por su código
        public string ObtenerNombreVendedor(string codigo)
        {
            if (vendedores.ContainsKey(codigo))
            {
                return vendedores[codigo];
            }
            else
            {
                return "Vendedor no encontrado";
            }
        }
    }

    // Clase Vendedor1 que implementa la interfaz IVendedor1
    public class Vendedor1 : Vendedor, IVendedor1
    {
        public string Nombre { get; }

        // Constructor con el nombre del vendedor ya asignado
        public Vendedor1()
        {
            Nombre = "Vendedor1";
        }

        // Método de la interfaz IVendedor1
        public void VentasContado()
        {
         
        }
    }

    // Clase Vendedor2 que implementa la interfaz IVendedor2
    public class Vendedor2 : Vendedor, IVendedor2
    {
        public string Nombre { get; }

        // Constructor con el nombre del vendedor ya asignado
        public Vendedor2()
        {
            Nombre = "Vendedor2";
        }

        // Método de la interfaz IVendedor2
        public string VentasCredito()
        {
            // Puedes implementar lógica específica aquí si es necesario
            return "Ventas a crédito realizadas";
        }
    }
}
