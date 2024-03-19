using System.Collections.Generic;

namespace Examen2.Controllers
{
   
    public class Vendedor
    {
       
        protected Dictionary<string, string> vendedores = new Dictionary<string, string>();

        
        public Vendedor()
        {
           
            vendedores.Add("001", "Vendedor1");
            vendedores.Add("002", "Vendedor2");
        }

        
        public Dictionary<string, string> ListadoVendedores()
        {
            return vendedores;
        }

       
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


    public class Vendedor1 : Vendedor, IVendedor1
    {
        public string Nombre { get; }

       
        public Vendedor1()
        {
            Nombre = "Vendedor1";
        }

       
        public void VentasContado()
        {
         
        }
    }

  
    public class Vendedor2 : Vendedor, IVendedor2
    {
        public string Nombre { get; }

        
        public Vendedor2()
        {
            Nombre = "Vendedor2";
        }

  
        public string VentasCredito()
        {
            
            return "Ventas a crédito realizadas";
        }
    }
}
