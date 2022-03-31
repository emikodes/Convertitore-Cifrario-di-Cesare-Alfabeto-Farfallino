using System;
using System.Collections.Generic;
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

namespace Farfallino___Cifrario_di_Cesare
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearAllElements()
        {
            plainText_ListBox.Items.Clear();
            cesare_ListBox.Items.Clear();
            farfallino_ListBox.Items.Clear();
        }

        private string Caesar(string textToCypher,int key)
        {
            char[] textEncrypted = textToCypher.ToCharArray();

            for (int i = 0; i < textEncrypted.Length; i++)
            {

                if ((textEncrypted[i] >= 'A') && (textEncrypted[i] <= 'Z'))
                { //if char is upperCase...
                    if ((textEncrypted[i] += (char)key) > 'Z')
                    {
                        textEncrypted[i]=(char)('A'+(textEncrypted[i]-'Z')-1);
                    }
                }
                else if ((textEncrypted[i] >= 'a') && (textEncrypted[i] <= 'z'))
                { //if char is lowerCase
                    if ((textEncrypted[i] += (char)key) > 'z')
                    {
                        textEncrypted[i] = (char)('a' + (textEncrypted[i]-'z')-1);
                    }
                }
                else
                {
                    textEncrypted[i] = '\0';
                }
            }

            return new string(textEncrypted);
        }

        private string Farfallinatore(string textToCypher)
        {
            string setVocali = "aeiouAEIOU";

            foreach(char c in setVocali)
            {
                textToCypher = textToCypher.Replace(Convert.ToString(c), c + (Char.IsUpper(c) ? "F" : "f") + c);
            }

            return textToCypher;
        }

        private void cifra_Button_Click(object sender, RoutedEventArgs e)
        {
            ClearAllElements();
            try
            {
                plainText_ListBox.Items.Add(testoDaCifrare_textBox.Text);
                cesare_ListBox.Items.Add(Caesar(testoDaCifrare_textBox.Text, Convert.ToInt32(Chiave_IntegerUpDown.Value)));
                farfallino_ListBox.Items.Add(Farfallinatore(testoDaCifrare_textBox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while parsing input.");
            }
        }
    }
}
