using System;
using System.Net.Http.Headers;

namespace HangmanGame
{
    class Program
    {
        static char RequestLetter(string message = "Rentrez une lettre : ")
        {
            
            while(true)
            {
                Console.Write(message);
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
            List<char> wrongLetters = new List<char>();

            const int NB_HEALTH = 6;
            int health = NB_HEALTH;


            while (health > 0)
            {
                Console.WriteLine(Hangman.PENDU[NB_HEALTH - health] + "\n");

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
                else if (!wrongLetters.Contains(UserChar))
                {
                    wrongLetters.Add(UserChar);
                    health--;
                }

                if (wrongLetters.Count > 0)
                {

                    Console.WriteLine("Le mot ne contient pas les lettres : " + String.Join(", ", wrongLetters));
                }
                Console.WriteLine($"vies restantes : {health}");
            }


            Console.WriteLine(Hangman.PENDU[NB_HEALTH - health] + "\n");

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
        static string[] LoadWords(string nameFile)
        {
            try
            {
                return File.ReadAllLines(nameFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de lecture du fichier : {nameFile} ({ex.Message})");
            }
            return null;
        }
        static bool SendReplay()
        {
            char UserChoice = RequestLetter("Voulez vous rejouer (o/n) ");

            if (UserChoice == 'o' || UserChoice == 'O')
            {
                return true;
            }
            else if (UserChoice == 'n' || UserChoice == 'N')
            {
                return false;
            }
            else
            {
                Console.WriteLine("Erreur : Vous devez répondre avec o ou n");
                return SendReplay();
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] words = LoadWords("words.txt");

            if(words == null || (words.Length == 0))
            {
                Console.WriteLine("La liste de mots est vide");
            }
            else
            {
                while (true)
                {
                    Random rnd = new Random();
                    string word = words[rnd.Next(words.Length)].Trim().ToUpper();

                    GuessWord(word);

                    if (!SendReplay())
                    {
                        break;
                    }
                    Console.Clear();
                }


                
               
            }

        }
    }
}