using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab3_1
{
    // ЗАВДАННЯ 5     Операції роботи з файлами в окремому класі
    public class FileHandler
    {
        private string _filePath;

        public FileHandler(string path)
        {
            _filePath = path;
        }
        // ЗАВДАННЯ 3   Застосування класів потокового виведення 
        //запис масиву у файл
        public void SaveToFile(Person[] people, int count)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, false)) // false означає перезапис файлу
            {
                for (int i = 0; i < count; i++)
                {
                    var p = people[i];
                    string type = p.GetType().Name;

                    //заголовок об'єкта: Тип Ім'яПрізвище
                    sw.WriteLine($"{type} {p.FirstName}{p.LastName}");
                    sw.WriteLine("{");
                    sw.WriteLine($" \"firstname\": \"{p.FirstName}\",");
                    sw.WriteLine($" \"lastname\": \"{p.LastName}\",");

                    //специфічні поля для студента
                    if (p is Student s)
                    {
                        sw.WriteLine($" \"studentId\": \"{s.StudentId}\",");
                        sw.WriteLine($" \"course\": \"{s.Course}\",");
                        sw.WriteLine($" \"birthdate\": \"{s.BirthDate:dd-MM-yyyy}\"");
                    }
                    else
                    {
                        //щоб закрити формат (коряво, але для лаби піде)
                        sw.WriteLine($" \"type\": \"generic\"");
                    }

                    sw.WriteLine("};");
                }
            }
            Console.WriteLine("Дані успішно збережено у файл!");
        }

        //ЗАВДАННЯ 3   читання з файлу. Повертає масив і кількість через out параметр
        public Person[] LoadFromFile(out int loadedCount)
        {
            Person[] tempArray = new Person[100]; //максимум 100, бо колекції не можна
            loadedCount = 0;

            if (!File.Exists(_filePath)) return tempArray;
            
            using (StreamReader sr = new StreamReader(_filePath))
            {
                string line;
                string currentType = "";
                string fName = "", lName = "", sId = "";
                int course = 0;
                DateTime bDate = DateTime.MinValue;

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (string.IsNullOrEmpty(line)) continue;

                    //початок об'єкта
                    if (!line.StartsWith("{") && !line.StartsWith("}") && !line.Contains(":"))
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length > 0) currentType = parts[0];
                    }

                    //парсинг атрибутів
                    if (line.Contains(":"))
                    {
                        //витягуємо ключ і значення через прості заміни
                        var parts = line.Split(':');
                        string key = parts[0].Replace("\"", "").Trim();
                        string value = parts[1].Replace("\"", "").Replace(",", "").Trim();

                        switch (key)
                        {
                            case "firstname": fName = value; break;
                            case "lastname": lName = value; break;
                            case "studentId": sId = value; break;
                            case "course": int.TryParse(value, out course); break;
                            case "birthdate": DateTime.TryParse(value, out bDate); break;
                        }
                    }

                    //кінець об'єкта
                    if (line.StartsWith("};"))
                    {
                        if (currentType == "Student")
                        {
                            tempArray[loadedCount++] = new Student(fName, lName, sId, bDate, course);
                        }
                        else if (currentType == "Teacher")
                        {
                            tempArray[loadedCount++] = new Teacher(fName, lName);
                        }
                        else if (currentType == "Astronaut")
                        {
                            tempArray[loadedCount++] = new Astronaut(fName, lName);
                        }

                        //скидання змінних
                        fName = ""; lName = ""; currentType = "";
                    }
                }
            }
            return tempArray;
        }
    }
}