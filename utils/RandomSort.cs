namespace DotQuest.Utils
{
    static class RandomSort
    {
        private static Random rng = new Random();
        public static List<T> Sort<T>(List<T> listToSort) => listToSort
          .OrderBy(x => rng.Next()).ToList();
    }
}
