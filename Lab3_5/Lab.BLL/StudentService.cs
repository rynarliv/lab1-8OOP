using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3_5.Core
{
    public class StudentService
    {
        // Метод чистий, приймає список студентів, тому його легко тестувати без Mock-ів
        public int CountThirdYearSummerStudents(List<Student> students)
        {
            if (students == null) throw new ArgumentNullException(nameof(students));

            int count = 0;
            foreach (var s in students)
            {
                // Перевірка: Курс 3
                bool isThirdYear = s.Course == 3;

                // Перевірка: Літо (червень-6, липень-7, серпень-8)
                bool isBornInSummer = s.DateOfBirth.Month >= 6 && s.DateOfBirth.Month <= 8;

                if (isThirdYear && isBornInSummer)
                {
                    count++;
                }
            }
            return count;
        }
    }
}