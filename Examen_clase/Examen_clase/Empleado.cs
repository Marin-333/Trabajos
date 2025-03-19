using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_clase
{
    internal class Empleado : Persona
    {
        public string Cargo { get; set; }
        public double Salario { get; set; }

        public Empleado(string nombre, string cargo, double salario) : base(nombre)
        {
            this.Cargo = cargo;
            this.Salario = salario;
        }

        public virtual double CalcularSalarioTotal()
        {
            return Salario;
        }
        public override string ToString()
        {
            return base.ToString() + $", Cargo: {Cargo}, salario: {Salario}";
        }
    }
}
