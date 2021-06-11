using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWithNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Keeps track of which numbers have been shown and which are not
            Dictionary<int, bool> isShown = new Dictionary<int, bool>();
            int[] currentSix = new int[6];
            Random random = new Random();
            int randomNum = 0;
            int highestOne = 100;
            int highestTwo = 100;
            int lowestOne = 1;
            int lowestTwo = 1;
            bool correctNum = false;
            bool right = false;
            int userInput = 0;
            int count = 0;
            int chances = 0;
            bool gameOver = false;

            int index = 0;

            //Generate numbers from 1 to 99 and store them in an array
            for (int i = 2; i <= 99; i++)
            {
                isShown.Add(i, false);
            }

            for (int i = 0; i < currentSix.Length; i++)
            {
                randomNum = random.Next(1, 99) + 1;
                if (isShown[randomNum])
                {
                    i--;
                    continue;
                }
                else
                {
                    isShown[randomNum] = true;
                    currentSix[i] = randomNum;
                }
            }

            while (!gameOver)
            {
                right = false;
                correctNum = false;

                Console.WriteLine($"Count: {count}");

                Console.WriteLine($"\n       1.     2. ");
                Console.WriteLine($"DOWN   {highestOne,2}    {highestTwo,2}");
                Console.WriteLine();
                Console.WriteLine($"Up     {lowestOne,2}     {lowestTwo,2}");
                Console.WriteLine("\nYou have the following numbers: ");
                for (int i = 0; i < currentSix.Length; i++)
                {
                    Console.Write(currentSix[i] + " ");
                }

                Console.WriteLine("\n");



                chances = 0;


                Console.WriteLine("Enter one of the numbers above: ");
                while (!right)
                {
                    int.TryParse(Console.ReadLine(), out userInput);

                    for (int i = 0; i < currentSix.Length; i++)
                    {
                        if (userInput == currentSix[i])
                        {
                            count++;
                            right = true;
                            index = i;
                            //currentSix[i] = 0;
                            correctNum = true;
                            break;

                        }
                        else if (i == currentSix.Length - 1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("The number you entered is not from the current six numbers");
                            Console.WriteLine("Enter another one: ");
                            Console.WriteLine();
                        }
                    }
                }
                char upDown;
                char column;
                do
                {
                    Console.WriteLine("Enter 'u' for up and 'd' for down:  ");
                    upDown = Console.ReadLine().ElementAt(0);
                } while (upDown != 'd' && upDown != 'u');


                do
                {
                    Console.WriteLine("Enter 1 for first column and 2 for the second column:  ");
                    column = Console.ReadLine().ElementAt(0);
                } while (column != '1' && column != '2');

                Console.WriteLine();


                bool exchange = false;
                if (correctNum)
                {
                    if (upDown == 'u' && column == '1' && (userInput > lowestOne || userInput == lowestOne - 10))
                    {
                        lowestOne = userInput;
                        exchange = true;
                    }
                    else if (upDown == 'u' && column == '2' && (userInput > lowestTwo || userInput == lowestTwo - 10))
                    {
                        lowestTwo = userInput;
                        exchange = true;
                    }
                    else if (upDown == 'd' && column == '1' && (userInput < highestOne || userInput == highestOne + 10))
                    {
                        highestOne = userInput;
                        exchange = true;
                    }
                    else if (upDown == 'd' && column == '2' && (userInput < highestTwo || userInput == highestTwo + 10))
                    {
                        highestTwo = userInput;
                        exchange = true;
                    }
                }

                if (exchange == false)
                {
                    Console.WriteLine($"The number {correctNum} cannot fit in {upDown}, column {column}. Try something else");
                    continue;
                }
                else
                {
                    currentSix[index] = 0;
                }

                if (count < 92)
                {
                    for (int i = 0; i < currentSix.Length; i++)
                    {
                        if (currentSix[i] == 0)
                        {
                            randomNum = random.Next(1, 99) + 1;
                            while (isShown[randomNum])
                            {
                                randomNum = random.Next(1, 99) + 1;
                            }
                            currentSix[i] = randomNum;
                            isShown[randomNum] = true;
                        }
                    }
                }

                for (int i = 0; i < currentSix.Length; i++)
                {
                    if ((currentSix[i] < lowestOne && lowestOne - currentSix[i] != 10) && (currentSix[i] < lowestTwo && lowestTwo - currentSix[i] != 10))
                        chances++;
                    if ((currentSix[i] > highestOne && currentSix[i] - highestOne != 10) && (currentSix[i] > highestTwo && currentSix[i] - highestOne != 10))
                        chances++;
                }
                if (count == 98)
                {
                    Console.WriteLine("You succesfully used all the numbers");
                    Console.WriteLine("You win!");
                    gameOver = true;
                }

                if (chances == 12)
                {
                    Console.WriteLine("Game Over!");
                    Console.WriteLine("You can't place any number!");
                    gameOver = true;
                }
                // Console.WriteLine("Chances: " + chances);
            }
            Console.ReadKey();
        }
    }
}
