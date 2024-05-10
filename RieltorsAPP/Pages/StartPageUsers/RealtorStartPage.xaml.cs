using System;
using System.Collections.Generic;
using RieltorsAPP.Data;
using System.Windows;
using System.Windows.Controls;


namespace RieltorsAPP.Pages.StartPageUsers
{
    /// <summary>
    /// Логика взаимодействия для RealtorStartPage.xaml
    /// </summary>
    public partial class RealtorStartPage : Page
    {
        public RealtorStartPage()
        {
            InitializeComponent();
        }

        private void BtnApartaments_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.StartFrame.Navigate(new ApartmentsPage());
        }

        private void BtnDocument_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.StartFrame.Navigate(new ReportsPage());
        }
    }
}
