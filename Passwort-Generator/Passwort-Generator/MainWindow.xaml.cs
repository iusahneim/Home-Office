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

namespace Passwort_Generator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string special = "@%+\\/'!#$^?:,(){}[]~´-_.";
        string lowercase = "abcdefghijklmnopqrstuvwxyz";
        string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "0123456789";
        string all = "";

        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            all = special + lowercase + uppercase + numbers;
        }

        string getPassword(int length, int lowercaseAmount = 0, int uppercaseAmount = 0, int specialAmount = 0, int numbersAmount = 0)
        {
            string password = "";

            //add random characters to password
            for(int i = 0; i < lowercaseAmount; i++)
                password += lowercase[random.Next(lowercase.Length)];
            for (int i = 0; i < uppercaseAmount; i++)
                password += uppercase[random.Next(uppercase.Length)];
            for (int i = 0; i < specialAmount; i++)
                password += special[random.Next(special.Length)];
            for (int i = 0; i < numbersAmount; i++)
                password += numbers[random.Next(numbers.Length)];

            for(int i = password.Length; i < length; i++)
            {
                password += all[random.Next(all.Length)];
            }

            //randomize order of characters in password
            char[] tempArr = password.ToArray();
            Shuffle<char>(tempArr);
            password = new string(tempArr);

            return password;
        }

        public void Shuffle<T>(T[] array)
        {
            var random = new Random();
            for (int x = 0; x < 100; x++)
            {
                for (int i = array.Length; i > 1; i--)
                {
                    // Pick random element to swap.
                    int j = random.Next(i); // 0 <= j <= i-1
                                            // Swap.
                    T tmp = array[j];
                    array[j] = array[i - 1];
                    array[i - 1] = tmp;
                }
            }
        }

        private void btnPasswort_Click(object sender, RoutedEventArgs e)
        {
            textBoxPwd.Text = getPassword((int)upDownLength.Value, (int)upDownLower.Value, (int)upDownUpper.Value, (int)upDownSpecial.Value, (int)upDownNumber.Value);
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textBoxPwd.Text);
        }
    }
}
