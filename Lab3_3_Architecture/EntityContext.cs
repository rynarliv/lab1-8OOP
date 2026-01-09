using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab3_3
{
    //РІВЕНЬ DAL  - доступ до даних
    //клас EntityContext, що містить методи для запису/читання файлу
    public class EntityContext<T>
    {
        private string _filePath;

        public EntityContext(string fileName)
        {
            _filePath = fileName;
        }

        //метод для запису даних у файл 
        public void SaveData(List<T> data)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

            //using, щоб файл точно закрився
            using (FileStream fs = new FileStream(_filePath, FileMode.Create))
            {
                formatter.Serialize(fs, data);
            }
        }

        //метод для читання даних з файлу (Десеріалізація)
        public List<T> LoadData()
        {
            //якщо файлу ще немає, повертаємо пустий список, щоб не було помилки
            if (!File.Exists(_filePath))
            {
                return new List<T>();
            }

            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                return (List<T>)formatter.Deserialize(fs);
            }
        }
    }
}