using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using Windows.ApplicationModel.Appointments.DataProvider;
using Windows.UI.ViewManagement;
using Windows.UI.WebUI;

namespace WpfLightAndDarkMode.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public MainViewModel()
        {
            UISettings settings = new UISettings();
            var foreground = settings.GetColorValue(UIColorType.Foreground);
            var background = settings.GetColorValue(UIColorType.Background);
            Color myforeColor = Color.FromArgb(foreground.A, foreground.R, foreground.G, foreground.B);
            ForeBrush = new SolidColorBrush(myforeColor);

            Color mybackColor = Color.FromArgb(background.A, background.R, background.G, background.B);
            BackBrush=new SolidColorBrush(mybackColor);
            Title = "Welcome to WPF";
        }

        private SolidColorBrush foreBrush = new SolidColorBrush(Colors.Black);
        public SolidColorBrush ForeBrush
        {
            get
            {
                return foreBrush;
            }
            set
            {
                foreBrush = value;
                NotifyPropertyChanged();
            }
        }


        private SolidColorBrush backBrush = new SolidColorBrush(Colors.White);
        public SolidColorBrush BackBrush
        {
            get
            {
                return backBrush;
            }
            set
            {
                backBrush = value;
                NotifyPropertyChanged();
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyPropertyChanged();
            }
        }

    }
}
