using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB2WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsClicked = true;
        bool isFirstOperation = true;
        string operation;
        bool isOperationInp = false;
        Calculator calculator = new Calculator();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddColumn_Click_1(object sender, RoutedEventArgs e)
        {
            if (IsClicked)
            {
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.SetColumn(pi, 4);
                Grid.SetRow(pi, 2);
                pi.Visibility = Visibility.Visible;

                Grid.SetColumn(exp, 4);
                Grid.SetRow(exp, 3);
                exp.Visibility = Visibility.Visible;

                Grid.SetColumn(sqrt, 4);
                Grid.SetRow(sqrt, 4);
                sqrt.Visibility = Visibility.Visible;

                Grid.SetColumn(pow, 4);
                Grid.SetRow(pow, 5);
                pow.Visibility = Visibility.Visible;

                Grid.SetColumn(ln, 4);
                Grid.SetRow(ln, 6);
                ln.Visibility = Visibility.Visible;

                Text.SetValue(Grid.ColumnSpanProperty,MainGrid.ColumnDefinitions.Count);

                IsClicked = false;
            }
            else 
            {
                MainGrid.ColumnDefinitions.RemoveAt(MainGrid.ColumnDefinitions.Count - 1);
                pi.Visibility = Visibility.Collapsed;
                exp.Visibility = Visibility.Collapsed;
                sqrt.Visibility = Visibility.Collapsed;
                pow.Visibility = Visibility.Collapsed;
                ln.Visibility = Visibility.Collapsed;
                Text.SetValue(Grid.ColumnSpanProperty, MainGrid.ColumnDefinitions.Count);
                IsClicked = true; 
            }
        }

        private double GetOperand(string text)
        {
            try
            {
                return double.Parse(text);
            }
            catch
            {
                switch (text)
                {
                    case "pi": return Math.PI;
                    case "e": return Math.E;
                }
            }
            return 0;
        }
        private void Result(object sender, RoutedEventArgs e)
        {
            try
            {
                double operand = GetOperand(Text.Text);
                switch (operation)
                {
                    case "+": calculator.Add(operand); break;
                    case "-": calculator.Sub(operand); break;
                    case "*": calculator.Mul(operand); break;
                    case "/": calculator.Div(operand); break;
                    case "n^x": calculator.Power(operand); break;
                    case "ln": calculator.Ln(operand); break;
                    case "sqrt": calculator.Sqrt(operand); break;
                }
                //Text.Text = calculator.GetValue.ToString();
                double res = calculator.GetValue;
                if ((Math.Abs(res) > 1e6 || Math.Abs(res) < 1e-6) && res != 0) Text.Text = res.ToString("0.0E0");
                else Text.Text = Math.Round(res, 6).ToString();
            }
            catch
            {
                Text.Text = string.Empty;
            }
        }
        private void InputByKeyBoard(object sender,KeyEventArgs e)
        {
            try
            {
                switch (e.Key)
                {
                    case Key.NumPad0: DisplayData("0"); break;
                    case Key.NumPad1: DisplayData("1"); break;
                    case Key.NumPad2: DisplayData("2"); break;
                    case Key.NumPad3: DisplayData("3"); break;
                    case Key.NumPad4: DisplayData("4"); break;
                    case Key.NumPad5: DisplayData("5"); break;
                    case Key.NumPad6: DisplayData("6"); break;
                    case Key.NumPad7: DisplayData("7"); break;
                    case Key.NumPad8: DisplayData("8"); break;
                    case Key.NumPad9: DisplayData("9"); break;
                    case Key.P: DisplayData("p"); break;
                    case Key.I: DisplayData("i"); break;
                    case Key.E: DisplayData("e"); break;
                    case Key.Back: Remove(sender, e); break;
                    case Key.Decimal: InputPoint(sender, e); break;
                }
            }
            catch
            {
                Text.Text = string.Empty;
            }
        }

        private void InputData(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DisplayData(button.Content.ToString());
        }

        private void DisplayData(string data)
        {
            if (Text.Text == "0" || isOperationInp) { Text.Text = string.Empty; isOperationInp = false; }
            Text.Text += data;
        }

        private void InputOperation(object sender, RoutedEventArgs e)
        {
            if (isFirstOperation) { calculator.Add(GetOperand(Text.Text)); isFirstOperation = false; }
            Button button = (Button)sender;
            operation = button.Content.ToString();
            isOperationInp = true;
        }

        private void Ln(object sender, RoutedEventArgs e)
        {
            operation = "ln";
            isFirstOperation = false;
            isOperationInp = true;
        }
        private void Undo(object sender, RoutedEventArgs e)
        {
            try
            {
                double res = calculator.Undo();
                if ((res > 1e6 || res < 1e-6)&&res!=0) Text.Text = res.ToString("0.0E0");
                else Text.Text = Math.Round(res,6).ToString();
            }
            catch
            {
                Text.Text = "0";
                isFirstOperation = true;
            }
        }

        private void Redo(object sender, RoutedEventArgs e)
        {
            calculator.Redo();
            Text.Text = calculator.GetValue.ToString();
        }

        private void InputPoint(object sender, RoutedEventArgs e)
        {
            Text.Text += ",";
        }

        private void CButton(object sender, RoutedEventArgs e)
        {
            isFirstOperation = true;
            Text.Text = "0";
            calculator = new Calculator();
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            try
            {
                Text.Text = Text.Text.Remove(Text.Text.Length - 1);
            }
            catch
            {
                Text.Text= "0";
            }
        }
    }
}
