using System;
namespace IronNinja
{
    class SweetTooth : Ninja
    {
        int MaxCalories;
        public SweetTooth() : base(){
            MaxCalories = 1500;
        }
        
        public override bool IsFull {get{return calorieIntake >= MaxCalories;}}
        public override void Consume(IConsumable item)
        {
            if(IsFull) {System.Console.WriteLine("SpiceHound is full!");}
            else
            {
                ConsumptionHistory.Add(item);
                calorieIntake += item.Calories;
                if(item.IsSpicy) {calorieIntake -= 5;}
                item.GetInfo();
            }
        }

    }
}