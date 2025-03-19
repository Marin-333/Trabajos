using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Examen_clase
{
    class Program
    {
        static void Main()
        {
            List<Empleado> listEmpleado = new List<Empleado>();
            List<Producto> productos = new List<Producto>();


            listEmpleado.Add(new Empleado("Jorge", "Analista", 2800000));
            listEmpleado.Add(new Empleado("Anita", "Cajera", 1200000));
            listEmpleado.Add(new Gerente("toño", "Gerente", 7896098,20000));
            productos.Add(new Producto("Deshodorante", 2000, 15, "Axe"));
            productos.Add(new Producto("Consolador", 50000, 10, "Orga"));
            productos.Add(new Producto("Camisa", 10000, 11, "LV"));

            Clientes cliente = new Clientes ("Sneyder", "Sneyder.marin8119@unaula.edu.co","3014879875");

            cliente.RegistrarCompra();

            Gerente gerente = new Gerente("Pipe", "Gerente Comercial", 6856098, 500000);
            Empleado empleado= new Empleado("Paola", "Aseo", 100000);
            Console.WriteLine($"La diferencia de salario entre la cajera y el gerente es de {gerente.CalcularSalarioTotal()-empleado.CalcularSalarioTotal()}");
            foreach (var m in listEmpleado)
            {
                Console.WriteLine($"El salario de {m.Nombre} es {m.CalcularSalarioTotal()}");
            }
            Console.ReadKey();

        }

    }
}
