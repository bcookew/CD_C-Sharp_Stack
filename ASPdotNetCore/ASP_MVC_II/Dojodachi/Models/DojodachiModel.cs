using System;
namespace Dojodachi.Models
{
    public class DojodachiPet
    {
        public int Fullness { get; private set; }
        public int Happiness { get; private set; }
        public int Meals { get; private set; }
        public int Energy { get; private set; }
        public string LastMsg { get; private set; }
        Random rand = new Random();
        public DojodachiPet ()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            LastMsg = "Welcome! Come meet your new Dojodachi!";
        }

        public DojodachiPet(int hap, int full, int ener, int meals)
        {
            Happiness = hap;
            Fullness = full;
            Energy = ener;
            Meals = meals;
        }

        private bool LikedIt()
        {
            if(rand.Next(1,5) != 1)
            {
                return true;
            }
            return false;
        }
        public void Feed()
        {
            if (Meals > 0)
            {
                Meals--;
                if(LikedIt())
                {
                    int added = rand.Next(5,11);
                    Energy += added;
                    LastMsg = ($"You fed your Dojodachi! Energy: +{added}");
                }
                else
                {
                    LastMsg = ActionResult("Dojodachi didn't like that!");
                }
            }
            else
            {
                LastMsg = ActionResult("You have no Meals available!");
            }
        }
        
        public void Play()
        {
            if (Energy > 5)
            {
                Energy -= 5;
                if(LikedIt())
                {
                    int added = rand.Next(5,11);
                    Happiness += added;
                    LastMsg = ActionResult($"You played with your Dojodachi! Happiness: +{added}");
                }
                else
                {
                    LastMsg = ActionResult("Dojodachi didn't like that!");
                }
            }
            else
            {
                LastMsg = ActionResult("You don't have enough Energy!");
            }
        }
        public void Work()
        {
            if (Energy > 5)
            {
                Energy -= 5;
                int added = rand.Next(1,4);
                Meals += added;
                LastMsg = ActionResult($"You worked with your Dojodachi! Meals: +{added}");
            }
            else
            {
                LastMsg = ActionResult("You don't have enough Energy!");
            }
        }
        public void Sleep()
        {
            Energy += 15;
            Happiness -= 5;
            Fullness -= 5;
            LastMsg = ActionResult($"Your Dojodachi got some rest! Energy: +15, Happiness: -5, Fullness: -5");
        }
        private string ActionResult(string msg)
        {
            if(Win())
            {
                return "You Won! You took care of your Dojodachi well!";
            }
            else if (Lose())
            {
                return "You lost! You took care of your Dojodachi poorly!";
            }
            else
            {
                return msg;
            }
        }
        private bool Win()
        {
            if(Energy >= 100 && Fullness >= 100 && Energy >= 100)
            {
                return true;
            }
            return false;
        }
        private bool Lose()
        {
            if(Fullness <= 0 || Energy <= 0)
            {
                return true;
            }
            return false;
        }


    }
}