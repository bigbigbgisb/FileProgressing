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
    /// RenameSettings.xaml 的交互逻辑
    /// </summary>
    public partial class RenameSettings : Window

    {
        private string selecetdModel;
        public RenameSettings()
        {
            InitializeComponent();
        }

        private void TN_Click(object sender, RoutedEventArgs e)
        {
            selecetdModel = "TN";
        }

        private void TNI_Click(object sender, RoutedEventArgs e)
        {
            selecetdModel = "TNI";
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (selecetdModel == null)
            {
                MessageBox.Show("请先选择模板或自定义模板", "警告");
                return;
            }
            else
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                if (mainWindow.selectedFiles == null || mainWindow.selectedFiles.Count == 0)
                {
                    MessageBox.Show("请先添加文件至待处理区，请检查?", "警告");
                    return;
                }
                
                if (selecetdModel == "TN")
                {
                    foreach (Border border in mainWindow.SelectedDocumentShower.Children)
                    {
                        var tagList = border.Tag as List<string>;
                        string oldPath = tagList[1];
                        string dir = System.IO.Path.GetDirectoryName(oldPath);
                        string fileName = System.IO.Path.GetFileName(oldPath);
                        string date = File.GetLastWriteTime(oldPath).ToString("yyyyMMdd_HHmmss");
                        string newPath = System.IO.Path.Combine(dir, $"{date}_{fileName}");
                        File.Move(oldPath, newPath);

                    }
                    MessageBox.Show("操作成功!","提示");
                    Close();
                }
                if (selecetdModel == "TNI")
                {
                    
                    int i = 0;
                    foreach (Border border in mainWindow.SelectedDocumentShower.Children)
                    {
                        i++;
                        var tagList = border.Tag as List<string>;
                        string oldPath = tagList[1];
                        string dir = System.IO.Path.GetDirectoryName(oldPath);
                        string fileName = System.IO.Path.GetFileName(oldPath);
                        string date = File.GetLastWriteTime(oldPath).ToString("yyyyMMdd_HHmmss");
                        string newPath = System.IO.Path.Combine(dir, $"{date}_{i}_{fileName}");
                        File.Move(oldPath, newPath);

                    }
                    MessageBox.Show("操作成功!", "提示");
                    Close();
                }
            }
        }
    }
}
