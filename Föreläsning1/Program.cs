using System;
namespace Lecture
{
    class Program
    {
        static int numbersRead = 0;

        static void Main(string[] args)
        {
            Console.WriteLine(Add(1, 6, 3, 8, 2, 5));

            bool exit;
            do
            {
                int number1;
                bool cont = ReadNumber(out number1);
                if (!cont) break;

                int number2;
                cont = ReadNumber(out number2, prompt: "Ange ett till tal");
                if (!cont) break;

                int summa = Add(number1, number2);
                Console.WriteLine("Summan är " + summa);

                Console.WriteLine("Antal lästa tal: " + numbersRead);
                Console.WriteLine("Press any key to continue, [q] to exit.");
                ConsoleKey key = Console.ReadKey(intercept: true).Key;
                exit = (key == ConsoleKey.Q);
            } while (!exit);
        }

        private static bool ReadNumber(out int number, string prompt = "Ange ett tal")
        {
            numbersRead += 1;

            bool success;
            string error = "";

            do
            {
                Console.WriteLine(prompt + error);
                string input = Console.ReadLine();
                success = int.TryParse(input, out number);
                if (input.ToLower().StartsWith("q")) return false;
                if (!success) error = " (obs, enbart siffror)";

            } while (!success);
            return true;
        }

        static int Add(params int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }


        static float Add(float a, float b)
        {
            return a + b;
        }

    }
}