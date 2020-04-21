using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L11
{
    class Program
    {
        static Digit zero = new Digit() { name = 0, top = "-", b1l = "|", b1r = "|", mid = " ", b2l = "|", b2r = "|", bot = "-" };
        static Digit one = new Digit() { name = 1, top = " ", b1l = " ", b1r = "|", mid = " ", b2l = " ", b2r = "|", bot = " " };
        static Digit two = new Digit() { name = 2, top = "-", b1l = " ", b1r = "|", mid = "-", b2l = "|", b2r = " ", bot = "-" };
        static Digit three = new Digit() { name = 3, top = "-", b1r = "|", mid = "-", b2r = "|", bot = "-" };
        static Digit four = new Digit() { name = 4, b1l = "|", b1r = "|", mid = "-", b2r = "|"};
        static Digit five = new Digit() { name = 5, top = "-", b1l = "|", mid = "-", b2r = "|", bot = "-" };
        static Digit six = new Digit() { name = 6, top = "-", b1l = "|", mid = "-", b2l = "|", b2r = "|", bot = "-" };
        static Digit seven = new Digit() { name = 7, top = "-", b1r = "|", b2r = "|" };
        static Digit eight = new Digit() { name = 8, top = "-", b1l = "|", b1r = "|", mid = "-", b2l = "|", b2r = "|", bot = "-" };
        static Digit nine = new Digit() { name = 9, top = "-", b1l = "|", b1r = "|", mid = "-", b2r = "|", bot = "-" };
        static Digit[] digits = new Digit[] { zero, one, two, three, four, five, six, seven, eight, nine };

        static void Main()
        {
            try
            {
                string[] input = File.ReadAllLines("file.txt"); //Считывание всех строк файла
                foreach (string line in input)
                {
                    try
                    {
                        int s = Convert.ToInt32(line.Split(new char[] { ' ' })[0]); // Размер цифр
                        int n = Convert.ToInt32(line.Split(new char[] { ' ' })[1]); // Число для визуализации
                        int[] digs = GetDigitsArray(n); // Получение массива, содержащего цифры числа
                        List<Digit> ds = new List<Digit>();
                        foreach (int a in digs)
                            foreach (Digit dig in digits)
                                if (dig.name == a) ds.Add(dig); // Добавление в коллекцию цифр для визуализации тех цифр, что содержатся в файле
                        Draw(ds.ToArray(), s); // Визуализировать цифры
                        Console.WriteLine();
                    }
                    catch (FormatException Fe)
                    {
                        Console.WriteLine(Fe.Message);
                    }
                }
            }
            catch (IOException IOe)
            {
                Console.WriteLine(IOe.Message);
            }
        }
        static int[] GetDigitsArray(int n)
        {
            List<int> digs = new List<int>();
            int d = 10;
            while(n > 0)
            {
                digs.Add(n % d);
                n /= 10;
            }
            digs.Reverse();
            return digs.ToArray();
        }
        static void Draw(Digit[] digs, int s)
        {
            DrawTop(digs, s);
            DrawB1(digs, s);
            DrawMid(digs, s);
            DrawB2(digs, s);
            DrawBot(digs, s);
            Console.WriteLine();
        }
        static void DrawTop(Digit[] digs, int s)
        {
            foreach(var dig in digs)
            {
                Console.Write(" ");
                for(int i = 0; i < s; i++)
                {
                    Console.Write(dig.top);
                }
                Console.Write(" ");
                Console.Write(" ");
            }
        }
        static void DrawB1(Digit[] digs, int s)
        {
            Console.WriteLine();
            for (int i = 0; i < s; i++)
            {
                foreach (var dig in digs)
                {
                    Console.Write(dig.b1l);
                    for (int j = 0; j < s; j++)
                        Console.Write(" ");
                    Console.Write(dig.b1r);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        static void DrawMid(Digit[] digs, int s)
        {
            foreach (var dig in digs)
            {
                Console.Write(" ");
                for (int i = 0; i < s; i++)
                {
                    Console.Write(dig.mid);
                }
                Console.Write(" ");
                Console.Write(" ");
            }
        }
        static void DrawB2(Digit[] digs, int s)
        {
            Console.WriteLine();
            for (int i = 0; i < s; i++)
            {
                foreach (var dig in digs)
                {
                    Console.Write(dig.b2l);
                    for (int j = 0; j < s; j++)
                        Console.Write(" ");
                    Console.Write(dig.b2r);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        static void DrawBot(Digit[] digs, int s)
        {
            foreach (var dig in digs)
            {
                Console.Write(" ");
                for (int i = 0; i < s; i++)
                {
                    Console.Write(dig.bot);
                }
                Console.Write(" ");
                Console.Write(" ");
            }
        }
        class Digit
        {
            public int name;
            public string top = " ";
            public string b1l = " ";
            public string b1r = " ";
            public string mid = " ";
            public string b2l = " ";
            public string b2r = " ";
            public string bot = " ";
        }
    }
}
