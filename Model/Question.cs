using DotQuest.Utils;

namespace DotQuest.Model
{
    public class QuestionOption
    {
        private bool correct = false;
        private bool selected = false;
        private string option_text = "<No option>";

        public bool Correct { get => correct; private set => correct = value; }
        public bool Selected { get => selected; protected set => selected = value; }
        public string OptionText { get => option_text; private set => option_text = value; }

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
        private string question_text = "<No question text>";
        private List<QuestionOption> list_options = [];

        public string QuestionText { get => question_text; private set => question_text = value; }
        public List<QuestionOption> ListOptions { get => list_options; private set => list_options = value; }

        public Question(string question_text, List<QuestionOption> list_options)
        {
            QuestionText = question_text;
            ListOptions = RandomSort.Sort<QuestionOption>(list_options);
        }

        public void Mark(int i)
        {
            if (0 <= i && i <= ListOptions.Count())
                ListOptions[i].Mark();
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
                result += "\n " + i + ". " + ListOptions[i].ToString();

            return result + "\n";
        }

        public string ToStringWithCorrect()
        {
            string result = QuestionText;

            for (int i = 0; i < ListOptions.Count(); i++)
                result += "\n " + i + ". " + ListOptions[i].ToStringWithCorrect();

            return result + "\n";
        }

    }
}
