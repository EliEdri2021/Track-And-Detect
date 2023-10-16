namespace Ex01_02
{
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            SimpleDiamond(9);

            System.Console.WriteLine(@"
Please Press Enter!");
            System.Console.ReadLine();
        }

        public static void SimpleDiamond(int i_DiamondHeight)
        {
            simpleDiamondUnwrapped(1,  (i_DiamondHeight / 2) + 1);
        }

        private static void simpleDiamondUnwrapped(int i_CurrentDepth, int i_MaxWidth)
        {
            StringBuilder outPutStrBuilder = new StringBuilder();

            for (int i = 1; i < i_MaxWidth + i_CurrentDepth; i++)
            {
                outPutStrBuilder.Append(i > (i_MaxWidth - i_CurrentDepth) ? "*" : " ");
            }

            string outPutStr = outPutStrBuilder.ToString();
            System.Console.WriteLine(outPutStr);

            if (i_CurrentDepth != i_MaxWidth)
            {
                simpleDiamondUnwrapped(i_CurrentDepth + 1, i_MaxWidth);

                System.Console.WriteLine(outPutStr);
            }
        }
    }
}