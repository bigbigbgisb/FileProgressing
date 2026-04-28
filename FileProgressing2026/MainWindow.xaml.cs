using MaterialDesignThemes.Wpf;
using System.IO;
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

        public MainWindow()
        {
            InitializeComponent();
            Activated += MainWindow_Activated;

        }
        //






        public void ProgrammersComment()
        {
            //Powered by C#
            //Program by J
            //print("hello,C#!")
            void print(string text) { Console.WriteLine(text); }
            print("What??Haha.In fact I set this method to public,so you have a small chance to see this,you are a good programmer bro👍");
            
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
                        break;
                    }
                    else
                    {
                        //pass
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
            Document_ChildWindow document_childWindow = new("help");
            document_childWindow.Show();
            document_childWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            document_childWindow.Owner = this;
            Point buttonPos = Help.PointToScreen(new Point(0, 0));
            document_childWindow.Left = buttonPos.X;
            document_childWindow.Top = buttonPos.Y + Document.Height;
            document_childWindow.Show();
            document_childWindow.Focus();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Document_ChildWindow document_childWindow = new("settings");
            document_childWindow.Show();
            document_childWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            document_childWindow.Owner = this;
            Point buttonPos = Settings.PointToScreen(new Point(0, 0));
            document_childWindow.Left = buttonPos.X;
            document_childWindow.Top = buttonPos.Y + Document.Height;
            document_childWindow.Show();
            document_childWindow.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Document_ChildWindow document_childWindow = new("edit");
            document_childWindow.Show();
            document_childWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            document_childWindow.Owner = this;
            Point buttonPos = Edit.PointToScreen(new Point(0, 0));
            document_childWindow.Left = buttonPos.X;
            document_childWindow.Top = buttonPos.Y + Document.Height;
            document_childWindow.Show();
            document_childWindow.Focus();
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Tag == "0")
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
                    (sender as Button).Tag = "1";
                }
            }
            else
            {
                foreach (Button button in DocumentShower.Children)
                {
                    button.Background = Bg.Background;

                    (button.Tag as List<string>)[1] = "0";
                    SelectedDocumentShower.Children.Clear();
                    (sender as Button).Tag = "0";
                }
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

    }
}