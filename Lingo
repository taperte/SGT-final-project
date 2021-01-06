using System;

namespace _10_brain_teaser
{
    class Program
    {
        static void Main(string[] args)
        {           
            //1) Create a string variable.
            string secretword = "force";

            //2) Define a string array with 5 values to display user's progress.
            string[] progress = { secretword.Substring(0, 1), "*", "*", "*", "*" };

            //3) Print instructions for the user.
            Console.WriteLine("Welcome to the LINGO game!");
            Console.WriteLine("To win the game, you have to guess the five-letter secret word.");
            Console.WriteLine("You can only enter five-letter words. After each attempt, the program will show your progress.");
            Console.WriteLine("If you've guessed a letter in the right position, the program will display it.");
            Console.WriteLine("You can only use lowercase Latin alphabet letters without any diacritics.");
            Console.WriteLine("The game continues until you've guessed the word. If you want to quit the game, please enter STOP.");
            Console.WriteLine("Good luck!");
            Console.WriteLine();

            //4) Print the first letter and the rest of the symbols print as stars.            
            Console.WriteLine(secretword.Substring(0, 1) + "****");

            //5) The game goes on until the user wins or quits.
            while (true)
            {                
                //6) The program asks for input.
                Console.Write("Please enter your guess: ");
                string input = Console.ReadLine();
                //7) If the user enters a correct guess, they win; the game ends.
                if (input == secretword)
                {
                    Console.WriteLine("Congratulations, you've won the game!");
                    Console.WriteLine("May the Force be with you!");
                    break;
                }
                //8) If the user enters STOP, the game ends.
                else if (input == "STOP" || input == "Stop" || input == "stop")
                {
                    Console.WriteLine("You've quit the game.");
                    break;
                }
                //9) If user's guess is incorrect, the program shows their progress
                //and goes back to input; the game continues.
                else if (input.Length == 5)
                {
                    //The loop compares user's input to the secret word
                    //(starts with i = 1, since the first letter is already given).
                    for (int i = 1; i < 5; i++)
                    {
                        if (input.Substring(i, 1) == secretword.Substring(i, 1))
                        {                            
                            //If there is a match, the progress array gets updated.
                            progress[i] = input.Substring(i, 1);                            
                        }                        
                    }
                    //The program displays current progress.
                    Console.WriteLine("Your current progress: ");
                    for (int i = 0; i < 5; i++)
                    {                        
                        //The color of the guessed letters gets changed to green.
                        if (progress[i] != "*" && i != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ResetColor();
                        }
                        Console.Write(progress[i]);
                    }                    
                    Console.ResetColor();
                    Console.WriteLine();
                }
                //10) If the user enters invalid input, the program shows an error message; the game continues.
                else if (input.Length != 5 && input != "STOP" && input != "Stop" && input != "stop")
                {
                    Console.WriteLine("You can only enter a five-letter word!");
                }
            }            
        }
    }
}
/*Create a lighter version of a latvian game called LINGO.
* In the program create a string variable with value with a length of 5
* which will be the word to guess, as in the real LINGO. -- check 
* Afterwards give the user the information about the game -- check
* and make the user guess the word until the value is guessed or user types STOP. -- check
* In this task use only lower case string values
* and don’t use any latvian/russian special characters. -- check
* Firstly print the hidden words first letter and all the rest symbols print as stars. -- check
* For example, if the word to guess would be “pulse”,
* then at the beginning of the game user sees - “p****”.
* User tries to guess the word and after each guess user gets the current progress. -- check
* If the user guesses a correct letter IN THE RIGHT POSITION
* then continue to print all the known letters. -- check
* For example, if a another users guess is “plane”,
* then continue to print “p***e” and so on until all the letters are guessed.
* The guessed letters print in green color. --check
* If the user wins then write an appropriate message. -- check
* Game ends when the user has guessed the word or he writes STOP. -- check
* User can only input words with 5 letters or the word STOP,
* if something else is inputted then show an error message. -- check*/
