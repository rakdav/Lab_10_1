using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_10_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MotoCycle motoCycle;
        public MainWindow()
        {
            InitializeComponent();
            motoCycle = new MotoCycle();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == false) return;
            ReadAsync(openFileDialog.FileName);
        }
        private async void ReadAsync(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                int i = 1;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    switch(i)
                    {
                        case 1:motoCycle.Marka = line; break;
                        case 2: motoCycle.Color = line; break;
                        case 3: motoCycle.SerialNumber = int.Parse(line); break;
                        case 4: motoCycle.RegNumber = line; break;
                        case 5: motoCycle.Year =int.Parse(line); break;
                        case 6: motoCycle.YearTech = int.Parse(line); break;
                        case 7: motoCycle.Price =decimal.Parse(line); break;
                    }
                    i++;
                }
                TextInput.Text = motoCycle.ToString();
            }
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == false) return;
            SaveAsync(saveFileDialog.FileName);
        }
        private async void SaveAsync(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                await writer.WriteLineAsync(TextInput.Text);
            }
        }
    }
}
