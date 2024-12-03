using System.Linq;

class HangmanGame
{
    static private bool isGameRunning = true;
    static private Random randomizer = new Random();
    static readonly Dictionary<int, string> wordBank = new()
    {
        {1, "Apple"},
        {2, "Banana"},
        {3, "Computer"},
        {4, "Development"},
        {5, "Programming"},
        {6, "Technology"},
        {7, "Laptop"},
        {8, "Keyboard"},
        {9, "Monitor"},
        {10, "Internet"}
    };

    static void Main(string[] args)
    {
        while (isGameRunning)
        {
            int randomKey = wordBank.Keys.ElementAt(randomizer.Next(wordBank.Count));

            if (wordBank.ContainsKey(randomKey) && wordBank.TryGetValue(randomKey, out string selectedWord))
            {
                char[] wordLetters = selectedWord.ToCharArray();
                StartGame(wordLetters, selectedWord);
            }
        }
    }

    static void StartGame(char[] wordLetters, string selectedWord)
    {
        char[] maskedWord = new string('_', wordLetters.Length).ToCharArray();
        int remainingAttempts = 5;

        Console.WriteLine("Welcome to the Hangman game, you have 5 attempts to get the right word!");
        while (remainingAttempts > 0)
        {
            Console.WriteLine(new string(maskedWord));
            char guessedLetter = GetValidLetter("\nGuess a letter: ");

            if (UpdateMaskedWord(guessedLetter, selectedWord.ToUpper(), maskedWord))
            {
                Console.WriteLine("You guessed correctly!");
            }
            else
            {
                remainingAttempts--;
                Console.WriteLine($"Wrong guess! Attempts remaining: {remainingAttempts}\n");
            }

            if (!maskedWord.Contains('_'))
            {
                Console.WriteLine($"Congratulations! You WON! The word was {selectedWord.ToUpper()}");
                break;
            }
        }

        if (remainingAttempts == 0)
        {
            Console.WriteLine($"You lost! The word was: {selectedWord.ToUpper()}\n");
        }

        Console.Write("\nDo you want to play again? (Y/N): ");
        isGameRunning = Console.ReadLine()?.Trim().ToUpper() == "Y";
    }

    static char GetValidLetter(string prompt)
    {
        char letter;

        do
        {
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim().ToUpper();
            bool hasNumber = input.Any(char.IsDigit);
            if (!string.IsNullOrEmpty(input) && input.Length == 1 && !hasNumber)
            {
                letter = input[0];
                return letter;
            }

            Console.WriteLine("Invalid input. Please enter a single letter.");
        } while (true);
    }

    static bool UpdateMaskedWord(char letter, string selectedWord, char[] maskedWord)
    {
        bool isCorrectGuess = false;

        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (selectedWord[i] == letter)
            {
                maskedWord[i] = letter;
                isCorrectGuess = true;
            }
        }
        return isCorrectGuess;
    }
}
