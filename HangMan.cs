using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
//19/09/2023 from: https://youtu.be/Bg3rMMuQ6Oo?si=vCdqqiL5sO9n4kgv
namespace HangmanGame
{

    internal class Program
    {

        private static void printHangman(int wrong) //how many times user guessed wrong
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("   ===");
                //stand
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O    |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O    |");
                Console.WriteLine("|    |");
                Console.WriteLine("     |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|   |");
                Console.WriteLine("     |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O    |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("      |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\ |");
                Console.WriteLine(" /    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\ |");
                Console.WriteLine(" /\\  |");
                Console.WriteLine("   ===");
            }
        }

        private static int printWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                }
                else
                {
                    Console.Write(" ");
                }
                counter += 1;
            }
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 "); //prints out the _ _ _ under the words
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman!");
            Console.WriteLine("---------------------");

            Random random = new Random();
            List<String> wordDictionary = new List<String> { "trust", "banana", "yeet", "word", "guess", "hello", "nice", "epic", "coding" };
            //words for the game
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            //6 is maximum length of the word/guesses
            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                //prompt the user for input
                Console.Write("\nGuess a letter: ");
                char lettersGuessed = Console.ReadLine()[0];

                //check if this letter has already been guessed
                if (currentLettersGuessed.Contains(lettersGuessed))
                {
                    Console.Write("\r\nYou have already guessed this letter!");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    //check if letter is in the word
                    bool right = false;
                    //by default is true
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (lettersGuessed == randomWord[i])
                        {
                            right = true;
                        }
                    }
                        if (right)
                        {
                            printHangman(amountOfTimesWrong);
                            currentLettersGuessed.Add(lettersGuessed);
                            currentLettersRight = printWord(currentLettersGuessed, randomWord);
                            Console.Write("\r\n");
                            printLines(randomWord);
                        }
                        else
                        {
                            amountOfTimesWrong++;
                            currentLettersGuessed.Add(lettersGuessed);
                            printHangman(amountOfTimesWrong);
                            currentLettersRight = printWord(currentLettersGuessed, randomWord);
                            Console.Write("\r\n");
                            printLines(randomWord);
                        }
                    }
                }

            //game over
            Console.WriteLine("\r\nGame Over! Thank you for playing :)");

        }
    }
}
