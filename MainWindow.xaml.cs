using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            outputTextBox.Text = Tokenizer.Tokenize("4.9+8").Count.ToString();
            foreach (Token t in Tokenizer.Tokenize("4.9*a+(z*3)^2"))
            {
                Debug.WriteLine(t.Text + " : " + t.type);
            }

            var tokens = Tokenizer.Tokenize("4.9*a+(z*3)^2");
            var parser = new Parser(tokens);
            var expression = parser.Parse();
            var variables = new Dictionary<string, double> { { "a", 2 }, { "z", 3 } };
            double result = expression.Evaluate(variables);
            Debug.WriteLine($"Das Ergebnis ist: {result}");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string input = button.Content.ToString();
            outputTextBox.Text += input;
        }

        private void butCalc_Click(object sender, RoutedEventArgs e)
        {
            string input = outputTextBox.Text;
            var tokens = Tokenizer.Tokenize(input);
            var parser = new Parser(tokens);
            var expression = parser.Parse();
            //the parameter which are necessary for Evaluate are asked by a dialog and then passed to the method
            
            //get all variables (letters) from input in list
            List<string> variables = new List<string>();
            foreach (Token t in tokens)
            {
                if (t.type == Token.Type.Variable)
                {
                    variables.Add(t.Text);
                }
            }
            // ask for values of variables
            Dictionary<string, double> values = new Dictionary<string, double>();

            foreach (string s in variables)
            {
                //inputbox should be displayed in the middle of the screen
                string value = Microsoft.VisualBasic.Interaction.InputBox
                    ("Please enter a value for " + s, 
                    "Value for " + s, "0", (int)SystemParameters.PrimaryScreenWidth / 2, 
                    (int)SystemParameters.PrimaryScreenHeight / 2);
                values.Add(s, double.Parse(value));
            }
            var result = expression.Evaluate(values);

            //Output result in textbox
            outputTextBox.Text = result.ToString();
        }
    }
}
