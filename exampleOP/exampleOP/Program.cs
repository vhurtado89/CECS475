using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampleOP
{
    class Program
    {
        static void Main(string[] args)
        {
            ex d = new ex("A");
            Console.WriteLine(d.id);


            string b = "b";
            d.changeID(ref b);

            Console.WriteLine(d.id);
           


            
        }
    }
}
