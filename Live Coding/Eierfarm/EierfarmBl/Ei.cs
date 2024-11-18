using System.Xml.Serialization;

namespace EierfarmBl
{
    public class Ei
    {
        private Ei()
        {

        }

        public Ei(IEiLeger mutter)
        {
            Random zufall = new Random();

            this.Gewicht = zufall.Next(45, 81);
            this.Farbe = (EiFarbe)zufall.Next(3); // DirectCast - kann zu InvalidCastException führen

            this.Mutter = mutter;

        }

        // Full-qualified property
        // Eigenschaft mit explizitem Backing Field
        private double _gewicht = 65;

        public double Gewicht
        {                             // Ei meinEi = new Ei();
            get { return _gewicht; }  // var a = meinEi.Gewicht;
            set
            {
                if (value > 0)
                {
                    _gewicht = value;
                }
            } // meinEi.Gewicht = 65;
        }

        // Auto-Property
        // Property mit automatisch durch den Compiler generiertem Backing Field
        public DateTime Legedatum { get; } = DateTime.Now; // Auto-Property Initializer (werden vor(!) den Konstruktoren ausgeführt!)

        // Öffentliches Feld
        public readonly DateTime Legedatum2;

        // Property ohne Backing Field!
        public DateTime Verfallsdatum
        {
            get
            {
                return this.Legedatum.AddDays(30);
            }
        }

        [XmlAttribute("id")] // ID als XML-Attribut
        public Guid Id { get; set; } = Guid.NewGuid();

        [XmlElement(ElementName = "Color")] // Tag-Bezeichner ändern
        public EiFarbe Farbe { get; set; }

        [XmlIgnore] // Element beim Serialisieren ignorieren
        public IEiLeger Mutter { get; set; }
    }

    public enum EiFarbe
    {
        Hell,
        Dunkel,
        Gruen
    }
}
