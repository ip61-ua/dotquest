using DotQuest.Utils;

namespace DotQuest.Model
{
    public class QuestionOption
    {
        public bool Correct { get; private set; } = false;
        public bool Selected { get; protected set; } = false;
        public string OptionText { get; private set; } = "<No option>";

        public QuestionOption(bool correct, string option_text)
        {
            OptionText = option_text;
            Correct = correct;
        }

        public void Mark()
        {
            Selected = Selected ? false : true;
        }

        public override string ToString()
        {
            return $"{(Selected ? "*" : "")}{OptionText}";
        }

        public string ToStringWithCorrect()
        {
            return $"{(Correct ? "✅" : "❌")} {ToString()}";
        }
    }

    public class Question
    {
        public string QuestionText { get; set; } = "<No question text>";
        public List<QuestionOption> ListOptions { get; private set; } = [];

        public Question(string question_text, List<QuestionOption> list_options)
        {
            QuestionText = question_text;
            ListOptions = RandomSort.Sort<QuestionOption>(list_options);
        }

        public bool IsValidOption(int i) => 0 <= i && i <= ListOptions.Count();


        public bool Mark(int i)
        {
            if (IsValidOption(i - 1))
            {
                ListOptions[i - 1].Mark();
                return true;
            }

            return false;
        }

        public bool Solve()
        {
            for (int i = 0; i < ListOptions.Count(); i++)
            {
                if (ListOptions[i].Correct != ListOptions[i].Selected)
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            string result = QuestionText;

            for (int i = 0; i < ListOptions.Count(); i++)
                result += "\n " + (i + 1) + ". " + ListOptions[i].ToString();

            return result + "\n";
        }

        public string ToStringWithCorrect()
        {
            string result = QuestionText;

            for (int i = 0; i < ListOptions.Count(); i++)
                result += "\n " + (i + 1) + ". " + ListOptions[i].ToStringWithCorrect();

            return result + "\n";
        }

    }
}
