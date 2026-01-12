using System;

namespace Lab3_1
{
    //З2.базовий абстрактний клас, щоб не копіювати ім'я/прізвище всюди
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public abstract void DisplayInfo(); //ПОЛІМОРФІЗМ щоб кожен показував себе по-своєму
        public abstract void SpecificAction(); //для Study(), Teach() і т.д.
    }

    public class Student : Person
    {
        //З2. додати атрибути по доцільності
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
        //СПЕЦИФІЧНІ ДІЇ 
        public override void SpecificAction()

        {

            Console.WriteLine($"Студент {LastName} гризе граніт науки в універі.");
        }

        //ДОД ВМІННЯ - співати
        public void Sing()
        {
            Console.WriteLine($"{FirstName} співає в караоке після пар.");
        }
    }
    // ЗАВДАННЯ       Додаткова сутність Teacher
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
    //ЗАВДАННЯ   Додаткова сутність Astronaut
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