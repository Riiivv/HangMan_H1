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
        private static string[] words = { "op", "judo", "skum", "rynke", "botanisk", "offentlige", "fare", "klemme" };
        private static string chosenWord;
        private static int life = 7;
        private static string player;
        private static string guessLetter;
        static void SetupGame()
        {
            Console.WriteLine("Spillet er klar");
            Console.WriteLine($"Du skal gætte det hemmelige ord der bliver generated du har {life} til at gætte det held og lykke");
        }

        static void GenerateRandomWord()
        {
            Random random = new Random();
            chosenWord = words[random.Next(words.Length)];
        }

        static void StartGame()
        {
            SetupGame();
            GenerateRandomWord();
            HangManGame();
        }

        static void HangManGame()
        {
            while (life > 0)
            {
                LetterGueseed();
                    if (life <= 0)
                {
                        Console.WriteLine("Du har deaværre tabt");
                    return;
                }
            }
                IsWordGuessed();
        }
        static void LetterGueseed()
        {
            Console.WriteLine("Gæt et bogstav");
            guessLetter = Console.ReadLine();

            if (chosenWord.Contains(guessLetter))
            {
                Console.WriteLine($"{guessLetter} +  _ Du fik et eller flere bogstav rigtigt");
            }
            else
                life--;
            {
                if (life <= 0)
                {
                    Console.WriteLine("Du har desværre tabt");
                    return;
                }
                else
                {
                    Console.WriteLine($"Du har {life} tilbage");
                }
            }
        }
        static void IsWordGuessed()
        {
            if (chosenWord.Contains(chosenWord))
            {
                Console.WriteLine($"Tillykke du har gættet {chosenWord} det er det rigtige ord du vandt \n tak for nu farvel :) ");
            }
            else if (life > 0)
            {
                Console.WriteLine("Det ord du har gættet er forkert prøv igen");
            }
            else if (life <= 0)
            {
                Console.WriteLine("Du har ikke flere liv tilbage du har tabt prøv igen ellers tak for nu :)");
            }
        }
    }
}
