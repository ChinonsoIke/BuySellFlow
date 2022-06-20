using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Syst

namespace practice
{
    internal class Manager : Company, IPerson
    {
        public string Name;
        public override string CompanyName { get; set; }

        public Manager(string Name, string CompanyName)
        {
            this.Name = Name;
            this.CompanyName = CompanyName;
        }
        public void Greet()
        {
            Console.WriteLine($"Manager: Hello, I am {Name}, the manager of {CompanyName}.");
        }

        public void FindFault(Cashier cashier)
        {
            if(new Random().Next(100) <= 40)
            {
                cashier.Strikes++;
            }
        }

        public void Fire(Cashier cashier)
        {
            cashier = null;
        }
    }
}
