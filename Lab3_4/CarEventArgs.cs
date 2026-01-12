using System;

namespace Lab3_4
{
    //клас для передачі повідомлення при виникненні події
    public class CarEventArgs : EventArgs
    {
        public string Message { get; }

        public CarEventArgs(string message)
        {
            Message = message;
        }
    }
}