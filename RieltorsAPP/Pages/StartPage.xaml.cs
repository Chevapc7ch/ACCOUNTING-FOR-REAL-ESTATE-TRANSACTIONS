using RieltorsAPP.Data;
using System.Windows;
using System.Windows.Controls;


namespace RieltorsAPP.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            DataUser.AdUser = 1;
            NavigationFrame.StartFrame.Navigate(new RegistrationPage());
        }

        /// <summary>
        /// Кнопка войти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEntrance_Click(object sender, RoutedEventArgs e)
        {
            DataUser.AdUser = 2;
            NavigationFrame.StartFrame.Navigate(new AuthorizationPage());
        }
    }
}
