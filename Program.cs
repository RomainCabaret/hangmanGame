using System;

namespace HangmanGame
{
    class Program
    {
        static char RequestLetter()
        {
            
            while(true)
            {
                Console.Write("Entrez une lettre : ");
                string UserChar = Console.ReadLine();
                try
                {
                    
                    char UserAnswer = char.Parse(UserChar.ToUpper());
                    return UserAnswer;
                }
                catch
                {
                    Console.WriteLine("ERREUR : Vous devez rentrer une lettre");
                }
            }
        }
        static void ShowWord(string word, List<char> letters)
        {
            string hiddenWord = "";
            for (int i = 0; i < word.Length; i++)
            {
                if (letters.Contains(word[i]))
                {
                    hiddenWord += $"{word[i]} ";
                }
                else
                {
                    hiddenWord += "_ ";
                }
            }
            Console.WriteLine($"\n{hiddenWord}");
        }
        static void GuessWord(string word)
        {
            List<char> letters = new List<char>();

            const int NB_HEALTH = 6;
            int health = NB_HEALTH;


            while (health > 0)
            {
                ShowWord(word, letters);
                char UserChar = RequestLetter();

                Console.Clear();
            
                if (word.Contains(UserChar))
                {
                    Console.WriteLine("Cette lettre est dans le mot");
                    letters.Add(UserChar);

                    if (CheckWin(word, letters))
                    {
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("Cette lettre n'est pas dans le mot");
                    health--;
                }
                Console.WriteLine($"vies restantes : {health}");
            }


            if (health == 0)
            {
                Console.WriteLine($"\nPERDU ! Le mot était : {word}");
            }
            else
            {
                Console.WriteLine("\n GAGNE !");
            }
            
        }
        static bool CheckWin(string word, List<char> letters)
        {

           foreach(var letter in letters)
            {
                word = word.Replace(letter.ToString(), "");    
            }

            if (word.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string word = "ELEPHANT";

            GuessWord(word);
        }
    }
}