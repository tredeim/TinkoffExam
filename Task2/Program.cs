using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var t = int.Parse(Console.ReadLine());
        for (var i = 0; i < t; i++)
        {
            var n = int.Parse(Console.ReadLine());
            var powers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            if (powers.Sum() >= 2 * (n - 1))
                Console.WriteLine("YeS");
            else
                Console.WriteLine("NO");
        }
    }
}