using System.Windows.Controls;
using System.Windows;

namespace RieltorsAPP.Data
{
    internal class MessageBoxInformation
    {
        public static void Length(TextBox textBox, PasswordBox passwordBox)
        {
            if (textBox.Text.Length == 0 && passwordBox.Password.Length == 0)
            {
                MessageBox.Show("Вы не ввели логин и пароль.", "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else if (textBox.Text.Length == 0 && passwordBox.Password.Length != 0)
            {
                MessageBox.Show("Вы не ввели логин.", "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else if (textBox.Text.Length != 0 && passwordBox.Password.Length == 0)
            {
                MessageBox.Show("Вы не ввели пароль.", "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        public static void InfoUser(string txt)
        {
            MessageBox.Show($"Вы вошли как {txt}", "Информация",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information);
        }

        public static void AddInfo(string txt)
        {
            MessageBox.Show($"{txt}", "Информация",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information);
        }

        public static void ErrorServer()
        {
            MessageBox.Show("Ошибка подключение к серверу.", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void UserError()
        {
            MessageBox.Show("Не правильный логин или пароль.", "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
