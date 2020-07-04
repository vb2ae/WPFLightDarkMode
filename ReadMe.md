 # WPF Light or Dark Mode
 
 Windows 10 has a Light and Dark mode you can set.  If you want to have your application respond to these settings you can start by adding the NuGet package Microsoft.Windows.SDK.Contracts
 
 
![NuGet](/images/NuGetWindowsSdkContracts.png)

Lets create a simple View Model which returns a title and the brushes to display the data in the right color.

First lets get the Colors to use for the brushes

            UISettings settings = new UISettings();
            var foreground = settings.GetColorValue(UIColorType.Foreground);
            var background = settings.GetColorValue(UIColorType.Background);

Now we can create the brushes to use

            Color myforeColor = Color.FromArgb(foreground.A, foreground.R, foreground.G, foreground.B);
            ForeBrush = new SolidColorBrush(myforeColor);

            Color mybackColor = Color.FromArgb(background.A, background.R, background.G, background.B);
            BackBrush=new SolidColorBrush(mybackColor);
            
Here is the whole View Model

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
        
When you run the app with windows in Light mode it looks like this

![Light Mode](/images/WPFLIGHT.png)

Dark mode looks like this

![Dark Mode](/images/WPFDark.png)

An alternate method to do this is to look in the registry

HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize\AppsUseLightTheme.  In the value of the key is 1 Windows 10 is in Light mode.


Depending on the value in the registry you would have to set the brush colors.
