using System;
using System.Linq;

namespace Desafio2_Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] Nombres = new String[5], ApRep = new String[5];
            Double[] Prom = new Double[5];
            Double[,] Notas = new Double[5, 5];
            int Fe = 0;
            Console.WriteLine($"" +
                $"Sistema de notas, ingresará 5 alumnos con 5 notas de cada uno\n" +
                $"El programa retornará sus promedios y su estado (aprobado,n" +
                $"regular o reprobado)");
            for (int n = 0; n < 5; n++)
            {
                Console.WriteLine($"Ingrese el nombre del alumno {n + 1}");
                Nombres[n] = Console.ReadLine();
                for (int c = 0; c < 5; c++)
                {
                    do
                    {
                        Fe = 0;
                        try
                        {
                            Console.WriteLine($"Ingrese la nota {c + 1} del alumno {n + 1}");
                            Notas[n, c] = Double.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Formato incorrecto");
                            Fe = 1;
                        }
                        if ((Fe == 0 && Notas[n, c] < 0) || (Fe == 0 && Notas[n, c] > 10))
                        {
                            Console.WriteLine("Ingrese un número válido (0-10)");
                        }
                    } while (Notas[n, c] < 0 || Notas[n, c] > 10 || Fe == 1);
                }
                Console.WriteLine();
            }
            for (int r = 0; r < 5; r++)
            {
                for (int sr = 0; sr < 5; sr++)
                {
                    Prom[r] += Notas[r, sr];
                }
                Prom[r] = Math.Truncate((Prom[r] / 5) * 100) / 100;
            }
            for (int a = 0; a < 5; a++)
            {
                if (Prom[a] >= 7)
                {
                    ApRep[a] = "Aprobado";
                }
                else if (Prom[a] >= 4 && Prom[a] < 7)
                {
                    ApRep[a] = "Regular";
                }
                else if (Prom[a] < 4)
                {
                    ApRep[a] = "Reprobado";
                }
            }
            for (int f = 0; f < 5; f++)
            {
                Console.Write($"Alumno {f + 1}\n" +
                    $"Nombre: {Nombres[f]}; nota: {Prom[f]}\n" +
                    $"Está {ApRep[f]} ");
                if (Prom[f] == Prom.Max())
                    Console.Write("(Promedio máximo)");
                if (Prom[f] == Prom.Min())
                    Console.Write("(Promedio mínimo)");
                Console.WriteLine(".\n");
            }
            Console.ReadKey();
        }
    }
}