



using System;
using System.Text.RegularExpressions;


namespace Lab3_1
{
    class Program
    {
        //БД на масивах
        static Person[] database = new Person[50];
        static int count = 0;
        static FileHandler fileHandler = new FileHandler("database.txt");

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\nМЕНЮ");
                Console.WriteLine("1. Додати Студента");
                Console.WriteLine("2. Додати Викладача");
                Console.WriteLine("3. Показати всіх");
                Console.WriteLine("4. Зберегти у файл");
                Console.WriteLine("5. Завантажити з файлу");
                Console.WriteLine("6. Завдання варіанту (Студенти 3 курсу, літні)");
                Console.WriteLine("0. Вихід");
                Console.Write("Вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": AddTeacher(); break;
                    case "3": ShowAll(); break;
                    case "4": fileHandler.SaveToFile(database, count); break;
                    case "5":
                        database = fileHandler.LoadFromFile(out count);
                        Console.WriteLine($"Завантажено {count} записів.");
                        break;
                    case "6": RunVariantTask(); break;
                    case "0": return;
                    default: Console.WriteLine("Щось не те натиснула."); break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Ім'я: ");
            string name = Console.ReadLine();
            Console.Write("Прізвище: ");
            string surname = Console.ReadLine();

            //ЗАВДАННЯ валідація ID регуляркою (наприклад, KB123456)
            string id;
            while (true)
            {
                Console.Write("Студентський (формат KBxxxxxx): ");
                id = Console.ReadLine();
                if (Regex.IsMatch(id, @"^[A-Z]{2}\d{6}$")) break;
                Console.WriteLine("Невірний формат! Спробуй ще раз.");
            }

            Console.Write("Курс (1-6): ");
            int course = int.Parse(Console.ReadLine());

            Console.Write("Дата народження (дд-мм-рррр): ");
            DateTime birth = DateTime.Parse(Console.ReadLine());

            database[count++] = new Student(name, surname, id, birth, course);
            Console.WriteLine("Студента додано.");
        }

        static void AddTeacher()
        {
            Console.Write("Ім'я: ");
            string name = Console.ReadLine();
            Console.Write("Прізвище: ");
            string surname = Console.ReadLine();
            database[count++] = new Teacher(name, surname);
            Console.WriteLine("Викладача додано.");
        }

        static void ShowAll()
        {
            if (count == 0) Console.WriteLine("Список порожній.");
            for (int i = 0; i < count; i++)
            {
                database[i].DisplayInfo();
                database[i].SpecificAction();
            }
        }
        // ЗАВДАННЯ    Обчислити кількість студентів 3-го курсу, які народилися влітку
        static void RunVariantTask()
        {
            Console.WriteLine("\nРезультати пошуку (3 курс, літо)");
            bool found = false;
            for (int i = 0; i < count; i++)
            {
                if (database[i] is Student s)
                {
                    bool isSummer = s.BirthDate.Month >= 6 && s.BirthDate.Month <= 8;
                    if (s.Course == 3 && isSummer)
                    {
                        s.DisplayInfo();
                        found = true;
                    }
                }
            }
            if (!found) Console.WriteLine("Таких не знайдено.");
        }
    }
}