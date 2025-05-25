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

        private void PrintRight()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Respuesta correcta");
            Console.ResetColor();
        }

        private void PrintWrong()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("RESPUESTA INCORRECTA\n" + ListQuestion[CurrentQuestionIndex].ToStringWithCorrect());
            Console.ResetColor();
        }


        public override void Render()
        {
            Console.Write(ListQuestion[CurrentQuestionIndex]);

            bool validResponse = false;

            int markOption = -1;
            string? response;

            do
            {
                validResponse = false;

                Console.WriteLine();
                Console.Write("Elige opción: ");

                try
                {
                    response = Console.ReadLine();

                    if (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response))
                        throw new Exception("Vacía.");

                    if (response == "n")
                        Next();

                    if (response == "p")
                        Prev();

                    if (response == "n" || response == "p" || response == "q")
                        break;

                    if (response == "s")
                    {
                        Console.Write(ListQuestion[CurrentQuestionIndex].ToStringWithCorrect());
                        validResponse = true;
                        break;
                    }


                    markOption = int.Parse(response);

                    if (!ListQuestion[CurrentQuestionIndex].IsValidOption(markOption))
                        throw new Exception("Fuera de rango.");

                    validResponse = true; // solo una respuesta máxima

                    Mark(markOption);

                    // solo una respuesta máxima
                    if (Solve()) PrintRight();
                    else PrintWrong();
                }
                catch (Exception ex)
                {
                    Console.Error.Write("Respuesta inválida: " + ex.Message);
                    continue;
                }
            } while (!validResponse);

            if (validResponse)
                Next();
        }
    }
}
