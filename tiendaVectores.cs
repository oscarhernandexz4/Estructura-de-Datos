using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorrido 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] ventas = { 200.000, 302.300, 400.000, 300.233, 700.410, 740.432, 100.233, 99.423, 823.231, 902.211 };
            double total = 0;
            double mayorVenta = ventas[0];
            double menorVenta = ventas[0];
            int diaMayorVenta = 0;
            int diaMenorVenta = 0;

            for (int i = 0; i < ventas.Length; i++)
            {
                total += ventas[i];

                if (ventas[i] > mayorVenta)
                {

                    mayorVenta = ventas[i];
                    diaMayorVenta = i;

                }
                if (ventas[i] < menorVenta)
                {
                    menorVenta = ventas[i];
                    diaMenorVenta = i;

                }

            }

            double promedio = total / ventas.Length;
            int diasSobrePromedio = 0;

            for (int i = 0; i < ventas.Length; i++)
            {
                if(ventas[i] > promedio)
                {
                    diasSobrePromedio++;
                }
            }

            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°° REPORTE DE VENTAS °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.WriteLine();

            Console.WriteLine($"Total vendido: ${total:f2}");
            Console.WriteLine($"Promedio diario: ${promedio:f2}");
            Console.WriteLine();

            Console.WriteLine($"Mayor Venta: ${mayorVenta} - el Dia {diaMayorVenta + 1}");
            Console.WriteLine($"Menor Venta: ${menorVenta} - el Dia {diaMenorVenta + 1}");

            Console.WriteLine($"Dias que superaron el promedio de ventas: {diasSobrePromedio}");
            Console.WriteLine();

            Console.WriteLine("Ventas por Dias");
            for (int i = 0; i < ventas.Length; i++)
            {
                Console.WriteLine($"Dia {i + 1}: ${ventas[i]:f3}");
            }





        }
    }

}
