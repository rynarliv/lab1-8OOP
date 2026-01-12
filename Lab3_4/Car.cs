using System;

namespace Lab3_4
{
    public class Car
    {
        // Подія - закінчення бензину/ використ стандартний EventHandler
        public event EventHandler<CarEventArgs> OutOfGas;

        public string Model { get; set; }
        public int Fuel { get; private set; }

        public Car(string model, int fuel)
        {
            Model = model;
            Fuel = fuel;
        }

        //метод, що імітує рух
        public void Drive(int km)
        {
            Console.WriteLine($"Автомобіль {Model} пробує проїхати {km} км");

            if (Fuel >= km)
            {
                Fuel -= km;
                Console.WriteLine($"Успішно. Залишилось пального: {Fuel} л");
            }
            else
            {
                //пального не вистачає
                Fuel = 0;
                Console.WriteLine("Немає пального");

                //якщо є підписники, викликаємо подію
                if (OutOfGas != null)
                {
                    OutOfGas(this, new CarEventArgs("Бак пустий"));
                }
            }
        }
    }
}