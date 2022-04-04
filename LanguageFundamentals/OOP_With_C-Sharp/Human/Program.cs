using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human ben = new Human("Ben",16,18,15,100);
            Human joe = new Human("Joe");
            System.Console.WriteLine(ben.Attack(joe));
        }
    }
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int Health;

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }
        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }

        public int Attack(Human target)
        {
            target.Health -= this.Strength * 5;
            return target.Health;
        }
    }
}
