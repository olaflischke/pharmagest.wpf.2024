namespace HistorischeKurseDalUnitTests
{
    public class ReferenzkursArchivUnitTests
    {
        string url;

        [SetUp]
        public void Setup()
        {
            url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
        }

        [Test]
        public void IsArchivInitializing()
        {
            ReferenzkursArchiv archiv = new ReferenzkursArchiv(url);

            Handelstag? handelstag = archiv.Handelstage?.FirstOrDefault();
            Wechselkurs? wechselkurs = handelstag?.Wechselkurse?.FirstOrDefault();


            Console.WriteLine($"Erster Handelstag {handelstag?.Datum:dd.MM.yy}: {wechselkurs.Symbol} - {wechselkurs.EuroKurs:#,##0.0000}");

            Assert.AreEqual(GetAttributeCount("time"), archiv.Handelstage.Count);
        }

        private int GetAttributeCount(string attributeName)
        {
            return 61;
        }

        [Test]
        public void FehlerhafteUrl()
        {
            Assert.Throws<HistorischeKurseDalException>(() =>
            {
                string testUrl = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90.xml";

                ReferenzkursArchiv archiv = new ReferenzkursArchiv(testUrl);
            });
        }
    }
}