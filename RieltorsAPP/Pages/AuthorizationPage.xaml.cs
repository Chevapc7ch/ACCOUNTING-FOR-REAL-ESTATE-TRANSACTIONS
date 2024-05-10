using RieltorsAPP.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RieltorsAPP.Pages.StartPageUsers;


namespace RieltorsAPP.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnEntrance_Click(object sender, RoutedEventArgs e)
        {
            if (TBLogin.Text.Length == 0 || PBPassword.Password.Length == 0)
            {
                MessageBoxInformation.Length(TBLogin, PBPassword);
            }
            else
            {
                try
                {                  
                    var user = App.DataBase.Users.Where(p =>
                    p.Login == TBLogin.Text && p.Password == PBPassword.Password).FirstOrDefault();

                    if (user != null)
                    {
                        DataUser.Login = user.Login;
                        DataUser.IdRole = Convert.ToByte(user.IdRole);

                        if (user.IdRole == 1)
                        {
                            MessageBoxInformation.InfoUser("Риелтор");                            
                            NavigationFrame.StartFrame.Navigate(new RealtorStartPage());
                        }

                        if (user.IdRole == 2)
                        {
                            MessageBoxInformation.InfoUser("Администратор");
                            NavigationFrame.StartFrame.Navigate(new AdministratorStartPage());
                        }

                        if (user.IdRole == 3 || user.IdRole == null)
                        {
                            MessageBoxInformation.InfoUser("Клиент");
                            NavigationFrame.StartFrame.Navigate(new ClientStartPage());
                        }
                    }
                    else
                    {
                        MessageBoxInformation.UserError();
                    }
                }
                catch
                {
                    MessageBoxInformation.ErrorServer();
                }
            }
        }
    }
}
