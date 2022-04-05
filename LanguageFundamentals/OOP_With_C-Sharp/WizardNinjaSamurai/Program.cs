using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Fighters!");
            Wizard wizard = new Wizard("Wanda");
            Ninja ninja = new Ninja("Nancy");
            Samurai samurai = new Samurai("Sam");

            System.Console.WriteLine($"Wanda the Wizard has attacked Samurai Sam leaving him at {wizard.Attack(samurai)}hp!");
            System.Console.WriteLine($"Nancy Ninja has attacked Samurai Sam leaving him at {ninja.Attack(samurai)}hp!");
            samurai.Attack(ninja);
            System.Console.WriteLine($"Wanda heals Sam to{wizard.Heal(samurai)}hp");
            System.Console.WriteLine($"Sam meditates and restores himself to {samurai.Meditate()}hp");
            System.Console.WriteLine($"Nancy stole life from Wanda raising her to {ninja.Steal(wizard)}hp\nand leaving Wanda at {wizard.Health}hp");
            // wizard.PrintAttribs();
            // ninja.PrintAttribs();
            // samurai.PrintAttribs();

        }
    }
}