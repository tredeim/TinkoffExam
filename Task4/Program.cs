using System;
using System.Collections.Generic;

class MainClass
{
    static List<HashSet<string>> namesSets;
    static List<List<int>> tree;
    static List<int> prices;
    static List<string> companies;
    static List<int> sums;
    static int[] used;

    static void Main()
    {
        var input = Console.ReadLine().Split();
        var n = int.Parse(input[0]);
        var k = int.Parse(input[1]);

        var names = new List<string>();
        for (var i = 0; i < k; i++)
        {
            names.Add(Console.ReadLine());
        }

        tree = new List<List<int>>();
        prices = new List<int>();
        companies = new List<string>();
        used = new int[n + 1];
        namesSets = new List<HashSet<string>>();
        sums = new List<int>();

        tree.Add(new List<int>());
        prices.Add(0);
        companies.Add("");

        for (var i = 1; i <= n; i++)
        {
            var vertex = Console.ReadLine().Split();
            var p = int.Parse(vertex[0]);
            var a = int.Parse(vertex[1]);
            var c = vertex[2];

            tree.Add(new List<int>());
            prices.Add(a);
            companies.Add(c);

            if (p != 0)
            {
                tree[p].Add(i);
            }
        }

        used[0] = 1;
        for (var i = 0; i <= n; i++)
        {
            namesSets.Add(new HashSet<string>());
            sums.Add(0);
        }

        DFS(1);

        var minSum = int.MaxValue;
        for (var i = 1; i <= n; i++)
        {
            if (namesSets[i].Count == k && sums[i] < minSum)
                minSum = sums[i];
        }

        if (minSum == int.MaxValue)
            Console.WriteLine(-1);
        else
            Console.WriteLine(minSum);
    }

    static void DFS(int v)
    {
        used[v] = 1;
        namesSets[v].Add(companies[v]);
        sums[v] += prices[v];

        foreach (var to in tree[v])
        {
            if (used[to] == 0)
            {
                DFS(to);
                namesSets[v].UnionWith(namesSets[to]);
                sums[v] += sums[to];
            }
        }
    }
}
