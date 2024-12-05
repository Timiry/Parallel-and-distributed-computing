using System;
namespace MyProgram
{
    public class Hello : System.MarshalByRefObject
    {
        public Hello()
        {
            Console.WriteLine("Объект создан");
        }
        ~Hello()
        {
            Console.WriteLine("Объект уничтожен");
        }
        public string Greeting(string name)
        {
            return "Привет, " + name;
        }
    }
}
