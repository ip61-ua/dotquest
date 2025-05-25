using DotQuest.Model;

namespace DotQuest.IO
{
    public static class FileQuestion
    {
        private static class InternalCounter
        {
            public static string CurrentQuestionStr { get; set; } = "";
            public static int CurrentCorrectIndex { get; set; } = -1;
            public static List<QuestionOption> CurrentCurrentOptions { get; set; } = [];

            public static void Reset()
            {
                CurrentQuestionStr = "";
                CurrentCorrectIndex = -1;
                CurrentCurrentOptions = [];
            }

            public static bool IsUndefinedStr() => CurrentQuestionStr == "";
            public static bool IsUndefinedIndex() => CurrentCorrectIndex == -1;
        }

        public static List<Question> Parse(string contents)
        {
            string[] lines = contents.TrimStart().Split('\n');
            List<Question> result = new();

            for (int i = 0; i < lines.Length; i++)
            {
                if (InternalCounter.IsUndefinedStr())
                    InternalCounter.CurrentQuestionStr = lines[i];
                else if (InternalCounter.IsUndefinedIndex())
                    InternalCounter.CurrentCorrectIndex = int.Parse(lines[i]) + i;
                else if (lines[i] == "" || i + 1 == lines.Length)
                {
                    result
                      .Add(new Question(InternalCounter.CurrentQuestionStr,
                        InternalCounter.CurrentCurrentOptions));
                    InternalCounter.Reset();
                }
                else
                    InternalCounter.CurrentCurrentOptions
                      .Add(new QuestionOption(i == InternalCounter.CurrentCorrectIndex,
                        lines[i]));
            }

            return result;
        }

        public static List<Question> Import(string srcFile)
        {
            return Parse(File.ReadAllText(srcFile));
        }
    }
}
