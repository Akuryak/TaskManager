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
using TaskManager.Models;

namespace TaskManager.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProjectInfoUserControl.xaml
    /// </summary>
    public partial class ProjectInfoUserControl : UserControl
    {
        public ProjectInfoUserControl(Project project, int number)
        {
            InitializeComponent();

            ProjectNumberTextBlock.Text = number.ToString();

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(project.Icon);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            ProjectImage.Source = bitmapImage;

            ProjectImage.ToolTip = project.FullTitle;
            ProjectTitleTextBlock.Text = project.FullTitle;

            if (project.Task != null)
            {
                ProjectDeadlineTextBlock.Text = project.Task.Deadliine.ToString();
                MainGrid.Background = new BrushConverter().ConvertFrom(project.Task.Status.ColorHex) as Brush;
            }
        }
    }
}
