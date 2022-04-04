using System;
using System.Collections.Generic;
namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Collections Practice!");
            
            // Arrays
            int[] arr1 = {0,1,2,3,4,5,6,7,8,9};
            string[] arr2 = {"Tim","Martin","Nikki","Sara"};
            bool[] arr3 = {true,false,true,false,true,false,true,false,true,false};

            // List Generic
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Vanilla");
            flavors.Add("Boysenberry");
            flavors.Add("Rocky Road");
            flavors.Add("Strawberry");
            System.Console.WriteLine(flavors.Count);
            System.Console.WriteLine(flavors[3]);
            flavors.RemoveAt(3);
            System.Console.WriteLine(flavors.Count);

            // Dictionary Generic
            Random rand = new Random();
            Dictionary<string,string> users = new Dictionary<string, string>();
            foreach (string name in arr2)
            {
                users.Add(name, flavors[rand.Next(0,flavors.Count)]);
            }
            foreach (KeyValuePair<string,string> pair in users)
            {
                System.Console.WriteLine($"{pair.Key} loves {pair.Value} ice cream!");
            }
            
        }
    }
}
