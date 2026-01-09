using System.Collections.Generic;
using System.Linq; //для пошуку

namespace Lab3_3
{
    //РІВЕНЬ BLL - Бізнес-логіка
    //EntityService - містить методи додавання, видалення, пошуку.   не працює з консоллю напряму

    public class EntityService
    {
        private EntityContext<Student> _context;
        private List<Student> _students;

        public EntityService()
        {
            //зв'язуємо сервіс із базою даних у файлі data.xml
            _context = new EntityContext<Student>("data.xml");

            //завантажуємо існуючих студентів при запуску
            _students = _context.LoadData();
        }

        public void AddStudent(Student newStudent)
        {
            _students.Add(newStudent);
            SaveChanges(); 
        }

        //отримання всіх студентів 
        public List<Student> GetAllStudents()
        {
            return _students;
        }

        //пошук студента за прізвищем
        public List<Student> FindStudentByName(string namePart)
        {
            //шукаємо всіх, чиє ім'я містить введений текст
            List<Student> found = new List<Student>();
            foreach (var s in _students)
            {
                if (s.FullName.Contains(namePart))
                {
                    found.Add(s);
                }
            }
            return found;
        }

        //метод збереження
        private void SaveChanges()
        {
            _context.SaveData(_students);
        }
    }
}