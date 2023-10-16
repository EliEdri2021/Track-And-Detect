namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("Please enter a valid 9 character input (either only English letters, or only numbers), and press Enter!");
            string userInput = System.Console.ReadLine();

            // CORRECT ERROR HANDLING was NOT explicitly specified, will notify user if his input was invalid.
            if (string.IsNullOrEmpty(userInput) || userInput.Length != 9)
            {
                System.Console.Write("Input is INVALID, 9 characters required!\n");

                if (userInput == string.Empty)
                {
                    userInput = " "; // Preventing possible unwanted exceptions
                }
            }

            System.Console.WriteLine(isAPalindrome(userInput) ? "Is a palindrome" : "Is NOT a palindrome");

            if (int.TryParse(userInput, out int userInputInt))
            {
                System.Console.WriteLine("The input is a number at it's {0} by 3", userInputInt % 3 == 0 ? "Divisible" : "Not Divisible");
            }
            else if (isAllEnglish(userInput))
            {
                System.Console.WriteLine("The input is an english string, There are {0} lowercase English characters", countLowercaseCharacters(userInput));
            }
            else
            {
                System.Console.WriteLine("Input is INVALID, can consist only of english letters OR only of numbers!");
            }

            System.Console.WriteLine("\nPlease Press Enter!");
            System.Console.ReadLine();
        }

        private static bool isAPalindrome(string i_InputToTest)
        {
            return isAPalindromeUnwrapped(i_InputToTest, 0, i_InputToTest.Length - 1);
        }

        private static bool isAPalindromeUnwrapped(string i_InputToTest, int i_IndexL, int i_IndexR)
        {
            bool resultCurStage = i_InputToTest[i_IndexL] == i_InputToTest[i_IndexR];
            bool shouldCheckNext = i_IndexL < i_IndexR;
            bool resultNextStage = true;

            if (shouldCheckNext)
            {
                resultNextStage = isAPalindromeUnwrapped(i_InputToTest, i_IndexL + 1, i_IndexR - 1);
            }

            return resultCurStage && resultNextStage;
        }

        private static bool isAllEnglish(string i_InputToTest)
        {
            bool result = true;
            for (int index = 0; index < i_InputToTest.Length; index++)
            {
                char currentCharToCheck = i_InputToTest[index];

                if (currentCharToCheck < 'A' || currentCharToCheck > 'z')
                {
                    result = false;
                }
            }

            return result;
        }

        private static int countLowercaseCharacters(string i_InputToTest)
        {
            int lowerCounter = 0;

            for (int index = 0; index < i_InputToTest.Length; index++)
            {
                if (char.IsLower(i_InputToTest[index]))
                {
                    lowerCounter++;
                }
            }

            return lowerCounter;
        }
    }
}