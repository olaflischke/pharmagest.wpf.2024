namespace EierfarmBl
{
    public class Huhn : Gefluegel
    {
        public Huhn() : base("Neues Huhn")
        {
            this.Gewicht = 1000;
        }

        public Huhn(string name) : this()
        {
            this.Name = name;
        }

        public override void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                // [Modifier] Typ Bezeichner = Wert
                Ei ei = new Ei(this); // Ei-Klasse: public Ei(Huhn mutter)
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < 3000)
            {
                this.Gewicht += 100;
            }
        }
    }
}