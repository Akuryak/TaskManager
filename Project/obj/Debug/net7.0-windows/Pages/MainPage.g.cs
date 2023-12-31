﻿#pragma checksum "..\..\..\..\Pages\MainPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E32B3EF27A315CF04E639064F5284D5ABFCCA047"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using TaskManager.Pages;


namespace TaskManager.Pages {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NavigateDashboardPageButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NavigateTasksPageButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NavigateGantDiagrammPageButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ProjectsListBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ProjectVersionAndBuildVersionTextBlock;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainPageFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TaskManager;component/pages/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\MainPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\Pages\MainPage.xaml"
            ((TaskManager.Pages.MainPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NavigateDashboardPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Pages\MainPage.xaml"
            this.NavigateDashboardPageButton.Click += new System.Windows.RoutedEventHandler(this.NavigateDashboardPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NavigateTasksPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Pages\MainPage.xaml"
            this.NavigateTasksPageButton.Click += new System.Windows.RoutedEventHandler(this.NavigateTasksPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NavigateGantDiagrammPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Pages\MainPage.xaml"
            this.NavigateGantDiagrammPageButton.Click += new System.Windows.RoutedEventHandler(this.NavigateGantDiagrammPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ProjectsListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 28 "..\..\..\..\Pages\MainPage.xaml"
            this.ProjectsListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ProjectsListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ProjectVersionAndBuildVersionTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.MainPageFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

