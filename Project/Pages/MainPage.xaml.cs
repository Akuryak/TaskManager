using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Models;

namespace TaskManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void RefreshProjectsListBox(List<Project> projects)
        {
            ProjectsListBox.Items.Clear();
            for (int i = 0; i < projects.Count; i++)
            {
                ProjectsListBox.Items.Add(new UserControls.ProjectInfoUserControl(projects[i], i + 1));
            }
            if (ProjectsListBox.Items.Count > 0)
                ProjectsListBox.SelectedIndex = 0;
        }

        private void CreateImageFromProjectName(Project project)
        {
            string? projectName = project.ShortTitle;
            if (string.IsNullOrWhiteSpace(project.ShortTitle))
            {
                projectName = project.FullTitle.Substring(0, 2).ToUpper();
                if (project.FullTitle.Split(" ").Length > 1)
                    projectName = $"{project.FullTitle.Split(" ")[0].First()}{project.FullTitle.Split(" ")[1].First()}".ToUpper();
            }

            Bitmap bmp = new Bitmap(120, 80);

            Graphics g = Graphics.FromImage(bmp);

            g.FillRectangle(System.Drawing.Brushes.Black, 0, 0, bmp.Width, bmp.Height);

            g.DrawString(projectName, new Font("Arial", 50, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.White, 0, 0);

            bmp.Save($"{Environment.CurrentDirectory}../../../../Assets/Images/{project.FullTitle}.png", ImageFormat.Png);

            App.Context.Projects.ToList().FirstOrDefault(x => x.Id == project.Id).Icon = $"{Environment.CurrentDirectory}../../../../Assets/Images/{project.FullTitle}.png";
            App.Context.SaveChanges();

            g.Dispose();
            bmp.Dispose();
        }

        private void CreateProjectsImages()
        {
            foreach (Project project in App.Context.Projects.ToList())
            {
                if (string.IsNullOrWhiteSpace(project.Icon))
                    CreateImageFromProjectName(project);
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

            MainPageFrame.Navigate(new DashboardPage());
            NavigateDashboardPageButton.IsEnabled = false;
            NavigateTasksPageButton.IsEnabled = true;
            NavigateGantDiagrammPageButton.IsEnabled = true;
        }

        private void NavigateTasksPageButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LastOpenedSelection = "Задачи";
            Properties.Settings.Default.Save();

            MainPageFrame.Navigate(new TasksPage());
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
            switch (Properties.Settings.Default.LastOpenedSelection)
            {
                case "Дашборд":
                    MainPageFrame.Navigate(new DashboardPage());
                    NavigateDashboardPageButton.IsEnabled = false;
                    break;

                case "Задачи":
                    MainPageFrame.Navigate(new TasksPage());
                    NavigateTasksPageButton.IsEnabled = false;
                    break;

                case "Диаграмма ганта":
                    MainPageFrame.Navigate(new GantDiagrammPage());
                    NavigateGantDiagrammPageButton.IsEnabled = false;
                    break;
            }

            RefreshProjectVersionAndBuildVersion();
            CreateProjectsImages();
            RefreshProjectsListBox(App.Context.Projects.ToList());

        }

        private void ProjectsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProjectsListBox.SelectedItem != null)
                ((UserControls.ProjectInfoUserControl)ProjectsListBox.SelectedItem).ProjectTitleTextBlock.FontWeight = FontWeights.Bold;

            foreach (UserControls.ProjectInfoUserControl userControl in ProjectsListBox.Items)
            {
                if (userControl != ProjectsListBox.SelectedItem)
                    userControl.ProjectTitleTextBlock.FontWeight = FontWeights.Thin;
            }
        }

        private void SearchProjectsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchProjectsTextBox.Text))
            {
                List<Project> projects = App.Context.Projects.ToList().Where(x=>x.FullTitle.ToLower().Contains(SearchProjectsTextBox.Text.ToLower())).ToList();
                projects = projects.Concat(App.Context.Projects.ToList().Where(x => x.Description == null ? default : x.Description.ToLower().Contains(SearchProjectsTextBox.Text.ToLower()))).ToList();

                RefreshProjectsListBox(projects);
            }
            else
                RefreshProjectsListBox(App.Context.Projects.ToList());
        }

        private void SearchProjectsTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchProjectsTextBlock.Visibility = Visibility.Collapsed;
        }

        private void SearchProjectsTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchProjectsTextBox.Text))
                SearchProjectsTextBlock.Visibility = Visibility.Visible;
        }
    }
}
