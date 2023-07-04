using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public static Project? SelectedProject { get; set; }
        public DashboardPage(Project project)
        {
            InitializeComponent();
            SelectedProject = project;
        }

        private async System.Threading.Tasks.Task Refresh()
        {
            List<Models.Task> UnfinishedTasks = new List<Models.Task>();
            List<Models.Task> OverdueTasks = new List<Models.Task>();
            List<Models.Task> ActiveTasks = new List<Models.Task>();
            List<Models.Task> UnfinishedTasksForAWeek = new List<Models.Task>();

            while (true)
            {
                await System.Threading.Tasks.Task.Run(() =>
                {
                    UnfinishedTasks = App.Context.Tasks.ToList().Where(x => x.FinishActualTime == null && x.ProjectId == SelectedProject?.Id).ToList();
                    OverdueTasks = App.Context.Tasks.ToList().Where(x => ((DateTime)x.Deadliine).CompareTo(DateTime.Now) > 0 && x.ProjectId == SelectedProject?.Id).ToList();
                    ActiveTasks = App.Context.Tasks.ToList().Where(x => x.FinishActualTime != null && x.ProjectId == SelectedProject?.Id).ToList();
                    UnfinishedTasksForAWeek = App.Context.Tasks.ToList().Where(x => x.FinishActualTime != null && x.ProjectId == SelectedProject?.Id && ((DateTime)x.StartActualTime).CompareTo(DateTime.Now.AddDays(-7)) < 0).ToList();
                });

                UnfinishedTasksListView.Items.Clear();
                foreach (Models.Task task in UnfinishedTasks)
                {
                    UnfinishedTasksListView.Items.Add(new UserControls.TaskInfoUserControl(task, null));
                }
                OverdueTasksListView.Items.Clear();
                foreach (Models.Task task in OverdueTasks)
                {
                    OverdueTasksListView.Items.Add(new UserControls.TaskInfoUserControl(task, null));
                }
                ActiveTasksListView.Items.Clear();
                foreach (Models.Task task in ActiveTasks)
                {
                    ActiveTasksListView.Items.Add(new UserControls.TaskInfoUserControl(task, null));
                }
                UnfinishedTasksForAWeekListView.Items.Clear();
                foreach (Models.Task task in UnfinishedTasksForAWeek)
                {
                    UnfinishedTasksForAWeekListView.Items.Add(new UserControls.TaskInfoUserControl(task, null));
                }

                TopFiveEmpoloyeeFinishedTasksListView.ItemsSource = App.Context.Employees.ToList().OrderBy(x => x.Tasks.Where(x => x.FinishActualTime != null && x.ProjectId == SelectedProject?.Id).ToList().Count).Take(5);
                TopFiveEmpoloyeeUnfinishedTasksListView.ItemsSource = App.Context.Employees.ToList().OrderBy(x => x.Tasks.Where(x => x.FinishActualTime == null && x.ProjectId == SelectedProject?.Id).ToList().Count).Take(5);

                if (OverdueTasks.Count > 2)
                    OverdueTasksListView.Background = Brushes.Red;
                else
                    OverdueTasksListView.Background = new BrushConverter().ConvertFrom("#9ED3D9") as Brush;

                if (DateTime.Now.Hour > 9 && DateTime.Now.Hour < 18 && App.Context.Tasks.ToList().Where(x => x.FinishActualTime != null && x.ProjectId == SelectedProject?.Id).Count() == 0)
                    ActiveTasksListView.Background = Brushes.Red;
                else
                    ActiveTasksListView.Background = new BrushConverter().ConvertFrom("#9ED3D9") as Brush;

                await System.Threading.Tasks.Task.Delay(30 * 1000);
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await Refresh();
        }
    }
}
