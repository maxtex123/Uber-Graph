/*
 * Maxine Teixeira
 * UberState.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis300_Assignment_6_F19_Shuber
{
    public class UberState
    {
        /// <summary>
        /// Customers' pick-up location that are set to true if the location has been visited, otherwise false.
        /// </summary>
        private bool[] _sources;
        /// <summary>
        /// Customers' drop-up location that are set to true if the location has been visited, otherwise false.
        /// </summary>
        private bool[] _destinations;
        /// <summary>
        /// Indicates whether the hash code has been calculated.
        /// </summary>
        private bool _hashcodeComputed;
        /// <summary>
        /// The objects hashcode.
        /// </summary>
        private int _hashcode;
        /// <summary>
        /// The current node location.
        /// </summary>
        public string CurrentNode { get; private set; }
        /// <summary>
        /// Constructs a new state with the given currentNode as the current node, and initializes customers pick up and drop off locations private fields.
        /// </summary>
        /// <param name="currentNode">Current node.</param>
        /// <param name="numCustomers">Number of customers.</param>
        public UberState(string currentNode, int numCustomers)
        {
            CurrentNode = currentNode;
            _sources = new bool[numCustomers];
            _destinations = new bool[numCustomers];
        }
        /// <summary>
        /// Replicates the information stored within this UberState object.
        /// </summary>
        /// <param name="other">UberState object.</param>
        private UberState(UberState other)
        {
            CurrentNode = other.CurrentNode;
            _sources = (bool[]) other._sources.Clone();
            _destinations = (bool[]) other._destinations.Clone();
        }
        /// <summary>
        /// Uses the parameter and this state’s private fields to generate and yield the next valid states.
        /// </summary>
        /// <param name="customers">List of tuples to generate and yield the next valid state.</param>
        /// <returns>All valid resulting states from a given state.</returns>
        public IEnumerable<UberState> NextStates(List<(string, string)> customers)
        {
            for (int i = 0; i < _sources.Length; i++)
            {
                if (!_sources[i])
                {
                    UberState next = TravelToSource(customers[i].Item1, i);
                    yield return next;
                }
            }
            for (int i = 0; i < _destinations.Length; i++)
            {
                if (_sources[i] && !_destinations[i])
                {
                    UberState next = TravelToDestination(customers[i].Item2, i);
                    yield return next;
                }
            }
        }
        /// <summary>
        /// Uses the copy constructor to create the state to be returned, updates the copied state's current node as the source and marks the source index as visited.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="sourceNum">Index of the source.</param>
        /// <returns>Result next state given the source and the source number</returns>
        public UberState TravelToSource(string source, int sourceNum)
        {
            if (sourceNum < 0 || sourceNum > _sources.Length)
            {
                throw new ArgumentException();
            }
            UberState s = new UberState(this);
            s.CurrentNode = source;
            s._sources[sourceNum] = true;
            return s;
        }
        /// <summary>
        /// Uses the copy constructor to create the state to be returned, updates the copied state's current node as the source and marks the source index as visited.
        /// </summary>
        /// <param name="destination">The destination.</param>
        /// <param name="destinationNum">Index of the destination.</param>
        /// <returns>Result next state given the destination and the destination number</returns>
        public UberState TravelToDestination(string destination, int destinationNum)
        {
            if (destinationNum < 0 || destinationNum > _destinations.Length)
            {
                throw new ArgumentException();
            }
            UberState d = new UberState(this);
            d.CurrentNode = destination;
            d._destinations[destinationNum] = true;
            return d;
        }
        /// <summary>
        /// Determines if this UberState represents a completed state of all sources/destinations visited by the driver.
        /// </summary>
        /// <returns>True if path is completed.</returns>
        public bool IsComplete()
        {
            for (int i = 0; i < _sources.Length; i++)
            {
                if (!_sources[i] || !_destinations[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Gets the previously calculated the hashcode, otherwise calculates the hash code for this object.
        /// </summary>
        /// <returns>The hash code that was calculated.</returns>
        public override int GetHashCode()
        {
            if (!_hashcodeComputed)
            {
                _hashcode = 0;
                foreach(char c in CurrentNode)
                {
                    _hashcode *= 37; //any prime number
                    _hashcode += c;
                }
                _hashcode *= 37;
                _hashcode += _sources.Length;
                for (int i = 0; i < _sources.Length; i++)
                {
                    _hashcode *= 37;
                    if (_sources[i])
                    {
                        _hashcode+=1;
                    }
                    _hashcode *= 37;
                    if (_destinations[i])
                    {
                        _hashcode+=1;
                    }
                }
                _hashcodeComputed = true;
            }
            return _hashcode;
        }
        /// <summary>
        /// Determines equality for two UberState objects
        /// </summary>
        /// <param name="x">UberState x.</param>
        /// <param name="y">UberState y.</param>
        /// <returns>True if equal.</returns>
        public static bool operator == (UberState x, UberState y)
        {
            if (Equals(x, null))
            {
                return Equals(y, null);
            }
            else if (Equals(y, null))
            {
                return false;
            }
            else
            {
                if (x._sources.Length != y._sources.Length)
                {
                    return false;
                }
                if (x.CurrentNode != y.CurrentNode)
                {
                    return false;
                }
                for (int i = 0; i < x._sources.Length; i++)
                {
                    if (x._sources[i] != y._sources[i] || x._destinations[i] != y._destinations[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        /// <summary>
        /// Compares this state with the given object for equality.
        /// </summary>
        /// <param name="obj">Object being compared.</param>
        /// <returns>True if equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is UberState uber)
            {
                return this == uber;
            }
            return false;
        }
        /// <summary>
        /// Determines whether the given states are different or not.
        /// </summary>
        /// <param name="x">UberState x.</param>
        /// <param name="y">UberState y.</param>
        /// <returns>True if not equal.</returns>
        public static bool operator != (UberState x, UberState y)
        {
            return !(x == y);
        }
    }
}
