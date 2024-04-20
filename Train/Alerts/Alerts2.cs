namespace Train.Alerts
{
    internal class Alerts2
    {
        public void Run(string inputFilePath = "")
        {
            string outputFilePath = $"{inputFilePath}.Test";
            using var input = new StreamReader(inputFilePath);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());

            var serviceString = input.ReadLine().Split();
            int usersCount = int.Parse(serviceString[0]);
            var requestCount = int.Parse(serviceString[1]);

            var usersEvents = new int[usersCount + 1];
            var usersEventsDictionary = new Dictionary<int, int>();
            var results = new int[requestCount];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = -1;
            }
            var lastFilledResultIndex = -1;
            var eventId = 0;

            var result = string.Empty;
            var lastRequestInputStr = string.Empty;
            var globalEventID = -1;
            for (int i = 0; i < requestCount; i++)
            {
                var intputStr = input.ReadLine();
                var userId = int.Parse(intputStr.Split()[1]);

                if (intputStr.Equals(lastRequestInputStr))
                {
                    if (intputStr[0] == '2')
                    {
                        lastFilledResultIndex++;
                        if (usersEventsDictionary.ContainsKey(userId))
                        {
                            results[lastFilledResultIndex] = usersEventsDictionary[userId];
                        }
                        else
                        {
                            if (globalEventID != -1)
                            {
                                results[lastFilledResultIndex] = globalEventID;
                            }
                            else
                            {
                                results[lastFilledResultIndex] = 0;
                            }
                        }
                        continue;
                    }

                    if (intputStr[0] == '1')
                    {
                        eventId++;
                        if (userId != 0)
                        {
                            usersEventsDictionary[userId] = eventId;
                        }
                        else
                        {
                            globalEventID = eventId;
                            usersEventsDictionary = new Dictionary<int, int>();
                        }

                        continue;
                    }
                }

                if (intputStr[0] == '1')
                {
                    eventId++;
                    if (userId != 0)
                    {
                        usersEventsDictionary[userId] = eventId;
                    }
                    else
                    {
                        globalEventID = eventId;
                        usersEventsDictionary = new Dictionary<int, int>();
                    }

                    continue;
                }

                if (intputStr[0] == '2')
                {
                    lastFilledResultIndex++;
                    if (usersEventsDictionary.ContainsKey(userId))
                    {
                        results[lastFilledResultIndex] = usersEventsDictionary[userId];
                    }
                    else
                    {
                        if (globalEventID != -1)
                        {
                            results[lastFilledResultIndex] = globalEventID;
                        }
                        else
                        {
                            results[lastFilledResultIndex] = 0;
                        }
                    }
                }

                lastRequestInputStr = intputStr;
            }

            for (int i = 0; i <= lastFilledResultIndex; i++)
            {
                output.WriteLine(results[i]);
            }
        }
    }
}