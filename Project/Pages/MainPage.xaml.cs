using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaskManager.Models;

namespace TaskManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static Employee LoginEmployee { get; set; }
        public MainPage(Employee loginEmployee)
        {
            InitializeComponent();
            LoginEmployee = loginEmployee;
        }

        private void RefreshProjectsListBox()
        {
            ProjectsListBox.Items.Clear();
            for (int i = 0; i < App.Context.Projects.ToList().Count; i++)
            {
                ProjectsListBox.Items.Add(new UserControls.ProjectInfoUserControl(App.Context.Projects.ToList()[i]));
            }
            if (ProjectsListBox.Items.Count > 0)
                ProjectsListBox.SelectedIndex = 0;
        }

        private void CreateProjectsImages()
        {
            foreach (Project project in App.Context.Projects.ToList())
            {
                if (string.IsNullOrWhiteSpace(project.Icon))
                    Assets.Helpers.ImageCreator.CreateImageFromProjectName(project);
            }
        }

        private void RefreshProjectVersionAndBuildVersion()
        {
            ProjectVersionAndBuildVersionTextBlock.Text = $"{Assembly.GetExecutingAssembly().GetName().Version}";
        }

        private void NavigateDashboardPageButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LastOpenedSelection = "Дашборд";
            Properties.Settings.Default.Save();

            MainPageFrame.Navigate(new DashboardPage((Project)((UserControls.ProjectInfoUserControl)ProjectsListBox.SelectedItem).DataContext));
            NavigateDashboardPageButton.IsEnabled = false;
            NavigateTasksPageButton.IsEnabled = true;
            NavigateGantDiagrammPageButton.IsEnabled = true;
        }

        private void NavigateTasksPageButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LastOpenedSelection = "Задачи";
            Properties.Settings.Default.Save();

            MainPageFrame.Navigate(new TasksPage(LoginEmployee, (Project)((UserControls.ProjectInfoUserControl)ProjectsListBox.SelectedItem).DataContext));
            NavigateTasksPageButton.IsEnabled = false;
            NavigateDashboardPageButton.IsEnabled = true;
            NavigateGantDiagrammPageButton.IsEnabled = true;
        }

        private void NavigateGantDiagrammPageButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LastOpenedSelection = "Диаграмма ганта";
            Properties.Settings.Default.Save();

            MainPageFrame.Navigate(new GantDiagrammPage());
            NavigateGantDiagrammPageButton.IsEnabled = false;
            NavigateDashboardPageButton.IsEnabled = true;
            NavigateTasksPageButton.IsEnabled = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshProjectVersionAndBuildVersion();
            CreateProjectsImages();
            RefreshProjectsListBox();

            switch (Properties.Settings.Default.LastOpenedSelection)
            {
                case "Дашборд":
                    MainPageFrame.Navigate(new DashboardPage((Project)((UserControls.ProjectInfoUserControl)ProjectsListBox.SelectedItem).DataContext));
                    NavigateDashboardPageButton.IsEnabled = false;
                    break;

                case "Задачи":
                    MainPageFrame.Navigate(new TasksPage(LoginEmployee, (Project)((UserControls.ProjectInfoUserControl)ProjectsListBox.SelectedItem).DataContext));
                    NavigateTasksPageButton.IsEnabled = false;
                    break;

                case "Диаграмма ганта":
                    MainPageFrame.Navigate(new GantDiagrammPage());
                    NavigateGantDiagrammPageButton.IsEnabled = false;
                    break;
            }
        }

        private void ProjectsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProjectsListBox.SelectedItem != null)
            {
                ((UserControls.ProjectInfoUserControl)ProjectsListBox.SelectedItem).MainBorder.Background = new BrushConverter().ConvertFrom("#8689DF") as System.Windows.Media.Brush;

                foreach (UserControls.ProjectInfoUserControl userControl in ProjectsListBox.Items)
                {
                    if (userControl != ProjectsListBox.SelectedItem)
                        userControl.MainBorder.Background = new BrushConverter().ConvertFrom("#4146D9") as System.Windows.Media.Brush;
                }
                MainPageFrame.Navigate(new TasksPage(LoginEmployee, (Project)((UserControls.ProjectInfoUserControl)ProjectsListBox.SelectedItem).DataContext));
                NavigateTasksPageButton.IsEnabled = false;
                NavigateDashboardPageButton.IsEnabled = true;
                NavigateGantDiagrammPageButton.IsEnabled = true;
            }
        }
    }
}
