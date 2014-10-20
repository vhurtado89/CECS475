/*
 * Victor Hurtado
 * CECS 475
 * Assignment 4
 * 
 * 
 * Test.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class test
    {
        static void Main(string[] args)
        {
            bool done = false;
            Invoice[] invoices = new Invoice[8];
            invoices[0] = new Invoice(83, "Electric sander", 7, 57.98m);
            invoices[1] = new Invoice(24, "Power saw", 18, 99.99m);
            invoices[2] = new Invoice(7, "Sledge hammer", 11, 21.50m);
            invoices[3] = new Invoice(77, "Hammer", 76, 11.99m);
            invoices[4] = new Invoice(39, "Lawn mower", 3, 79.50m);
            invoices[5] = new Invoice(68, "Screwdriver", 106, 6.99m);
            invoices[6] = new Invoice(56, "Jig saw", 21, 11.00m);
            invoices[7] = new Invoice(3, "Wrench", 34, 7.5m);

            while (!done)
            {
                
                Console.WriteLine("Please Select one of the following.");
                Console.WriteLine("1. Sort by Part Description");
                Console.WriteLine("2. Sort by Price");
                Console.WriteLine("3. Sort by Quantity, select Part Description and Quantity.");
                Console.WriteLine("4. Select Part Description and the value of the Invoice");
                Console.WriteLine("5. Use above query to select Invoice in the range of $200 and $ 500");
                Console.WriteLine("6. Quit");

                switch (checkInput())
                {
                    case 1:
                        Console.WriteLine("Sorted by Description");
                        var partDescription = from p in invoices
                                              orderby p.PartDescription
                                              select p;
                        foreach (var i in partDescription)
                            Console.WriteLine(i);
                        break;
                    case 2:
                        Console.WriteLine("Sorted by price");
                        var price = from p in invoices
                                    orderby p.Price
                                    select p;
                        foreach (var i in price)
                            Console.WriteLine(i);
                        break;
                    case 3:
                        Console.WriteLine("Selected description and quantity, sort by quantity");
                        var quantity = from q in invoices
                                       select new { q.PartDescription, q.Quantity };
                        foreach (var i in quantity)
                            Console.WriteLine(i);
                        break;
                    case 4:
                        Console.WriteLine("Select description and invoice total, sort by invoice total.");
                        var invoice = from i in invoices
                                      let total = i.Quantity*i.Price
                                      orderby total
                                      select new { i.PartDescription, total};
                        foreach (var s in invoice)
                            Console.WriteLine(s);
                        break;
                    case 5:
                        Console.WriteLine("Invoice totals between $200 and $500");
                        var rangeInvoice = from i in invoices
                                      let total = i.Quantity*i.Price
                                      orderby total
                                      where total>200.00m && total<500.00m
                                      select new { i.PartDescription, total};
                        foreach (var s in rangeInvoice)
                            Console.WriteLine(s);
                        break;
                    case 6:
                        Console.WriteLine("Good bye");
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Wrong number input. Try Again");
                        break;
                }
                Console.WriteLine();
                
            }            


        }
        public static int checkInput()
        {
            int x = 0;
            bool correct = false;
            while (!correct)
            {
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    correct = true;
                }
                else
                {
                    Console.WriteLine("Input was a letter, try again");
                }

            }
            return x;
        }

    }
}
