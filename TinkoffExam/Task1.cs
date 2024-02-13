using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var t = int.Parse(Console.ReadLine());
        var d0 = Counter("TINKOFF");

        for (var i = 0; i < t; i++)
        {
            var d = Counter(Console.ReadLine());
            Console.WriteLine(AreEqual(d0, d));
        }
    }


    static Dictionary<char, int> Counter(string s)
    {
        if (s.Length != 7)
            return new Dictionary<char, int>();

        var lettersCount = new Dictionary<char, int>();
        foreach (char letter in s)
        {
            lettersCount[letter] = lettersCount.GetValueOrDefault(letter, 0) + 1;
        }

        return lettersCount;
    }

    static string AreEqual(Dictionary<char, int> d0, Dictionary<char, int> d1)
    {
        foreach (var key in d0.Keys)
        {
            if (!(d1.ContainsKey(key) && d0[key] == d1[key]))
                return "NO";
        }

        return "YeS";
    }
}
