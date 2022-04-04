using System;
using System.Collections.Generic;
namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Ninja Buffet!");
            Ninja Ben = new Ninja();
            Buffet buffet = new Buffet();
            while (!Ben.IsFull)
            {
                Ben.Eat(buffet.serve());
            }
            Ben.Eat(buffet.serve());
        }
    }
    class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;
        
        public Food (string name, int cals, bool spicy, bool sweet)
        {
            Name = name;
            Calories = cals;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }
    class Buffet
    {
        public List<Food> Menu;
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Pizza", 300, false, false),
                new Food("Yoghurt", 120, false, false),
                new Food("Buffalo Wings", 250, true, false),
                new Food("Habanero Pineapple Salsa", 100, true, true),
                new Food("Cake", 600, false, true)
            };
        }
        public Food serve()
        {
            Random rand = new Random();
            return Menu[rand.Next(0,Menu.Count)];
        }
    }
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }
        public bool IsFull
        {
            get{return calorieIntake > 1200;}
        }
        public void Eat(Food item)
        {   
            if (this.IsFull)
            {
                System.Console.WriteLine("The ninja is full and cannot consume any more food!");
            }
            else
            {
                this.FoodHistory.Add(item);
                this.calorieIntake += item.Calories;
                System.Console.WriteLine($"The ninja ate {item.Name}");
                if (item.IsSweet && item.IsSpicy)
                {
                    System.Console.WriteLine("It was Sweet and Spicy!");
                }
                else if (item.IsSpicy)
                {
                    System.Console.WriteLine("It was Spicy!");
                }
                else if (item.IsSweet)
                {
                    System.Console.WriteLine("It was Sweet!");
                }
            }
        }
    }
}
