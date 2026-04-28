using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FileProgressing2026
{
    /// <summary>
    /// Orangnize.xaml 的交互逻辑
    /// </summary>
    public partial class Orangnize : Window
    {
        private List<string> selectedRules = new();
        public Orangnize()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRules.Contains("image")) { selectedRules.Remove("image"); Image.Background = LightBlack.Background;  }
            else { selectedRules.Add("image");  Image.Background = Bg.Background; }
        }

        private void Document_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRules.Contains("document")) { selectedRules.Remove("document"); Document.Background = LightBlack.Background; }
            else { selectedRules.Add("document");  Document.Background = Bg.Background; }
        }

        private void Code_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRules.Contains("code")) { selectedRules.Remove("code"); Code.Background = LightBlack.Background; }
            else { selectedRules.Add("code"); Code.Background = Bg.Background; }
        }

        private void Zip_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRules.Contains("zip")) { selectedRules.Remove("zip"); Zip.Background = LightBlack.Background;  }
            else { selectedRules.Add("zip");  Zip.Background = Bg.Background; }
        }
    }
}
