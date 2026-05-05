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
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (selectedExtension == null)
            {
                MessageBox.Show("请先选择要转换为的文件后缀", "警告");
                return;
            }
            if (mainWindow.selectedFiles == null || mainWindow.selectedFiles.Count == 0)
            {
                MessageBox.Show("请先添加文件至待处理区，请检查?", "警告");
                return;
            }
            else
            {
                
                if (mainWindow.SelectedDocumentShower.Children == null) { return; }
                foreach (Border border in mainWindow.SelectedDocumentShower.Children)
                {
                    List<string> tag = border.Tag as List<string>;
                    string oldPath = tag[1];
                    string dir = System.IO.Path.GetDirectoryName(oldPath);
                    string newPath = System.IO.Path.Combine(dir, $"{System.IO.Path.GetFileNameWithoutExtension(oldPath)}.{selectedExtension}");
                    File.Move(oldPath, newPath);
                }
                MessageBox.Show("操作成功!", "提示");
                Close();
            }
        }
        private void Extenstion_Click(object sender, RoutedEventArgs e)
        {
            string extensionName = (sender as Button).Name.ToLower();
            selectedExtension = extensionName;
        }

    }
}
