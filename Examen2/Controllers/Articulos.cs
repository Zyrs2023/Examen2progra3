using System;

namespace Examen2.Controllers
{
    public class Articulos
    {
        public string[] Codigo;
        public string[] Nombre;
        public double[] Precio;
        public int[] Cantidad;
        public int contador;

        public Articulos()
        {
            Codigo = new string[5];
            Nombre = new string[5];
            Precio = new double[5];
            Cantidad = new int[5];
            contador = 0;
        }

        public string AgregarArticulo(string codigo, string nombre, double precio, int cantidad)
        {
            try
            {
                if (contador < 5)
                {
                    Codigo[contador] = codigo;
                    Nombre[contador] = nombre;
                    Precio[contador] = precio;
                    Cantidad[contador] = cantidad;
                    contador++;
                    return "Artículo agregado correctamente.";
                }
                else
                {
                    return "No se pueden agregar más artículos. Límite alcanzado.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al agregar artículo: {ex.Message}";
            }
        }

        public string ConsultarArticulo(string codigo)
        {
            try
            {
                for (int i = 0; i < contador; i++)
                {
                    if (Codigo[i] == codigo)
                    {
                        return $"Código: {Codigo[i]}, Nombre: {Nombre[i]}, Precio: {Precio[i]}, Cantidad: {Cantidad[i]}";
                    }
                }
                return "Artículo no encontrado.";
            }
            catch (Exception ex)
            {
                return $"Error al consultar artículo: {ex.Message}";
            }
        }

        public void BorrarArticulo(string codigo)
        {
            try
            {
                bool encontrado = false;
                for (int i = 0; i < contador; i++)
                {
                    if (Codigo[i] == codigo)
                    {
                        for (int j = i; j < contador - 1; j++)
                        {
                            Codigo[j] = Codigo[j + 1];
                            Nombre[j] = Nombre[j + 1];
                            Precio[j] = Precio[j + 1];
                            Cantidad[j] = Cantidad[j + 1];
                        }
                        contador--;
                        encontrado = true;
                        Console.WriteLine("Artículo borrado correctamente.");
                        break;
                    }
                }
                if (!encontrado)
                {
                    Console.WriteLine("Artículo no encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar artículo: {ex.Message}");
            }
        }

        public void ModificarArticulo(string codigo, string nuevoNombre, double nuevoPrecio, int nuevaCantidad)
        {
            try
            {
                bool encontrado = false;
                for (int i = 0; i < contador; i++)
                {
                    if (Codigo[i] == codigo)
                    {
                        Nombre[i] = nuevoNombre;
                        Precio[i] = nuevoPrecio;
                        Cantidad[i] = nuevaCantidad;
                        encontrado = true;
                        Console.WriteLine("Artículo modificado correctamente.");
                        break;
                    }
                }
                if (!encontrado)
                {
                    Console.WriteLine("Artículo no encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar artículo: {ex.Message}");
            }
        }

        public int ObtenerIndiceArticulo(string codigo)
        {
            try
            {
                for (int i = 0; i < contador; i++)
                {
                    if (Codigo[i].Trim().Equals(codigo.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        return i;
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener índice del artículo: {ex.Message}");
                return -1;
            }
        }

        public string GetCodigo(int indice)
        {
            return Codigo[indice];
        }

        public void SetCodigo(int indice, string codigo)
        {
            Codigo[indice] = codigo;
        }

        public string GetNombre(int indice)
        {
            return Nombre[indice];
        }

        public void SetNombre(int indice, string nombre)
        {
            Nombre[indice] = nombre;
        }

        public double GetPrecio(int indice)
        {
            return Precio[indice];
        }

        public void SetPrecio(int indice, double precio)
        {
            Precio[indice] = precio;
        }

        public int GetCantidad(int indice)
        {
            return Cantidad[indice];
        }

        public void SetCantidad(int indice, int cantidad)
        {
            Cantidad[indice] = cantidad;
        }
    }
}
