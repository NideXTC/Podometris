﻿#pragma checksum "C:\Users\Alexis DUCERF\Documents\Visual Studio 2013\Projects\Podometris\Podometris\Objectives.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "478BB0EA4E354BEC17563C20BD4E5E1D"
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
    
    
    public partial class Objectives : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.ListBox ItemsListBox;
        
        internal System.Windows.Controls.TextBox km;
        
        internal System.Windows.Controls.TextBox time;
        
        internal System.Windows.Controls.Button newAddButton;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Podometris;component/Objectives.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.ItemsListBox = ((System.Windows.Controls.ListBox)(this.FindName("ItemsListBox")));
            this.km = ((System.Windows.Controls.TextBox)(this.FindName("km")));
            this.time = ((System.Windows.Controls.TextBox)(this.FindName("time")));
            this.newAddButton = ((System.Windows.Controls.Button)(this.FindName("newAddButton")));
        }
    }
}

