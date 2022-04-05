using System;

namespace WizardNinjaSamurai
{
    class Ninja : Human
    {
        public Ninja(string name, int str=3, int intel=3, int hp=100) : base(name, str, intel, 175, hp)
        {
            
        }
        public override int Attack(Human target)
        {
            Random rand = new Random();
            target.Health -= Dexterity * 5;
            if (rand.Next(1,6) == 1)
            {
                target.Health -= 10;
            }
            return target.Health;
            
        }
        public int Steal(Human target)
        {
            target.Health -= 5;
            Health += 5;
            return Health;
        }
    }

}