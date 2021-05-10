using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A885843.Actividad03
{
    class PlanDeCuentas
    {
        //const string archivo = "PlanDeCuentas.txt";
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        List<PlanDeCuentas> cuentas = new List<PlanDeCuentas>();
        
        public PlanDeCuentas(string linea)
        {
            var datos = linea.Split('|');
            Codigo = int.Parse(datos[0]);
            Nombre = datos[1];
            Tipo = datos[2];
        }

        public PlanDeCuentas() { }

        public bool BuscarCodigo(int codigo)
        {
            int posicion = 0;
            bool ok = false;
            while (posicion < cuentas.Count && !ok)
            {
                if (cuentas[posicion].Codigo == codigo)
                {
                    ok = true;
                }
                else
                {
                    posicion++;
                }
            }
            return ok;
        }

    }
}