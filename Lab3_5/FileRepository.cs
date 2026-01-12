using Lab3_5;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Lab3_5
{
    public class FileRepository
    {
        //метод зчитує дані з файлу і повертає список студентів
        public List<Student> GetAllStudents(string filePath)
        {
            var students = new List<Student>();

            //1. Перевірка чи існує файл
            if (!File.Exists(filePath))
            {
                //файлу немає - кидає помилку, яку зловимо в Program.cs
                throw new FileNotFoundException($"Файл '{filePath}' не знайдено!");
            }

            //2. Зчитуємо всі рядки
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                //апропуск пусті рядки, щоб не було помилок
                if (string.IsNullOrWhiteSpace(line)) continue;

                //3. Розділяємо рядок за комою
              
                string[] parts = line.Split(',');

                //перевіряємо, чи є всі 5 елементів
                if (parts.Length == 5)
                {
                    try
                    {
                        string lastName = parts[0].Trim();
                        string firstName = parts[1].Trim();
                        int course = int.Parse(parts[2].Trim());
                        string ticket = parts[3].Trim();

                        //парсимо дату у точний формат "день-місяць-рік" (як у завданні XX-XX-XXXX)
                        DateTime dob = DateTime.ParseExact(parts[4].Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                        //створюємо об'єкт і додаємо в список
                        students.Add(new Student(lastName, firstName, course, ticket, dob));
                    }
                    catch (Exception)
                    {
                        //Якщо рядок пошкоджений то ряд пропуск
                        continue;
                    }
                }
            }

            return students;
        }
    }
}