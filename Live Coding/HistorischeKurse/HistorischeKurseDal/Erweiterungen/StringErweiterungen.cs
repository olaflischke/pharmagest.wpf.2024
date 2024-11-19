using System.Reflection.Metadata;

namespace HistorischeKurseDal.Erweiterungen
{
    public static class StringErweiterungen
    {
        /// <summary>
        /// Prüft, ob der gg. String numerisch auswertbar ist.
        /// </summary>
        /// <param name="text">Zu prüfender String</param>
        /// <returns>True, wenn der gg. String eine Zahl ist.</returns>
        public static bool IsNumeric(this string text)
        {
            return double.TryParse(text, out _);
        }
    }

    public static class ListErweiterungen
    {
        public static void AddIfNew<T>(this List<T> list, T item, IEqualityComparer<T> comparer) 
        {
            if (list.Contains(item, comparer)) { return; }

            list.Add(item);
        }
    }
}
