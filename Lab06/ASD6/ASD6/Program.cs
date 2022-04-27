using System;

namespace ASD6
{
    internal class Program
    {
        //x * ( a / ( b * c - d ) - 3 )
        static void Main(string[] args)
        {
            //create loop where user can enter value or get chosen value or exit
            while (true)
            {
                Console.WriteLine("Type exit to exit");
                Console.WriteLine("Type example to see example");
                Console.WriteLine("Type write to write yours value");
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                else if (input == "example")
                {
                    Console.WriteLine("x * ( a / ( b * c - d ) - 3 )");
                    //
                    Console.WriteLine(Converter("x * ( a / ( b * c - d ) - 3 )"));
                    //
                }
                else if(input.Equals("write"))
                {
                    Console.WriteLine("PLEASE! type like ( x + 2 ) * 3");
                    Console.WriteLine("NOT LIKE (x+2)*3");
                    Console.WriteLine("I did it to make possible to work with numbers that more then 9");
                    //
                    string ttmm = Console.ReadLine();
                    
                        Console.WriteLine(Converter(ttmm));
                    
                    
                    //
                }
            }

            Console.ReadKey();
        }
        
        static string cst="+-*/()";
        static string Converter(string s)
        {
            string res = "";
            string[] stArr = s.Split(' ');
            Stk stk = new Stk();
            for (int i = 0; i < stArr.Length; i++)
            {
                if (!cst.Contains(stArr[i]))
                {
                    res += stArr[i] + " ";
                }
                else
                {
                    if (!stArr[i].Equals(")"))
                    {


                        if ((i+2)<stArr.Length)
                        {
                            if (stArr[i].Equals("*")|| stArr[i].Equals("/"))
                            {
                                if (!stArr[i+1].Equals("("))
                                {
                                    res += stArr[i + 1] + " " + stArr[i] + " ";
                                    i++;
                                }
                                else
                                {
                                    stk.Push(stArr[i]);
                                    WriteArr(stk.GetAll());
                                }

                            }
                            else if (stArr[i].Equals("+") || stArr[i].Equals("-"))
                            {
                                if ((!stArr[i + 1].Equals("(")) && !"*/".Contains(stArr[i + 1]))
                                {
                                    res += stArr[i + 1] + " " + stArr[i] + " ";
                                    i++;
                                }
                                else
                                {
                                    stk.Push(stArr[i]);
                                    WriteArr(stk.GetAll());
                                }
                                

                            }
                            else
                            {
                                stk.Push(stArr[i]);
                                WriteArr(stk.GetAll());
                            }
                        }
                        else
                        {
                            stk.Push(stArr[i]);
                            WriteArr(stk.GetAll());
                        }
                        //----

                        //stk.Push(stArr[i]);

                    }
                    else
                    {
                        while ((!stk.Peek().Equals("("))&&(!stk.IsEmpty()))
                        {
                            res += stk.Pop() + " ";
                            WriteArr(stk.GetAll());
                        }
                        if (stk.IsEmpty())
                        {
                            throw new Exception("You did smth wrong");
                        }
                        else
                        {
                            stk.Pop();
                            WriteArr(stk.GetAll());
                        }
                        //?
                        if (!stk.IsEmpty())
                        {
                            if (stk.Peek().Equals("/")|| stk.Peek().Equals("*"))
                            {
                                res += stk.Pop() + " ";
                                WriteArr(stk.GetAll());
                            }
                        }
                    }
                }
            }
            while (!stk.IsEmpty())
            {
                res += stk.Pop() + " ";
                WriteArr(stk.GetAll());
            }
            Console.WriteLine("RESULT: ");
            return res;
        }

        static void WriteArr(string[] arr)
        {
            Console.WriteLine("Stack:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static bool chk4bomb(string[] str)
        {
            bool b = true;
            if (str.Length<3)
            {
                b = false;
            }
            string h = "+-*/";
            int cnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (h.Contains(str[i])&&str[i].Length==1)
                {
                    cnt++;
                }
                else
                {
                    cnt--;
                }
            }
            return b && (cnt == -1);
            
        }
    }
}
