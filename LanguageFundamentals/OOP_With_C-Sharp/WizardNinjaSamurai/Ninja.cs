using System;

namespace WizardNinjaSamurai
{
    class Ninja : Human
    {
        public Ninja(string name) : base(name, 3, 3, 175, 100){}
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