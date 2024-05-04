
namespace Train.Summator
{
    internal class Summator
    {
        public void Run()
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            using var output = new StreamWriter(Console.OpenStandardOutput());

            int t = int.Parse(input.ReadLine());
            if (t < 1 || t > 10000)
            {
                throw new Exception($"t={t} value outside the boundary. t can be 1 ≤ t ≤ 10000.");
            }
             
            for(int i = 0; i < t; i++)
            {
                var s = input.ReadLine().Split();
                if (s.Length != 2)
                {
                    throw new Exception($"s({s.Length}) does not contain 2 arguments.");
                }

                int a = int.Parse(s[0]);
                int b = int.Parse(s[1]);
                if (a < -1000 || a > 1000)
                {
                    throw new Exception($"a={a} value outside the boundary. a can be -1000 ≤ a ≤ 10000.");
                }
                if (b < -1000 || b > 1000)
                {
                    throw new Exception($"b={b} value outside the boundary. b can be -1000 ≤ b ≤ 10000.");
                }

                int sum = a + b;
                output.WriteLine(sum);
            }
        }
    }
}
