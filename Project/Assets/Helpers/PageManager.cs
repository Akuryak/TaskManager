using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaskManager.Assets.Helpers
{
    internal class PageManager
    {
        public static Frame? MainFrame { get; set; }

        public static void Navigate(Page page)
        {
            if (App.Current.MainWindow != null)
            {
                App.Current.MainWindow.Title = page.Title;
                App.Current.MainWindow.MinHeight = page.MinHeight;
                App.Current.MainWindow.MinWidth = page.MinWidth;
            }
            MainFrame?.Navigate(page);
        }

        public static void Navigate(Page page, string title)
        {
            if (App.Current.MainWindow != null)
            {
                App.Current.MainWindow.Title = title;
                App.Current.MainWindow.MinHeight = page.MinHeight;
                App.Current.MainWindow.MinWidth = page.MinWidth;
            }
            MainFrame?.Navigate(page);
        }
    }
}
