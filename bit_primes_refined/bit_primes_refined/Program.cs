//Coded by Randy White -=R_DuBz=-
/*
 *  YOU CAN GRAB THIS CODE AT: http://www.github.com/romxero
 * 
 * */
using System;
using System.Collections;
using System.Text;

//make sure to include regular collections library

//didn't need to use this...

namespace bit_primes_refined
{
    internal class Program
    {
        private static string BSieve(BitArray bArray)
        {
            bArray.SetAll(true);

            bArray[0] = bArray[1] = false; //clever ;-) -> These wont be considered prime numbers

            for (int i = 2; i < bArray.Length; i++)
                //this iterations goes through and finds true values inside of the passed bit array
            {
                if (bArray[i]) //if true then the next iteration happens
                {
                    for (int k = 2; (i*k) < bArray.Length; k++)
                        /*this iteration creates multiples of the prime 
                            number and sets thos multiples int the bit array to false */
                    {
                        bArray[(i*k)] = false;
                    }
                }
            }


            var primeStringOutput = new StringBuilder(); //string variable
            ushort quickCounter = 0; //a quick counter variable

            for (int i = 0; i < bArray.Length; i++) //this iteration creates the string
            {
                if (bArray[i]) //if true then increase the quick counter and append the main output string
                {
                    primeStringOutput.Append(i.ToString());
                    quickCounter++;

                    if (quickCounter == 7)
                    {
                        primeStringOutput.Append("\n");
                        quickCounter = 0;
                    } //if true then create a new line and reset the counter
                    else
                    {
                        primeStringOutput.Append("\t");
                    }
                    ; //else just tab each numeric character
                }
            }


            return primeStringOutput.ToString(); //returns string at very end
        }

        private static void Main(string[] args)
        {

            Console.Clear(); //clear the console.

            Console.ForegroundColor = ConsoleColor.Red; //Red text
            Console.BackgroundColor = ConsoleColor.DarkBlue; //Dark blue background

            Console.Clear(); //clear the console...redundant

            Console.WriteLine("Enter an index to find your prime numbers! \n"); //print the line
            BitArray mainBitArray; //initialize bitArray
            int input_Buffer = 0; //declares a integer data type and sets it to 0! A C#, you are too sneaky =P

            while (true) //infinite loop
            {
                try //exception handling
                {
                    input_Buffer = int.Parse(Console.ReadLine()); //parse the input from a string to a integer

                    if (input_Buffer == 0 || input_Buffer == 1)
                    {
                        Console.WriteLine("Please enter a number other than 1 or 0!!\n");
                    }
                        //check to see if a 1 or 0 has been entered
                    else
                    {
                        break;
                    }
                    ; //breaks out of loop
                }
                catch
                {
                    Console.WriteLine("Sorry dude, not a valid number!- \nTRY AGAIN! \n"); //print this line for error
                }
            }


            mainBitArray = new BitArray(input_Buffer + 1);
                //allocate memory for bitArray !Make sure to always add one to the array index so you can display all the numbers!

            Console.Clear(); //clear the console...very redundant...

            Console.WriteLine(BSieve(mainBitArray) + "\n\n"); //prints out the data, very compact

            input_Buffer = 0; //sets the input to 0

            Console.WriteLine("Enter a number to see if it is a prime?!?!"); //dude? where is my prime number?


            while (true) //to infinity and beyond in this loop!
            {
                try //exception handling
                {
                    input_Buffer = int.Parse(Console.ReadLine());
                    if (input_Buffer == 0 || input_Buffer == 1)
                    {
                        Console.WriteLine("Please enter a number other than 1 or 0!!\n");
                    }
                        //if its a 1 or 0 show this and play the stupid ass sound
                    else
                    {
                        break;
                    }
                    ; //break out of the god forsaken loop!
                }

                catch
                {
                    Console.WriteLine("Sorry dude, not a valid number!- \nTRY AGAIN! \n");
                        //print this line for errors inside catch block
                }
            }


            while (true) //infinite loop
            {
                try //exception handling
                {
                    if (input_Buffer >= mainBitArray.Length)
                        //makes sure the number you entered is not outside of the instantiated index of the array
                    {
                        Console.WriteLine("You've entered a number outside the bounds of the array index,\n" + //lol
                                          "Please tell me you aren't on the crack?\n" +
                                          "Please enter the number again!\n");
                        input_Buffer = int.Parse(Console.ReadLine()); //readline again
                    }
                    else
                    {
                        if (mainBitArray[input_Buffer]) //determines if you are correct in your choosing
                        {
                            Console.WriteLine("\n Yes, the number " + input_Buffer //You are correct! 
                                              + " Is a prime number");
                            break; //breakout!!
                        }
                        else
                        {
                            Console.WriteLine("\n No, the number " + input_Buffer //You are wrong!
                                              + " Is NOT! prime number");
                            break; //breakout!!
                        }
                        ;
                    }
                }
                catch
                {
                    Console.WriteLine("Sorry dude, not a valid number!- \nTRY AGAIN! \n");
                        //print this line for errors inside catch block
                }
            }


            Console.ReadLine(); //pause...
        }
    }
}