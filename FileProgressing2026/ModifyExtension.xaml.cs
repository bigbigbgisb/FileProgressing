using System;
using System.Collections.Generic;
using System.IO;
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
    /// ModifyExtension.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyExtension : Window
    {
        private string selectedExtension;
        public ModifyExtension()
        {
            InitializeComponent();

        }


        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (selectedExtension == null)
            {
                MessageBox.Show("请先选择要转换为的文件后缀", "警告");
                return;
            }
            else
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                if (mainWindow.SelectedDocumentShower.Children == null) { return; }
                foreach (Border border in mainWindow.SelectedDocumentShower.Children)
                {
                    List<string> tag = border.Tag as List<string>;
                    string oldPath = tag[1];
                    string dir = System.IO.Path.GetDirectoryName(oldPath);
                    string newPath = System.IO.Path.Combine(dir, $"{System.IO.Path.GetFileNameWithoutExtension(oldPath)}{selectedExtension}");
                    File.Move(oldPath, newPath);
                }
                MessageBox.Show("操作成功!","提示");
                Close();
            }
        }

        private void Md_Click(object sender, RoutedEventArgs e)
        {
            selectedExtension = ".md";
        }

        private void Txt_Click(object sender, RoutedEventArgs e)
        {
            selectedExtension = ".txt";
        }

        private void Cs_Click(object sender, RoutedEventArgs e)
        {
            selectedExtension = ".cs";
        }

        private void Py_Click(object sender, RoutedEventArgs e)
        {
            selectedExtension = ".py";
        }


        private void C_Click(object sender, RoutedEventArgs e)
        {
            selectedExtension = ".c";
        }

        private void H_Click(object sender, RoutedEventArgs e)
        {
            selectedExtension = ".h";
        }

        private void Cpp_Click(object sender, RoutedEventArgs e)
        {
            selectedExtension = ".cpp";
        }

        private void Hpp_Click(object sender, RoutedEventArgs e)
        {
            selectedExtension = ".hpp";
        }
    }
}
