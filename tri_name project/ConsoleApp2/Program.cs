using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = (s.Length);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i; j++) {
                    Console.Write(s[j]);
                    
                }
                Console.WriteLine("");


            }
         
            //int n = Convert.ToInt32(Console.ReadLine());
            //int i = n;
            //for (; i > 0;)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.BackgroundColor = ConsoleColor.White;
            //    for (int j = 1; j <= i; j++)
            //        Console.Write("saeed.");
            //    Console.WriteLine("");
            //    i = i - 1;
            //}
            //i = 1;
            //for (; i <= n;)
            //{
            //    for (int j = 1; j <= i; j++)
            //        Console.Write("majid.");
            //    Console.WriteLine("");
            //    i = i + 1;
            //}
            Console.ReadKey();
        }
    }
}
