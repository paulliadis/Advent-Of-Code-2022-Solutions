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

namespace AdventOfCode2022
{
    public partial class Day4 : Form
    {
        public Day4()
        {
            InitializeComponent();
        }

        public class Section
        {
            public Elf Elf1 { get; set; }
            public Elf Elf2 { get; set; }

        }

        public class Elf
        {
            public int Lower { get; set; }
            public int Upper { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Data\day4.txt");

            string[] lines = System.IO.File.ReadAllLines(path); // Read all lines into an array

            var bag = new List<Section>();

            foreach (string line in lines)
            {
                string[] arr = line.Split(",");
                string[] boundElf1 = arr[0].Split("-");
                string[] boundElf2 = arr[1].Split("-");

                Elf e1 = new Elf();
                Elf e2 = new Elf();

                e1.Lower = Convert.ToInt32(boundElf1[0]);
                e1.Upper = Convert.ToInt32(boundElf1[1]);

                e2.Lower = Convert.ToInt32(boundElf2[0]);
                e2.Upper = Convert.ToInt32(boundElf2[1]);

                bag.Add(new Section
                {
                    
                    Elf1 = e1,
                    Elf2 = e2
                }); ; ;

            }

            int total = 0;

            foreach (var elf in bag)
            {
                int returned = 0;

                returned = doesItFullyContain(elf.Elf1, elf.Elf2, "part2");
                total = total + returned;
            }

            txtAnswer.Text = total.ToString();
        }
        private int doesItFullyContain(Elf elf1, Elf elf2, string part1or2) {


            if (part1or2 == "part1")
            {
                if ((elf2.Lower >= elf1.Lower) && (elf2.Upper <= elf1.Upper))
                {
                    return 1;
                }

                if ((elf1.Lower >= elf2.Lower) && (elf1.Upper <= elf2.Upper))
                {
                    return 1;
                }
            }
            else
            {
                IEnumerable<int> elf1Entries = Enumerable.Range(elf1.Lower, (elf1.Upper - elf1.Lower) + 1);
                IEnumerable<int> elf2Entries = Enumerable.Range(elf2.Lower, (elf2.Upper - elf2.Lower) + 1);

                foreach(int o in elf1Entries)
                {
                    foreach(int m in elf2Entries)
                    {
                        if(o == m)
                        {
                            return 1;
                        }
                    }
                }

            }


            return 0;
        }
    }
}
