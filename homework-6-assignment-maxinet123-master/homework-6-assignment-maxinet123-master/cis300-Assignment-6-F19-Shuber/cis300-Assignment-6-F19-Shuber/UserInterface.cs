/*
 * Maxine Teixeira
 * UserInterface.cs
 */
using Ksu.Cis300.Graphs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cis300_Assignment_6_F19_Shuber
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Holds the graph that represents the connections among all nodes in the present scenario.
        /// </summary>
        private DirectedGraph<string, int> _graph;
        /// <summary>
        /// Holds the list of customers information in pairs.
        /// </summary>
        private List<(string, string)> _customers;
        /// <summary>
        /// Holds the node where the Shuber drive is located.
        /// </summary>
        private string _startNode;
        /// <summary>
        /// Initializes components.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Loads the text file with the specifications of a graph and a ride.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _graph = ReadGraph(uxOpenDialog.FileName, out _customers, out _startNode);
                    FillBoxes();
                    FindBestPath();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        /// <summary>
        /// Extracts the information from the given file into the appropriate variables.
        /// </summary>
        /// <param name="fn">Name of file.</param>
        /// <param name="customers">List of customers.</param>
        /// <param name="startNode">Starting node.</param>
        /// <returns>The graph that is read from the file.</returns>
        private DirectedGraph<string, int> ReadGraph(string fn, out List<(string, string)> customers, out string startNode)
        {
            DirectedGraph<string, int> map = new DirectedGraph<string, int>();
            customers = new List<(string, string)>();
            using (StreamReader sr = File.OpenText(fn))
            {
                string[] line = sr.ReadLine().Split(' ');
                int numEdges = Convert.ToInt32(line[0]);
                int numCustomers = Convert.ToInt32(line[1]);
                for (int i = 0; i < numEdges; i++)
                {
                    string[] edgeInfo = sr.ReadLine().Split(' ');
                    map.AddEdge(edgeInfo[0], edgeInfo[1], Convert.ToInt32(edgeInfo[2])); //sourceNode, destinationNode,edgeWeight
                    map.AddEdge(edgeInfo[1], edgeInfo[0], Convert.ToInt32(edgeInfo[2])); //add in both dirrections bc you dont know which way you going
                }
                for (int i = 0; i < numCustomers; i++)
                {
                    string[] cusmInfo = sr.ReadLine().Split(' ');
                    customers.Add((cusmInfo[0],cusmInfo[1]));
                }
                startNode = sr.ReadLine();
                return map;
            }
        }
        /// <summary>
        /// Determines if a path for the current scenario exist for the driver to take.
        /// </summary>
        private void FindBestPath()
        { 
            int found = PathFinder.BestShuberPath(_graph, _startNode, _customers, out List<string> path);
            if (found == -1)
            {
                //uxCustomerNodesBox.Items.Clear();
                //uxAllNodesBox.Items.Clear();
                //uxPathBox.Items.Clear();
                uxPathWeightBox.Text = "Path not found.";
            }
            else
            {
                DisplayPath(path);
                uxPathWeightBox.Text = found.ToString();
            }

        }
        /// <summary>
        /// Displays the given trip path in the Path listbox.
        /// </summary>
        /// <param name="path">List of string for the path.</param>
        private void DisplayPath(List<string> path)
        {
            uxPathBox.Items.Clear();
            uxPathBox.BeginUpdate();
            foreach(string s in path)
            {
                uxPathBox.Items.Add(s);
            }
            uxPathBox.EndUpdate();
        }
        /// <summary>
        /// Displays the non-path related data read from the file in the appropriate listboxes.
        /// </summary>
        private void FillBoxes()
        {
            uxAllNodesBox.Items.Clear();
            uxAllNodesBox.BeginUpdate();
            foreach (string s in _graph.Nodes)
            {
                uxAllNodesBox.Items.Add(s);
            }
            uxAllNodesBox.EndUpdate();
            uxCustomerNodesBox.Items.Clear();
            uxCustomerNodesBox.BeginUpdate();
            foreach ((string, string) s in _customers)
            {
                uxCustomerNodesBox.Items.Add(s);
            }
            uxCustomerNodesBox.EndUpdate();
        }
    }
}
