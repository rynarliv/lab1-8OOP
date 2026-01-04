using System;

namespace Lab3_1
{
    //базовий абстрактний клас, щоб не копіювати ім'я/прізвище всюди
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public abstract void DisplayInfo(); //щоб кожен показував себе по-своєму
        public abstract void SpecificAction(); //для Study(), Teach() і т.д.
    }

    public class Student : Person
    {
        public string StudentId { get; set; } //студентський квиток
        public DateTime BirthDate { get; set; }
        public int Course { get; set; }

        public Student(string first, string last, string id, DateTime birth, int course)
            : base(first, last)
        {
            StudentId = id;
            BirthDate = birth;
            Course = course;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Student] {FirstName} {LastName}, ID: {StudentId}, Курс: {Course}, ДН: {BirthDate:dd.MM.yyyy}");
        }

        public override void SpecificAction()
















        {
            Console.WriteLine($"Студент {LastName} гризе граніт науки в універі.");
        }

        // Це по варіанту 1 - співати
        public void Sing()
        {
            Console.WriteLine($"{FirstName} співає в караоке після пар.");
        }
    }

    public class Teacher : Person
    {
        public Teacher(string first, string last) : base(first, last) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Teacher] {FirstName} {LastName}");
        }

        public override void SpecificAction()
        {
            Console.WriteLine($"Викладач {LastName} проводить лекцію.");
        }

        public void Teach()
        {
            Console.WriteLine($"{FirstName} навчає студентів розуму.");
        }
    }

    public class Astronaut : Person
    {
        public Astronaut(string first, string last) : base(first, last) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Astronaut] {FirstName} {LastName}");
        }

        public override void SpecificAction()
        {
            Console.WriteLine($"Астронавт {LastName} готується до перевантажень.");
        }
    }
}