using System;
using System.IO;
using System.Text.Json;
using System.Text;

namespace Techpoint
{

    public class Folder
    {
        public string dir { get; set; }
        public string[] files { get; set; }
        public Folder[] folders { get; set; }
    }

    public class Virus
    {
        public static int GetHackFilesCount(Folder folder, bool isVirus)
        {
            int filesCount = 0;

            if (folder.files != null)
            {
                foreach (var fileName in folder.files)
                {
                    if (fileName.EndsWith(".hack"))
                    {
                        isVirus = true;
                        break;
                    }
                }
                if (isVirus)
                    filesCount += folder.files.Length;
            }

            if (folder.folders != null)
            {
                foreach (var f in folder.folders)
                {
                    filesCount += GetHackFilesCount(f, isVirus);
                }
            }

            return filesCount;
        }

        public static void Main(string[] args)
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            using var output = new StreamWriter(Console.OpenStandardOutput());

            int t = int.Parse(input.ReadLine());
            for (int i = 0; i < t; i++)
            {
                StringBuilder jsonStr = new StringBuilder();
                int n = int.Parse(input.ReadLine());
                for (int j = 0; j < n; j++)
                {
                    jsonStr.Append(input.ReadLine());
                }

                Folder root = JsonSerializer.Deserialize<Folder>(jsonStr.ToString());
                int filesCount = GetHackFilesCount(root, false);
                output.WriteLine(filesCount);
            }
        }
    }
}