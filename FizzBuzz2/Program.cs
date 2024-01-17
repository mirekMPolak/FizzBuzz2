using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Podaj dowolną liczbę całkowitą z przedziału: {long.MinValue + 1}...-3, -2, -1, 0, 1, 2, 3,...{long.MaxValue - 1} :");

                var number = CheckInt();

                var playFizzBuzz = new FizzBuzz2();

                Console.WriteLine(playFizzBuzz.IsDivisible(number));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
        private static long CheckInt()
        {
            var input = IsNotEmpty();

            var permissibleValuesForInputInt = "-1234567890";

            foreach (var sign in input)
            {
                if (!permissibleValuesForInputInt.Contains(sign))
                {
                    throw new Exception("Wprowadzane dane muszą składać się wyłącznie z cyfr oraz ewentualnie znaku '-' na początku.!");
                }
            }

            if (input.IndexOf("-", 0, input.Length, StringComparison.CurrentCulture) > 0 | input == "-")
            {
                throw new Exception("Znak minus tylko na początku, przed liczbą.!");
            }

            if (!long.TryParse(input, out long inputInt))
            {
                throw new Exception("Podana wartość jest nieprawidłowa ( z poza podanego zakresu ).!");
            }
            return inputInt;
        }
        private static string IsNotEmpty()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Nie wypełniono pola.!");
            }
            return input;
        }
    }
}
