using System;
using System.IO;
class Program
{
    static void Main()
    {
        string ruta = "C:\\Users\\sala-1.UNICARIBE\\Desktop\\ESTRUCTURA DE DATOS\\calificacionesez.csv";
        if (File.Exists(ruta))
        {
            string[] lineas = File.ReadAllLines(ruta);
            foreach (string linea in lineas)
            {
                string[] campos = linea.Split(',');
                Console.WriteLine($"Nombre: {campos[0]}, Asignatura: {campos[2]}");
            }
        }
        using (StreamWriter sw = new StreamWriter("C:\\Users\\sala-1.UNICARIBE\\Desktop\\ESTRUCTURA DE DATOS\\calificacionesez.csv", append: true))
        {
            sw.WriteLine("Pedro,23,Estructura de Datos,5.0,Aprobado");
        }
    }
}
