using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Data;

namespace ConsoleApp3_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Program p = new Program();
            Console.WriteLine("Калькулятор");
            Console.WriteLine();
            double first = 0;
            double second = 0;
            string a = "";
            string b = "";
            try
            {
                Console.Write("Введите первое число ");
                a = Console.ReadLine();
                first = Convert.ToDouble(a);
                Console.Write("Введите второе число ");
                b = Console.ReadLine();
                second = Convert.ToDouble(b);
            }
            catch
            {
                Console.WriteLine("Не число");
                Console.ReadLine();
                Run();
                Environment.Exit(0);
            }

            Console.WriteLine("Введите знак операции:");
            Console.WriteLine("     '+' - сложение");
            Console.WriteLine("     '-' - вычитание");
            Console.WriteLine("     '*' - умножение");
            Console.WriteLine("     '/' - деление");
            string oper = Console.ReadLine();

            if (!(oper == "+" | oper == "-" | oper == "*" | oper == "/"))
            {
                Console.WriteLine(oper + " не является знаком операции");
            }
            else
            {                
                using (DataTable table = new DataTable())
                    Console.WriteLine("Результат " + a + oper + b + " = " + Convert.ToDouble(table.Compute(a + oper + b, null)));
            }
            Console.ReadLine();
            Run();
            Environment.Exit(0);
        }

        public void ReadString(string path, out string[] words, out string text)
        {
            text = "";
            words = new string[0];
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                    text = text.Replace("  ", "");
                    words = text.Split(' ');
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}