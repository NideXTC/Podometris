﻿#pragma checksum "C:\Users\Alexis DUCERF\Documents\Visual Studio 2013\Projects\Podometris\Podometris\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "74F5C9ED4759B1107A59C8B61C15EA26"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34011
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Podometris {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Maps.Controls.Map Map;
        
        internal System.Windows.Controls.TextBlock distanceLabel;
        
        internal System.Windows.Controls.TextBlock timeLabel;
        
        internal System.Windows.Controls.TextBlock caloriesLabel;
        
        internal System.Windows.Controls.TextBlock paceLabel;
        
        internal System.Windows.Controls.Button StartButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Podometris;component/MainPage.xaml", System.UriKind.Relative));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.Map = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("Map")));
            this.distanceLabel = ((System.Windows.Controls.TextBlock)(this.FindName("distanceLabel")));
            this.timeLabel = ((System.Windows.Controls.TextBlock)(this.FindName("timeLabel")));
            this.caloriesLabel = ((System.Windows.Controls.TextBlock)(this.FindName("caloriesLabel")));
            this.paceLabel = ((System.Windows.Controls.TextBlock)(this.FindName("paceLabel")));
            this.StartButton = ((System.Windows.Controls.Button)(this.FindName("StartButton")));
        }
    }
}
