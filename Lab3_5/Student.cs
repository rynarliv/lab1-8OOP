using System;

namespace Lab3_5
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Course { get; set; }
        public string StudentTicket { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(string lastName, string firstName, int course, string ticket, DateTime dob)
        {
            LastName = lastName;
            FirstName = firstName;
            Course = course;
            StudentTicket = ticket;
            DateOfBirth = dob;
        }
    }
}