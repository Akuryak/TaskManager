using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Assets.Helpers
{
    internal class ImageCreator
    {
        public static void CreateImageFromProjectName(Project project)
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
    }
}
