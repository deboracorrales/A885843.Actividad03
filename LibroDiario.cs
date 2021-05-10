using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A885843.Actividad03
{
    static class LibroDiario
    {
        private static readonly Dictionary<int, Asiento> ingresos;
        const string nombreArchivo = "Diario.txt";
        static LibroDiario()
        {
            ingresos = new Dictionary<int, Asiento>();

            if (File.Exists(nombreArchivo)) //si existe el archivo lo va a grabar
            {
                var stream = File.OpenRead(nombreArchivo);
                var reader = new StreamReader(stream); //le paso lo de arriba para leer

                while (!reader.EndOfStream) 
                {
                    var linea = reader.ReadLine(); 
                    var asiento = new Asiento(linea);
                    ingresos.Add(asiento.NroAsiento, asiento);
                }
            }
        }

        public static void Agregar(Asiento asiento) 
        {
            ingresos.Add(asiento.NroAsiento, asiento);
            Grabar();
        }


        public static bool Existe(int nroAsiento) 
        {
            return ingresos.ContainsKey(nroAsiento);
        }

        public static void Grabar()
        {
            using (var writer = new StreamWriter(nombreArchivo, append: false)) 
            {
                foreach (var asiento in ingresos.Values)
                {
                    var linea = asiento.ObtenerLineaDatos(); 
                    writer.WriteLine(linea); 
                }
            }

        }

    }
}
