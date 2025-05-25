using Model;

namespace DotQuest
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var test = new Question("ESTO ES UN TEST", []);
            /**
              for (int i = 0; i < args.Length; i++)
                  Console.Write(args[i] + "\n");
            */
            Console.Write(test);
        }
    }
}
