using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace Notepad
{
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            richtextbox.SetValue(Paragraph.LineHeightProperty, 1.0);
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Method to save stuff in your text editor
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                richtextbox.Save(saveFileDialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) { /* cut */ richtextbox.Cut(); }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) { /*copy*/ richtextbox.Copy(); }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e) { /*paste*/ richtextbox.Paste(); }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e) { /* Exit */ Application.Current.Shutdown(); }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {   /* open */

            var openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == true)
            {
                richtextbox.Text = File.ReadAllText(openFileDialog.FileName);
            }

        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {   /*AboutMe Notepad*/
            var aboutWindow = new MoreAboutUs();
            aboutWindow.Show();
        }

        private void ChangeFont_Click(object sender, RoutedEventArgs e)
        {
            var changeFontWindow = new ChangeFont();
            changeFontWindow.Show();
        }

        private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e) { MenuItem_Click(sender, e); }

        private void cSharp_Click(object sender, RoutedEventArgs e)
        {
            richtextbox.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C#");
        }

        private void php_Click(object sender, RoutedEventArgs e)
        {
            richtextbox.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("PHP");
        }

        private void cpp_Click(object sender, RoutedEventArgs e)
        {
            richtextbox.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C++");
        }

        private void compileAndRun_Click(object sender, RoutedEventArgs e)
        {
            var fileSystem = new FileSystem();
        }
        private void IncreaseFontSize_Click_1(object sender, RoutedEventArgs e)
        {
            richtextbox.FontSize += 1;
        }

        private void DecreaseFontSize_Click(object sender, RoutedEventArgs e)
        {
            richtextbox.FontSize -= 1;
        }
    }
}
