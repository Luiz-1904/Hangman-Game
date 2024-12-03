# Hangman Game

This is a simple console-based Hangman game written in C#. The game allows the user to guess a randomly selected word by inputting letters. The user has a limited number of attempts (5) to guess the word correctly.

## How to Play

1. **Start the Game:** When you run the program, a word will be randomly chosen.
2. **Guess Letters:** Enter one letter at a time to guess the word.
3. **Attempts:** You have 5 attempts to guess the word correctly. Incorrect guesses reduce the number of attempts.
4. **Victory:** The game ends when you correctly guess the entire word or run out of attempts.
5. **Play Again:** After the game ends, you can choose to play again by typing `Y` for yes or `N` for no.

## Code Walkthrough

### Main Components:

1. **`wordBank`:** A dictionary that holds predefined words, identified by a unique number.
2. **`randomizer`:** A `Random` object that selects a random word from the `wordBank`.
3. **`StartGame()`:** This method initializes the game with a masked word and handles the guessing loop. It reduces the number of remaining attempts on incorrect guesses and updates the masked word on correct guesses.
4. **`GetValidLetter()`:** A helper function that ensures the player inputs a valid letter (one character without numbers).
5. **`UpdateMaskedWord()`:** This function checks if the guessed letter is in the word and updates the displayed word accordingly.

### Game Flow:

1. A word is selected randomly from the `wordBank`.
2. The user is shown a masked version of the word (e.g., `_ _ _ _`).
3. The user guesses a letter.
4. If the letter is correct, it is revealed in the masked word.
5. If the letter is incorrect, the number of remaining attempts decreases.
6. The game continues until the word is guessed correctly or attempts run out.
7. After the game ends, the user is prompted to play again.

## License

This project is open source and available under the [MIT License](LICENSE).
