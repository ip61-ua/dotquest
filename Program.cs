using Model;

namespace DotQuest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var o1 = new QuestionOption(false, "Se debe ceder el paso a los vehículos que circulen por la izquierda.");
            var o2 = new QuestionOption(true, "Se debe ceder el paso a los vehículos que circulen por la derecha.");
            var o3 = new QuestionOption(false, "No es necesario ceder el paso a ningún vehículo.");

            var q = new Question("En una intersección sin señalización expresa, ¿qué norma general se aplica respecto a la preferencia de paso?", [o1, o2, o3]);

            Console.Write(q);
            Console.Write(q.ToStringWithCorrect());
            q.Mark(2);
            Console.Write(q);
            Console.Write(q.ToStringWithCorrect());

        }
    }
}
