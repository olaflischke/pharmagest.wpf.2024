using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfUserControlDemo;

/// <summary>
/// Interaction logic for NumericUpDown.xaml
/// </summary>
public partial class NumericUpDown : UserControl
{
    private Regex _numMatch = new Regex(@"^-?\d+$");

    public NumericUpDown()
    {
        InitializeComponent();

        this.Minimum = 0;
        this.Maximum = 100;

        txtValue.Text = "0";
    }

    private void txtValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var tb = (TextBox)sender;
        var text = tb.Text.Insert(tb.CaretIndex, e.Text);

        e.Handled = !_numMatch.IsMatch(text);
    }

    private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tb = (TextBox)sender;
        if (!_numMatch.IsMatch(tb.Text)) ResetText(tb);
        Value = Convert.ToInt32(tb.Text);
        if (Value < Minimum) Value = Minimum;
        if (Value > Maximum) Value = Maximum;

        RaiseEvent(new RoutedEventArgs(ValueChangedEvent));
    }

    private void tvtValue_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.IsDown && e.Key == Key.Up && Value < Maximum)
        {
            Value++;
            RaiseEvent(new RoutedEventArgs(ValueIncreasedEvent));
        }
        else if (e.IsDown && e.Key == Key.Down && Value > Minimum)
        {
            Value--;
            RaiseEvent(new RoutedEventArgs(ValueDecreasedEvent));
        }
    }



    private void btnDown_Click(object sender, RoutedEventArgs e)
    {
        if (Value > Minimum)
        {
            Value--;
            RaiseEvent(new RoutedEventArgs(ValueDecreasedEvent));
        }
    }

    private void btnUp_Click(object sender, RoutedEventArgs e)
    {
        if (Value < Maximum)
        {
            Value++;
            RaiseEvent(new RoutedEventArgs(ValueIncreasedEvent));
        }
    }

    #region Routed Events
    public event RoutedEventHandler ValueChanged
    {
        add { AddHandler(ValueChangedEvent, value); }
        remove { RemoveHandler(ValueChangedEvent, value); }
    }

    private static readonly RoutedEvent ValueChangedEvent =
                                            EventManager.RegisterRoutedEvent("ValueChanged",
                                                RoutingStrategy.Bubble,
                                                typeof(RoutedEventHandler),
                                                typeof(NumericUpDown));

    public event RoutedEventHandler ValueIncreased
    {
        add { AddHandler(ValueIncreasedEvent, value); }
        remove { RemoveHandler(ValueIncreasedEvent, value); }
    }

    private static readonly RoutedEvent ValueIncreasedEvent = EventManager.RegisterRoutedEvent("IncreaseClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));

    public event RoutedEventHandler ValueDecreased
    {
        add { AddHandler(ValueDecreasedEvent, value); }
        remove { RemoveHandler(ValueDecreasedEvent, value); }
    }

    private static readonly RoutedEvent ValueDecreasedEvent = EventManager.RegisterRoutedEvent("DecreaseClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));


    #endregion

    #region DependencyProperties

    public int Value
    {
        get { return (int)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0, OnPropertyChanged));




    public int Minimum
    {
        get { return (int)GetValue(MinimumProperty); }
        set { SetValue(MinimumProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MinimumProperty =
        DependencyProperty.Register("Minimum", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));



    public int Maximum
    {
        get { return (int)GetValue(MaximumProperty); }
        set { SetValue(MaximumProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MaximumProperty =
        DependencyProperty.Register("Maximum", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));





    private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        NumericUpDown numericUpDown = d as NumericUpDown;
        numericUpDown.txtValue.Text = e.NewValue.ToString();
    }


    #endregion    

    private void ResetText(TextBox textBox)
    {
        textBox.Text = 0 < Minimum ? Minimum.ToString() : "0";
        textBox.SelectAll();
    }

}
