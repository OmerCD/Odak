﻿#pragma checksum "..\..\..\..\Views\UserControllers\Anasayfa.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29B7D1601AADEB3EA8FD962342A00C120DDC7A61"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ListviewProje.Views.UserControllers {
    
    
    /// <summary>
    /// Anasayfa
    /// </summary>
    public partial class Anasayfa : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AnaGrid;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition sideBar;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel menuStack;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock KullaniciAdi;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl AnasayfaIcerik;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle NotificationIcon;
        
        #line default
        #line hidden
        
        /// <summary>
        /// NotificationLabel Name Field
        /// </summary>
        
        #line 119 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Label NotificationLabel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ListviewProje;component/views/usercontrollers/anasayfa.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AnaGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 9 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
            this.AnaGrid.Loaded += new System.Windows.RoutedEventHandler(this.AnaGrid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.sideBar = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 3:
            this.menuStack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            
            #line 25 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Toggle);
            
            #line default
            #line hidden
            return;
            case 5:
            this.KullaniciAdi = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 45 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Baglangic);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 57 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Testler);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 69 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Sonuclar);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 90 "..\..\..\..\Views\UserControllers\Anasayfa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Ayarlar);
            
            #line default
            #line hidden
            return;
            case 10:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.AnasayfaIcerik = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 12:
            this.NotificationIcon = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 13:
            this.NotificationLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

