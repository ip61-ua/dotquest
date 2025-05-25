using DotQuest.Utils;
using DotQuest.IO;
using DotQuest.UI.CLI;

namespace DotQuest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProgramArguments.Parse(args);
            new Cli(FileQuestion.Import(ProgramArguments.FileSource));
        }
    }
}
