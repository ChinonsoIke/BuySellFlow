using practice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class Cashier : Company, IPerson
    {
        public string Name;
        public int Strikes = 0;
        public override string CompanyName { get; set; }

        public Cashier(string Name, string CompanyName)
        {
            this.Name = Name;
            this.CompanyName = CompanyName;
        }
        public void Greet()
        {
            Console.WriteLine($"Cashier: Hello, I am {Name}. Welcome to {CompanyName}.");
        }

        public void Sell()
        {
            Console.WriteLine($"{Name}: Thank you for your purchase.");
        }
    }
}
