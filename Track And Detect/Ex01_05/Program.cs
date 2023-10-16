namespace Ex01_05
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int userInput = getValidInput();
            int rightmostDigit = userInput % 10;
            int digitsSmallerThanRightmost = 0;
            int digitsDivisibleByThree = 0;
            int totalDigitsInNumber = 0;
            int totalDigitSum = 0;
            int biggestDigit = -9;

            while (userInput != 0)
            {
                int curDigit = userInput % 10;

                if (curDigit < rightmostDigit)
                {
                    digitsSmallerThanRightmost++;
                }

                if (curDigit > biggestDigit)
                {
                    biggestDigit = curDigit;
                }

                if (curDigit % 3 == 0)
                {
                    digitsDivisibleByThree++;
                }

                totalDigitSum += curDigit;
                totalDigitsInNumber += 1;
                userInput /= 10;
            }

            if (totalDigitsInNumber < 9 && rightmostDigit != 0)
            {
                digitsSmallerThanRightmost += 9 - totalDigitsInNumber;
                totalDigitsInNumber = 9;
            }

            float averageDigit = (float)totalDigitSum / totalDigitsInNumber;

            System.Console.WriteLine("{0} Digits are smaller than rightmost, Biggest Digit Is {1}, {2} Digits Are Divisible By 3, Digit Average {3}", Math.Abs(digitsSmallerThanRightmost), Math.Abs(biggestDigit), Math.Abs(digitsDivisibleByThree), Math.Abs(averageDigit));

            System.Console.WriteLine(@"
Please Press Enter!");
            System.Console.ReadLine();
        }

        private static bool isValidInputLength(string i_UserInput)
        {
            return (i_UserInput[0] != '-' && i_UserInput.Length == 9) || (i_UserInput[0] == '-' && i_UserInput.Length == 10);
        }

        private static int getValidInput()
        {
            int result;

            System.Console.WriteLine("Please Enter A 9 Digit Integer Number");

            string userInputStr = System.Console.ReadLine();

            while (!int.TryParse(userInputStr, out result) || !isValidInputLength(userInputStr))
            {
                System.Console.WriteLine("Your input is invalid, Please try again!");

                userInputStr = System.Console.ReadLine();
            }

            return result;
        }
    }
}
