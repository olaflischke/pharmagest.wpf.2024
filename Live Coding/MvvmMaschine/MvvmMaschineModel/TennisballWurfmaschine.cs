using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Threading;

namespace MVVMMaschine
{
    public class TennisballWurfmaschine : INotifyPropertyChanged
    {

        #region Lokale Variablen
        private DispatcherTimer timTimer;
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TennisballWurfmaschine()
        {
            timTimer = new DispatcherTimer();
            timTimer.Tick += TimTimer_Tick;
        }

        private void TimTimer_Tick(object sender, EventArgs e)
        {
            this.Stueckzahl++;
        }


        #region Eigenschaften der Maschine
        private int _intSpeed;

        /// <summary>
        /// Geschwindigkeit, mit der die Bälle geworfen werden.
        /// </summary>
        public int Geschwindigkeit
        {
            get { return _intSpeed; }
            set
            {
                if (value > 0)
                {
                    _intSpeed = value;
                    timTimer.Interval = TimeSpan.FromMilliseconds(1000 / this.Geschwindigkeit);
                    OnPropertyChanged();
                }
            }
        }

        private int _intStueck;

        /// <summary>
        /// Anzahl der geworfenen Bälle.
        /// </summary>
        public int Stueckzahl
        {
            get { return _intStueck; }
            set
            {
                _intStueck = value;
                OnPropertyChanged();
            }
        }
        public bool IstAmLaufen
        {
            get => timTimer.IsEnabled;
        }

        #endregion

        #region Methoden
        public void Start()
        {
            timTimer.Interval = TimeSpan.FromMilliseconds(1000);
            timTimer.Start();
            //this.IstAmLaufen = true;
            this.Geschwindigkeit = 1;

        }

        public void Stopp()
        {
            timTimer.Stop();
            //this.IstAmLaufen = false;
        }
        #endregion

    }
}
