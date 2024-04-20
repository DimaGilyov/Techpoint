namespace Train.Cards
{
    internal class Cards
    {
        public void Run(string inputFilePath = "")
        {
            string outputFilePath = $"{inputFilePath}.Test";
            using var input = new StreamReader(inputFilePath);
            using var output = new StreamWriter(outputFilePath);

            //using var input = new StreamReader(Console.OpenStandardInput());
            //using var output = new StreamWriter(Console.OpenStandardOutput());


            int[] inputData = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
            int[] friends = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
            int n = inputData[0]; //Кол-во друзей
            int m = inputData[1]; //Кол-во карточек
            int[] cards = new int[m];
            for (int i = 0; i < m; i++)
            {
                cards[i] = m - i;
            }

            (int index, int card)[] friends2 = new (int, int)[friends.Length];
            for (int i = 0; i < friends2.Length; i++)
            {
                friends2[i] = (i, friends[i]);
            }
            Array.Sort(friends2, (x, y) => y.card.CompareTo(x.card));

            bool success = false;
            int[] gifts = new int[friends.Length];
            if (n <= m)
            {
                for (int i = 0; i < friends2.Length; i++)
                {
                    int index = friends2[i].index;
                    int card = friends2[i].card;
                    if (card < cards[i])
                    {
                        gifts[index] = cards[i];
                        success = true;
                    }
                    else
                    {
                        success = false;
                        break;
                    }
                }
            }

            if (success)
            {
                string resp = string.Join(" ", gifts);
                output.WriteLine(resp);
            }
            else 
            {
                output.WriteLine(-1);
            }
        }
    }
}
