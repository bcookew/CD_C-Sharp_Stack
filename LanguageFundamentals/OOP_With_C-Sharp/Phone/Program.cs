using System;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Phone World!");

            Galaxy s8 = new Galaxy("s8",100,"T-Mobile","Dooo do doo dooo");
            Nokia elevenHundred = new Nokia("1100", 60, "Metro PCS", "Ringgg ring ringgg");

            s8.DisplayInfo();
            System.Console.WriteLine(s8.Ring());
            System.Console.WriteLine(s8.Unlock(),"\n");

            elevenHundred.DisplayInfo();
            System.Console.WriteLine(elevenHundred.Ring());
            System.Console.WriteLine(elevenHundred.Unlock(),"\n");
        }
    }
}
