using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Podometris
{
    public partial class Objectives : PhoneApplicationPage
    {
        public Objectives()
        {
            InitializeComponent();
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
    }
}