using System;

namespace Lab3_3
{
    //описати клас, заданий варіантом (В1 Студент)
    public class Student
    {
        public string TicketNumber { get; set; } 
        public string FullName { get; set; }     
        public int BirthYear { get; set; }      
        public string GroupNumber { get; set; } 

        //обов'язковий пустий конструктор для XML-серіалізації
        public Student() { }

        public Student(string ticket, string name, int year, string group)
        {
            TicketNumber = ticket;
            FullName = name;
            BirthYear = year;
            GroupNumber = group;
        }

        //перевизначили метод щоб гарно виводити інформацію 
        public override string ToString()
        {
            return $"Студент: {FullName}, Група: {GroupNumber}, Квиток: {TicketNumber}, Рiк: {BirthYear}";
        }
    }
}