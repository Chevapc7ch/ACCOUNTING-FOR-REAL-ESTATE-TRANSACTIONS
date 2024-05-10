using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using RieltorsAPP.Data;
using RieltorsAPP.Entities;

namespace RieltorsAPP.AddAditData
{
    /// <summary>
    /// Логика взаимодействия для AdAditReporsPage.xaml
    /// </summary>
    public partial class AdAditReporsPage : Page
    {
        private Report _currentReport = new Report();

        public AdAditReporsPage(Report selectReport)
        {
            InitializeComponent();

            if(selectReport != null)
            {
                _currentReport = selectReport;
            }

            DataContext = _currentReport;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentReport.Name == null)
            {
                errors.AppendLine("\nУкажите ФИО");
            }

            if (_currentReport.Price < 0)
            {
                errors.AppendLine("\nУкажите цену");
            }

            if (_currentReport.Buyer == null)
            {
                errors.AppendLine("\nУкажите покупателя");
            }

            if (_currentReport.Description == null)
            {
                errors.AppendLine("\nУкажите описание");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if(_currentReport.Id != 0)
            {
                try
                {
                    App.DataBase.SaveChanges();
                    MessageBoxInformation.AddInfo("Данные успешно изменены.");
                    NavigationFrame.StartFrame.GoBack();

                }
                catch
                {
                    MessageBoxInformation.AddInfo("Данные не добавлены.");
                }
            }

            if (_currentReport.Id == 0)
            {
                App.DataBase.Report.Add(_currentReport);
                try
                {
                    App.DataBase.SaveChanges();
                    MessageBoxInformation.AddInfo("Данные успешно добавлены.");
                    NavigationFrame.StartFrame.GoBack();
                }
                catch  (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
