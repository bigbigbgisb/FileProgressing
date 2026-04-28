using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Document_ChildWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Document_ChildWindow : Window
        
    {
        private string _type;
        //以下为Document变量所需
        private string[] documents;
        private string slnxPath;
        private string saveSlnxPath;
         
        public Document_ChildWindow(string type)
        {
            InitializeComponent();
            _type = type;
            
            if (_type == "document")
            {
                Button1.Content = "选取文件夹作为工作文件夹";
                Button2.Content = "选取多文件作为工作文件";
                Button3.Content = "打开解决方案";
                Button4.Content = "保存为解决方案";

            }
            
            
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (_type == "document")
            {

                var folderDialog = new OpenFolderDialog() { Title="选取文件夹" };
                if (folderDialog.ShowDialog() == true) 
                {
                    await Task.Run(() =>
                    {
                        documents = Directory.GetFiles(folderDialog.FolderName, "*", SearchOption.AllDirectories);
                    });
                    
                }
                if (documents == null) { return; }
                foreach (string file in documents)
                {
                    Debug.WriteLine(file);
                }
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.DocumentShower.Children.Clear();
                mainWindow.SelectedDocumentShower.Children.Clear();

                await Task.Run(() =>
                {
                    foreach (var fileName in documents)
                    {
                        
                        mainWindow.Dispatcher.Invoke(() =>
                        {
                            var bt = new Button { Content = System.IO.Path.GetFileName(fileName), Background = Bg.Background, Height = 50, Width = mainWindow.DocumentShower.Width - 20, Foreground = Button1.Foreground, Margin = new Thickness(10, 10, 10, 0), BorderThickness = new Thickness(0), Tag = new List<string> { fileName, "0" } };
                            bt.Click += mainWindow.SelectedElement;
                            mainWindow.DocumentShower.Children.Add(bt);
                        });
                        
                    }
                });
                

            }
        }

        private async void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (_type == "document")
            {
                documents = [];
                var fileDialog = new OpenFileDialog() { Multiselect=true,Title = "选取文件(可选取多个)"  };
                if (fileDialog.ShowDialog() == true)
                {
                    documents = fileDialog.FileNames;
                }
                foreach (string file in documents) {
                    Debug.WriteLine(file);
                }
                if (documents == null) { return; }
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.DocumentShower.Children.Clear();
                mainWindow.SelectedDocumentShower.Children.Clear();

                await Task.Run(() =>
                {
                    foreach (var fileName in documents)
                    {
                        
                        mainWindow.Dispatcher.Invoke(() =>
                        {
                            var bt = new Button { Content = System.IO.Path.GetFileName(fileName), Background = Bg.Background, Height = 50, Width = mainWindow.DocumentShower.Width - 20, Foreground = Button1.Foreground, Margin = new Thickness(10, 10, 10, 0), BorderThickness = new Thickness(0), Tag = new List<string> { fileName, "0" } };
                            bt.Click += mainWindow.SelectedElement;
                            mainWindow.DocumentShower.Children.Add(bt);
                        });
                        
                    }
                });
                

            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (_type == "document")
            {
                var folderDialog = new OpenFolderDialog() { Title="选取解决方案路径" };
                if (folderDialog.ShowDialog() == true)
                {
                    slnxPath = folderDialog.FolderName;
                }
                Debug.WriteLine(slnxPath);
                //TODO you know get some contetn gang gang gang👍


            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (_type == "document")
            {
                var folderDialog = new OpenFolderDialog() { Title = "选取解决方案保存路径" };
                if (folderDialog.ShowDialog() == true)
                {
                    saveSlnxPath = folderDialog.FolderName;
                }
                Debug.WriteLine(saveSlnxPath);
                string arr = "";
                foreach (var file in documents) 
                {
                    arr += file;
                    arr += " ";
                }
                //TODO dosth you know?

            }
        }
    }
}
