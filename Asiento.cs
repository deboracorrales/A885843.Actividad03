using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace A885843.Actividad03
{
    class Asiento
    {
        public int NroAsiento { get; set; }
        public DateTime FechaCarga { get; set; }
        public int CodCuenta { get; set; }
        public Double MontoDebe { get; set; }
        public Double MontoHaber { get; set; }

        public Asiento() { }

        public Asiento(string linea)
        {
            //FORMATO: NroAsiento|Fecha|CodigoCuenta|Debe|Haber
            var datos = linea.Split('|'); //split divide una cadena a partir de un separador
            NroAsiento = int.Parse(datos[0]);
            FechaCarga = DateTime.Parse(datos[1]);
            CodCuenta = int.Parse(datos[3]);
            MontoDebe = double.Parse(datos[4]);
            MontoHaber = double.Parse(datos[5]);        
        }

        public string ObtenerLineaDatos()
        {
            return $"{NroAsiento};{FechaCarga};{CodCuenta};{MontoDebe};{MontoHaber}";
        }

        public static Asiento CargarNuevo()
        {
            var asiento = new Asiento();

            Console.WriteLine("Nuevo asiento contable");

            asiento.NroAsiento = IngresarNroAsiento();
            asiento.FechaCarga = IngresarFecha("Ingrese la fecha de carga del asiento");
            asiento.CodCuenta = IngresarCuenta(); 

            asiento.MontoDebe = IngresarMonto(); //revisar si usar uno o un metodo por cada uno
            asiento.MontoHaber = IngresarMonto();

            return asiento; //una vez que se completaron todos los datos, devuelve el asiento
        }

        internal void MostrarPlanDeCuentas() //Corregir en clase planDeCuentas
        {
            throw new NotImplementedException();
        }

        private static int IngresarNroAsiento(bool obligatorio = true) // OK!!
        {
            var titulo = "Ingrese el Numero de Asiento:";

            if (!obligatorio)
            {
                titulo += " o presione [Enter] para continuar.";
            }

            Console.WriteLine(titulo);
            do
            {
                var ingreso = Console.ReadLine();

                if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                {
                    return 0;
                }

                if (!int.TryParse(ingreso, out var nroAsiento))
                {
                    Console.WriteLine("No ha ingresado un Nro de Asiento valido");
                    continue;
                }

                if (nroAsiento < 1)
                {
                    Console.WriteLine("Debe ser un numero positivo");
                    continue;
                }

                if (LibroDiario.Existe(nroAsiento)) //consulta a la clase estatica LIBRODIARIO si existe el NroAsiento ingresado
                {
                    Console.WriteLine("El Nro. indicado ya existe en el libro diario.");
                    continue;
                }
                return nroAsiento;

            } while (true);
        }

        private static DateTime IngresarFecha(string titulo, bool obligatorio = true) // OK!!
        {
            do
            {
                if (!obligatorio)
                {
                    titulo += " o presione [Enter] para continuar.";
                }

                Console.WriteLine(titulo);
                var ingreso = Console.ReadLine();

                if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                {
                    return DateTime.MinValue;
                }

                if (!DateTime.TryParse(ingreso, out DateTime fechaDeCarga))
                {
                    Console.WriteLine("No es una fecha valida.");
                    continue;
                }

                if (fechaDeCarga > DateTime.Now)
                {
                    Console.WriteLine("La fecha no puede ser mayor a la actual.");
                    continue;
                }

                return fechaDeCarga;

            } while (true); //no hace falta poner condicion xq la salida esta explicita en el break;
        }

        private static int IngresarCuenta() //revisar porque no funciona BuscarCodigo
        {

            throw new NotImplementedException();
            /*
            int codigo;
            do
            {
                Console.WriteLine("Ingrese el codigo de cuenta a cargar:");

                if (!int.TryParse(Console.ReadLine(), out codigo))
                {
                    Console.WriteLine("Error. Debe ingresar un dato numerico.");
                    
                }
                else if(!PlanDeCuentas.BuscarCodigo(codigo)) //Error. metodo no estatico??
                {
                    Console.WriteLine("El código ingresado no se encuentra en el Plan de Cuentas");
                }

            } while (!PlanDeCuentas.BuscarCodigo(codigo)); //Error. metodo no estatico??

            return codigo; */
        }

        private static double IngresarMonto()
        {
            throw new NotImplementedException();
        }
            /*
            private static double IngresarMonto()
            {
                bool salir = false;
                do
                {
                    Console.WriteLine();
                    Console.Write("Cargar monto");
                    Console.WriteLine("--------------");

                    Console.WriteLine("3 - Cargar DEBE");
                    Console.WriteLine("4 - Cargar HABER");
                    Console.WriteLine("0 - Salir");

                    Console.Write("\n Ingrese una opcion y presione [Enter] \n");
                    var opcion = Console.ReadLine();
                    switch (opcion)
                    {
                        case "3":
                            //cargar DEBE
                            double debe=0;
                            var ingreso = Console.ReadLine();
                            if (!double.TryParse(ingreso, out debe))
                            {
                                Console.WriteLine("El importe debe ser númerico.");
                                continue;
                            }
                            else if (debe > 0)
                            {
                                Console.WriteLine("El importe debe ser mayor o igual a cero.");
                                continue;
                            }
                            break;

                        case "4":
                            //cargar HABER
                            double haber = 0;
                            var ingreso2 = Console.ReadLine();
                            if (!double.TryParse(ingreso2, out haber))
                            {
                                Console.WriteLine("El importe debe ser númerico.");
                                continue;
                            }
                            else if (haber < 0)
                            {
                                Console.WriteLine("El importe debe ser menor o igual a cero.");
                                continue;
                            }
                            break;

                        case "0":
                            salir = true;
                            break;

                        default: //caso de opcion invalida
                            Console.WriteLine("No ha ingresado una opcion del menu.");
                            break;
                    }

                } while (!salir);

                return ;
                
        }*/
    }
    
}
