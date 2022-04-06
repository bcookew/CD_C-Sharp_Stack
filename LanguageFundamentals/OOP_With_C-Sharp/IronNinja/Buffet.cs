using System;
using System.Collections.Generic;

namespace IronNinja
{
    class Buffet
    {
        public List<IConsumable> Menu;
        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Pizza", 300, false, false),
                new Food("Yoghurt", 120, false, false),
                new Food("Buffalo Wings", 250, true, false),
                new Food("Habanero Pineapple Salsa", 100, true, true),
                new Food("Cake", 600, false, true),
                new Drink("Coke", 200),
                new Drink("Iced Tea", 150),
                new Drink("Sprite", 175),
                new Drink("Water", 0),
                new Drink("Gin", 50),
                new Drink("Cranberry Juice", 120)
            };
        }
        public IConsumable serve()
        {
            Random rand = new Random();
            return Menu[rand.Next(0,Menu.Count)];
        }
    }
}