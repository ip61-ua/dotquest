namespace DotQuest.Utils
{
    public static class ProgramArguments
    {
        public static string FileSource { get; private set; } = "";

        public static void Parse(string[] args)
        {
            if (args.Length < 1)
                throw new Exception("Se requiere un archivo de preguntas de entrada.");

            FileSource = args[0];
        }
    }
}
