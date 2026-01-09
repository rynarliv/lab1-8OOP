using Lab3_3;
using System;

namespace Lab3_3
{
    //РІВЕНЬ PL  - Рівень представлення
    //Menu для взаємодії з користувачем
    public class Menu
    {
        private EntityService _service;

        public Menu()
        {
            _service = new EntityService();
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("1. Показати всіх студентів");
                Console.WriteLine("2. Додати студента");
                Console.WriteLine("3. Знайти студента");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        AddNew();
                        break;
                    case "3":
                        Search();
                        break;
                    case "0":
                        return; 
                        Console.WriteLine("Невірний вибір");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAll()
        {
            Console.Clear();
            var students = _service.GetAllStudents();

            Console.WriteLine("Список студентів");
            if (students.Count == 0)
            {
                Console.WriteLine("Список пустий.");
            }
            else
            {
                foreach (var s in students)
                {
                    Console.WriteLine(s.ToString());
                }
            }
            Console.WriteLine("\nНатисніть будь-яку кнопку");
            Console.ReadKey();
        }

        private void AddNew()
        {
            Console.Clear();
            Console.WriteLine("Додавання студента");

            Console.Write("Введіть ПІБ: ");
            string name = Console.ReadLine();

            Console.Write("Введіть номер квитка: ");
            string ticket = Console.ReadLine();

            Console.Write("Введіть групу: ");
            string group = Console.ReadLine();

            Console.Write("Введіть рік народження: ");
            //проста перевірка на число, щоб програма не впала
            int year;
            if (!int.TryParse(Console.ReadLine(), out year))
            {
                year = 2000; 
            }

            //створюємо об'єкт і передаємо в сервіс
            Student s = new Student(ticket, name, year, group);
            _service.AddStudent(s);

            Console.WriteLine("Студента успішно додано і збережено!");
            Console.ReadKey();
        }

        private void Search()
        {
            Console.Clear();
            Console.Write("Введіть частину імені для пошуку: ");
            string query = Console.ReadLine();

            var results = _service.FindStudentByName(query);

            Console.WriteLine($"\nЗнайдено: {results.Count}");
            foreach (var s in results)
            {
                Console.WriteLine(s.ToString());
            }
            Console.ReadKey();
        }
    }
}