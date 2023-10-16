namespace Ex01_01
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // Receiving input from user
            string userInputBinOne = getValidBinaryNumStr();
            string userInputBinTwo = getValidBinaryNumStr();
            string userInputBinThree = getValidBinaryNumStr();

            // Converting to sort and print
            int userInputDecOne = binaryToDecimal(userInputBinOne);
            int userInputDecTwo = binaryToDecimal(userInputBinTwo);
            int userInputDecThree = binaryToDecimal(userInputBinThree);

            // Printing out the user's input as decimals in ascending order
            System.Text.StringBuilder sortedNumbersStr = new System.Text.StringBuilder(@"
Input Numbers Sorted In Ascending Order (represented in Decimal format): ");
            int userInputDecMin = Math.Min(Math.Min(userInputDecOne, userInputDecTwo), Math.Min(userInputDecTwo, userInputDecThree));
            int userInputDecMax = Math.Max(Math.Max(userInputDecOne, userInputDecTwo), Math.Max(userInputDecTwo, userInputDecThree));

            sortedNumbersStr.Append(userInputDecMin);
            sortedNumbersStr.Append(", ");

            if (userInputDecMin != userInputDecOne && userInputDecMax != userInputDecOne)
            {
                sortedNumbersStr.Append(userInputDecOne);
            }
            else if (userInputDecMin != userInputDecTwo && userInputDecMax != userInputDecTwo)
            {
                sortedNumbersStr.Append(userInputDecTwo);
            }
            else
            {
                sortedNumbersStr.Append(userInputDecThree);
            }

            sortedNumbersStr.Append(", ");
            sortedNumbersStr.Append(userInputDecMax);

            System.Console.WriteLine(sortedNumbersStr.ToString());

            // Printing 1 / 0 statistics
            int totalOnes = countOnesInStr(userInputBinOne) + countOnesInStr(userInputBinTwo) + countOnesInStr(userInputBinThree);
            int totalZeros = (3 * userInputBinOne.Length) - totalOnes;

            System.Console.WriteLine("{0}Input statistics, 0/1 ratio in submitted binary numbers is {1}", System.Environment.NewLine, (float)totalZeros / totalOnes);

            // computing and printing total number of numbers that are divisible by 3 (without a reminder)
            int totalDivisibleByThreeCount = convertBoolToInt(userInputDecOne % 3 == 0) + convertBoolToInt(userInputDecTwo % 3 == 0) + convertBoolToInt(userInputDecThree % 3 == 0);
            System.Console.WriteLine("{0}Total Amount Of Numbers Divisible By 3 Is {1}", System.Environment.NewLine, totalDivisibleByThreeCount);

            // computing and printing total number of decimals that are palindromes
            int totalPalindromeCount = convertBoolToInt(IsPalindrome(userInputDecOne)) + convertBoolToInt(IsPalindrome(userInputDecTwo)) + convertBoolToInt(IsPalindrome(userInputDecThree));
            System.Console.WriteLine("{0}Total Palindrome Count Is {1}", System.Environment.NewLine, totalPalindromeCount);

            System.Console.WriteLine(@"
Please Press Enter!");
            System.Console.ReadLine();
        }

        public static bool IsPalindrome(int i_DecNumber)
        {
            bool result = true;
            string decNumberStr = i_DecNumber.ToString();

            for (int index = 0; index < decNumberStr.Length / 2 && result; index++)
            {
                if (decNumberStr[index] != decNumberStr[decNumberStr.Length - 1 - index])
                {
                    result = false;
                }
            }

            return result;
        }

        private static bool isStringAValidBinaryNum(string i_StrToCheck)
        {
            // Checks if the input (Str) is a binary number with 7 digits.
            bool result = int.TryParse(i_StrToCheck, out int numberToCheck) && i_StrToCheck.Length == 7;

            if (result)
            {
                while (numberToCheck != 0 && result)
                {
                    if (numberToCheck % 10 != 0 && numberToCheck % 10 != 1)
                    {
                        result = false;
                    }

                    numberToCheck /= 10;
                }
            }

            return result;
        }

        private static int binaryToDecimal(string i_BinaryNumberStr)
        {
            // This function receives a str representing a VALID binary number.
            int result = 0;

            int binaryNumber = int.Parse(i_BinaryNumberStr);
            int positionInBinNumber = 0;

            while (binaryNumber != 0)
            {
                result += (binaryNumber % 10) * (int)Math.Pow(2, positionInBinNumber);

                binaryNumber /= 10;
                positionInBinNumber++;
            }

            return result;
        }

        private static string getValidBinaryNumStr()
        {
            // Will receive a valid binary number from the user (if not valid will try again)
            System.Console.WriteLine("Please input a valid 7 digit long binary number");

            string userInput = System.Console.ReadLine();

            while (!isStringAValidBinaryNum(userInput))
            {
                System.Console.WriteLine("Uh oh! The number you entered is invalid. Try again!");

                userInput = System.Console.ReadLine();
            }

            return userInput;
        }

        private static int convertBoolToInt(bool i_ToConvert)
        {
            return i_ToConvert ? 1 : 0;
        }

        private static int countOnesInStr(string i_BinNumStr)
        {
            int onesCount = 0;

            for (int index = 0; index < i_BinNumStr.Length; index++)
            {
                if (i_BinNumStr[index] == '1')
                {
                    onesCount++;
                }
            }

            return onesCount;
        }
    }
}
