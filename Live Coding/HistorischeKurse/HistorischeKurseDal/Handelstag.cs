using System.Xml.Linq;
using System.Globalization;

namespace HistorischeKurseDal
{
    public class Handelstag
    {
        // <Cube time = "2024-06-24" >

        //          < Cube currency="USD"
        //	      rate="1.073"/>
        //	<Cube currency = "JPY"

        //                rate="171.17"/>
        //	<Cube currency = "BGN"

        //                rate="1.9558"/>
        //	<Cube currency = "CZK"

        //                rate="24.893"/>
        //	<Cube currency = "DKK"

        //                rate="7.4593"/>
        //	<Cube currency = "GBP"

        //                rate="0.8473"/>
        //	<Cube currency = "HUF"

        //                rate="394.36"/>
        //	<Cube currency = "PLN"

        //                rate="4.3003"/>
        //	<Cube currency = "RON"

        //                rate="4.9774"/>
        //	<Cube currency = "SEK"

        //                rate="11.2555"/>
        //	<Cube currency = "CHF"

        //                rate="0.9586"/>
        //	<Cube currency = "ISK"

        //                rate="149.1"/>
        //	<Cube currency = "NOK"

        //                rate="11.349"/>
        //	<Cube currency = "TRY"

        //                rate="35.2953"/>
        //	<Cube currency = "AUD"

        //                rate="1.6157"/>
        //	<Cube currency = "BRL"

        //                rate="5.8278"/>
        //	<Cube currency = "CAD"

        //                rate="1.4682"/>
        //	<Cube currency = "CNY"

        //                rate="7.7891"/>
        //	<Cube currency = "HKD"

        //                rate="8.3772"/>
        //	<Cube currency = "IDR"

        //                rate="17596.13"/>
        //	<Cube currency = "ILS"

        //                rate="4.0003"/>
        //	<Cube currency = "INR"

        //                rate="89.5833"/>
        //	<Cube currency = "KRW"

        //                rate="1489.57"/>
        //	<Cube currency = "MXN"

        //                rate="19.3887"/>
        //	<Cube currency = "MYR"

        //                rate="5.0554"/>
        //	<Cube currency = "NZD"

        //                rate="1.7543"/>
        //	<Cube currency = "PHP"

        //                rate="63.066"/>
        //	<Cube currency = "SGD"

        //                rate="1.452"/>
        //	<Cube currency = "THB"

        //                rate="39.347"/>
        //	<Cube currency = "ZAR"

        //                rate="19.5122"/>
        //</Cube>


        public Handelstag(XElement handelstagNode)
        {
            this.Datum = DateOnly.Parse(handelstagNode.Attribute("time").Value);

            //CultureInfo ciEzb = new CultureInfo("en-US");
            //NumberFormatInfo nfiEzb = ciEzb.NumberFormat;

            NumberFormatInfo nfiEzb = new NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" };

            var q = handelstagNode.Elements()
                                        .Select(el => new Wechselkurs()
                                        {
                                            Symbol = el.Attribute("currency").Value,
                                            EuroKurs = Convert.ToDouble(el.Attribute("rate").Value, nfiEzb) //NumberFormatInfo.InvariantInfo)
                                        });

            this.Wechselkurse = q.ToList();
        }

        public DateOnly? Datum { get; set; }
        public List<Wechselkurs>? Wechselkurse { get; set; }
    }
}