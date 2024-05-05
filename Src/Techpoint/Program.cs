namespace Techpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\55");
            //ITask task = new Task1();

            //string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\287");
            //ITask task = new Task2();
            //
            string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\288");
            ITask task = new Task3();
            //
            //string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\75");
            //ITask task = new Task4();
            //
            //string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\75");
            //ITask task = new Task5();
            //
            //string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\75");
            //ITask task = new Task6();
            //
            //string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\75");
            //ITask task = new Task7();
            //
            //string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\75");
            //ITask task = new Task8();
            //
            //string[] files = Directory.GetFiles(@"C:\Users\DimaG\Downloads\75");
            //ITask task = new Task9();

            bool start = true;
            if (start)
            {
                DateTime startTime = DateTime.Now;
                foreach (string file in files)
                {
                    if (!file.EndsWith(".a"))
                    {
                        Console.WriteLine($"Run:{file}");
                        task.Run(file);
                    }
                }
                Console.WriteLine(DateTime.Now - startTime);

                foreach (string file in files)
                {
                    if (file.EndsWith(".a"))
                    {
                        Test(file);
                    }
                }
            }
            else
            {
                foreach (string file in files)
                {
                    if (file.EndsWith(".Test"))
                    {
                        Console.WriteLine($"Delete {file}");
                        File.Delete(file);
                    }
                }
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }

        public static void Test(string inputFilePath)
        {
            string testPath = inputFilePath.Replace(".a", ".Test");
            //string orig = File.ReadAllText(inputFilePath).Trim().Replace("\r\n", "\n");
            //string myResult = File.ReadAllText(testPath).Trim().Replace("\r\n", "\n");
            //if (orig != myResult)
            //{
            //    Console.WriteLine($"Test failed:{inputFilePath}");
            //}

            string[] orig = File.ReadAllLines(inputFilePath);
            string[] test = File.ReadAllLines(testPath);
            for (int i = 0; i < orig.Length; i++)
            {
                string origLine = orig[i];
                string testLine = test[i];
                if (origLine != testLine)
                {
                    Console.WriteLine($"Test failed:{inputFilePath} {i}, origLine={origLine}, testLine={testLine}");
                }
            }
        }
    }
}