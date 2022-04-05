using System;

namespace WizardNinjaSamurai
{
    class Wizard : Human
    {
        public Wizard(string name, int str=3, int dex=3) : base(name, str, 25, dex, 50)
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