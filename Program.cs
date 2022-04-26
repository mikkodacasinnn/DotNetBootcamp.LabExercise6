using System;
using System.Collections.Generic;

namespace CSharp.LabExercise6
{
    public class Scrabble
    {
        public int Points { get; set; }
        public static Dictionary<char, int> letters = new Dictionary<char, int>()
        {
            {'A', 1 }, {'E', 1 }, {'I', 1 }, {'O', 1 }, {'U', 1 }, {'L', 1 }, {'N', 1 },
            {'R', 1 }, {'S', 1 }, {'T', 1 }, {'D', 2 }, {'G', 2 }, {'B', 3 }, {'C', 3 },
            {'M', 3 }, {'P', 3 }, {'F', 4 }, {'H', 4 }, {'V', 4 }, {'W', 4 }, {'Y', 4 },
            {'K', 5 }, {'J', 4 }, {'X', 4 }, {'Q', 10 }, {'Z', 10 }
        };

        public int ScoreTotal;
        public int Score(string inputWord)
        {
            ScoreTotal = 0;
            foreach (char letter in inputWord)
            {
                letters.TryGetValue(letter, out ScoreTotal);
                Points += ScoreTotal;
            }
            return Points;
        }

    }

    class Validator
    {
        public string ValidInput { get => "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }

        public bool Validation(string inputWord)
        {
            for (int i = 0; i < inputWord.Length; i++)
            {
                if (!ValidInput.Contains(inputWord[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Scrabble scrabble = new Scrabble();
                Validator validator = new Validator();

                Console.WriteLine("*****MIKKO'S SCRABBLE*****");
                Console.Write("Enter a word: ");
                string inputWord = Console.ReadLine();
                
                if (!validator.Validation(inputWord.ToUpper()))
                {
                    Console.WriteLine("Invalid Input. Please try again");
                    continue;
                }

                Console.WriteLine($"Score: {scrabble.Score(inputWord.ToUpper())}");
                Console.WriteLine("DO YOU WANT TO CONTINUE? Y/N");
                string choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                {
                    Main();
                }
                else
                {
                    Environment.Exit(0);
                }
            } 
        }
    }
}
