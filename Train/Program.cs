using Train.Summator;

namespace Techpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Summator summator= new Summator();
            summator.Run();
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}