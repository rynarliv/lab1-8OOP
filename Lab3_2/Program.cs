using System;
using System.Collections;       //ArrayList
using System.Collections.Generic; //List<T>
using System.Linq; 

namespace Lab3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створимо тестові дані
            Student s1 = new Student(101, "Бондаренко Іван", 2004, 301);
            Student s2 = new Student(102, "Коваленко Марія", 2005, 301);
            Student s3 = new Student(103, "Шевченко Тарас", 2003, 401);

            Console.WriteLine(" 1. РОБОТА ЗІ ЗВИЧАЙНИМ МАСИВОМ");
            // Масив має фіксований розмір
            Student[] studentsArray = new Student[3];

            // Додавання (через індекс)
            studentsArray[0] = s1;
            studentsArray[1] = s2;
            studentsArray[2] = s3;

            // Прохід по набору (вивід)
            Console.WriteLine("Список масиву:");
            foreach (var s in studentsArray)
            {
                if (s != null) Console.WriteLine(s);
            }

            // Оновлення (зміна групи)
            Console.WriteLine("\nОновлення першого студента в масиві:");
            studentsArray[0].MoveToNextCourse();

            // Видалення (в масиві не можна просто видалити, можна тільки занулити)
            Console.WriteLine("Видалення студента з масиву (занулення):");
            studentsArray[2] = null; // Видалили s3

            // Пошук (тільки циклом)
            Console.WriteLine("Пошук студента з квитком 102:");
            for (int i = 0; i < studentsArray.Length; i++)
            {
                if (studentsArray[i] != null && studentsArray[i].TicketNumber == 102)
                {
                    Console.WriteLine("Знайдено: " + studentsArray[i]);
                }
            }


            Console.WriteLine("\n\n 2. РОБОТА З ARRAYLIST");
            // Стара колекція, зберігає все як object
            ArrayList arrayList = new ArrayList();

            // Додавання
            arrayList.Add(s1);
            arrayList.Add(s2);
            arrayList.Add(s3);
            arrayList.Add("текст"); 
            arrayList.Remove("текст"); 

            // Видалення
            Console.WriteLine("Видаляємо s2 зі списку...");
            arrayList.Remove(s2);

            // Прохід (треба приведення типів)
            Console.WriteLine("Вміст ArrayList:");
            foreach (object item in arrayList)
            {
                if (item is Student s)
                {
                    Console.WriteLine(s);
                }
            }


            Console.WriteLine("\n\n 3. РОБОТА З LIST<T> ");
           
            List<Student> studentList = new List<Student>();

            // Додавання
            studentList.Add(s1);
            studentList.Add(s2);
            studentList.Add(s3);

            // Пошук 
            Console.WriteLine("Шукаємо студента за прізвищем 'Коваленко':");
            // Використовуємо лямбду для пошуку
            Student foundStudent = studentList.Find(s => s.FullName.Contains("Коваленко"));
            if (foundStudent != null)
            {
                Console.WriteLine($"Знайдено: {foundStudent}");

                // Оновлення
                Console.WriteLine("Змінюємо їй групу");
                foundStudent.GroupNumber = 555;
            }

            // Видалення
            Console.WriteLine("Видаляємо студентів 2003 року народження...");
            studentList.RemoveAll(s => s.BirthYear == 2003);

            // Прохід
            Console.WriteLine("Фінальний список List<Student>:");
            foreach (var s in studentList)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nВисновки:");
            Console.WriteLine("-Масив: швидкий, але фіксований розмір.");
            Console.WriteLine("-ArrayList: гнучкий розмір, але повільний (boxing/unboxing) і немає перевірки типів.");
            Console.WriteLine(" List<T>: поєднує швидкість і гнучкість, найкращий вибір.");

            Console.ReadLine();
        }
    }
}