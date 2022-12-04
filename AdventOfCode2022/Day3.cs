using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace AdventOfCode2022
{
    public class Rucksack
    {
        public string Compartment1 { get; set; }
        public string Compartment2 { get; set; }
    }

    public partial class Day3 : Form
    {
        public Day3()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> priorities = new Dictionary<string, int>();
            priorities.Add("a", 1);
            priorities.Add("b", 2);
            priorities.Add("c", 3);
            priorities.Add("d", 4);
            priorities.Add("e", 5);
            priorities.Add("f", 6);
            priorities.Add("g", 7);
            priorities.Add("h", 8);
            priorities.Add("i", 9);
            priorities.Add("j", 10);
            priorities.Add("k", 11);
            priorities.Add("l", 12);
            priorities.Add("m", 13);
            priorities.Add("n", 14);
            priorities.Add("o", 15);
            priorities.Add("p", 16);
            priorities.Add("q", 17);
            priorities.Add("r", 18);
            priorities.Add("s", 19);
            priorities.Add("t", 20);
            priorities.Add("u", 21);
            priorities.Add("v", 22);
            priorities.Add("w", 23);
            priorities.Add("x", 24);
            priorities.Add("y", 25);
            priorities.Add("z", 26);
            priorities.Add("A", 27);
            priorities.Add("B", 28);
            priorities.Add("C", 29);
            priorities.Add("D", 30);
            priorities.Add("E", 31);
            priorities.Add("F", 32);
            priorities.Add("G", 33);
            priorities.Add("H", 34);
            priorities.Add("I", 35);
            priorities.Add("J", 36);
            priorities.Add("K", 37);
            priorities.Add("L", 38);
            priorities.Add("M", 39);
            priorities.Add("N", 40);
            priorities.Add("O", 41);
            priorities.Add("P", 42);
            priorities.Add("Q", 43);
            priorities.Add("R", 44);
            priorities.Add("S", 45);
            priorities.Add("T", 46);
            priorities.Add("U", 47);
            priorities.Add("V", 48);
            priorities.Add("W", 49);
            priorities.Add("X", 50);
            priorities.Add("Y", 51);
            priorities.Add("Z", 52);


            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Data\day3.txt");

            string[] lines = System.IO.File.ReadAllLines(path); // Read all lines into an array
            var bag = new List<Rucksack>();
            int totalPriorities = 0;

            foreach (string line in lines)
            {
                int length = line.Length;
                int half = (length / 2);
                bag.Add(new Rucksack
                {
                    Compartment1 = line.Substring(0,half),
                    Compartment2 = line.Substring(half)
                });

            }

            foreach (var item in bag)
            {
                string commonLetter;

                commonLetter = findCommon(item.Compartment1,item.Compartment2);
                totalPriorities = totalPriorities + priorities[commonLetter];
            }
        }

        private string findCommon(string compartment1, string compartment2)
        {

            var intersect = compartment1.Intersect(compartment2);


            foreach (int id in intersect)
            {
                char c = (char)id;
                string s = c.ToString();
                return s;
            }
            return "";
        }
    }
}
