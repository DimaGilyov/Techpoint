using System.Text;

namespace Train.Stickers
{
    internal class Stickers
    {
        public void Run(string inputFilePath="")
        {
            //string outputFilePath = $"{inputFilePath}.Test";
            //using var input = new StreamReader(inputFilePath);
            //using var output = new StreamWriter(outputFilePath);

            using var input = new StreamReader(Console.OpenStandardInput());
            using var output = new StreamWriter(Console.OpenStandardOutput());

            string sticker = input.ReadLine();
            StringBuilder newSticker = new StringBuilder(sticker);

            int n = int.Parse(input.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = input.ReadLine().Split();
                int startIndex = int.Parse(data[0]) - 1;
                int endIndex = int.Parse(data[1]) - 1;
                string str = data[2];

                newSticker.Remove(startIndex, (endIndex - startIndex) + 1);
                newSticker.Insert(startIndex, str);
            }

            output.WriteLine(newSticker);
        }
    }
}
