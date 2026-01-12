using Xunit; // Або using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3_5.Core;
using System;
using System.Collections.Generic;

namespace Lab3_5.Tests
{
    public class StudentServiceTests
    {
        [Fact] // В MSTest це [TestMethod]
        public void CountThirdYearSummer_ShouldReturnCorrectCount()
        {
            // --- Arrange (Підготовка даних) ---
            var service = new StudentService();
            var students = new List<Student>
            {
                // Підходить: 3 курс, Липень (Літо)
                new Student("Test1", "Name", 3, "001", new DateTime(2000, 07, 15)), 
                // Не підходить: 2 курс, Липень (Літо)
                new Student("Test2", "Name", 2, "002", new DateTime(2001, 07, 15)),
                // Не підходить: 3 курс, Грудень (Зима)
                new Student("Test3", "Name", 3, "003", new DateTime(2000, 12, 01)),
                // Підходить: 3 курс, Серпень (Літо)
                new Student("Test4", "Name", 3, "004", new DateTime(2000, 08, 30)),
            };

            // --- Act (Виконання дії) ---
            int result = service.CountThirdYearSummerStudents(students);

            // --- Assert (Перевірка результату) ---
            // Ми очікуємо 2 студентів (першого і четвертого)
            Assert.Equal(2, result);
        }

        [Fact]
        public void CountThirdYearSummer_EmptyList_ShouldReturnZero()
        {
            // Arrange
            var service = new StudentService();
            var students = new List<Student>();

            // Act
            int result = service.CountThirdYearSummerStudents(students);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountThirdYearSummer_NullList_ShouldThrowException()
        {
            // Arrange
            var service = new StudentService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => service.CountThirdYearSummerStudents(null));
        }
    }
}