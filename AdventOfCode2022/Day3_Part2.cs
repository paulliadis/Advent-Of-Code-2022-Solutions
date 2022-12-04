using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode2022
{
    public partial class Day3_Part2 : Form
    {
        public Day3_Part2()
        {
            InitializeComponent();
        }

        public class ElfGroup
        {
            public string Elf1 { get; set; }
            public string Elf2 { get; set; }
            public string Elf3 { get; set; }
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
            var elf = new List<ElfGroup>();

            int totalPriorities = 0;
            int rowCounter = 1;

            ElfGroup elfy = new ElfGroup();

            foreach (string line in lines)
            {
                if(rowCounter < 4)
                {

                    if (rowCounter == 1)
                    {
                        elfy.Elf1 = line;
                        rowCounter++;
                    }
                    else if(rowCounter == 2)
                    {
                        elfy.Elf2 = line;
                        rowCounter++;
                    }
                    else if(rowCounter == 3)
                    {
                        elfy.Elf3 = line;

                        elf.Add(elfy);
                        elfy = new ElfGroup();
                        rowCounter = 1;
                    }
                }

            }

            foreach (var em in elf)
            {
                string commonLetter;

                commonLetter = findCommon(em.Elf1, em.Elf2, em.Elf3);
                totalPriorities = totalPriorities + priorities[commonLetter];
            }

            txtAnswer.Text = totalPriorities.ToString();

        }

        private string findCommon(string Elf1, string Elf2, string Elf3)
        {

            var intersect = Elf1.Intersect(Elf2);
            var intersect1 = Elf3.Intersect(intersect);

            foreach (int id in intersect1)
            {
                char c = (char)id;
                string s = c.ToString();
                return s;
            }
            return "";
        }
    }
}
