using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    internal class _0994
    {
        public int OrangesRotting(int[][] grid)
        {
            var rotters = new HashSet<(int Row, int Column)>();
            var links = new Dictionary<(int Row, int Col),List<(int Row, int Col)>>();
            var fresh = 0;

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    var slot = grid[row][col];

                    if(slot == 0)
                        continue;

                    if (slot == 1)
                        fresh++;

                    if (slot == 2)
                        rotters.Add((row, col));

                    if (!links.ContainsKey((row, col)))
                        links[(row, col)] = new List<(int Row, int Col)>();

                    if (col + 1 < grid[row].Length && grid[row][col + 1] != 0)
                    {
                        if (links.TryGetValue((row, col), out var list))
                        {
                            list.Add((row, col + 1));
                            if(links.TryGetValue((row, col + 1), out list))
                                list.Add((row, col));
                            else
                                links[(row, col + 1)] = new List<(int Row, int Col)>() { (row, col) };
                        }
                        else
                        {
                            links[(row, col)] = new List<(int Row, int Col)>() { (row, col + 1) };
                            if (links.TryGetValue((row, col + 1), out list))
                                list.Add((row, col));
                            else
                                links[(row, col + 1)] = new List<(int Row, int Col)>() { (row, col) };
                        }
                    }

                    if (row + 1 < grid.Length && grid[row + 1][col] != 0)
                    {
                        if (links.TryGetValue((row, col), out var list))
                        {
                            list.Add((row + 1, col));
                            if (links.TryGetValue((row + 1, col), out list))
                                list.Add((row, col));
                            else
                                links[(row + 1, col)] = new List<(int Row, int Col)>() { (row, col) };
                        }
                        else
                        {
                            links[(row, col)] = new List<(int Row, int Col)>() { (row + 1, col) };
                            if (links.TryGetValue((row + 1, col), out list))
                                list.Add((row, col));
                            else
                                links[(row + 1, col)] = new List<(int Row, int Col)>() { (row, col) };
                        }
                    }
                }
            }

            var iterations = 0;
            var stateChange = false;
            do
            {
                stateChange = false;
                var newVictims = new HashSet<(int Row, int Column)>();

                foreach (var rotter in rotters)
                {
                    foreach(var potentialVictim in links[rotter])
                    {
                        if (!rotters.Contains(potentialVictim))
                            newVictims.Add(potentialVictim);
                    }
                }

                stateChange = newVictims.Any();
                if (newVictims.Any())
                {
                    rotters.UnionWith(newVictims);
                    fresh -= newVictims.Count;
                    iterations++;
                }
            } 
            while (stateChange);

            if (fresh == 0)
                return iterations;

            return -1;
        }

        [Test]
        public void Test1()
        {
            Assert.That(OrangesRotting(
                    [
                    [2, 1, 1], 
                    [1, 1, 0], 
                    [0, 1, 1]
                    ]
                ), Is.EqualTo(4));
        }

        [Test]
        public void Test2()
        {
            Assert.That(OrangesRotting([[2, 1, 1], [0, 1, 1], [1, 0, 1]]), Is.EqualTo(-1));
        }

        [Test]
        public void Test3()
        {
            Assert.That(OrangesRotting([[0, 2]]), Is.EqualTo(0));
        }
    }
}
