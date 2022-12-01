using System.Reflection;

namespace AdventOfCode2022
{
    public partial class Day1 : Form
    {
        public Day1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Logged in to adventofcode via github
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Data\day1.txt");

            string[] lines = System.IO.File.ReadAllLines(path); // Read all lines into an array

            //Initialize variables
            int elfCounter = 0;
            int totalCalories = 0;

            //Create a dictionary to store the totals for each elf
            Dictionary<int, int> elves = new Dictionary<int, int>();

            foreach (string line in lines)
            {
                if (line != "")
                {   
                    // If not a blank line, convert the line to int and add to total 
                    int calories = Convert.ToInt32(line);
                    totalCalories = totalCalories + calories;
                }
                else
                {
                    // If blank line, add previous to dictionary and init total to 0
                    elves.Add(elfCounter, totalCalories);
                    elfCounter++;
                    totalCalories = 0;
                }

            }


            List<int> sortedElves = new List<int>(elves.Values); // Convert dictionary to a list

            sortedElves.Sort(); // Sort the list
            sortedElves.Reverse(); // Reverse the list so top 3 are in first spots of list

            var newList = sortedElves.Take(3); // Get first 3 items from the list, these are the largest totals

            int top3 = 0;

            foreach (var str in newList)
                top3 = top3 + str; // Add them together

            txtCalories.Text = top3.ToString();

            //var mostCalories = sortedElves.LastOrDefault();
            //txtCalories.Text = mostCalories.ToString();
        }
    }
}