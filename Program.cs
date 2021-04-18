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
            int[] nums = new int[100];
            bool[] isShown = new bool[100];
            int[] currentSix = new int[6];
            Random random = new Random();
            int randomNum = 0;
            int highest = 100;
            int lowest = 0;
            bool correctNum = false;
            bool right = false;
            int userInput = 0;
            int count = 0;
            int chances = 0;

            //Generate numbers from 1 to 99 and store them in an array
            for (int i = 1; i <= 99; i++)
            {
                nums[i] = i;
            }
            // Console.WriteLine(nums[100]);

            for (int i = 0; i < currentSix.Length; i++)
            {
                randomNum = random.Next(99) + 1;
                if (isShown[randomNum])
                {
                    i--;
                    continue;
                }
                else
                {
                    isShown[randomNum] = true;
                    currentSix[i] = nums[randomNum];
                }
            }

            while (true)
            {
                right = false;
                correctNum = false;

                

                Console.WriteLine("DOWN   UP");
                Console.WriteLine(highest + "    " + lowest);
                Console.WriteLine("\nYou have the following numbers: ");
                for (int i = 0; i < currentSix.Length; i++)
                {
                    Console.Write(currentSix[i] + " ");
                }

                Console.WriteLine("\n");

                if (count == 100)
                {
                    Console.WriteLine("You succesfully used all the numbers");
                    Console.WriteLine("You win!");
                }

                if (chances == 12)
                {
                    Console.WriteLine("Game Over");
                    break;
                }

                chances = 0;

                
                Console.WriteLine("Enter one of the numbers above: ");
                while (!right)
                {
                    userInput = int.Parse(Console.ReadLine());

                    for (int i = 0; i < currentSix.Length; i++)
                    {
                        if (userInput == currentSix[i])
                        {
                            count++;
                            right = true;
                            currentSix[i] = 0;
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

                Console.WriteLine("Enter 'u' for up and 'd' for down:  ");
                char upDown = Console.ReadLine().ElementAt(0);

                Console.WriteLine();



                if (correctNum)
                {
                    if (upDown == 'u' && (userInput > lowest || userInput == lowest - 10))
                        lowest = userInput;
                    else if (upDown == 'd' && (userInput < highest || userInput == highest + 10))
                        highest = userInput;
                }

                if(count < 95) {
                    for (int i = 0; i < currentSix.Length; i++)
                    {
                        if (currentSix[i] == 0)
                        {
                            randomNum = random.Next(99) + 1;
                            while (isShown[randomNum])
                            {
                                randomNum = random.Next(99) + 1;
                            }
                            currentSix[i] = randomNum;
                            isShown[randomNum] = true;
                        }
                    }
                }

              for (int i = 0; i < currentSix.Length; i++)
                {
                    if (currentSix[i] < lowest)
                        chances++;
                    if (currentSix[i] > highest)
                        chances++;
                }
               // Console.WriteLine("Chances: " + chances);
            }
        }
    }
}
