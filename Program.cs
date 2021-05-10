using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A885843.Actividad03
{
    class Program
    {
        /*1) A partir de los asientos ingresados por el usuario, una aplicación debe generar/actualizar un archivo de texto llamado “Diario.txt” 
        con el siguiente formato por línea:
        NroAsiento|Fecha|CodigoCuenta|Debe|Haber
        /Utilizará el archivo de plan de cuentas adjunto para validar los datos ingresados(recuerde especialmente: Debe = Haber y Activo = Pasivo + PN) */

        static void Main(string[] args)
        {
            //MENU donde el usuario pueda seleccionar las acciones
            bool salir = false;
            do
            {
                Console.WriteLine();
                Console.Write("MENU PRINCIPAL");
                Console.WriteLine("--------------");

                Console.WriteLine("1 - Cargar asiento");
                Console.WriteLine("2 - Consultar plan de cuentas"); 
                Console.WriteLine("9 - Salir");

                Console.Write("\n Ingrese una opcion y presione [Enter] \n");
                var opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        CargarAsiento();
                        break;

                    case "2":
                        ConsultarPlanCuentas();
                        break;

                    case "9":
                        salir = true;
                        break;

                    default: //caso de opcion invalida
                        Console.WriteLine("No ha ingresado una opcion del menu.");
                        break;
                }

            } while (!salir); //muestro el menu mientras no salga

        }
        
        const string archivo = "PlanDeCuentas.txt";
        private static void ConsultarPlanCuentas()
        {
            if (File.Exists(archivo))
            {
                using (var reader = new StreamReader(archivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        Console.WriteLine(linea);
                    }
                }
            }
        }

        private static void CargarAsiento()
        {
            //CARGAR NUEVO ASIENTO:
            var asiento = Asiento.CargarNuevo();
            LibroDiario.Agregar(asiento);
        }

    }
}
