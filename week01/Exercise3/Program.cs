using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new();
        int magicNumber;

        string guessNumberInput;
        int guessNumber;
        int guesses;
        bool keepPlaying = true;

        while (keepPlaying)
        {
            magicNumber = randomGenerator.Next(1, 100);
            guesses = 0;

            do
            {
                Console.Write("What is your guess? ");
                guessNumberInput = Console.ReadLine();

                guesses++;

                guessNumber = int.Parse(guessNumberInput);

                if (magicNumber > guessNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guessNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (magicNumber != guessNumber);

            Console.WriteLine($"You did {guesses} guesses.");
            Console.Write("Do you want to play again? ");

            keepPlaying = Console.ReadLine() == "yes";
        }

        Console.WriteLine("Thank you for playing!");
    }
}
