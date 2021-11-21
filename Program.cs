using System;
using static System.Math;
namespace ASD2Lab11
{
    class Program
    {
        static int Maxx = int.MinValue;
        static int Minn = int.MaxValue;
        static bool nmt = true;

        static void minmax(int a) {
            if (nmt)
            {
                Minn = Min(Minn, a);
            }
            else
            {
                Maxx = Max(Maxx, a);
            }
        }
        static int[,] routeNcut(int[,] arr) {
            int num = arr.GetLength(0);
            int[,] res = new int[num - 1, num - 1];
            for (int i = 1; i < num; i++)
            {
                for (int j = 1; j < num; j++)
                {
                    res[i-1, j-1] = arr[num - i , num - j ];
                }
            }            
            nmt = false;
            return res;
        }
        // not in cheme=============================
        static void swM(int[,] matr, int l1, int l2)
        {
            for (int i = 0; i < l1; i++)
            {

                Console.Write("|");
                for (int j = 0; j < l2; j++)
                {
                    Console.Write("{0,5} |", matr[i, j]); ;
                }
                Console.WriteLine();
                
            }
        }
        //===========================================
        static int[,] butcher(int[,] ar) {
            var num1 = ar.GetLength(0);

            int[,] recn = new int[num1 - 3, num1 - 3];
    
                for (int i = 1; i < num1 - 2; i++)
                {
                    for (int j = 1; j < num1 - 2; j++)
                    {
                        recn[i - 1, j - 1] = ar[i, j];
                    }
                }

            return recn;
        }
        static void res1(int[,] ar)
        {

            var num1 = ar.GetLength(0);

            if (num1==1)
            {
                Console.WriteLine(ar[0,0]);
                minmax(ar[0, 0]);
                return;
            } else

            if (num1==2)
            {
                Console.Write(ar[0,1]+" "+ar[1,0]+" "+ar[0,0]);
                minmax(ar[0, 0]); minmax(ar[0, 1]); 
                minmax(ar[1, 0]); minmax(ar[1, 1]);
                
                return;
            }
            else { 
            
            for (int i = 0; i < num1; i++)
            {
                Console.Write(ar[i, num1 - 1 - i] + " ");
                    minmax(ar[i, num1 - 1 - i]);                   
                }

            for (int i = num1 - 2; i >= 0; i--)
            {
                Console.Write(ar[i, 0] + " ");
                    minmax(ar[i, 0]);
                }
                
            for (int i = 1; i < num1 - 1; i++)
            {
                Console.Write(ar[0, i] + " ");
                    minmax(ar[0, i]);
                }

             if(num1>2)   res1(butcher(ar));
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 2) {
                Console.WriteLine("Incorrect input data");
            }
            int[,] arr = new int[n, n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = r.Next(-111, 111);                    
                }
            }
            swM(arr, n, n);
            res1(arr);
            Console.WriteLine();
            res1(routeNcut(arr));
            Console.WriteLine();
            Console.WriteLine("Max = {0}, Min ={1}",Maxx,Minn);
        }
    }
}
