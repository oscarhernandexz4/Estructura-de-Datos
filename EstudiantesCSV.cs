using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string ruta = "C:\\Users\\sala-1.UNICARIBE\\Desktop\\ESTRUCTURA DE DATOS\\calificacionesez.csv";
        using (StreamWriter sw = new StreamWriter(ruta))
        {
            sw.WriteLine("Nombre,Edad,Asignatura,Nota,Estado");
            sw.WriteLine("Oscar,18,Estructura de Datos,2.7,Reprobado");
            sw.WriteLine("Jose,20,Estructura de Datos,3.0,Aprobado");
            sw.WriteLine("Stevel,Estructura de Datis,3.5,Aprobado");
        }
        Console.WriteLine("Felicidades creaste el archivo con éxito!!.");
    }
}
