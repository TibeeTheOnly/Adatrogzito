using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Adatrogzito
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public ListWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string[] lines = File.ReadAllLines("users.txt");
            NamesListBox.Items.Clear(); // Clear existing items before loading new data
            foreach (string line in lines)
            {
                string name = line.Split(',')[0];
                NamesListBox.Items.Add(name); // Add names to the NamesListBox
            }
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            LoadData(); // Refresh the data when the button is clicked
            NamesListBox_SelectionChanged(null, null);
        }

        private void NamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NamesListBox.SelectedItem != null)
            {
                string selectedName = NamesListBox.SelectedItem.ToString();
                string[] lines = File.ReadAllLines("users.txt");
                foreach (string line in lines)
                {
                    string[] attributes = line.Split(',');
                    if (attributes[0] == selectedName)
                    {
                        NameTextBox.Text = attributes[0];
                        AgeTextBox.Text = attributes[1];
                        TelephoneTextBox.Text = attributes[2];
                        AddressTextBox.Text = attributes[3];
                        EmailTextBox.Text = attributes[4];
                        GenderTextBlock.Text = attributes[5];
                        CommentTextBox.Text = attributes[6];
                        break;
                    }
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void OnDeleteClick(object sender, MouseButtonEventArgs e)
        {
            if (NamesListBox.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Biztos szeretnéd törölni ezt a személyt a nyilvántartásól?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    string selectedName = NamesListBox.SelectedItem.ToString();
                    string[] lines = File.ReadAllLines("users.txt");
                    using (StreamWriter sw = new StreamWriter("users.txt"))
                    {
                        foreach (string line in lines)
                        {
                            string name = line.Split(',')[0];
                            if (name != selectedName)
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                    NamesListBox.Items.Remove(selectedName);
                }
            }
        }
    }
}
