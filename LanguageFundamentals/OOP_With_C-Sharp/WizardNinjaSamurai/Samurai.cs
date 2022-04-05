using System;

namespace WizardNinjaSamurai
{
    class Samurai : Human
    {
        public Samurai(string name, int str=3, int intel=3, int dex=3) : base(name, str, intel, dex, 200)
        {
            
        }
        public override int Attack(Human target)
        {
            base.Attack(target);
            if (target.Health < 50)
            {
                target.Health = 0;
            }
            return target.Health;
            
        }
        public int Meditate()
        {
            Health = 200;
            return Health;
        }
    }
}