namespace Model
{
    public class QuestionOption
    {
        private bool correct = false;
        private bool selected = false;
        private string option_text = "<No option>";

        public bool Correct { get => correct; private set => correct = value; }
        public bool Selected { get => selected; set => selected = value; }
        public string OptionText { get => option_text; private set => option_text = value; }

        public QuestionOption(bool correct, string option_text)
        {
            OptionText = option_text;
            Correct = correct;
        }

        public override string ToString()
        {
            return $"{OptionText}";
        }

        public string ToStringWithCorrect()
        {
            return $"{(Correct ? "✅" : "❌")} {OptionText.ToString()}";
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
            Random rng = new Random();
            ListOptions = list_options.OrderBy(x => rng.Next()).ToList();
        }

        public override string ToString()
        {
            string result = QuestionText;

            for (int i = 0; i < ListOptions.Count(); i++)
                result += "\n" + ListOptions[i].ToString();

            return result;
        }
    }
}
