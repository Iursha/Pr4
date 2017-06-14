using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr4
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10, M = 7;
            int[,] a = new int[N, M];

            Random random = new Random();
            int rand;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    rand = random.Next(0, 100);
                    a[i, j] = rand;
                }
            }
            Console.WriteLine("исходная матрица:");

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)

                    Console.Write(a[i, j] + " ");

                Console.WriteLine();
            }
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
