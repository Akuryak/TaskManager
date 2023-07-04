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

namespace TaskManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text) || string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
                return;
            }
            Employee employee = null;
            try
            {
                employee = App.Context.Employees.ToList().FirstOrDefault(x=>x.Login == LoginTextBox.Text && x.Password == PasswordTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при получении данных с базы данных: {ex.Message}", "Ошибка");
            }

            if (employee == null)
            {
                MessageBox.Show("Неверный логин или пароль", "Уведомление");
                return;
            }

            Assets.Helpers.PageManager.Navigate(new Pages.MainPage(employee));
        }
    }
}
