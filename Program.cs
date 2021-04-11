using System;

namespace Scramble
{
    class Program
    {
        static void Main(string[] args)
        {
            int guesses = 0;
            bool isCorrectlyGuessed = false;
            string scrambledWord;
            string guess;

            Game.Load("Words.txt");
            Game.PickWord();

            scrambledWord = Game.Scramble();

            do
            {
                Console.Clear();

                Console.WriteLine("Guesses left: " + (Game.MAX_GUESSES - guesses));
                Console.Write("Unscrambled the following: ");
                Console.WriteLine(scrambledWord);
                
                guess = Console.ReadLine();

                if (guess == Game.Word)
                {
                    isCorrectlyGuessed = true;
                }
                else
                {
                    guesses++;
                }
                
            } while ((guesses < Game.MAX_GUESSES) && (!isCorrectlyGuessed));

            if (isCorrectlyGuessed)
            {
                Console.WriteLine("That was correct!");
            }
            else
            {
                Console.WriteLine("Ran out of guesses...");
                Console.WriteLine("The word was " + Game.Word + ".");
            }
        }
    }
}
