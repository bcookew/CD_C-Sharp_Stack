using System;

namespace WizardNinjaSamurai
{
    public class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
         
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
         
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
         
        public Human(string name, int str=3, int intel=3, int dex=3, int hp=100)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }
         
        // Build Attack method
        public virtual int Attack(Human target)
        {
            int dmg = Strength * 3;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
        public void PrintAttribs()
        {
            System.Console.WriteLine($"Name: {Name}\nStr: {Strength}\nInt: {Intelligence}\nDex: {Dexterity}\nHealth: {Health}");
        }
    }
}