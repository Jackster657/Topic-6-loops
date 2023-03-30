using System;
using Topic_5._5;

namespace Topic_6_loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int program;
            Console.WriteLine("Choose a code to activate. Press 1 for in between, Press 2 for percentage passing \n and press 3 for odd sum machine, press 4 for random numbers, press 5 for dice game.");
            while (true)
            {
                
                if (Int32.TryParse(Console.ReadLine(), out program))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    
                }
            }
            if (program == 1)
            {
                InBetween();
            }
            else if (program == 2)
            {
                PercentagePassing();
            }
            else if (program == 3)
            {
                OddSum();
            }
            else if (program == 4)
            {
                RandomNumbers();
            }
            else if (program == 5)
            {
                DiceGame();
            }

            
        }

        public static void InBetween()
        {
            int min, max, input;

            Console.Write("Enter a minimum number: ");
            min = int.Parse(Console.ReadLine());

            Console.Write("Enter a maximum number: ");
            max = int.Parse(Console.ReadLine());

            while (true)
            {
                Console.Write($"Enter a number between {min} and {max}: ");
                input = int.Parse(Console.ReadLine());

                if (input > min && input < max)
                {
                    break;
                }
            }

            Console.WriteLine($"You entered {input}.");

        }

        public static void PercentagePassing()
        {
            int score, above70 = 0, totalCount = 0;

            while (true)
            {
                Console.Write("Enter a score (-1 to stop): ");
                score = int.Parse(Console.ReadLine());

                if (score == -1)
                {
                    break;
                }

                totalCount++;

                if (score > 70)
                {
                    above70++;
                }
            }

            if (totalCount > 0)
            {
                double percentage = ((double)above70 / totalCount) * 100;
                Console.WriteLine($"Percentage of scores above 70%: {percentage}%");
            }
            else
            {
                Console.WriteLine("No scores entered.");
            }

           

        }
        public static void OddSum()
        {
            int sum = 0;
            Console.WriteLine("Please enter a number:");
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i += 2)
            {
                sum += i;
            }

            Console.WriteLine($"The sum of odd numbers from 1 to {num} is {sum}.");
        }
        public static void RandomNumbers()
        {
            Random generator = new Random();
            int max, min;   
            Console.WriteLine("Give a minimum value, then a maximum.");
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out min))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out max))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(generator.Next(min, max + 1));
            }

        }
        public static void DiceGame()
        {
            int sides = 0;
            int account = 100;
            int bet;
            string guess, quit;
            bool validBet = false;
            ClassDie die1, die2;

            Console.WriteLine("Welcome to the dice game, How big do you want your dice to be?(6-9)");
            sides = Convert.ToInt32(Console.ReadLine());


            while (account > 0)
            {
                die1 = new ClassDie(sides);
                die2 = new ClassDie(sides);
                Console.WriteLine("How much would you like to bet?");
                if (int.TryParse(Console.ReadLine(), out bet))
                {
                    if (bet <= 0)
                    {
                        bet = 0;
                        validBet = true;
                    }
                    if (bet > account)
                    {
                        bet = account;
                        validBet = true;
                    }
                    else
                    {
                        validBet = true;
                    }
                    if (validBet)
                    {
                        Console.WriteLine("Pick an outcome for the dice \n Doubles (2x), Not doubles (1/2), Even sum (1x), Odd sum (1x).");
                        guess = Console.ReadLine();
                        guess = guess.ToLower();
                        if (guess == "doubles")
                        {
                            if (die1.Roll == die2.Roll)
                            {
                                bet *= 2;
                                account += bet;
                                Console.WriteLine("You win. you have " + account.ToString("C"));
                            }
                            else
                            {
                                account -= bet;
                                Console.WriteLine("You lose. you have " + account.ToString("C"));
                            }
                            die1.DrawRoll();
                            die2.DrawRoll();
                        }
                        else if (guess == "not doubles")
                        {
                            if (die1.Roll != die2.Roll)
                            {
                                bet /= 2;
                                account += bet;
                                Console.WriteLine("You win. you have " + account.ToString("C"));
                            }
                            else
                            {
                                account -= bet;
                                Console.WriteLine("You lose. you have " + account.ToString("C"));
                            }
                            die1.DrawRoll();
                            die2.DrawRoll();
                        }
                        else if (guess == "even sum")
                        {

                            if ((die1.Roll + die2.Roll) % 2 == 0)
                            {

                                account += bet;
                                Console.WriteLine("You win. you have " + account.ToString("C"));
                            }
                            else
                            {
                                account -= bet;
                                Console.WriteLine("You lose. you have " + account.ToString("C"));
                            }
                            die1.DrawRoll();
                            die2.DrawRoll();
                        }
                        else if (guess == "odd sum")
                        {
                            if ((die1.Roll + die2.Roll) % 2 != 0)
                            {

                                account += bet;
                                Console.WriteLine("You win. you have " + account.ToString("C"));
                            }
                            else
                            {
                                account -= bet;
                                Console.WriteLine("You lose. you have " + account.ToString("C"));
                            }
                            die1.DrawRoll();
                            die2.DrawRoll();
                        }

                    }
                    Console.WriteLine("Would you like to quit. yes or no");
                    quit = Console.ReadLine().ToLower();
                    if (quit == "yes")
                    {
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid bet");
                }
            }
        }

    }
}