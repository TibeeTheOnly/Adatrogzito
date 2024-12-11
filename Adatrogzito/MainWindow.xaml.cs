using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Adatrogzito
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            int age = int.Parse(AgeTextBox.Text);
            string phoneNumber = TelephoneTextBox.Text;
            string address = AddressTextBox.Text;
            string email = EmailTextBox.Text;
            string gender = GenderComboBox.Text;
            string comment = CommentTextBox.Text;

            User user = new User(name, age, phoneNumber, address, email, gender, comment);
            using (StreamWriter sw = new StreamWriter("users.txt", true))
            {
                sw.WriteLine(user.ToString());
            }

            MessageBox.Show("Sikeres regisztráció", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
            ListWindow listWindow = new ListWindow();
            listWindow.Show();
            this.Close();
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            foreach (char c in phoneNumber)
            {
                if(!char.IsDigit(c) || c == '+')
                {
                    return false;
                }
            }
            return true;
        }

        private void InputFields_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isAgeValid = int.TryParse(AgeTextBox.Text, out int age);
            bool isComboBoxSelected = GenderComboBox.SelectedItem != null;

            if (NameTextBox.Text.Length > 3 && age > 0 &&
                isAgeValid && TelephoneTextBox.Text.Length > 8 &&
                AddressTextBox.Text.Length > 0 && isComboBoxSelected && IsPhoneNumberValid(TelephoneTextBox.Text))
            {
                RegisterButton.IsEnabled = true;
            }
            else
            {
                RegisterButton.IsEnabled = false;
            }
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            ListWindow listWindow = new ListWindow();
            listWindow.Show();
            this.Close();
        }

        private void InputFields_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isAgeValid = int.TryParse(AgeTextBox.Text, out int age);
            bool isComboBoxSelected = GenderComboBox.SelectedItem != null;

            if (NameTextBox.Text.Length > 3 && age > 0 &&
                isAgeValid && TelephoneTextBox.Text.Length >= 8 &&
                AddressTextBox.Text.Length > 0 && isComboBoxSelected && IsPhoneNumberValid(TelephoneTextBox.Text))
            {
                RegisterButton.IsEnabled = true;
            }
            else
            {
                RegisterButton.IsEnabled = false;
            }
        }
    }
}