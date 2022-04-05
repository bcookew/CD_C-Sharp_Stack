using System;

namespace WizardNinjaSamurai
{
    class Wizard : Human
    {
        public Wizard(string name) : base(name, 3, 25, 3, 50)
        {
            
        }
        public override int Attack(Human target)
        {
            target.Health -= Intelligence * 5;
            return target.Health;
            
        }
        public int Heal(Human target)
        {
            target.Health += Intelligence * 10;
            return target.Health;
        }
    }

}