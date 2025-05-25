using DotQuest.Utils;
using DotQuest.IO;
using DotQuest.UI;

namespace DotQuest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProgramArguments.Parse(args);
            Menu.launch(FileQuestion.Import(ProgramArguments.FileSource));
        }
    }
}
