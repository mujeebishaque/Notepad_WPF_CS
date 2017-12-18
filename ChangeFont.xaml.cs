using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Notepad
{
    public partial class ChangeFont : MetroWindow, INotifyPropertyChanged
    {
        public object valueChangeFont;
        private string textFontWin;
        public string TextFontWin
        {
            get { return textFontWin; }
            set { textFontWin = value; OnPropertyChange(); }
        }
        public ChangeFont()
        {
            InitializeComponent();
            fontComboFast.ItemsSource = Fonts.SystemFontFamilies;
            TextFontWin = "Change Your Font using the Combo Box below.";
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(caller)); }
        }
        private void changeFont_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).richtextbox.FontFamily = (FontFamily)fontComboFast.SelectedItem;
            Close();
        }

    }
}
