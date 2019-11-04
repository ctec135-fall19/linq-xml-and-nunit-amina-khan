/*
Author: Amina Khan
Date: 10/30/2019
CTEC 135: Microsoft Software Development with C#
Module 6, Programming Assignment 5, Prob 1
  LINQ
=>Create a static method that
 1. creates an array of strings (the ordering of the strings should be random)
 2. create a LINQ statement that returns the strings that start with 'a' - 'f'
 3. output the result 
 4. modify the array in such a way that the result will be different
 5. output the result again
 6. modify the array in such a way that the result will be different
 7. capture the result as a List<string> object and return it
=> in Main, output the returned result
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob_1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> final = SomeMethod();

            // output the returned result
            Console.WriteLine("\nGreetings after modifying\n");
            output(final);
            
            Console.WriteLine();

        }

        static List<string> SomeMethod()
        {
            // an array of strings
            string[] greetings = {"Hello", "What's up", "Hi", "Hey there",
                "Good morning", "Olah", "Que pasa", "Bonjour", "Cool" };

            // LINQ statement that returns greeting begining 'a'-'f'
            List<string> result = (from greet in greetings
                                   where greet[0] >= 'A' && greet[0] <= 'F'
                                   orderby greet
                                   select greet).ToList<string>();

            // output the results
            Console.WriteLine("\nGreetings that start with a - f \n");
            output(result);


            // modifying the array
            greetings[0] = "Aloha";

            // get results after modification
            result = (from greet in greetings
                      where greet[0] >= 'A' && greet[0] <= 'F'
                      orderby greet
                      select greet).ToList<string>();

            // output the results again
            Console.WriteLine("\nGreetings after modifying array\n");
            output(result);

            // modifying the array again
            greetings[1] = "Chao";
            greetings[2] = "Fun times";

            result = (from greet in greetings
                      where greet[0] >= 'A' && greet[0] <= 'F'
                      orderby greet
                      select greet).ToList<string>();

            return result;

        }

        // method for displaying results
        static void output(List<string> resultList)
        {
            foreach (string item in resultList)
            {
                Console.WriteLine(item);
            }
        }

    }
}
