using DotQuest.Model;

namespace DotQuest.UI.CLI
{
    public class Cli : Menu
    {
        public Cli(List<Question> listQuestion) : base(listQuestion) { }

        public override void Init()
        {
            Console.Clear();
        }

        public override void Render()
        {
            Console.Write(ListQuestion[CurrentQuestionIndex]);

            bool validResponse = false;
            bool performSolving = false;

            int markOption = -1;

            do
            {
                validResponse = false;

                Console.WriteLine();
                Console.Write("Elige opción: ");
                var response = Console.ReadLine();
                if (response == null) continue;

                if (response == "n")
                    Next();

                if (response == "p")
                    Prev();

                if (response == "n" || response == "p")
                    break;

                if (response == "s")
                    performSolving = true;

                markOption = int.Parse(response);

                if (string.IsNullOrWhiteSpace(response) ||
                  !ListQuestion[CurrentQuestionIndex].Mark(markOption) || response != "s")
                {
                    Console.Error.Write("Respuesta inválida");
                    continue;
                }

                performSolving = true; // Por defecto, solo marcar una

                if (performSolving)
                    if (Solve()) Console.Write("🟦 Respuesta correcta");
                    else Console.Write("🟨 RESPUESTA INCORRECTA\n" + ListQuestion[CurrentQuestionIndex].ToStringWithCorrect());

                break;
            } while (!validResponse);

            if (validResponse)
                Next();
        }
    }
}
