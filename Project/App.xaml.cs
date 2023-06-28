using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Models.TaskManagerContext Context { get; } = new Models.TaskManagerContext();
        //Scaffold-DbContext "Server=localhost;Database=Taskmanager;User=root;Password=12345" "Pomelo.EntityFrameworkCore.MySql" -outputdir Models -context TaskManagerContext -f
    }
}
