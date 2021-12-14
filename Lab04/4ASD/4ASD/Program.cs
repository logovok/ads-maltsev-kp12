using System;

namespace _4ASD
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first element");
            DualLList dll = new DualLList(new DualLList.DLNode(int.Parse(Console.ReadLine())));
            void Vari3Zavd(int k)
            {
                if (k > 0 && k < 99)
                {
                    dll.Add2Pos(1, k);
                }
                else
                {
                    dll.AddFirst(k);
                }
            }
            bool g = true;
            while (g)
            {
                string temp = Console.ReadLine();
                try
                {


                    switch (temp)
                    {
                        case "stop":
                            g = false;
                            break;
                        case "help":
                            helpMSG();
                            break;
                        case "AddFirst":
                            Console.WriteLine("Enter your value");
                            dll.AddFirst(int.Parse(Console.ReadLine()));
                            dll.dsplay();
                            Console.WriteLine("Enter next command please");
                            break;
                        case "DeleteFirst":
                            dll.DelFirst();
                            dll.dsplay();
                            Console.WriteLine("Enter next command please");
                            break;
                        case "Add2Position":
                            Console.WriteLine("Enter posoiton");
                            int i = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter value");
                            dll.Add2Pos(i,int.Parse(Console.ReadLine()));
                            dll.dsplay();
                            Console.WriteLine("Enter next command please");
                            break;
                        case "DeleteAtPos":
                            Console.WriteLine("Enter position");
                            dll.Del2Pos(int.Parse(Console.ReadLine()));
                            dll.dsplay();
                            Console.WriteLine("Enter next command please");
                            break;
                        case "AddLast":
                            Console.WriteLine("Enter value");
                            dll.AddLust(int.Parse(Console.ReadLine()));
                            dll.dsplay();
                            Console.WriteLine("Enter next command please");
                            break;
                        case "DeleteLast":
                            dll.DelLust();
                            dll.dsplay();
                            Console.WriteLine("Enter next command please");
                            break;
                        case "Print":
                            dll.dsplay();
                            Console.WriteLine("Enter next command please");
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("Wrong command, pleas read healp message!");
                            helpMSG();
                            break;
                    }
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Command cannot be performed");
                    Console.WriteLine("Type of elements is integer!");
                    Console.WriteLine("try to use another one");
                    helpMSG();
                    Console.WriteLine("=====");
                    Console.WriteLine("Try command: Print");
                    Console.WriteLine("If it couldnt be performed you may have deleted all elements");
                    Console.WriteLine("In that case program needs restart");
                }
            }
            
        }
        static void helpMSG() {
            Console.WriteLine("To stop the program type: stop");
            Console.WriteLine("To add element in head type: AddFirst");
            Console.WriteLine("To delete element from head type: DeleteFirst");
            Console.WriteLine("To add element in position type: Add2Position");
            Console.WriteLine("To delete element frim position type: DeleteAtPos");
            Console.WriteLine("To add element to last posotion type : AddLast");
            Console.WriteLine("To delete element from last posotion type : DeleteLast");
            Console.WriteLine("To see all elements type: Print");
        }
        
    }
}
