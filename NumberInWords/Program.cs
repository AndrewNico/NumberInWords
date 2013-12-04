using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberInWords
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder userInput = new StringBuilder();

            //Если параметров командной строки нет - запросить число у пользователя
            if (args.Length == 0)
            {
                Console.Write("Введите число для преобразования:");
                userInput.Append(Console.ReadLine());
            }
             //Вывести справку по использованию
            else if (args[0] == "/?" || args[0] == "-?")
            {
                showHelp();
                return;
            }
            //Использовать первый аргумент командной строки в качестве числа для преобразования 
            else 
            {
                userInput.Append(args[0]);
            }

            decimal numberToTranslate;
            
            //Получить системный разделитель целой и дробной частей
            NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;

            //Заменить пользовательские разделители на системный
            userInput.Replace(".", nfi.NumberDecimalSeparator);
            userInput.Replace(",", nfi.NumberDecimalSeparator);

            //Пробуем распознать число и преобразовать его в текст
            if (Decimal.TryParse(userInput.ToString(), out numberToTranslate))
            {
                
                try
                {
                    INumberToWordsTranslate ntwt = new NumberInWordsRussianCurrency(numberToTranslate, true);
                    Console.WriteLine(ntwt.Translate());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    showHelp();
                }

            }
            else
            {
                Console.WriteLine("Введенное значение не распознано как число");
                showHelp();
            }
            //Console.ReadKey();

        }

        /// <summary>
        /// Отображает справку по использованию утилиты
        /// </summary>
        private static void showHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Вывод числа прописью в денежном формате");
            Console.WriteLine();
            Console.WriteLine("NUMBERINWORDS [число]");
            Console.WriteLine();
            Console.WriteLine("  число       Число для преобразования");
            Console.WriteLine("              дробная часть числа должна задаваться двумя знаками");
            Console.WriteLine("              при указании большего числа знаков они будут усечены");
            //Console.ReadKey();
        }
    }
}
