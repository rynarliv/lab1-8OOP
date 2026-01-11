using Lab3_3;
using System;

namespace Lab3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //налаштування консолі для відображення української мови
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            //В Main повинен бути тільки виклик методу MainMenu
            Menu myMenu = new Menu();
            myMenu.MainMenu();
        }
    }
}