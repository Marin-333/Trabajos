using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_clase
{
    internal class Clientes
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int ComprasRealizadas { get; private set; }

        public Clientes(string nombre, string correo, string telefono)
        {
            this.Nombre = nombre;
            this.Correo = correo;
            this.Telefono = telefono;
            this.ComprasRealizadas = 0;
        }

        public void RegistrarCompra()
        {
            ComprasRealizadas++;
        }
    }
}
