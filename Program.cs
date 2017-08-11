using System;

namespace AnagramSolverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            string firstWord, secondWord;
            bool result = false;

            // Title and purpose
            Console.WriteLine("Anagram Checker");
            Console.WriteLine("By Jeff Peterson\n");

            Console.WriteLine("Input two words or phrases and the app will");
            Console.WriteLine("determine if they are anagrams or not\n");

            // Get the input
            Console.Write("Enter the first word/phrase: ");
            firstWord = PromptForString();

            Console.Write("Enter the second word/phrase: ");
            secondWord = PromptForString();

            // Check if the words/phrases are anagrams of each other
            // This will be accomplished over three different tests to check
            // if all three methods work or not.
            Console.Write("Method 1 (Compare ASCII Values): ");
            result = CheckAnagramBrian(firstWord, secondWord);
            if (result == true)
            {
                Console.WriteLine("They are anagrams");
            }
            else
            {
                Console.WriteLine("Not anagrams");
            }

            Console.Write("Method 2 (Compare sorted characters in strings): ");
            result = CheckAnagramJeff(firstWord, secondWord);
            if (result == true)
            {
                Console.WriteLine("They are anagrams");
            }
            else
            {
                Console.WriteLine("Not anagrams");
            }

        }

        public static string RemoveDelimiters(string word)
        {
            // Removes the various delimiters from the input string
            // such as spaces and punctuation
            char[] delimiters = { '-', '.', '!', '(', ')', ',', '\"', '\'', '*', '&', '?', '/', '+' };
            string temp = word;
            
            foreach (char item in delimiters)
            {
                temp = temp.Replace(item, ' ');
            }
            return temp;
        }

        public static bool CheckAnagramBrian(string word1, string word2)
        {
            // This method, thought up by Brian, looks to add the ASCII value
            // of each character. If the total for both words are equal,
            // the words should be anagrams. Spaces are ignored in both as
            // an anagrammed word can add/remove spaces from the old word.

            // Discovered yesterday that this doesn't work.
            // In this case, ccc = bcd. Boo! This was an awesome idea though.

            // Variables
            int totalWord1 = 0;
            int totalWord2 = 0;
            char[] buffer;

            // Initialize the buffer for the longest word.
            if (word1.Length >= word2.Length)
            {
                buffer = new char[word1.Length];
            }
            else        // word1.Length < word2.Length
            {   
                buffer = new char[word2.Length];
            }

            // Remove punctuation, converting into spaces
            word1 = RemoveDelimiters(word1);
            word2 = RemoveDelimiters(word2);

            // Find the ASCII equivalent total for the first word
            buffer = word1.ToLower().ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] != ' ')       // Ignore the spaces
                    totalWord1 += (int)buffer[i];
            }

            // Find the ASCII equivalent total for the second word
            buffer = word2.ToLower().ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] != ' ')       // Ignore the spaces
                    totalWord2 += (int)buffer[i];
            }

            // Now for the result!
            if (totalWord2 == totalWord1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // not going to bother implementing this version as I
        // came up with something much better!
        //public static bool CheckAnagramJeff(string word1, string word2)
        //{
        //    // This method, thought up by me, counts up the number of
        //    // unique characters in a string. If the counts are equal,
        //    // the words should be anagrams. Seems HIGHLY complex (O(n^2))

        //    // Variables
        //    int[] countWord1;
        //    int[] countWord2;
            
        //    // Initialize the arrays for the longest word
        //    if (word1.Length >= word2.Length)
        //    {
        //        countWord1 = new int[word1.Length];
        //        countWord2 = new int[word1.Length];
        //    }
        //    else        // word1.Length < word2.Length
        //    {
        //        countWord1 = new int[word2.Length];
        //        countWord2 = new int[word2.Length];
        //    }

        //    // Remove extraneous punctuation
        //    word1 = RemoveDelimiters(word1);
        //    word2 = RemoveDelimiters(word2);

        //    // Count each character into the arrays
        //    word1 = word1.ToLower();
        //    word2 = word2.ToLower();
        //    for (int i = 0; i < countWord1.Length; i++)
        //    {

        //    }

        //    return false;
        //}

        //public static bool CheckAnagramShaw(string word1, string word2)
        //{
        //    // This method, discussed by Shaw, concatenates the two words
        //    // and counts each character into an array (I'll use a List).
        //    // It then checks each item in the array for even counts.
        //    // If so, it is an anagram. Should be an O(n^2) as well

        //    // Variables
        //    List<int> counts = new List<int>();
        //    string combinedWord = word1 + word2;

        //    // Loop through the combined word and check other characters
        //    // Count each instance and save in the list
        //    for (int i = 0; i < combinedWord.Length; i++)
        //    {
        //        for (int j = 0; j < combinedWord.Length; j++)
        //        {
        //            if (combinedWord[i] == combinedWord[j])
        //            {
        //                counts[i]++;
                        
        //            }
        //        }
        //    }
        //    return false;
        //}

        public static bool CheckAnagramJeff(string word1, string word2)
        {
            /* This method uses char arrays, sorts them alphabetically, and
             * restores them into strings. The strings are compared and, if
             * they are equal, the words are anagrams.
             * */

            // Remove punctuation, converting into spaces
            word1 = RemoveDelimiters(word1);
            word2 = RemoveDelimiters(word2);

            // Store the strings as char arrays
            char[] foo1 = word1.ToLower().ToCharArray();
            char[] foo2 = word2.ToLower().ToCharArray();

            // Sort the arrays
            Array.Sort(foo1);
            Array.Sort(foo2);

            // Need to remove the spaces
            // Place them back into the strings
            word1 = new string(foo1);
            word2 = new string(foo2);
            string[] buffer1 = word1.Split(' ');
            string[] buffer2 = word2.Split(' ');
            word1 = buffer1[buffer1.GetUpperBound(0)];
            word2 = buffer2[buffer2.GetUpperBound(0)];

            // Compare and return
            if (word1 == word2)
                return true;
            else
                return false;
        }

        public static string PromptForString()
        {
            /*
             * string PromptForString()
             * 
             * Pauses execution while user inputs a string, also checking that something was entered.
             */
            string result = "";
            bool flag = true;

            // Loop until we get some actual input.
            while (flag)
            {
                result = Console.ReadLine();
                if (result.Length < 1)
                {
                    Console.Write("Give me something!  Try again: ");
                }
                else
                {
                    flag = false;
                }
            }

            // Out of the loop so return the string!
            return result;
        }

        public static double PromptForDouble(string prompt, double minValue = 0, double maxValue = 0)
        {
            /*
             * PromptForDouble(string prompt)
             * 
             * Retrieves valid integer input from a user, ensuring a correct value within a range
             * If min and maxValue are default, no range is checked.
             * Method user is required to ensure prompt is correctly formatted to look nice.
             * Prompt will always place a newline before displaying the prompt.
             */

            // Variables
            double outValue = 0.0;
            bool flag = true;

            // Enter an infinite loop until the user gives us something valid.
            while (flag)
            {
                // Display the prompt for the user to know what to enter.
                Console.Write("\n" + prompt);

                // Check for a valid input (i.e. it is a number!)
                if (double.TryParse(Console.ReadLine(), out outValue) == false)
                {
                    Console.WriteLine("\nThat is not a number.  Try again.");
                    continue;
                }

                // Verify that the number is within the proper range.
                // If the default values haven't been changed, skip this.
                if (!(minValue == 0 && maxValue == 0))
                {
                    if (outValue < minValue)
                    {
                        Console.WriteLine("Your number is smaller than the minimum acceptable.  Try again.");
                        continue;
                    }
                    if (outValue > maxValue)
                    {
                        Console.WriteLine("You number is greater than the maximum acceptable.  Try again.");
                        continue;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else        // Nothing else to do because the defaults are the same. Bye!
                {
                    flag = false;
                }
            }

            // Send the integer back!
            return outValue;
        }

        public static int PromptForInt(string prompt, int minValue = 0, int maxValue = 0)
        {
            /*
             * PromptForInt(string prompt, int minValue = 0, int maxValue = 0)
             * 
             * Retrieves valid integer input from a user, ensuring a correct value within a range
             * If min and maxValue are default, no range is checked.
             * Method user is required to ensure prompt is correctly formatted to look nice.
             * Prompt will always place a newline before displaying the prompt.
             */

            // Variables
            int outValue = 0;
            bool flag = true;

            // Enter an infinite loop until the user gives us something valid.
            while (flag)
            {
                // Display the prompt for the user to know what to enter.
                Console.Write("\n" + prompt);

                // Check for a valid input (i.e. it is a number!)
                if (int.TryParse(Console.ReadLine(), out outValue) == false)
                {
                    Console.WriteLine("\nThat is not a number.  Try again.");
                    continue;
                }

                // Verify that the number is within the proper range.
                // If the default values haven't been changed, skip this.
                if (!(minValue == 0 && maxValue == 0))
                {
                    if (outValue < minValue)
                    {
                        Console.WriteLine("Your number is smaller than the minimum acceptable.  Try again.");
                        continue;
                    }
                    if (outValue > maxValue)
                    {
                        Console.WriteLine("You number is greater than the maximum acceptable.  Try again.");
                        continue;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else        // Nothing else to do because the defaults are the same. Bye!
                {
                    flag = false;
                }
            }

            // Send the integer back!
            return outValue;
        }
    }
}
