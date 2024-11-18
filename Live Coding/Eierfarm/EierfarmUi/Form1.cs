using EierfarmBl;
using System.Xml.Serialization;

namespace EierfarmUi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNeuesHuhn_Click(object sender, EventArgs e)
        {
            Huhn huhn = new Huhn();

            huhn.EigenschaftGeaendert += this.Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(huhn);
            cbxTiere.SelectedItem = huhn;
        }

        private void Gefluegel_EigenschaftGeaendert(object? sender, GefluegelEventArgs e)
        {
            pgdTier.SelectedObject = sender;
            //MessageBox.Show(
            //    text: $"Tier {((Gefluegel)sender).Name} hat Eigenschaft {e.GeaenderteEigenschaft} geändert!",
            //    caption: "Änderung",
            //    buttons: MessageBoxButtons.OK,
            //    icon: MessageBoxIcon.Information);
        }

        private void btnNeueGans_Click(object sender, EventArgs e)
        {
            Gans gans = new Gans();

            gans.EigenschaftGeaendert += Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }

        private void btnSchnabeltier_Click(object sender, EventArgs e)
        {
            Schnabeltier schnabeltier = new Schnabeltier();

            cbxTiere.Items.Add(schnabeltier);
            cbxTiere.SelectedItem = schnabeltier;
        }


        private void cbxTiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgdTier.SelectedObject = cbxTiere.SelectedItem;
        }

        private void btnFuettern_Click(object sender, EventArgs e)
        {
            IEiLeger tier = cbxTiere.SelectedItem as IEiLeger; // SafeCast, liefert null, wenn Cast fehlschlägt
            if (tier != null)
            {
                tier.Fressen();
             //pgdTier.Refresh();
            }
        }

        private void btnEiLegen_Click(object sender, EventArgs e)
        {
            if (cbxTiere.SelectedItem is IEiLeger tier)
            {
                tier.EiLegen();
                //pgdTier.Refresh();
            }
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            if (cbxTiere.SelectedItem is IEiLeger tier)
            {
                // Benutzer nach Speicherort fragen
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    RestoreDirectory = true,
                    Filter = "Hühner|*.hn|Gänse|*.gs|Schnabeltier|*.st|Alles|*.*",
                    FilterIndex = 0
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Tier dort speichern 
                    XmlSerializer serializer = new XmlSerializer(tier.GetType());
                    StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
                    serializer.Serialize(writer, tier);
                }

            }
        }

        private void btnLaden_Click(object sender, EventArgs e)
        {
            // TODO: Analog btnSpeichern_Click Tiere laden
        }

    }
}
