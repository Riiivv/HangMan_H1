using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HangMan_H1
{
    internal class Game
    {
        // Array of possible words for the game
        private static string[] words = { "op", "judo", "skum", "rynke", "botanisk", "offentlige", "fare", "klemme" };
        private static string chosenWord; // The word randomly chosen for this game
        private static int life = 7; // Player's lives/attempts
        private static string guessLetter; // The current letter guessed by the player
        private static string guessedWord; // Representation of the guessed letters and unknown letters in the chosen word

        // Sets up the game, including selecting the word and initializing the guessed word display
        static void SetupGame()
        {
            Console.WriteLine("Game is ready.");
            Console.WriteLine($"Guess the secret word. You have {life} lives. Good luck!");

            // Generate a random word for this session
            GenerateRandomWord();

            // Initialize guessedWord with underscores for each letter in chosenWord
            guessedWord = new string('_', chosenWord.Length);
        }

        // Randomly selects a word from the list
        static void GenerateRandomWord()
        {
            Random random = new Random();
            chosenWord = words[random.Next(words.Length)];
        }

        // Starts the game by setting up and then running the main game loop
        public static void StartGame()
        {
            SetupGame();
            HangManGame();
        }

        // Main game loop, continues until player wins or runs out of lives
        static void HangManGame()
        {
            // Main game loop: runs as long as the player has lives left and hasn't guessed the full word
            while (life > 0 && guessedWord.Contains('_'))
            {
                // Display current progress of guessed letters and underscores
                Console.WriteLine($"Current guess: {guessedWord}");

                // Calls method allowing player to guess a letter or full word
                LetterGuessed();
            }

            // After the loop exits, check if the player won or lost
            if (life > 0)
                Console.WriteLine($"Congratulations! You guessed the word: {chosenWord}");
            else
                Console.WriteLine("Sorry, you lost. Try again!");
        }

        // Allows the player to guess a letter or the full word
        static void LetterGuessed()
        {
            Console.WriteLine("Guess a letter or type the full word:");
            string input = Console.ReadLine().ToLower();

            // Check if the player is trying to guess the full word
            if (input.Length > 1)
            {
                if (input == chosenWord.ToLower())
                {
                    guessedWord = chosenWord; // Reveal the full word
                    Console.WriteLine($"Congratulations! You guessed the word: {chosenWord}");
                    life = 0; // End the game
                }
                else
                {
                    life--; // Incorrect guess reduces lives
                    Console.WriteLine($"Incorrect guess! You have {life} lives left.");
                }
            }
            else
            {
                // Player guessed a single letter
                guessLetter = input;

                if (chosenWord.ToLower().Contains(guessLetter))
                {
                    // If the guessed letter is in the chosen word, inform the player of a correct guess
                    Console.WriteLine($"{guessLetter} is correct!");

                    // Update guessedWord to reveal the correct letter(s) in their positions
                    UpdateGuessedWord();
                }
                else
                {
                    // Deduct one life for an incorrect guess
                    life--;
                    Console.WriteLine($"Incorrect! You have {life} lives left.");
                }
            }
        }

        // Updates guessedWord with any correctly guessed letters in their positions
        static void UpdateGuessedWord()
        {
            // Convert guessedWord (which displays progress) to a character array for updating specific positions
            char[] guessedChars = guessedWord.ToCharArray();

            // Iterate over the chosenWord to find matching letters and prints the letter out if guessed
            for (int i = 0; i < chosenWord.Length; i++)
            {
                if (chosenWord[i].ToString().ToLower() == guessLetter)
                {
                    guessedChars[i] = chosenWord[i];
                }
            }

            // Update guessedWord with the new guessed letters
            guessedWord = new string(guessedChars);
        }
    }
}
