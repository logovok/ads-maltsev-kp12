using System;

namespace _3ASD
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int clc = 0;
            double tmp = 0;
            double[] arr = new double[N];
            Random r = new Random();
            for (int i = 0; i < N; i++)
            {
                tmp= r.NextDouble()*111;
                if (!(tmp<(N/2.0)))
                {
                    arr[clc] = tmp;
                    clc++;
                }
                else
                {
                    arr[N - 1 - i+clc] = tmp;
                }
                Console.Write(tmp+" "); // Представлення згенерованого масиву
            }
            Console.WriteLine();
            for (int i = 0; i < clc; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write(Math.Round(arr[clc - 1 - i], 4) + " ");           
            }

            bool srtd1 = false;
            
            int ttmp = clc;
            
            
            while (!srtd1)
            {
                srtd1 = true;
                for (int i = clc; i < N - 1; i++)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                        srtd1 = false;                     
                    }
                }
                if (srtd1)
                {                  
                    break;                    
                }
                for (int i = N-2; i > clc; i--)
                {
                    if (arr[i-1] < arr[i])
                    {
                        tmp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = tmp;
                        srtd1 = false;                  
                    }
                }
                N--; clc++;
            }
            Console.BackgroundColor = ConsoleColor.Green;
            for (int i = ttmp; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
