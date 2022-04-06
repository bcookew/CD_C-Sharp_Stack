using System;
namespace IronNinja
{
    class SpiceHound : Ninja
    {
        public int MaxCalories;
        public SpiceHound() : base(){
            MaxCalories = 1200;
        }
        public override bool IsFull {get{return calorieIntake >= MaxCalories;}}
        public override void Consume(IConsumable item)
        {
            if(IsFull) {System.Console.WriteLine("SweetTooth is full!");}
            else
            {
                ConsumptionHistory.Add(item);
                calorieIntake += item.Calories;
                if (item.IsSweet) {calorieIntake += 5;}
                item.GetInfo();
            }
        }
        
    }
}