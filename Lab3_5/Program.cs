using System;
using Lab3_5;

namespace Lab3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторна 3.5 - Варіант 1");

            string path = "students.txt";

            //1. Ініціалізація шарів
            var repo = new FileRepository();
            var service = new StudentService();

            try
            {
                //2. Отримання даних (DAL)
                var students = repo.GetAllStudents(path);
                Console.WriteLine($"Завантажено студентів: {students.Count}");

                //3. Обробка даних (BLL)
                int result = service.CountThirdYearSummerStudents(students);

                Console.WriteLine($"Студентів 3-го курсу, народжених влітку: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}