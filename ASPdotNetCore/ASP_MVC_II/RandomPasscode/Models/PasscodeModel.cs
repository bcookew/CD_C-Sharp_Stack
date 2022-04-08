using System;
namespace RandomPasscode.Models
{
    public class Passcode
    {
        private string CharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public int count {get;set;}
        public string code {get;set;}

        public Passcode()
        {
            NewCode();
        }
        public void NewCode()
        {
            Random rand = new Random();
            count += 1;
            code = "";
            for (int i = 0; i < 14; i++)
            {
                code += CharSet[rand.Next(0,CharSet.Length)];
            }            
        }
    }
}