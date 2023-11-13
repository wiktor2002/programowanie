using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rownanieKwadratowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj parametry równania ax^2 + bx + c = 0:");
            Console.Write("a: ");
            double wma = Convert.ToDouble(Console.ReadLine());
            Console.Write("b: ");
            double wmb = Convert.ToDouble(Console.ReadLine());
            Console.Write("c: ");
            double wmc = Convert.ToDouble(Console.ReadLine());

            if (wma == 0)
            {
                // Rozwiązywanie równania liniowego
                if (wmb == 0)
                {
                    if (wmc == 0)
                    {
                        Console.WriteLine("Równanie ma nieskończenie wiele rozwiązań.");
                    }
                    else
                    {
                        Console.WriteLine("Równanie nie ma rozwiązań.");
                    }
                }
                else
                {
                    double wmx = -wmc / wmb;
                    Console.WriteLine("Rozwiązanie równania: x = {0}", wmx);
                }
            }
            else
            {
                // Rozwiązywanie równania kwadratowego
                double wmdelta = wmb * wmb - 4 * wma * wmc;

                if (wmdelta > 0)
                {
                    double wmx1 = (-wmb + Math.Sqrt(wmdelta)) / (2 * wma);
                    double wmx2 = (-wmb - Math.Sqrt(wmdelta)) / (2 * wma);
                    Console.WriteLine("Rozwiązania równania: x1 = {0}, x2 = {1}", wmx1, wmx2);
                }
                else if (wmdelta == 0)
                {
                    double wmx = -wmb / (2 * wma);
                    Console.WriteLine("Równanie ma jedno rozwiązanie: x = {0}", wmx);
                }
                else
                {
                    Console.WriteLine("Równanie nie ma rozwiązań.");
                }
            }

            Console.ReadLine();
        }
    }
}
