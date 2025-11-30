using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleAppMichael
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// 1. list for levels
            levels = new List<decimal>();

            // 2. set Upper price
            Console.WriteLine("Введите начальную цену: ");
            string str = Console.ReadLine().Replace('.', ','); //"1.0".Replace('.', ',');
            //decimal startPrice;

            bool isNumber = decimal.TryParse(str, out startPrice);

            while (!isNumber)
            {
                Console.WriteLine("Некорректное значение, введите десятичное число:");
                str = Console.ReadLine().Replace('.', ',');
                isNumber = decimal.TryParse(str, out startPrice);
            }

            // 4. set levels quantity, >= minstep
            Console.WriteLine("Введите количество уровней:");
            str = Console.ReadLine().Replace('.', ','); 
            //int levelsTotal;

            isNumber = Int32.TryParse(str, out levelsTotal);

            while (!isNumber)
            {
                Console.WriteLine("Некорректное значение, введите количество уровней:");
                str = Console.ReadLine().Replace('.', ',');
                isNumber = Int32.TryParse(str, out levelsTotal);
            }

            // 5.set minstep for instrument, >0
            Console.WriteLine("Введите шаг цены уровней: ");
            str = Console.ReadLine().Replace('.', ','); //"1.0".Replace('.', ',');
            //decimal stepPrice;

            isNumber = decimal.TryParse(str, out stepPrice);

            while (!isNumber)
            {
                Console.WriteLine("Некорректное значение, введите шаг цены уровней:");
                str = Console.ReadLine().Replace('.', ',');
                isNumber = decimal.TryParse(str, out stepPrice);
            }
            // переменные для расчёта уровней по введённым данным
            decimal priceLevel = startPrice;

            // cycle
            int i = 0;
            while (i < levelsTotal && priceLevel > 0)
            {
                levels.Add(priceLevel);
                priceLevel -= stepPrice;
                i += 1;
            }

            WriteListByLine();


        }
        // пользовательские переменные
        static List<decimal> levels;
        static decimal startPrice;
        static int levelsTotal;
        // рассчётные переменнные
        static decimal priceLevel;
        static decimal stepPrice;

        static void WriteListByLine()
            {
            Console.WriteLine("Количество уровней: " + levels.Count().ToString());

            for (int i = 0; i < levels.Count(); i++)
            {
                Console.WriteLine(levels[i]);
            }
        }
    }
}
