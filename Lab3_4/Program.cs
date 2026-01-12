using System;

namespace Lab3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //ч1.лямбда-вираз             сортування
            Console.WriteLine("Завдання 1. лямбда-вираз");
            Console.WriteLine("Суть: Програма має взяти перемішані числа і поскладати їх по порядку.");

            int[] nums = { 7, 2, 9, 1, 5 };

            //делегат через лямбда-вираз
            SortDelegate sortOperation = (arr) => Array.Sort(arr);

            sortOperation(nums);

            Console.WriteLine("Масив відсортовано: " + string.Join(", ", nums));
            Console.WriteLine();

            //ч2. подія машина 
            Console.WriteLine("Завдання 2 і 3. Події");
            Console.WriteLine("Суть: Створити машину, їздити, поки не закінчиться бензин.");
            Console.WriteLine("Коли бензин скінчиться — має спрацювати автоматичне сповіщення (Подія).\n");

            Car myCar = new Car("Toyota", 15);
            Console.WriteLine($"START! створили машину {myCar.Model}. У баку {myCar.Fuel} літрів пального.");

            myCar.OutOfGas += Car_Handler;

            //тест
            myCar.Drive(10); 
            myCar.Drive(10); 

            Console.ReadKey();
        }

        private static void Car_Handler(object sender, CarEventArgs e)
        {
            Car carInfo = (Car)sender;
            Console.WriteLine($"/ПОДІЯ ОТРИМАНА/ Автомобіль {carInfo.Model}: {e.Message}");
        }
    }
}