using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

/*
 * Solution for the 2nd advent of code challenge 2020
 * Find out more about advent of code @ https://adventofcode.com/
 */
namespace AdventOfCode_2020_Day_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            //shorter version of ([0-9]+)-([0-9]+) ([a-z]): ([a-z]+)
            string pattern = @"(\d+)-(\d+) (\w): (\w+)";

            MatchCollection matches = Regex.Matches(input, pattern);

            Console.WriteLine("Valid Passwords Puzzle One: " + PuzzleOne(matches));
            Console.WriteLine("Valid Passwords Puzzle Two: " + PuzzleTwo(matches));
            Console.ReadKey(true);
        }

        static int PuzzleOne(in MatchCollection matches)
        {
            int min, max, validPasswords = 0, count;
            char search;
            string searchText;
            foreach (Match m in matches)
            {
                min = Convert.ToInt32(m.Groups[1].Value);
                max = Convert.ToInt32(m.Groups[2].Value);
                search = Convert.ToChar(m.Groups[3].Value);
                searchText = m.Groups[4].Value;
                count = searchText.Count(c => c == search);
                if (count >= min && count <= max)
                    validPasswords++;
            }
            return validPasswords;
        }

        static int PuzzleTwo(in MatchCollection matches)
        {
            int indexOne, indexTwo, validPasswords = 0;
            char search;
            string searchText;
            foreach (Match m in matches)
            {
                indexOne = Convert.ToInt32(m.Groups[1].Value);
                indexTwo = Convert.ToInt32(m.Groups[2].Value);
                search = Convert.ToChar(m.Groups[3].Value);
                searchText = m.Groups[4].Value;
                if ((searchText[indexOne-1] == search) != (searchText[indexTwo-1] == search))
                    validPasswords++;
            }
            return validPasswords;
        }
    }
}
