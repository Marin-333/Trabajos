using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_clase
{
    internal class Gerente : Empleado
    {
        public double BonoAnual { get; set; }

        public Gerente(string nombre, string cargo, double salario, double bonoAnual)
            : base(nombre, cargo, salario)
        {
            this.BonoAnual = bonoAnual;
        }

        public override double CalcularSalarioTotal()
        {
            return Salario + BonoAnual;
        }
        public override string ToString()
        {
            return base.ToString()+ $",Bono anual: {BonoAnual}";
        }
    }
}
