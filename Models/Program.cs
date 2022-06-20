using System;

namespace practice.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cashier1 = new Cashier("Emeka", "Temple Hill Supermarket");
            var manager1 = new Manager("Steve", "Temple Hill Supermarket");
            var customer1 = new Customer(30);
            customer1.Greet();
            cashier1.Greet();

            Interract(cashier1, customer1);
            bool done = false;
            bool customerSatisfied = CheckSatisfied(cashier1);

            while (customerSatisfied && !done)
            {
                Console.WriteLine($"{cashier1.Name}: Would you like to make another purchase?");
                Console.Write($"You (Y/N): ");

                if (Console.ReadLine() == "Y")
                {
                    Interract(cashier1, customer1);
                    customerSatisfied = CheckSatisfied(cashier1);
                }
                else
                {
                    Console.WriteLine($"{cashier1.Name}: Thank you for coming in. Have a nice day.");
                    done = true;
                }
            }

            if (!customerSatisfied)
            {
                Console.WriteLine($"{cashier1.Name}: I'm so sorry about that. Let me get my manager.");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine();
                GetManager(manager1, cashier1);
            }


        }

        public static void GetManager(Manager manager, Cashier cashier)
        {
            manager.Greet();
            Console.WriteLine($"{manager.Name}: I'm sorry you had a bad experience with us. Was this due to something the cashier did?");
            Console.Write($"You (Y/N): ");
            string reply4 = Console.ReadLine();

            if (reply4 == "Y")
            {
                Console.WriteLine($"{manager.Name}: Thank you for your feedback. I am going to look into this issue.");
                manager.FindFault(cashier);
                if (cashier.Strikes == 2)
                {
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine();
                    Console.WriteLine($"{manager.Name}: This is the 2nd time we have found {cashier.Name} guilty of mistreating a customer. He has therefore been let go.");
                    manager.Fire(cashier);
                }
                Console.WriteLine("We are sorry you had to experience that. Have a nice day.");
            }
        }

        public static void Interract(Cashier cashier, Customer customer)
        {
            var products = Enum.GetValues(typeof(Products));
            Console.WriteLine($"{cashier.Name}: Our available products include:");
            foreach (int product in products)
            {
                Console.WriteLine($"{Enum.GetName(typeof(Products), product)}: ${product:N2}");
            }
            Console.WriteLine($"{cashier.Name}: What would you like to purchase?");
            Console.Write("You: ");
            string reply = Console.ReadLine().ToLower();

            if (Enum.IsDefined(typeof(Products), reply))
            {
                decimal price = (int)Enum.Parse(typeof(Products), reply);
                Console.WriteLine($"{cashier.Name}: Okay, {reply} costs ${price:N2}. Do you want it?");
                Console.Write("You (Y/N): ");
                string reply2 = Console.ReadLine();

                if (reply2 == "Y")
                {
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine();
                    if (customer.Budget >= price)
                    {
                        customer.Buy(price);
                        cashier.Sell();
                    }
                    else
                        Console.WriteLine($"{cashier.Name}: Sorry your money is not enough to make this purchase.");
                }
            }
        }

        public static bool CheckSatisfied(Cashier cashier)
        {
            Console.WriteLine($"{cashier.Name}: Thank you for coming in. Are you satisfied with our service?");
            Console.Write($"You (Y/N): ");
            string reply3 = Console.ReadLine();

            if (reply3 == "N")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
