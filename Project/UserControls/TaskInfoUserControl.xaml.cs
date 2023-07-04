using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TaskManager.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TaskInfoUserControl.xaml
    /// </summary>
    public partial class TaskInfoUserControl : UserControl
    {
        public TaskInfoUserControl(Models.Task task, int? number)
        {
            InitializeComponent();

            DataContext = task;

            if (number != null)
                NumberTextBlock.Text = number.ToString();
            TitleTextBlock.Text = task.FullTitle;
            ExecutiveEmlpoyeeTextBlock.Text = $"Создал: {task.ExecutiveEmployee?.Surname} {task.ExecutiveEmployee?.Name}";
            DeadlineTextBlock.Text = $"До: {task.Deadliine}";
        }
    }
}
