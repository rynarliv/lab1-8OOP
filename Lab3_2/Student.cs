using System;

namespace Lab3_2
{
    public class Student
    {
        
        public int TicketNumber { get; set; } 
        public string FullName { get; set; }  
        public int BirthYear { get; set; }    
        public int GroupNumber { get; set; } 

        public Student(int ticket, string name, int year, int group)
        {
            TicketNumber = ticket;
            FullName = name;
            BirthYear = year;
            GroupNumber = group;
        }

       

        // Переведення на наступний курс
        public void MoveToNextCourse()
        {
            GroupNumber += 100; // Наприклад, з 101 групи в 201
            Console.WriteLine($"-> Студента {FullName} переведено до групи {GroupNumber}.");
        }

        // Обчислення віку
        public int GetAge()
        {
            return DateTime.Now.Year - BirthYear;
        }

        // Виведення інформації (перевизначаємо ToString для зручності)
        public override string ToString()
        {
            return $"Студент: {FullName} (Квиток: {TicketNumber}), {GetAge()} років, Група: {GroupNumber}";
        }
    }
}