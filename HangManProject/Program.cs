using System;
using System.Collections.Generic;

namespace HangManProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<string> words = new List<string>() { "excavator", "bulldozer", "distributor", "dismissal", "quest", "integration", "faith", "carriage", "narrow", "unfortunate", "headquarters", "deviation", "competition", "tendency", "birthday" };
            List<char> usedLetters = new List<char>();

            int index = rnd.Next(15);
            string hiddenWord = words[index];
            //string hiddenWord = "dog";

            int lives = 8;
            int attempts = 0;
            char easterEgg = '$';

            char[] stars = new char[hiddenWord.Length];

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Array.Fill(stars, '*');

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Welcome to Hangman!");

            List<string[]> hangManPics = new List<string[]>
            {
                new string[]
                {
                    " +----+\n",
                    " |    |\n",
                    "      |\n",
                    "      |\n",
                    "      |\n",
                    "      |\n",
                    "=======\n"
                },

                   new string[]
                {
                    " +----+\n",
                    " |    |\n",
                    " O    |\n",
                    "      |\n",
                    "      |\n",
                    "      |\n",
                    "=======\n"
                },

                      new string[]
                {
                    " +----+\n",
                    " |    |\n",
                    " O    |\n",
                    " |    |\n",
                    "      |\n",
                    "      |\n",
                    "=======\n"
                },

                         new string[]
                {
                    " +----+\n",
                    " |    |\n",
                    " O    |\n",
                    "/|    |\n",
                    "      |\n",
                    "      |\n",
                    "=======\n"
                },
                            new string[]
                {
                    " +----+\n",
                    " |    |\n",
                    " O    |\n",
                    "/|\\  |\n",
                    "      |\n",
                    "      |\n",
                    "=======\n"
                },

                         new string[]
                {
                    " +----+\n",
                    " |    |\n",
                    " O    |\n",
                    "/|\\  |\n",
                    "/     |\n",
                    "      |\n",
                    "=======\n"
                },

                     new string[]
                {
                    " +----+\n",
                    " |    |\n",
                    " O    |\n",
                    "/|\\  |\n",
                    "/ \\  |\n",
                    "      |\n",
                    "=======\n"
                },


            };

            while (true)
            {
                bool letterFound = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Lives left: {lives}");
                Console.WriteLine("Today hidden Word is: " + String.Join("", stars));
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Enter a letter: ");
                char letterG = Convert.ToChar(Console.ReadLine());
                attempts++;


                if (usedLetters.Contains(letterG))
                {
                    Console.WriteLine("Sorry, you already used that letter! Try another one!");
                    continue;
                }
                else
                {
                    usedLetters.Add(letterG);
                }

                if (letterG == easterEgg)
                {
                    Console.WriteLine("You found an easterEgg and rewarded 2 extra lives for you");
                    lives += 2;
                }

                if (letterG == easterEgg)
                {
                    letterFound = true;
                }

                for (int i = 0; i < hiddenWord.Length; i++)
                {
                    if (letterG == hiddenWord[i])
                    {
                        letterFound = true;
                        stars[i] = letterG;
                    }
                }

                if (!letterFound)
                {
                    lives--;
                    foreach(var line in hangManPics[0])
                    {
                        Console.WriteLine(line);
                    }
                    hangManPics.RemoveAt(0);
                }

                if (lives == 0 || hangManPics.Count == 0)
                {
                    Console.WriteLine("You lost the game!");
                    break;
                }

                if (!string.Join("", stars).Contains('*'))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Congrats! You guessed the word: {hiddenWord} for {attempts} attempts!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                }


            }
            Console.WriteLine("Press any key to close the program!");
            Console.ReadKey();
        }
    }
}
