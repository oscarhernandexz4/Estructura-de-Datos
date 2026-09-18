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
            string[] estudiantes =
                { "Ana", "Luis", "Carlos", "Marta" };
            for (int i = 0; i < estudiantes.Length; i++)
            {
                Console.WriteLine(
                    $"Indice [{i}] {estudiantes[i]}"
                    );
            }

        }
    }
}
