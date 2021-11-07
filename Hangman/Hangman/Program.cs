//*********************************************
//Alluysios Arriba Lab #4 Hangman
//*********************************************
using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string runProgram;     // Rerun or stop the program.
            string letterGuess;         // User letter guess
            string secretWord;          // Secret word
            char[] secretGuessLetters;  // list of user letter input

            // 800, 600 canvas
            CDrawer Hangman = new CDrawer();
            do
            {
                runProgram = "";
                string hashSecret = ""; // hash secret word
                int lives = 5;  // number of lives your have
                string usedLetters = "Letters used: ";
                bool gameOver = false;      // Check if game is over

                // generate secret word and store
                secretWord = GenerateSecretWord();

                // hash secret word and set to the guess letters
                for (int i = 0; i < secretWord.Length; i++)
                    hashSecret += "-";
                secretGuessLetters = hashSecret.ToCharArray();

                do
                {
                    // Refresh Hangman (this acts as a frame, kind of)
                    Hangman.Clear();

                    // DrawHangman GUI
                    DrawHangman(Hangman, lives);

                    // Display letters used
                    Hangman.AddText(usedLetters, 24, 20, 30, 450, 40, Color.DeepSkyBlue);

                    int index = 0;          // Index of letter in secret word
                    bool isValid = false;   // Check input validation

                    // Display the length of secret word and letters guess
                    int xTextPos = 260;

                    if (lives > 0)
                    {
                        foreach (var c in secretGuessLetters)
                        {
                            Hangman.AddText(c.ToString() + "  ", 56, xTextPos, 480, 70, 70, Color.Orange);
                            xTextPos += 30;
                        }
                    }

                    // Input letter guess
                    Console.Write("What's your guess: ");
                    letterGuess = Console.ReadLine();

                    // Rerun if user input is invalid letter
                    do
                    {
                        // display error user input didn't enter a letter
                        if (letterGuess.Length != 1)
                        {
                            Console.Write("Please a valid letter: ");
                            letterGuess = Console.ReadLine();
                        }
                        else
                        {
                            // return -1 if guess is wrong else will get the index of right guess
                            index = secretWord.IndexOf(letterGuess);
                            isValid = true;

                            usedLetters += letterGuess;
                        }
                    } while (!isValid);

                    // wrong guess
                    if (index < 0)
                    {
                        Console.WriteLine("wrong!");
                        // reduce lives
                        lives--;
                    }
                    // right guess
                    else
                    {
                        secretGuessLetters[index] = Convert.ToChar(letterGuess);
                    }

                    if (lives==0)
                    {
                        // Reset whole thing
                        Hangman.Clear();

                        // Display letters used
                        Hangman.AddText(usedLetters, 24, 20, 30, 450, 40, Color.DeepSkyBlue);

                        // Display letters used
                        Hangman.AddText("You Lose!", 96, 100, 200, 600, 100, Color.Gray);

                        // reveal secret word
                        secretGuessLetters = secretWord.ToCharArray();
                        xTextPos = 260;

                        // Reveal secret word
                        DrawHangman(Hangman, lives);
                        foreach (var c in secretGuessLetters)
                        {
                            Hangman.AddText(c.ToString(), 56, xTextPos, 480, 70, 70, Color.Orange);
                            xTextPos += 30;
                        }

                        gameOver = true;
                    } 
                } while (!gameOver);

                if (runProgram == "y")
                {
                    gameOver = !gameOver;
                } else
                {
                    // Input the run program
                    Console.Write("\nRun the program again? (y/n): ");
                    runProgram = Console.ReadLine().ToLower();
                }

                Console.Clear();
                Hangman.Clear();
            } while (runProgram == "y");

            
        }

        // return a random secret word
        private static string GenerateSecretWord()
        {
            string secretWord = "";     // secret word that will be returned
            Random rand = new Random();

            // Create stream
            StreamReader srInputFile;
            srInputFile = new StreamReader("words.txt");

            // set random secret word
            try
            {
                int count = 0;  // count of each line
                int wordNumber = rand.Next(0, 5460);    // Random number between 0 - 5459
                string word;    // word from file

                while ((word = srInputFile.ReadLine()) != null)
                {
                    if (count == wordNumber)
                        secretWord = word;

                    count++;
                }

                // Close stream
                srInputFile.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }

            return secretWord;
        }


        private static void DrawHangman(CDrawer drawing, int lives)
        {
            // Draw Gallow
            Point pointLine1 = new Point(300, 100);
            drawing.AddLine(pointLine1, 350, Math.PI, Color.SkyBlue, 5);
            Point pointLine11 = new Point(300, 140);
            drawing.AddLine(pointLine11, 38, 1, Color.SkyBlue, 5);
            Point pointLine2 = new Point(450, 400);
            drawing.AddLine(pointLine2, 50, Math.PI, Color.SkyBlue, 5);
            Point pointDiagonal1 = new Point(300, 450);
            drawing.AddLine(pointDiagonal1, 155, Math.PI / 2.49, Color.SkyBlue, 5);
            Point pointDiagonal2 = new Point(300, 400);
            drawing.AddLine(pointDiagonal2, 155, Math.PI / 1.66, Color.SkyBlue, 5);
            Point pointLine3 = new Point(300, 400);
            drawing.AddLine(pointLine3, 160, Math.PI / 2, Color.SkyBlue, 5);
            Point pointLine4 = new Point(300, 120);
            drawing.AddLine(pointLine4, 100, Math.PI / 2, Color.SkyBlue, 5);

            //Rope
            Point pointRope = new Point(365, 120);
            drawing.AddLine(pointRope, 60, Math.PI, Color.Red, 5);

            // Draw body with depends on lives
            if(lives <= 5)
            {
                if(lives > 0)
                {
                    // Head
                    drawing.AddEllipse(350, 175, 30, 30, Color.LightYellow);
                    // Body
                    drawing.AddCenteredEllipse(365, 235, 30, 70, Color.LightYellow);
                }
                

                if (lives > 4)
                {
                    // Right Arm
                    Point pointRightArm = new Point(375, 210);
                    drawing.AddLine(pointRightArm, 30, Math.PI / 1.66, Color.LightYellow, 5);
                }

                if(lives > 3)
                {
                    // Left Arm
                    Point pointLeftArm = new Point(326, 219);
                    drawing.AddLine(pointLeftArm, 30, Math.PI / 2.49, Color.LightYellow, 5);
                }
                
                if(lives > 2)
                {
                    // Right Leg
                    Point pointRightLeg = new Point(375, 260);
                    drawing.AddLine(pointRightLeg, 40, Math.PI / 1.2, Color.LightYellow, 5);
                }
                
                if(lives > 1)
                {
                    // Left Leg
                    Point pointLeftLeg = new Point(326, 290);
                    drawing.AddLine(pointLeftLeg, 40, Math.PI / 3.95, Color.LightYellow, 5);
                }
                
            }
        }
    }
}
