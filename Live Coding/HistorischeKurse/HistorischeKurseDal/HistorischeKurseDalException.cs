
namespace HistorischeKurseDal
{
    [Serializable]
    public class HistorischeKurseDalException : Exception
    {
        public HistorischeKurseDalException()
        {
        }

        public HistorischeKurseDalException(string? message) : base(message)
        {
        }

        public HistorischeKurseDalException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}