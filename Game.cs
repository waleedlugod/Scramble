using System;
using System.Collections.Generic;
using System.IO;

namespace Scramble
{
    public static class Game
    {
        public const int MAX_GUESSES = 5;
        private static List<string> words = new List<string>();
        private static string word;


        public static List<string> Load(string fileName)
        {
            TextReader textIn = new StreamReader(fileName);
            
            // First line in file is dedicated to how many words are in the file
            string wordCountStr = textIn.ReadLine();
            int wordCount = int.Parse(wordCountStr);

            for (int i = 0; i < wordCount; i++)
            {
                string word = textIn.ReadLine();
                Words.Add(word);
            }
            textIn.Close();

            return Words;
        }

        public static string PickWord()
        {
            Random rnd = new Random();

            int index = rnd.Next(1, 100);
            Word = Words[index];

            return Word;
        }

        public static string Scramble()
        {
            Random rnd = new Random();
            string result;
            char[] scrambledWord;
            int index;
            char letter;

            scrambledWord = Word.ToCharArray();

            do
            {
                // Loops through each letter of the word
                for (int i = 0; i < Word.Length; i++)
                {
                    // Chooses a random letter which is not the current letter
                    do
                    {
                        index = rnd.Next(0, Word.Length);
                    } while (index == i);

                    // Swaps the current letter and the randomly chosen letter
                    letter = scrambledWord[i];
                    scrambledWord[i] = scrambledWord[index];
                    scrambledWord[index] = letter;
                }

                result = new string(scrambledWord);
            } while (Word == result);

            return result;

        }


        public static List<string> Words
        {
            get {return words;}
            set {words = value;}
        }

        public static string Word
        {
            get {return word;}
            set {word = value;}
        }
    }
}