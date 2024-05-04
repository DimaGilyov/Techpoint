using System.Text;
using System.Text.Json;

namespace Train.VirusFile
{
    internal class VirusFile
    {
        public void Run(string inputFilePath = "")
        {
            string outputFilePath = $"{inputFilePath}.Test";
            using var input = new StreamReader(inputFilePath);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());

            var options = new JsonSerializerOptions
            {
                MaxDepth = 1000
            };

            int t = int.Parse(input.ReadLine());
            for (int i = 0; i < t; i++)
            {
                StringBuilder jsonStr = new StringBuilder();
                int n = int.Parse(input.ReadLine());
                for (int j = 0; j < n; j++)
                {
                    jsonStr.Append(input.ReadLine());
                }

                Folder root = JsonSerializer.Deserialize<Folder>(jsonStr.ToString(), options);
                int filesCount = GetHackFilesCount(root, false);
                output.WriteLine(filesCount);
            }
        }

        public int GetHackFilesCount(Folder folder, bool isVirus)
        {
            int filesCount = 0;
            int curFoldersCount = folder.files == null ? 0 : folder.files.Length;
            if (isVirus)
            {
                filesCount += curFoldersCount;
            }
            else if (curFoldersCount > 0)
            {
                for (int i = 0; i < curFoldersCount; i++)
                {
                    string fileName = folder.files[i];
                    if (fileName.EndsWith(".hack"))
                    {
                        isVirus = true;
                        filesCount += curFoldersCount;
                        break;
                    }
                }
            }

            if (folder.folders != null)
            {
                for (int i = 0; i < folder.folders.Length; i++)
                {
                    Folder f = folder.folders[i];
                    filesCount += GetHackFilesCount(f, isVirus);
                }
            }

            return filesCount;
        }
    }


    class Folder
    { 
            public string dir { get; set; }
            public string[] files { get; set; }
            public Folder[] folders { get; set; }
    }
}
