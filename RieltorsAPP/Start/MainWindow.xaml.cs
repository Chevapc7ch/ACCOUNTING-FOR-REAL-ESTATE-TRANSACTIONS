using System;
using System.Windows;
using RieltorsAPP.Data;
using RieltorsAPP.Pages;

namespace RieltorsAPP.Start
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SFrame.Navigate(new StartPage()); // Метод Navigate позволит нам отобразить нужную страницу
            NavigationFrame.StartFrame = SFrame;
        }

        private void SFrame_ContentRendered(object sender, EventArgs e)
        {
            if (SFrame.Content.GetType().Name == "StartPage")
            {
               BtnBack.Visibility = Visibility.Collapsed; // Если фрайм может возвращаться назад, то кнопка будет отображаться с помощью свойств Visibility
            }
            else
            {
                BtnBack.Visibility= Visibility.Visible; // иначе скрывать
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.StartFrame.GoBack();
        }
    }
}
