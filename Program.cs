using DotQuest.IO;

namespace DotQuest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                throw new Exception("Se requiere un archivo de preguntas de entrada.");
            }


            var l = FileQuestion.Import(args[0]);

            foreach (var q in l)
            {
                Console.WriteLine(q.ToStringWithCorrect());
            }

        }
    }
}
