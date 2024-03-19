using System;
using System.Collections.Generic;

namespace Examen2.Controllers
{
   
    public class Categoria
    {
    
        protected List<int> categorias = new List<int> { 1, 2, 3 };

      
        public List<int> ListadoCategorias()
        {
            return categorias;
        }

        
        public bool ExisteCategoria(int categoria)
        {
            return categorias.Contains(categoria);
        }

        
        public string ObtenerNombreCategoria(int codigo)
        {
            switch (codigo)
            {
                case 1:
                    return "Categoría 1";
                case 2:
                    return "Categoría 2";
                case 3:
                    return "Categoría 3";
                default:
                    return "Categoría no encontrada";
            }
        }

      
        public virtual double AplicarDescuento(double precio)
        {
            return 0; 
        }
    }

    
    public class Categoria1 : Categoria
    {
        
        public override double AplicarDescuento(double precioArticulo)
        {
            double descuento = 0.15;
            return precioArticulo * descuento;
        }
    }

 
    public class Categoria2 : Categoria
    {
       
        public override double AplicarDescuento(double precioArticulo)
        {
          
            return precioArticulo / 2; 
        }
    }

  
    public class Categoria3 : Categoria
    {
       
        public override double AplicarDescuento(double precioArticulo)
        {
    
            double descuento = 0.5; 
            return precioArticulo * descuento;
        }
    }
}
