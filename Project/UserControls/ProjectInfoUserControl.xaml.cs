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
        public ProjectInfoUserControl(Project project)
        {
            InitializeComponent();

            DataContext = project;

            try
            {
                GetImage(project);
            }
            catch
            {
                Assets.Helpers.ImageCreator.CreateImageFromProjectName(project);
                GetImage(project);
            }

            ProjectImage.ToolTip = project.FullTitle;
        }

        private void GetImage(Project project)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(project.Icon);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            ProjectImage.Source = bitmapImage;
        }
    }
}
