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
using static System.Formats.Asn1.AsnWriter;

namespace AdventOfCode2022
{
    public partial class Day2 : Form
    {
        public Day2()
        {
            InitializeComponent();
        }

        // 1st column
        // A = Rock
        // B = Paper
        // C = Scissors

        // 2nd column
        // X = Rock
        // Y = Paper
        // Z = Scissors

        //The winner of the whole tournament is the player with the highest score. Your total score is the sum of your scores for each round. 
        //The score for a single round is the score for the shape you selected(1 for Rock, 2 for Paper, and 3 for Scissors) plus the score 
        //for the outcome of the round(0 if you lost, 3 if the round was a draw, and 6 if you won).

        //Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock. If both players choose the same shape,
        //the round instead ends in a draw.

        private void button1_Click(object sender, EventArgs e)
        {
            // Logged in to adventofcode via github

            Dictionary<string, int> scores = new Dictionary<string, int>();
            scores.Add("X", 1);
            scores.Add("Y", 2);
            scores.Add("Z", 3);

            Dictionary<string, int> pointLookup = new Dictionary<string, int>();
            pointLookup.Add("X", 0);
            pointLookup.Add("Y", 3);
            pointLookup.Add("Z", 6);

            int roundScore = 0;
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Data\day2.txt");

            string[] lines = System.IO.File.ReadAllLines(path); // Read all lines into an array
            
            foreach (string line in lines)
            {
                roundScore = (calculateYourMove(line.Substring(0, 1), line.Substring(2, 1)) + pointLookup[line.Substring(2, 1)]) + roundScore;

                // Part 1 calculation -> roundScore =  (scores[line.Substring(2, 1)] + didYouWin_Part1(line.Substring(0, 1), line.Substring(2,1))) + roundScore;
            }

            txtTotal.Text = roundScore.ToString();
        }

        private int didYouWin_Part1(string opponent, string you)
        {
            if ((opponent == "A") && (you == "X") || (opponent == "B") && (you == "Y") || (opponent == "C") && (you == "Z")) // draw
            {
                return 3;
            }
            else
            {
                if (opponent == "A") // Rock
                {
                    if (you == "Z") // Scissors
                    {
                        return 0; // Loss
                    }
                    else
                    {
                        return 6; // Win

                    }
                }

                if (opponent == "B") // Paper
                {
                    if (you == "X") // Rock
                    {
                        return 0; // Loss
                    }
                    else
                    {
                        return 6; // Win

                    }
                }

                if (opponent == "C") // Scissors
                {
                    if (you == "Y") // Paper
                    {
                        return 0; // Loss
                    }
                    else
                    {
                        return 6; // Win

                    }
                }
            }
            return 0;
        }

        private int calculateYourMove(string opponent, string outcome)
        {
             
            Dictionary<string, int> moveLookup = new Dictionary<string, int>();
            moveLookup.Add("A", 1);
            moveLookup.Add("B", 2);
            moveLookup.Add("C", 3);

            if (outcome == "Y") // Draw
            {
                return moveLookup[opponent];
            }

            if (outcome == "X") // Loss
            {
                if(opponent == "A")
                {
                    return 3;
                }

                if (opponent == "B")
                {
                    return 1;
                }

                if (opponent == "C")
                {
                    return 2;
                }
            }

            if (outcome == "Z") // Win
            {
                if (opponent == "A")
                {
                    return 2;
                }

                if (opponent == "B")
                {
                    return 3;
                }

                if (opponent == "C")
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
