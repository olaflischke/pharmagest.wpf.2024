
using Microsoft.Win32;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace HistorischeKurseDal
{
    public class ReferenzkursArchiv
    {
        /// <summary>
        /// Erzeugt eine Instanz der ReferenzkursArchiv-Klasse mit den Daten aus der durch die URL gg. GEMSES-XML-Datei.
        /// </summary>
        /// <param name="url">Die URL gg. GEMSES-XML-Datei.</param>
        public ReferenzkursArchiv(string url)
        {
            this.Handelstage = GetData(url);
        }

        /// <summary>
        /// Erzeugt eine Liste von Handelstagen aus der gg. XML-GESMES-Datei.
        /// </summary>
        /// <param name="url">URL oder Pfad der XML-GESMES-Datei.</param>
        /// <returns>Eine Liste von Handelstagen.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        private List<Handelstag>? GetData(string url)
        {
            try
            {
                XDocument document = XDocument.Load(url);

                IEnumerable<Handelstag>? q = document.Root?.Descendants()
                                    .Where(xe => xe.Name.LocalName == "Cube" && xe.Attributes().Any(at => at.Name == "time"))
                                    // Projektion
                                    .Select(xe => new Handelstag(xe)); //{ Datum = DateOnly.Parse(xe.Attribute("time")?.Value) });

                //List<Handelstag> tage = new List<Handelstag>();

                //foreach (var xe in q)
                //{
                //    Handelstag handelstag = new Handelstag() { Datum = DateOnly.Parse(xe.Attribute("time")?.Value) };
                //    tage.Add(handelstag);
                //}

                // Deferred Execution
                return q.ToList();

            }
            catch (Exception ex)
            {

                throw new HistorischeKurseDalException("Laden der Daten fehlgeschlagen", ex);
            }


        }

        private bool CheckNode(XElement xe)
        {
            if (xe.Name.LocalName == "Cube" && xe.Attributes().Any(at => at.Name == "time"))
            {
                return true;
            }
            return false;
        }

        private Handelstag CreateHandelstag(XElement xe)
        {

            return new Handelstag(xe);
        }


        /// <summary>
        /// Gibt die Handelstage des Archivs zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Kann Spuren von null enthalten!
        /// </remarks>
        private List<Handelstag> _tage = new List<Handelstag>();
        public List<Handelstag>? Handelstage
        {
            get => _tage; // Expression-bodied memsber
            set => _tage = value;
        }
    }
}
