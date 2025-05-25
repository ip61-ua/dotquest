using DotQuest.Model;

namespace DotQuest.UI
{
    public abstract class Menu
    {
        public int CurrentQuestionIndex { get; private set; } = -1;
        public List<Question> ListQuestion { get; protected set; } = [];
        public List<Question> OriginalListQuestion { get; private set; } = [];

        public Menu(List<Question> listQuestion)
        {
            OriginalListQuestion = ListQuestion = listQuestion;
            CurrentQuestionIndex = 0;
            Init();
        }

        public void Next()
        {
            CurrentQuestionIndex++;
            Render();
        }

        public void Prev()
        {
            CurrentQuestionIndex--;
            Render();
        }

        protected void Reset()
        {
            CurrentQuestionIndex = 0;
            ListQuestion = OriginalListQuestion;
            Render();
        }

        protected void Mark(int i) => ListQuestion[CurrentQuestionIndex].Mark(i);
        public bool Solve() => ListQuestion[CurrentQuestionIndex].Solve();

        abstract public void Init();
        abstract public void Render();
    }
}
