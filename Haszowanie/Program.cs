using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Haszowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Hashing hashing = new Hashing(111);
            int iter=5000;

            while (iter > 0)
            {
                hashing.Add(random.Next(0,1000));
                iter--;
                if (iter % 100 == 0)
                {
                Console.Clear();
                Console.WriteLine("Wymiar tablicy: " +hashing.table.Length );
                }
            }
                hashing.Print();

      
            Console.ReadKey();

           
        }
    }
}
