using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
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
            string savePath = "";
            OpenFolderDialog openFolderDialog = new() { Title="请选择分类好的文件夹存储的位置" };
            if (openFolderDialog.ShowDialog() == true)
            {
                savePath = openFolderDialog.FolderName;
            }

            if (savePath == "")
            {
                MessageBox.Show("请先选择保存路径!", "警告");
                return;
            }
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow.selectedFiles.Count == 0 || mainWindow.selectedFiles.Count == 0)
            {
                MessageBox.Show("请先添加文件至待处理区，请检查?", "警告");
                return;
            }
            if (selectedRules == null)
            {
                MessageBox.Show("请先选择模板，请检查?", "警告");
                return;
            }
            
            foreach(var rule in selectedRules)
            {

                List<string> extenstionList = new();
                if (rule == "image") { extenstionList = new(){".jpg",".png",".jpeg",".webp" }; }
                if (rule == "document") { extenstionList = new() { ".doc", ".docx", ".xlsx", ".pdf", ".txt" }; }
                if (rule == "code") { extenstionList = new() { ".py", ".cs", ".c", ".cpp", ".hpp", ".h", ".html", ".js", ".java", ".kt", ".swift", ".go", ".rs", ".rb", ".php", ".sql", ".json", ".xml", ".lua", ".sh", ".pl", ".xaml" }; }
                if (rule == "zip") { extenstionList = new() { ".zip", ".rar", ".7z" }; }
                if (rule == "video") { extenstionList = new() { ".mp4", ".avi", ".mov", ".mkv", ".flv", ".wmv", ".webm", ".m4v", ".mpg", ".mpeg", ".3gp", ".ogv", ".vob" }; }
                if (rule == "audio")
                {
                    extenstionList = new(){
                        ".mp3", ".wav", ".flac", ".aac", ".ogg", ".m4a", ".wma",
                        ".opus", ".ape", ".aiff"
                    };
                }
                if (rule == "exe")
                {
                    extenstionList = new(){
                        ".exe", ".msi", ".bat", ".cmd", ".com",
                        ".app", ".dmg", ".pkg", ".sh"
                    };
                }

                Directory.CreateDirectory(System.IO.Path.Combine(savePath, rule));
                foreach(var filePath in mainWindow.selectedFiles)
                {
                    foreach(var extenstion in extenstionList)
                    {
                        if (System.IO.Path.GetExtension(filePath).ToLower() == extenstion)
                        {
                            File.Copy(filePath, System.IO.Path.Combine(savePath, rule, System.IO.Path.GetFileName(filePath)));
                            break;
                        }
                    }
                    
                }
                
            }
            MessageBox.Show("操作成功", "提示");
            Close();
        }

        private void Rule_Click(object sender, RoutedEventArgs e)
        {
            string ruleName = (sender as Button).Name.ToLower();
            Button button = sender as Button;
            if (selectedRules.Contains(ruleName)){ selectedRules.Remove(ruleName); button.Background = LightBlack.Background;  }
            else { selectedRules.Add(ruleName);  button.Background = Bg.Background; }
        }

       
    }
}
