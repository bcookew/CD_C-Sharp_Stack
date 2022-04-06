using System;

namespace IronNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Iron Ninja!\n");
            Buffet GrandBuffet = new Buffet();
            SweetTooth Noni = new SweetTooth();
            SpiceHound Ben = new SpiceHound();
            while (!Ben.IsFull)
            {
                Ben.Consume(GrandBuffet.serve());
            }
            while (!Noni.IsFull)
            {
                Noni.Consume(GrandBuffet.serve());
            }
            if(Noni.ConsumptionHistory.Count > Ben.ConsumptionHistory.Count)
            {
                System.Console.WriteLine($"Noni consumed {Noni.ConsumptionHistory.Count} IConsumables");
            }
            else
            {
                
                System.Console.WriteLine($"Ben consumed {Ben.ConsumptionHistory.Count} IConsumables");
            }
        }
    }
}
