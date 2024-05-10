using RieltorsAPP.Data;
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

namespace RieltorsAPP.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (TBLogin.Text.Length == 0 || PBPassword.Password.Length == 0)
            {
                MessageBoxInformation.Length(TBLogin, PBPassword);
            }
            else
            {
                try
                {
                    string login = TBLogin.Text;
                    
                    var user = App.DataBase.Users.FirstOrDefault(u => u.Login == login);

                    if (user == null)
                    {
                        
                        string command = "";
                        if (CBRole.SelectedIndex == 2)
                        {
                            if(CBClient.SelectedIndex != -1)
                            {
                                command = "INSERT INTO Users (Login,Password, IdRole, IdClients)" +
                                $" VALUES ('{TBLogin.Text}','{PBPassword.Password}',NULL, {CBClient.SelectedIndex + 1});";

                            }
                            else
                            {
                                MessageBoxInformation.AddInfo("Выберите клиента");
                                return;
                            }
                        }

                        if (CBRole.SelectedIndex != 2)
                        {
                          command = "INSERT INTO Users (Login,Password, IdRole, IdClients)" +
                          $" VALUES ('{TBLogin.Text}','{PBPassword.Password}',{CBRole.SelectedIndex + 1}, NULL);";
                        }
                        if(CBRole.SelectedIndex == -1)
                        {
                            MessageBoxInformation.AddInfo("Выберите роль");
                            return;
                        }

                       
                        App.DataBase.Database.ExecuteSqlCommand(command);
                        MessageBoxInformation.AddInfo("Данные добавились успешно");
                        NavigationFrame.StartFrame.GoBack();
                    }
                    else
                    {
                        MessageBoxInformation.AddInfo("Пользователь с таким логином уже существует");
                    }
                }
                catch
                {
                    MessageBoxInformation.ErrorServer();
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
             CBRole.ItemsSource = App.DataBase.Role.ToList();
            if(DataUser.AdUser == 1)
            {
                BtnReg.Content = "Регистрация";
                TblokTitle.Text = "Регистрация";

            }
            else
            {
                BtnReg.Content = "Добавить пользователя";
                TblokTitle.Text = "Добавить";
            }
        }

        private void CBRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBRole.SelectedIndex == 2)
            {
                SPClient.Visibility = Visibility.Visible;
                CBClient.ItemsSource = App.DataBase.Client.ToList();
            }

            if (CBRole.SelectedIndex != 2)
            {
                SPClient.Visibility = Visibility.Collapsed;
                CBClient.ItemsSource = null;
                CBClient.SelectedIndex = -1;
            }
        }
    }
}
