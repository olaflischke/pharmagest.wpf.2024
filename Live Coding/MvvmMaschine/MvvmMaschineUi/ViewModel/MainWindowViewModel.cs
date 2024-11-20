using MVVMMaschine;

namespace MvvmMaschineUi.ViewModel;

public class MainWindowViewModel
{
    public MainWindowViewModel()
    {
        this.Maschine = new TennisballWurfmaschine();

        this.StartCommand = new RelayCommand(p => CanStarten(), a => Starten());
        this.StoppCommand = new RelayCommand(p => CanStoppen(), a => Stoppen());
    }

    private bool CanStoppen()
    {
        return this.Maschine.IstAmLaufen;
    }

    private void Stoppen()
    {
        this.Maschine.Stopp();
    }

    private bool CanStarten()
    {
        return !this.Maschine.IstAmLaufen;
    }

    private void Starten()
    {
        this.Maschine.Start();
    }

    // Model
    public TennisballWurfmaschine Maschine { get; set; }

    // Commands
    public RelayCommand StartCommand { get; set; }
    public RelayCommand StoppCommand { get; set; }
}
