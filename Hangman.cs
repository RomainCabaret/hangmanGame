﻿namespace HangmanGame
{
    public static class Hangman
    {
        public static string[] PENDU = { @"
  +---+
  |   |
      |
      |
      |
      |
=========",

@"
  +---+
  |   |
  O   |
      |
      |
      |
=========",

@"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========
",
@"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========
",
@"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========
",
@"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========
",
@"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========
"
            };
    }
}