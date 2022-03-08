
using System;
using System.Collections.Generic;
namespace _5Asd1
{
    class Program
    {
        static int[] mrgSrtd(int[] ajj) {
            if (ajj.Length > 1)
            {
                int[] arr1 = new int[ajj.Length / 2];
                int[] arr2 = new int[ajj.Length - arr1.Length];
                int i = 0;
                for (; i < arr1.Length; i++)
                {
                    arr1[i] = ajj[i];
                }
                for (; i < ajj.Length; i++)
                {
                    arr2[i - arr1.Length] = ajj[i];
                }
                arr1 = mrgSrtd(arr1);
                arr2 = mrgSrtd(arr2);
                ajj = outMerge(arr1, arr2);
            }
            //Console.WriteLine("123");
            return ajj;

        }

        static int[] outMerge(int[] arr1, int[] arr2) {
            int[] arroz = new int[arr1.Length + arr2.Length];
            int c1 = 0, c2 = 0, c3 = 0; ;

            while ((c1 != arr1.Length) && (c2 != arr2.Length))
            {


                if (arr1[c1] > arr2[c2])
                {

                    arroz[c3] = arr1[c1];
                    c1++; c3++;
                }
                else {
                    arroz[c3] = arr2[c2];
                    c2++; c3++;

                }

            }
            //Console.WriteLine("=-" + arr1.Length);
            //Console.WriteLine("=-" + arr1.Length);

            try
            {
                while (c1 != arr1.Length)
                {
                    arroz[c3] = arr1[c1];
                    c1++; c3++;
                }
            }
            catch (Exception)
            {


            }
            try
            {
                while (c2 != arr2.Length)
                {
                    arroz[c3] = arr2[c2];
                    c2++; c3++;
                }
            }
            catch (Exception)
            {

                //throw;
            }

            return arroz;
        }

        static int[,] fmR(int N, int M) {
            int[,] nArr = new int[N, M];
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    nArr[i, j] = rnd.Next(10, 99);
                    Console.Write(nArr[i, j] + " ");
                }
                Console.WriteLine();
            }
            return nArr;
        }

        static int[,] fmCNTR()
        {
            N = 3;M = 3;
            int[,] nArr = { {0,0,6},
                            {0,4,0 },
                            {8,0,9 }, };
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(nArr[i, j] + " ");
                }
                Console.WriteLine();
            }
            return nArr;
        }

        static int[,] fmKB(int N, int M)
        {
            int[,] nArr = new int[N, M];
            //Scanner sc = new Scanner(System.in);
            for (int i = 0; i < N; i++)
            {
                string[] tmp = Console.ReadLine().Split(' ');
                for (int j = 0; j < M; j++)
                {
                    nArr[i, j] = int.Parse(tmp[j]);
                    //nArr[i, j] = rnd.Next(10, 99);
                    //Console.Write(nArr[i, j] + " ");
                }
                //Console.WriteLine();
            }
            return nArr;
        }
        static int N = 0, M = 0;
        static int[,] takeNormalArrayFromMatrix(int[,] mtr) {
            List<int> ls = new List<int>();
            for (int i = 0; i < Math.Min(M,N); i++)
            {
                ls.Add(mtr[N - i - 1, (M - N > 0 ? (M - N) + i : i) ]);
            }
            int c = ls.Count ;
            //Console.WriteLine(mtr.);
            for (int i = 0;i<c / 2; i++)
            {
                ls.Add(mtr[N - i - 1, mtr.Length / N-i-1]);
            }
            int[] inAr = mrgSrtd(ls.ToArray());
            int k = 0;
            for (int i = 0; i < Math.Min(mtr.Length / N, N); i++)
            {
                //mtr[N - i - 1, Math.Abs(M - N)  + i] = inAr[k];
                mtr[N - i - 1, (M - N>0? (M - N) + i:i) ] = inAr[k];
                //mtr[N - i - 1, i] = inAr[k];
                k++;
            }
            
            for (int i = 0; i < c / 2; i++)
            {
                mtr[N - i - 1, mtr.Length / N - i - 1] = inAr[k];
                k++;
            }
            Console.WriteLine("Result");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < mtr.Length / N; j++)
                {
                    Console.Write(mtr[i,j]+" ");
                }
                Console.WriteLine();
            }
            return mtr;
        }

        static void shmt() { }

        static void Main(string[] args)
        {
            Console.WriteLine("Write -> rnd <- to generate metritx automaticaly");
            Console.WriteLine("Write -> control <- to see how program works with the control set");
            Console.WriteLine("Write -> manual <- to enter matrix manualy");
            Console.WriteLine("Write -> stop <- to stop the program");
            string tmS = "";
            while (!tmS.Equals("stop")) {
                tmS = Console.ReadLine();
                if (tmS.Equals("rnd"))
                {
                    Console.WriteLine("Enter N, press Enter, then Enter M and press Enter again");
                    N = int.Parse(Console.ReadLine());
                    M = int.Parse(Console.ReadLine());
                    takeNormalArrayFromMatrix(fmR(N, M));
                }
                else if (tmS.Equals("control"))
                {
                    takeNormalArrayFromMatrix(fmCNTR());
                }
                else if (tmS.Equals("manual")) {
                    Console.WriteLine("Enter N, press Enter, then Enter M and press Enter again");
                    N = int.Parse(Console.ReadLine());
                    M = int.Parse(Console.ReadLine());
                    takeNormalArrayFromMatrix(fmKB(N,M));
                }
                else
                {
                    Console.WriteLine("Write -> rnd <- to generate metritx automaticaly");
                    Console.WriteLine("Write -> control <- to see how program works with the control set");
                    Console.WriteLine("Write -> manual <- to enter matrix manualy");
                    Console.WriteLine("Write -> stop <- to stop the program");
                }
            }
            {

            }
            
            
        }
    }
}
