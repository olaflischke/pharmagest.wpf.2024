using EierfarmBl;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace EierfarmMvvmUi;

public class MainWindowViewModel : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    public MainWindowViewModel()
    {
        this.FuetternCommand = new RelayCommand(p => CanFuettern(), a => Fuettern());
        this.EiLegenCommand = new RelayCommand(p => CanEiLegen(), a => EiLegen());

        this.NeueGansCommand = new RelayCommand(p => true, a => NeueGans());
        this.NeuesHuhnCommand = new RelayCommand(p => CanNeuesHuhn(), a => NeuesHuhn());
        this.NeuesSchnabeltierCommand = new RelayCommand(p => CanNeuesSchnabeltier(), a => NeuesSchnabeltier());
    }


    private void NeuesSchnabeltier()
    {
        Schnabeltier tier = new Schnabeltier();

        this.Tiere.Add(tier);
        this.SelectedTier = tier;
    }

    private bool CanNeuesSchnabeltier() => true;

    private void NeuesHuhn()
    {
        Huhn huhn = new Huhn();

        this.Tiere.Add(huhn);
        this.SelectedTier = huhn;
    }

    private bool CanNeuesHuhn()
    {
        return true;
    }

    private void NeueGans()
    {
        Gans gans = new Gans();

        this.Tiere.Add(gans);
        this.SelectedTier = gans;
    }

    private bool CanNeueGans()
    {
        return true;
    }

    private void EiLegen()
    {
        this.SelectedTier?.EiLegen();
    }

    private bool CanEiLegen()
    {
        return this.SelectedTier != null;
    }

    private void Fuettern()
    {
        this.SelectedTier?.Fressen();
    }

    private bool CanFuettern()
    {
        return this.SelectedTier != null;
    }

    public ObservableCollection<IEiLeger> Tiere { get; set; } = new ObservableCollection<IEiLeger>();

    private IEiLeger? selectedTier = null;

    public IEiLeger? SelectedTier
    {
        get
        {
            return selectedTier;
        }
        set
        {
            selectedTier = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand FuetternCommand { get; set; }
    public RelayCommand EiLegenCommand { get; set; }
    public RelayCommand NeueGansCommand { get; set; }
    public RelayCommand NeuesHuhnCommand { get; set; }
    public RelayCommand NeuesSchnabeltierCommand { get; set; }
}
