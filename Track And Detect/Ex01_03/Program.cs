namespace Ex01_03
{
    using Ex01_02;

    public class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("Please Input A Height For Creating a Diamond-Like (Rhombus) Asterisk Formation");
            string userInputStr = System.Console.ReadLine();

            if (int.TryParse(userInputStr, out int userInputInt))
            {
                if (userInputInt % 2 == 0)
                {
                    userInputInt++;
                    System.Console.WriteLine("Your Input Was INVALID! Automatically Altered To Achieve Validity.");
                }

                Ex01_02.Program.SimpleDiamond(userInputInt);
            }
            else
            {
                System.Console.WriteLine("Your Input Was INVALID! It Couldn't Be Altered To Validity, Will Not Print.");
            }

            System.Console.WriteLine("Please Press Enter!");
            System.Console.ReadLine();
        }
    }
}
