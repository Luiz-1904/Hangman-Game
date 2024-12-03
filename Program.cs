using System;
using System.Collections.Generic;

class HangmanGame
{
    static bool isGameRunning = true;
    static Random randomizer = new Random();
    static readonly Dictionary<int, string> wordBank = new()
    {
        { 1, "Apple" }, { 2, "Banana" }, { 3, "Computer" },
        { 4, "Development" }, { 5, "Programming" }, { 6, "Technology" },
        { 7, "Laptop" }, { 8, "Keyboard" }, { 9, "Monitor" }, { 10, "Internet" }
    };

    static void Main(string[] args)
    {
        while (isGameRunning)
        {
            Console.Clear();
            string selectedWord = SelectRandomWord();
            PlayGame(selectedWord);
        }
    }

    static string SelectRandomWord()
    {
        int randomKey = randomizer.Next(1, wordBank.Count + 1);
        return wordBank[randomKey];
    }

    static void PlayGame(string selectedWord)
    {
        char[] maskedWord = new string('_', selectedWord.Length).ToCharArray();
        HashSet<char> triedLetters = new();
        int remainingAttempts = 5;

        Console.WriteLine("\nWelcome to the Hangman game! You have 5 attempts to guess the word.");

        while (remainingAttempts > 0)
        {
            Console.WriteLine($"\nWord: {new string(maskedWord)}");
            Console.WriteLine($"Tried letters: {string.Join(", ", triedLetters)}");
            Console.WriteLine($"Remaining attempts: {remainingAttempts}");
            char guessedLetter = GetValidLetter("\nGuess a letter: ", triedLetters);

            triedLetters.Add(guessedLetter);

            if (UpdateMaskedWord(guessedLetter, selectedWord.ToUpper(), maskedWord))
            {
                Console.Clear();
                Console.WriteLine("Correct guess!");

            }
            else
            {
                remainingAttempts--;
                Console.Clear();
                Console.WriteLine("Wrong guess!");

            }

            if (!maskedWord.Contains('_'))
            {
                Console.WriteLine($"\nCongratulations! You won! The word was {selectedWord.ToUpper()}");
                break;
            }
        }

        if (remainingAttempts == 0)
        {
            Console.WriteLine($"\nYou lost! The word was: {selectedWord.ToUpper()}");
        }

        isGameRunning = AskToPlayAgain();
    }

    static char GetValidLetter(string prompt, HashSet<char> triedLetters)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim().ToUpper();

            if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.IsLetter(input[0]))
            {
                char letter = input[0];
                if (triedLetters.Contains(letter))
                {
                    Console.WriteLine("You've already tried this letter. Try another.");
                }
                else
                {
                    return letter;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single letter.");
            }
        }
    }

    static bool UpdateMaskedWord(char letter, string selectedWord, char[] maskedWord)
    {
        bool isCorrect = false;
        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (selectedWord[i] == letter)
            {
                maskedWord[i] = letter;
                isCorrect = true;
            }
        }
        return isCorrect;
    }

    static bool AskToPlayAgain()
    {
        Console.Write("\nDo you want to play again? (Y/N): ");
        string input = Console.ReadLine()?.Trim().ToUpper();
        return input == "Y";
    }
}
