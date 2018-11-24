using Eventos.IO.Domain.Eventos;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var evento = new Evento("",DateTime.Now,DateTime.UtcNow,true,50,true,"");

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
