using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MoreAboutUs.xaml
    /// </summary>
    public partial class MoreAboutUs : MetroWindow, INotifyPropertyChanged
    {

        private string details;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        public string Details
        {
            get { return details; }
            set { details = value; OnPropertyChange(); }
        }

        public MoreAboutUs()
        {
            InitializeComponent();
            Details = "This software is licensed under MIT License. It's provided as is. The Name's Mujeeb Ishaq aged 21. I am programmer from Lahore, Pakistan. Contact Me at nhawk1100@gmail.com";
            DataContext = this;
        }
    }
}

