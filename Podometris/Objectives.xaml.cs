using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.IO.IsolatedStorage;
using System.Collections.ObjectModel;

namespace Podometris
{
    public partial class Objectives : PhoneApplicationPage
    {
        private ObservableCollection<Stats> items ;


        public ObservableCollection<Stats> Items
        {
            get { return items; }
            set { items = value; }
        }

        public Objectives()
        {
  
            InitializeComponent();
            Items = new ObservableCollection<Stats>();
            Items = this.Read();
        }

        private ObservableCollection<Stats> Read()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("stats"))
            {
                List<Stats> myList = new List<Stats>();
                myList = (List<Stats>)IsolatedStorageSettings.ApplicationSettings["stats"];
                ObservableCollection<Stats> myObs = new ObservableCollection<Stats>(myList);
                return myObs;
            }
            else
            {
                return new ObservableCollection<Stats>();
            }
        }

        
        private void Write(Stats stats)
        {
            ObservableCollection<Stats> data = this.Read();
            data.Add(stats);

            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings.Remove("stats");
            settings.Add("stats", data.ToList());
            settings.Save();            
        }

        // List of objectives
        private void ApplicationBarIconButton_MainPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        // Quit the application
        private void ApplicationBarIconButton_Exit(object sender, EventArgs e)
        {
            Application.Current.Terminate();
        }


        private  void newAddButton_Click(object sender, RoutedEventArgs e)
        {
            try{
                Stats stat = new Stats() { Km = int.Parse(this.km.Text), Time = this.time.Text, Date = DateTime.Now };
                this.Write(stat);
            }catch(Exception){
              
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.LayoutRoot.DataContext = this;
        }


    }
}