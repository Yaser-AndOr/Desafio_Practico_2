using System;

namespace Desafio2_Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] Nombres = new String[5], Estado = new String[5];
            Double[] Ganancias = new Double[5];
            Double GanTot = 0;
            int[] NumEmp = new int[5], agregados = new int[5];
            int Fe = 0, Sobrantes = 0, SobraCache = 0, Despedidos = 0, reg = 0, may = 0;
            Console.WriteLine("" +
                "Cadena de sucursales, ingrese el nombre de cada una\n" +
                "de las 5 sucursales con sus respectivas ganancias y \n" +
                "número de empleados, el programa se encargará de precisar\n" +
                "la funcionalidad correcta de la empresa.");
            for (int c = 0; c < 5; c++)
            {
                Console.WriteLine($"Ingrese el nombre de la sucursal # {c + 1}");
                Nombres[c] = Console.ReadLine();
                Ganancias[c] = Math.Truncate(Ganado(c, Fe) * 100) / 100;
                do
                {
                    Fe = 0;
                    try
                    {
                        Console.WriteLine($"Ingrese cantidad de empleados de la sucursal # {c + 1}");
                        NumEmp[c] = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formato incorrecto");
                        Fe = 1;
                    }
                    if (NumEmp[c] < 0 && Fe == 0)
                    {
                        Console.WriteLine("Ingrese un valor positivo");
                    }
                    else if (NumEmp[c] < 10 && Fe == 0)
                    {
                        Console.WriteLine("Ingrese un valor correcto (10 en adelante)");
                    }
                    else if (NumEmp[c] > 20 && Fe == 0)
                    {
                        SobraCache = NumEmp[c] - 20;
                        NumEmp[c] = 20;
                        Sobrantes += SobraCache;
                        Console.WriteLine($"Se transferirán {SobraCache} empleados");
                    }
                } while (NumEmp[c] < 10 || Fe == 1);
                Console.WriteLine();
            }
            while (Sobrantes > 0)
            {
                for (int s = 0; s < 5; s++)
                {
                    if (NumEmp[s] < 20)
                    {
                        NumEmp[s]++;
                        agregados[s]++;
                        Sobrantes--;
                    }
                    if (Sobrantes <= 0)
                        break;
                }
                if (NumEmp[0] >= 20 && NumEmp[1] >= 20 && NumEmp[2] >= 20 && NumEmp[3] >= 20 && NumEmp[4] >= 20)
                {
                    Despedidos = Sobrantes;
                    Sobrantes = 0;
                    break;
                }
            }
            for (int s = 0; s < 5; s++)
            {
                if (Ganancias[s] >= 30000)
                    Estado[s] = "Bien hecho";
                if (Ganancias[s] < 30000)
                    Estado[s] = "Regular";
                if (Ganancias[s] < 25000)
                    reg++;
                if (Ganancias[s] >= 25000)
                    may++;
                GanTot += Math.Truncate(Ganancias[s] * 100) / 100;
            }
            Console.WriteLine($"Hay {reg} sucursales que ganan entre $1000 y $25000");
            Console.WriteLine($"Hay {may} sucursales que ganan más de $25000");
            for (int r = 0; r < 5; r++)
            {
                Console.Write($"Sucursal # {r + 1}, {Nombres[r]} ({Estado[r]}) \n" +
                       $"Ganancias: ${Ganancias[r]}\n" +
                       $"Empleados: {NumEmp[r]}");
                if (agregados[r] > 0)
                    Console.Write($" (Se agregaron {agregados[r]} empleados de otras tiendas.)");
                Console.WriteLine(".\n");
            }
            Console.WriteLine($"La ganancia total de las 5 sucursales este mes fue de ${GanTot}.");
            if (Despedidos > 0)
                Console.WriteLine($"Se tiene que despedir a {Despedidos} empleado(s) que no se pudieron reubicar.");
            Console.ReadKey();
        }
        private static Double Ganado(int Proced, int Exc)
        {
            Double Ganar = 0;
            do
            {
                Exc = 0;
                try
                {
                    Console.WriteLine($"Ingrese las ganancias de la sucursal # {Proced + 1}");
                    Ganar = Double.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato incorrecto");
                    Exc = 1;
                }
                if (Ganar < 0 && Exc == 0)
                {
                    Console.WriteLine("Ingrese un valor positivo");
                }
                else if (Ganar < 1000 && Exc == 0)
                {
                    Console.WriteLine("Ingrese un valor correcto (1000 en adelante)");
                }
            } while (Ganar < 1000 || Exc == 1);
            return Ganar;
        }
    }
}