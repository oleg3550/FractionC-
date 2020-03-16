using System;

namespace FractionCShp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checking default constructor...");
            FractCshp.Fraction fraction = new FractCshp.Fraction();
            Console.WriteLine(fraction.ToString());
            Console.WriteLine("Введите две дроби в формате числитель/знаменатель");
            FractCshp.Fraction fr1;
            FractCshp.Fraction fr2;
            while (true)
            {
                try
                {
                    fr1 = FractCshp.Fraction.Parse(Console.ReadLine());
                    fr2 = FractCshp.Fraction.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Вы ошиблись, повторите ввод!");
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            long a;
            Console.WriteLine("Введите любое целое число");
            while (true)
            {
                try
                {
                    a = Int64.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Вы ошиблись, повторите ввод!");
                    continue;
                }
            }

            try
            {
                Console.WriteLine("Унарный минус: {0}", -fr1);
                Console.WriteLine("Сумма двух дробей: {0}", fr1 + fr2);
                Console.WriteLine("Разность двух дробей: {0}", fr1 - fr2);
                Console.WriteLine("Произведение двух дробей: {0}", fr1 * fr2);
                Console.WriteLine("Частное двух дробей: {0}", fr1 / fr2);

                Console.WriteLine("Сумма дроби и числа: {0}", fr1 + a);
                Console.WriteLine("Разность дроби и числа: {0}", fr1 - a);
                Console.WriteLine("Произведение дроби и числа: {0}", fr1 * a);
                Console.WriteLine("Частное дроби и числа: {0}", fr1 / a);

                Console.WriteLine("Проверка на равенство: {0}", fr1 == fr2);
                Console.WriteLine("Проверка на неравенство: {0}", fr1 != fr2);
                Console.WriteLine("Проверка на >: {0}", fr1 > fr2);
                Console.WriteLine("Проверка на <: {0}", fr1 < fr2);
                Console.WriteLine("Проверка на >=: {0}", fr1 >= fr2);
                Console.WriteLine("Проверка на <=: {0}", fr1 <= fr2);
                Console.WriteLine("Проверка на хеш-коды: {0} {1}",
                fr1.GetHashCode(), fr2.GetHashCode());

                Console.WriteLine("Вывод в формате double: {0}", fr1.ToDouble());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}

