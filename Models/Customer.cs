using practice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class Customer : IPerson
    {
        public decimal Budget;

        public Customer(decimal budget)
        {
            Budget = budget;
        }

        public void Greet()
        {
            Console.WriteLine("You: Hello, good day to you");
        }

        public void Buy(decimal price)
        {
            Budget -= price;
        }
    }
}
