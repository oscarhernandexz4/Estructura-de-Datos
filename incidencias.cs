using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Registro de incidencias de un soporte tecnico utilizando archivo (.txt) 
// 1. Guardar una lista de incidencias atendidas a un archivo de texto
// 2. Leer el archivo
// 3. Generar un reporte que cuenta cuantas incidencias hay por prioridad (Alta, Media, Baja)
// La estructura del archivo es: ID, NOMBRE, DESCRIPCION, PRIORIDAD.
namespace RegistrosIncidencias
{
    internal class Program
    {
        static string pathArchivo = "incidencias.txt";

        static void GuardarIncidencias(List<string[]> incidencias) {
            try {
                using (StreamWriter sw = new StreamWriter(pathArchivo, false)) {
                    foreach (string[] incidencia in incidencias) {
                        sw.WriteLine(incidencia);
                    }
                }
            }
            catch (Exception ex){

                Console.WriteLine($"Error al escribir el archivo: {ex.Message}");
            }
        }

        static List<string[]> LeerIncidencias()
        {
            List<string[]> incidencias = new List<string[]>();

            if (!File.Exists(pathArchivo)) {
                Console.WriteLine("El archivo mo existe aun.");
                return incidencias;
            }
            try {
                string linea;
                using (StreamReader sr = new StreamReader(pathArchivo)) {
                    while ((linea = sr.ReadLine()) != null) {
                        if (!string.IsNullOrWhiteSpace(linea)) {
                            string[] campos = linea.Split(';');
                            incidencias.Add(campos);
                        }
                    }
                }
            }
            catch (Exception error) {
                Console.WriteLine($"Error el leer el archivo {error.Message}");
            }
            return incidencias;
        }

        static void GenerarReporte(List<string[]> incidencias) {
            if (incidencias.Count == 0) {
                Console.WriteLine("No hay incidencias para reportar. ");
                return;
            }
            Dictionary<string, int> conteoPorPrioridad = new Dictionary<string, int>();

            foreach (string[] inc in incidencias) {
                if (inc.Length > 4) continue;
                string prioridad = inc[3];
                if (conteoPorPrioridad.ContainsKey(prioridad)) {
                    conteoPorPrioridad[prioridad]++;
                }
                else
                    conteoPorPrioridad[prioridad] = 1;
            }
            Console.WriteLine("\n REPORTE DE INCIDENCIAS");
            Console.WriteLine($"Total Atendidas: {incidencias.Count}");
            Console.WriteLine("Detalle por prioridad");
            foreach (var inc in conteoPorPrioridad)
                Console.WriteLine($"\nPrioridad {inc.Key}: {inc.Value}");

        }

        static void Main(string[] args) {
            List<string[]> incidenciasToday = new List<string[]> {
              new string[] {"1", "Oscar Hernandez", "No Imprime", "ALTA"},
              new string[] {"2", "Carlo Martinez", "Olvido Contraseña", "BAJA"},
              new string[] {"3", "Ana Guette", "Wifi Lento", "ALTA"},
              new string[] {"4", "Juan Diaz", "Pantalla Azul", "MEDIA"},
              new string[] {"5", "Maria Gomez", "Pc no enciende", "ALTA"}
            };
            Console.WriteLine("REGISTRO DE INCIDENCIAS UNICARIBE");
            GuardarIncidencias(incidenciasToday);

            Console.WriteLine("\n --- Leyendo incidencias del archivo ---");
            List<string[]> incidenciasLeidas = LeerIncidencias();

            Console.WriteLine("\n LISTADO DE INCIDENCIAS LEIDAS: ");
            Console.WriteLine($"{"ID",-4}{"Usuario",-15}{"Descripcion",-20}{"Prioridad",-10}");
            Console.WriteLine(new string('-', 55));

            foreach (string[] inc in incidenciasLeidas) {
                if (inc.Length < 4) continue;
                Console.WriteLine($"{inc[0],-4} {inc[1],-15} {inc[2],-20} {inc[3],-10}");
            }
            GenerarReporte(incidenciasLeidas);
            Console.WriteLine("\nPresione cualquier tecla para salir!!!!");
            Console.ReadKey();
        }
    }
}
