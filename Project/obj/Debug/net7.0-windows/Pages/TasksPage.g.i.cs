﻿#pragma checksum "..\..\..\..\Pages\TasksPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8D035F64D1A059ABE8066ABC382358B12F1A3AD6"
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
    /// TasksPage
    /// </summary>
    public partial class TasksPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition TasksListColumn;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition TasksEditColumn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TasksListGrid;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchProjectsTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SearchProjectsTextBlock;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ProjectTasksListBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateNewTaskButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TaskEditGrid;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FullTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ShortTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar DeadlineDatePicker;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveChangesButton;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelChangesButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pages\TasksPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteTaskButton;
        
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
            System.Uri resourceLocater = new System.Uri("/TaskManager;component/pages/taskspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\TasksPage.xaml"
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
            
            #line 9 "..\..\..\..\Pages\TasksPage.xaml"
            ((TaskManager.Pages.TasksPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TasksListColumn = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 3:
            this.TasksEditColumn = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 4:
            this.TasksListGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.SearchProjectsTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\..\Pages\TasksPage.xaml"
            this.SearchProjectsTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchProjectsTextBox_TextChanged);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\Pages\TasksPage.xaml"
            this.SearchProjectsTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.SearchProjectsTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\Pages\TasksPage.xaml"
            this.SearchProjectsTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.SearchProjectsTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SearchProjectsTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.ProjectTasksListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 24 "..\..\..\..\Pages\TasksPage.xaml"
            this.ProjectTasksListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ProjectTasksListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CreateNewTaskButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Pages\TasksPage.xaml"
            this.CreateNewTaskButton.Click += new System.Windows.RoutedEventHandler(this.CreateNewTaskButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TaskEditGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.FullTitleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.ShortTitleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.DescriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.DeadlineDatePicker = ((System.Windows.Controls.Calendar)(target));
            return;
            case 14:
            this.SaveChangesButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\Pages\TasksPage.xaml"
            this.SaveChangesButton.Click += new System.Windows.RoutedEventHandler(this.SaveChangesButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.CancelChangesButton = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\Pages\TasksPage.xaml"
            this.CancelChangesButton.Click += new System.Windows.RoutedEventHandler(this.CancelChangesButton_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.DeleteTaskButton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\Pages\TasksPage.xaml"
            this.DeleteTaskButton.Click += new System.Windows.RoutedEventHandler(this.DeleteTaskButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

