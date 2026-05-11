using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace FileProgressing2026
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public List<string> selectedFiles = new();
        public MainWindow()
        {
            InitializeComponent();
            Activated += MainWindow_Activated;

        }
        //






        public void ProgrammersComment()
        {
            //Powered by C#
            //Program by Pan Xuexin
            //print("hello,C#!")
           
        }






        //
        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            foreach (Window w in App.Current.Windows)
            {
                if (w != this && w.IsVisible)
                {
                    w.Close();
                }
            }
        }
        public void SelectedElement(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if ((button.Tag as List<string>)[1] == "0")
            {
                button.Background = Document.Background;

                (button.Tag as List<string>)[1] = "1";

                var selectedElementBlock = new Border { Background = Bg.Background, CornerRadius = new CornerRadius(5), Width = 150, Height = 150, Margin = new Thickness(20, 20, 0, 0), Tag = new List<string>() { (button.Content as string), (((button.Tag as List<string>)[0]) as string) } };
                var stackPanel = new StackPanel();
                stackPanel.Children.Add(new TextBlock() { Height = 50, Width = 130, Text = button.Content as string, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Foreground = Document.Foreground, Margin = new Thickness(20, 20, 0, 0) });
                stackPanel.Children.Add(new TextBlock() { Height = 50, Width = 130, Text = $"文件类型:{System.IO.Path.GetExtension((button.Tag as List<string>)[0])}", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Bottom, Foreground = Document.Foreground, Margin = new Thickness(20, 0, 0, 20) }); ;
                selectedElementBlock.Child = stackPanel;
                SelectedDocumentShower.Children.Add(selectedElementBlock);
                selectedFiles.Add(((button.Tag as List<string>)[0]) as string);

            }
            else
            {
                button.Background = Bg.Background;

                (button.Tag as List<string>)[1] = "0";
                foreach (Border element in SelectedDocumentShower.Children)
                {
                    if ((element.Tag as List<string>)[0] as string == button.Content as string)
                    {
                        SelectedDocumentShower.Children.Remove(element);
                        selectedFiles.Remove(((button.Tag as List<string>)[0]) as string);
                        break;
                    }
                    else
                    {
                        //pass??
                    }
                }

            }


        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); }
            catch { }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Document_Click(object sender, RoutedEventArgs e)
        {
            Document_ChildWindow document_childWindow = new("document");
            document_childWindow.Show();
            document_childWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            document_childWindow.Owner = this;
            Point buttonPos = Document.PointToScreen(new Point(0, 0));
            document_childWindow.Left = buttonPos.X;
            document_childWindow.Top = buttonPos.Y + Document.Height;
            document_childWindow.Show();
            document_childWindow.Focus();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            //以后再写
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            //以后再写
        }


        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (SelectAll.Tag == "0")
            {
                foreach (Button button in DocumentShower.Children)
                {
                    button.Background = Document.Background;

                    (button.Tag as List<string>)[1] = "1";

                    var selectedElementBlock = new Border { Background = Bg.Background, CornerRadius = new CornerRadius(5), Width = 150, Height = 150, Margin = new Thickness(20, 20, 0, 0), Tag = new List<string>() { (button.Content as string), (((button.Tag as List<string>)[0]) as string) } };
                    var stackPanel = new StackPanel();
                    stackPanel.Children.Add(new TextBlock() { Height = 50, Width = 130, Text = button.Content as string, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Foreground = Document.Foreground, Margin = new Thickness(20, 20, 0, 0) });
                    stackPanel.Children.Add(new TextBlock() { Height = 50, Width = 130, Text = $"文件类型:{System.IO.Path.GetExtension((button.Tag as List<string>)[0])}", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Bottom, Foreground = Document.Foreground, Margin = new Thickness(20, 0, 0, 20) }); ;
                    selectedElementBlock.Child = stackPanel;
                    SelectedDocumentShower.Children.Add(selectedElementBlock);
                    (SelectAll).Tag = "1";
                    selectedFiles.Add(((button.Tag as List<string>)[0]) as string);
                    SelectAll.Background = Brushes.White;
                    SelectAll.Content = "✔";
                    
                }
            }
            else
            {
                foreach (Button button in DocumentShower.Children)
                {
                    button.Background = Bg.Background;

                    (button.Tag as List<string>)[1] = "0";
                    SelectedDocumentShower.Children.Clear();
                    (SelectAll).Tag = "0";
                    selectedFiles.Remove(((button.Tag as List<string>)[0]) as string);
                }
                SelectAll.Background = Bg.Background;
                SelectAll.Content = "";
            }

        }

        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            RenameSettings renameSettings = new();
            renameSettings.Show();
        }

        private void ModifyExtension_Click(object sender, RoutedEventArgs e)
        {
            ModifyExtension modifyExtension = new();
            modifyExtension.Show();
        }

        private void Concat_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new() { FileName=$"FileProgressing{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}合并文本.txt",DefaultExt="txt",Filter="文本文件(*.txt) | *.txt",Title="选择保存路径"};
            string savePath = "";
            if (saveFileDialog.ShowDialog() == true)
            {
                savePath = saveFileDialog.FileName;
            }
            if (savePath == "")
            {
                MessageBox.Show("请先选择保存路径!", "警告");
                return;
            }
            string contents = "";
            string skipFile = "";
            foreach (Border border in SelectedDocumentShower.Children)
            {

                var tag = border.Tag as List<string>;
                var path = tag[1];
                if (System.IO.Path.GetExtension(path) != ".txt") { skipFile += (System.IO.Path.GetFileName(path) + " "); return; }
                var content = File.ReadAllText(path);
                contents += content;
            }
            File.WriteAllText(savePath, contents);
            MessageBox.Show($"操作成功 跳过文件{skipFile.Split(" ").Length - 1}个:\n{skipFile}\n共{SelectedDocumentShower.Children.Count}个", "提示");
        }

        private void Orangnize_Click(object sender, RoutedEventArgs e)
        {
            Orangnize orangnize = new();
            orangnize.Show();
        }

        private void Replacewords_Click(object sender, RoutedEventArgs e)
        {
            Replacewords replacewords = new();
            replacewords.Show();
        }
    }
}