using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Documents;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml    
    /// </summary>
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
            //TextRange range;
            //range = new TextRange(richtextbox.Document.ContentStart, richtextbox.Document.ContentEnd);
            //string text = range.Text;

            if (saveFileDialog.ShowDialog() == true)
            {
                //  File.WriteAllText(saveFileDialog.FileName, text);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) { /* cut */ richtextbox.Cut(); }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) { /*copy*/ richtextbox.Copy(); }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e) { /*paste*/ richtextbox.Paste(); }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e) { /* Exit */ Application.Current.Shutdown(); }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {   /* open */
            var openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text Files(*.txt)|*.txt";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            //TextRange range;
            //range = new TextRange(richtextbox.Document.ContentStart, richtextbox.Document.ContentEnd);
            //string text = range.Text;


            if (openFileDialog.ShowDialog() == true)
            {
                //  richtextbox.Document.Blocks.Clear();
            }

        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {   /*AboutMe Notepad*/
            var aboutWindow = new MoreAboutUs();
            aboutWindow.Show();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            /*font size
            TextRange allText = new TextRange(richtextbox.Document.ContentStart, richtextbox.Document.ContentEnd);
            allText.ApplyPropertyValue(RichTextBox.FontSizeProperty, FontSize += 1);
            */
        }

        private void ChangeFont_Click(object sender, RoutedEventArgs e)
        {
            var changeFontWindow = new ChangeFont();
            changeFontWindow.Show();
        }
    }
}
