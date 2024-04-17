using Train.Stickers;
using Train.Summator;

namespace Techpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stickers prigramm = new Stickers();
            string[] files = Directory.GetFiles(@"C:\\Users\\DimaG\Downloads\238");

            foreach (string file in files)
            {
                if (file.EndsWith(".Test"))
                {
                    File.Delete(file);
                }
            }

            foreach (string file in files)
            {
                if (!file.EndsWith(".a"))
                {
                    prigramm.Run(file);
                }
            }

            foreach (string file in files)
            {
                if (file.EndsWith(".a"))
                {
                    Test(file);
                }
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }

        public static void Test(string inputFilePath)
        {
            string testPath = inputFilePath.Replace(".a", ".Test");
            string orig = File.ReadAllText(inputFilePath).Trim();
            string myResult = File.ReadAllText(testPath).Trim();
            if (orig != myResult)
            {
                Console.WriteLine($"Test failed:{inputFilePath}");
            }
        }
    }
}