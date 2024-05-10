
using System.Windows;
using System.Windows.Controls;
using RieltorsAPP.Data;

namespace RieltorsAPP.Pages.StartPageUsers
{
    /// <summary>
    /// Логика взаимодействия для AdministratorStartPage.xaml
    /// </summary>
    public partial class AdministratorStartPage : Page
    {
        public AdministratorStartPage()
        {
            InitializeComponent();
        }

        private void BtnAdUser_Click(object sender, RoutedEventArgs e)
        {
            DataUser.AdUser = 2;
            NavigationFrame.StartFrame.Navigate(new RegistrationPage());
        }
    }
}
