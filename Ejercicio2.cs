using System;

namespace Ej2Parcial
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[10];
            int valor, multiplos3 = 0, multiplos5 = 0, multiplosTotales = 0;
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    Console.WriteLine($"Ingrese valores enteros: {i + 1}");
                    valor = int.Parse(Console.ReadLine());
                    if (valor > 500 || valor < 0)
                        Console.Write("Error. ");
                } while (valor > 500 || valor < 0);

                if (valor % 5 == 0)
                {
                    multiplos5++;
                }
                if (valor % 3 == 0)
                {
                    multiplos3++;
                }
                if (valor % 5 == 0 && valor % 3 == 0)
                {
                    multiplosTotales++;
                }
            }
            Console.WriteLine($"Hay: {multiplos5} multiplos de 5.");
            Console.WriteLine($"Hay: {multiplos3} multiplos de 3.");
            Console.WriteLine($"Hay: {multiplosTotales} multiplos de 3 y de 5.");
            Console.ReadKey();
        }
    }
}