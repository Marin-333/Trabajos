using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_clase
{
    internal class Producto
    {

        private string nombre;
        private double precio;
        private double stock;
        private string marca;

        public Producto(string nombre, double precio, int stock, string marca)
        {
            if (precio<0)
            {
                throw new ArgumentException("No puede ser negativo el precio");
            }
            if (stock<0)
            {
                throw new ArgumentException("No puede ser negativo el stock");
            }
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
            this.marca = marca;
        }
        public void Setprecio(double precio)
        {
            if (precio<0)
            {
                throw new ArgumentException("No puede ser negativo el precio");
            }
            this.precio = precio;
        }
        public void Setstock(double stock)
        {
            if (stock < 0)
            {
                throw new ArgumentException("No puede ser negativo el stock");
            }
            this.stock = stock;
        }


        
    }
}
