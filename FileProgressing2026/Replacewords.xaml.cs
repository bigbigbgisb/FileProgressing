using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Replacewords.xaml 的交互逻辑
    /// </summary>
    
    public partial class Replacewords : Window
    {
        public bool isFirstFocusOnOriWord = true;
        public bool isFirstFocusOnAftWord = true;
        public Replacewords()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(OriWord.Text,AftWord.Text);
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow.selectedFiles == null || mainWindow.selectedFiles.Count == 0)
            {
                MessageBox.Show("请先选择文件,检查是否放入待选区?","警告");
                return;
            }
            if (string.IsNullOrEmpty(OriWord.Text) || string.IsNullOrEmpty(AftWord.Text))
            {
                MessageBox.Show("请确认您填写完毕转换前后内容!","警告");
                return;
            }
            string skipFile = "";
            foreach (var path in mainWindow.selectedFiles)
            {
                if (System.IO.Path.GetExtension(path) != ".txt") { skipFile += (System.IO.Path.GetFileName(path) + " "); return; }
                string content = File.ReadAllText(path);
                string newContent;
                if (IsAllowRegex.IsChecked == true) 
                {
                    MessageBox.Show("请确保您会使用正则表达式,否则可能会对您的文件造成不必要的损害", "提示");
                    newContent = Regex.Replace(content,OriWord.Text,AftWord.Text);
                }
                else
                {
                    newContent = Regex.Replace(content, OriWord.Text, AftWord.Text);
                }
                File.WriteAllText(path, newContent);
                
            }
            MessageBox.Show($"操作成功 跳过文件{skipFile.Split(" ").Length - 1}个:\n{skipFile}\n共{mainWindow.selectedFiles.Count}个", "提示");


        }

        private void OriWord_GotFocus(object sender, RoutedEventArgs e)
        {
            if (isFirstFocusOnOriWord)
            {
                OriWord.Text = "";
                isFirstFocusOnOriWord = false;
            }
            
        }

        private void AftWord_GotFocus(object sender, RoutedEventArgs e)
        {
            if (isFirstFocusOnAftWord)
            {
                AftWord.Text = "";
                isFirstFocusOnAftWord = false;
            }
                
        }
    }
}
