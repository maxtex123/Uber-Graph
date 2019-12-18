/*
 * Maxine Teixeira
 * PathFinder.cs
 */
using Ksu.Cis300.Graphs;
using Ksu.Cis300.PriorityQueueLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis300_Assignment_6_F19_Shuber
{
    public class PathFinder
    {
        /// <summary>
        /// Calculates the shortest paths in order to determine the optimal path for the "driver to pick up and drop all customers off, with the restriction that someone must be picked up before them may be dropped off.
        /// </summary>
        /// <param name="graph">Contains the information about what nodes are connected to one another.</param>
        /// <param name="start">The starting node location.</param>
        /// <param name="customers">List of customers in pairs.</param>
        /// <param name="bestPath">Out parameter to return the node traversal of optimal path.</param>
        /// <returns></returns>
        public static int BestShuberPath(DirectedGraph<string, int> graph, string start, List<(string, string)> customers, out List<string> bestPath)
        {
            MinPriorityQueue <int, (UberState, UberState, List<string>)> q = new MinPriorityQueue<int, (UberState, UberState, List<string>)>();
            Dictionary<UberState, UberState> paths = new Dictionary<UberState, UberState>();
            Dictionary<UberState, List<string>> partial = new Dictionary<UberState, List<string>>();
            UberState startState = new UberState(start, customers.Count);
            q.Add(0, (null, startState, null));
            while (q.Count > 0)
            {
                int pathLength = q.MinimumPriority;
                (UberState, UberState, List<string>) remove = q.RemoveMinimumPriority();
                UberState previous = remove.Item1;
                UberState current = remove.Item2;
                List<string> list = remove.Item3;
                if (!paths.ContainsKey(current))
                {
                    paths.Add(current, previous);
                    partial.Add(current, list);
                    if (current.IsComplete())
                    {
                        bestPath = CombinePath(paths, partial, current);
                        return pathLength;
                    }
                    foreach (UberState next in current.NextStates(customers))
                    {
                        int dist = ShortestPath(current.CurrentNode, next.CurrentNode, graph, out Dictionary<string,string> partialPaths);
                        if (dist != -1)
                        {
                            List<string> nextPartial = ExtractPath(partialPaths, current.CurrentNode, next.CurrentNode);
                            q.Add(pathLength + dist, (current, next, nextPartial));
                        }
                    }
                }
            }
            bestPath = null;
            return -1;
        }
        /// <summary>
        /// Takes information from the BestShuberPath and reconstructs the path in the correct order.
        /// </summary>
        /// <param name="paths">Dictionary storing the pieces of the path in reverse order.</param>
        /// <param name="source">Node where the paths start.</param>
        /// <param name="dest">Node where the path ends</param>
        /// <returns></returns>
        private static List<string> ExtractPath(Dictionary<string, string> paths, string source, string dest)
        {
            List<string> actual = new List<string>();
            Stack<string> stack = new Stack<string>();
            while (dest != source)
            {
                stack.Push(dest);
                dest = paths[dest];
            }
            actual.Add(source);
            while (stack.Count > 0)
            {
                actual.Add(stack.Pop());
            }
            return actual;
        }
        /// <summary>
        /// Takes the information from BestShuberPath and reconstructs the entire path from the start to the finish.
        /// </summary>
        /// <param name="paths">Dictionary storing the pieces of the path in reverse order.</param>
        /// <param name="lookup">Dictionary that contains the correctly ordered partial path from the destination state.</param>
        /// <param name="lastState">Represents the completed path of the final UberState.</param>
        /// <returns></returns>
        private static List<string> CombinePath(Dictionary<UberState, UberState> paths, Dictionary<UberState, List<string>> lookup, UberState lastState)
        {
            List<string> combine = new List<string>();
            Stack<UberState> stack = new Stack<UberState>();
            while(lastState != null)
            {
                stack.Push(lastState);
                lastState = paths[lastState];
            }
            stack.Pop();
            bool first = true;
            while (stack.Count > 0)
            {
                UberState state = stack.Pop();
                List<string> partial = lookup[state];
                for (int i = 0; i < partial.Count; i++)
                {
                    if(first && i == 0)
                    {
                        combine.Add(partial[i]);
                        first = false;
                    }
                    else if(i != 0)
                    {
                        combine.Add(partial[i]);
                    }
                }
            }
            return combine;
        }
        /// <summary>
        /// Finds the shortest path from the given start node to the given end node in the graph.
        /// </summary>
        /// <param name="start">The starting node location.</param>
        /// <param name="end">The ending node location.</param>
        /// <param name="map">Graph of the paths.</param>
        /// <param name="paths">Dictionary storing the pieces of the path in reverse order.</param>
        /// <returns>The length of the shortest path.</returns>
        private static int ShortestPath(string start, string end, DirectedGraph<string, int> map, out Dictionary<string, string> paths)
        {
            MinPriorityQueue<int, Edge<string, int>> q = new MinPriorityQueue<int, Edge<string, int>>();
            Dictionary<string, string> path = new Dictionary<string, string>();
            path.Add(start, start);
            if (start == end)
            {
                paths = path;
                return 0;
            }
            foreach (Edge<string, int> e in map.OutgoingEdges(start))
            {
                q.Add(e.Data, e);
            }
            while (q.Count > 0)
            {
                int p = q.MinimumPriority;
                Edge<string, int> remove = q.RemoveMinimumPriority();
                string x = remove.Destination;
                if (!path.ContainsKey(x))
                {
                    path.Add(x, remove.Source);
                    if (x == end)
                    {
                        paths = path;
                        return p;
                    }
                    else
                    {
                        foreach (Edge<string,int> e in map.OutgoingEdges(x))
                        {
                            q.Add(p + e.Data, e);
                        }
                    }
                }
            }
            paths = path;
            return -1;
        }
    }
}
