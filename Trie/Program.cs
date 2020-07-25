using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Trie
{
    class Program
    {
        static void Main()
        {
            var items = new List<string> { "armed", "armed", "jazz", "jaws" };
            var stream = new StreamReader(@"words.txt");

            while (!stream.EndOfStream)
                items.Add(stream.ReadLine());

            var stopwatch = new Stopwatch();

            var trie = new Trie();
            var hashset = new HashSet<string>();
            const string s = "gau";

            stopwatch.Start();
            trie.InsertRange(items);
            stopwatch.Stop();
            Console.WriteLine($"Trie insertion in {stopwatch.ElapsedTicks} ticks");
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < items.Count; i++)
                hashset.Add(items[i]);
            stopwatch.Stop();
            Console.WriteLine($"HashSet in {stopwatch.ElapsedTicks} ticks");
            stopwatch.Reset();

            Console.WriteLine("-------------------------------");

            stopwatch.Start();
            var prefix = trie.Prefix(s);
            var foundT = prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
            stopwatch.Stop();
            Console.WriteLine($"Trie search in {stopwatch.ElapsedTicks} ticks found:{foundT}");
            stopwatch.Reset();

            stopwatch.Start();

            var foundL = hashset.FirstOrDefault(str => str.StartsWith(s));

            stopwatch.Stop();
            Console.WriteLine($"$HashSet search in {stopwatch.ElapsedTicks} ticks found:{foundL}");

            trie.Delete("jazz");
            Console.Read();
        }
    }
}
