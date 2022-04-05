using System;

namespace WizardNinjaSamurai
{
    class Samurai : Human
    {
        public Samurai(string name) : base(name, 3, 3, 3, 200){}
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