
namespace EierfarmBl
{
    public class GefluegelEventArgs : EventArgs
    {

        public GefluegelEventArgs(string eigenschaftsName)
        {
            this.GeaenderteEigenschaft = eigenschaftsName;
        }

        private string _eigenschaftsName;

        public string GeaenderteEigenschaft
        {
            get { return _eigenschaftsName; }
            set { _eigenschaftsName = value; }
        }

    }
}