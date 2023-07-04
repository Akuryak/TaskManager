using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для TasksPage.xaml
    /// </summary>
    public partial class TasksPage : Page
    {
        private static Project? SelectedProject { get; set; }
        private static Employee? LoginEmployee { get; set; }
        public TasksPage(Employee loginEmployee, Project project)
        {
            InitializeComponent();
            SelectedProject = project;
            LoginEmployee = loginEmployee;
        }

        private void RefreshProjectTasks(List<Models.Task> tasks)
        {
            tasks = tasks.Where(x=>x.DeletedTime == null).ToList();
            ProjectTasksListBox.Items.Clear();
            if (tasks.Count > 0)
            {
                SearchProjectsTextBox.Visibility = Visibility.Visible;
                ProjectTasksListBox.Visibility = Visibility.Visible;
                for (int i = 0; i < tasks.Count; i++)
                {
                    ProjectTasksListBox.Items.Add(new UserControls.TaskInfoUserControl(tasks[i], i + 1));
                }
            }
        }

        private void SearchProjectsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchProjectsTextBox.Text))
            {
                List<Task> tasks = App.Context.Tasks.ToList().Where(x => x.ProjectId == (SelectedProject?.Id)).ToList();

                tasks = tasks.Where(x => x.FullTitle.ToLower().Contains(SearchProjectsTextBox.Text.ToLower())).ToList();
                tasks = tasks.Concat(App.Context.Tasks.ToList().Where(x => x.Description == null ? default : x.Description.ToLower().Contains(SearchProjectsTextBox.Text.ToLower()) && !tasks.Contains(x))).ToList();

                RefreshProjectTasks(tasks);
                SearchProjectsTextBlock.Visibility = Visibility.Collapsed;
            }
            else
                RefreshProjectTasks(App.Context.Tasks.ToList().Where(x => x.ProjectId == (SelectedProject?.Id)).ToList());
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

        private void ProjectTasksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProjectTasksListBox.SelectedItem == null)
                return;

            ((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).MainGrid.Background = new BrushConverter().ConvertFrom("#8689DF") as System.Windows.Media.Brush;

            foreach (UserControls.TaskInfoUserControl task in ProjectTasksListBox.Items)
            {
                if (task != ProjectTasksListBox.SelectedItem)
                    task.MainGrid.Background = new BrushConverter().ConvertFrom("#4146D9") as System.Windows.Media.Brush;
            }

            TaskEditGrid.Visibility = Visibility.Visible;

            TasksListColumn.Width = (GridLength)new GridLengthConverter().ConvertFrom(TasksListColumn.ActualWidth / 2);
            TasksListColumn.Width = default;
            TasksEditColumn.Width = new GridLength(1, GridUnitType.Star);

            FullTitleTextBox.Text = ((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).FullTitle;
            ShortTitleTextBox.Text = ((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).ShortTitle;
            DescriptionTextBox.Text = ((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).Description;
            DeadlineDatePicker.SelectedDates.AddRange(((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).CreatedTime, (DateTime)((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).Deadliine);
            DeadlineDatePicker.DisplayDate = ((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).CreatedTime;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshProjectTasks(App.Context.Tasks.ToList().Where(x => x.ProjectId == SelectedProject?.Id).ToList());
        }

        private void CancelChangesButton_Click(object sender, RoutedEventArgs e)
        {
            TasksListGrid.Visibility = Visibility.Collapsed;
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullTitleTextBox.Text) || string.IsNullOrWhiteSpace(ShortTitleTextBox.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
                return;
            }

            if (DeadlineDatePicker.SelectedDates.Count < 2)
            {
                MessageBox.Show("Выберите больше двух дней", "Ошибка");
                return;
            }

            if (ProjectTasksListBox.SelectedItem != null)
            {
                App.Context.Tasks.ToList().FirstOrDefault(x => x.Id == ((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).Id).FullTitle = FullTitleTextBox.Text;
                App.Context.Tasks.ToList().FirstOrDefault(x => x.Id == ((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).Id).ShortTitle = ShortTitleTextBox.Text.ToUpper();
                App.Context.Tasks.ToList().FirstOrDefault(x => x.Id == ((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).Id).Description = DescriptionTextBox.Text;
                App.Context.Tasks.ToList().FirstOrDefault(x => x.Id == ((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).Id).StartActualTime = DeadlineDatePicker.SelectedDates.First();
                App.Context.Tasks.ToList().FirstOrDefault(x => x.Id == ((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).Id).Deadliine = DeadlineDatePicker.SelectedDates.Last();
                App.Context.Tasks.ToList().FirstOrDefault(x => x.Id == ((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).Id).UpdatedTime = DateTime.Now;
                App.Context.SaveChanges();
                MessageBox.Show($"Задача {FullTitleTextBox.Text} обновлена", "Уведомление");
            }
            else
            {
                App.Context.Tasks.Add(new Task(App.Context.Tasks.ToList().Max(x=>x.Id) + 1, SelectedProject.Id, FullTitleTextBox.Text, ShortTitleTextBox.Text, DescriptionTextBox.Text, LoginEmployee?.Id, 1, DateTime.Now, null, null, DeadlineDatePicker.SelectedDates.Last(), DeadlineDatePicker.SelectedDates.First(), null, App.Context.Tasks.ToList().LastOrDefault(x=>x.ProjectId == SelectedProject?.Id)?.Id, null, null!, null!, null, null!));
                App.Context.SaveChanges();

                MessageBox.Show($"Вы успешно добавили задачу {FullTitleTextBox.Text}", "Уведомление");
            }
        }

        private void CreateNewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskEditGrid.Visibility = Visibility.Visible;
            ProjectTasksListBox.SelectedItem = null;

            TasksListColumn.Width = (GridLength)new GridLengthConverter().ConvertFrom(TasksListColumn.ActualWidth / 2);
            TasksListColumn.Width = default;
            TasksEditColumn.Width = new GridLength(1, GridUnitType.Star);
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить задачу {((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).FullTitle}", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext).FinishActualTime != null)
                {
                    MessageBox.Show("Вы не можете удалить завершенную задачу", "Уведомление");
                    return;
                }

                App.Context.Tasks.Remove((Models.Task)((UserControls.TaskInfoUserControl)ProjectTasksListBox.SelectedItem).DataContext);
                MessageBox.Show("Вы успешно удалили задачу", "Уведомление");
                RefreshProjectTasks(App.Context.Tasks.ToList());
            }
        }
    }
}
