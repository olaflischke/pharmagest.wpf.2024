using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EierfarmBl
{

    public abstract class Gefluegel : INotifyPropertyChanged, IEiLeger, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Gefluegel(string name)
        {
            this.Name = name;
        }

        // Deklaration eines Events
        public event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;

        private void OnEigenschaftGeaendert([CallerMemberName] string eigenschaftsName = "")
        {
            if (EigenschaftGeaendert != null)
            {
                EigenschaftGeaendert(this, new GefluegelEventArgs(eigenschaftsName));
            }
        }


        private double _gewicht;

        public double Gewicht
        {
            get
            {
                return _gewicht;
            }
            set
            {
                _gewicht = value;
                OnEigenschaftGeaendert("Gewicht");
                OnPropertyChanged();
            }
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnEigenschaftGeaendert(nameof(this.Name));
                OnPropertyChanged();
            }
        }

        private Guid _id = Guid.NewGuid();

        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnEigenschaftGeaendert();
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();

        private DateTime _schluepfdatum = DateTime.Now;
        public DateTime Schluepfdatum
        {
            get
            {
                return _schluepfdatum;
            }
            set
            {
                _schluepfdatum = value;
                OnEigenschaftGeaendert();
                OnPropertyChanged();
            }
        }
        public abstract void Fressen();

        public abstract void EiLegen();

        public void Dispose()
        {
            // Aufräumen hier!
        }
    }
}