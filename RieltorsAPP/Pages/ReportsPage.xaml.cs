using RieltorsAPP.AddAditData;
using RieltorsAPP.Data;
using RieltorsAPP.Entities;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using MessageBox = System.Windows.MessageBox;
using Word = Microsoft.Office.Interop.Word;

namespace RieltorsAPP.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        private Word.Document document = null;
        public ReportsPage() => InitializeComponent();
       

        private void BtnAdd_Click(object sender, RoutedEventArgs e) =>        
            NavigationFrame.StartFrame.Navigate(new AdAditReporsPage(null));
        

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var realtyForRemoving = DGridReports.SelectedItems.Cast<Report>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {realtyForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.DataBase.Report.RemoveRange(realtyForRemoving);
                    App.DataBase.SaveChanges();                    
                    MessageBox.Show("Данные удалены!");

                    DGridReports.ItemsSource = App.DataBase.Report.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.StartFrame.Navigate(new AdAditReporsPage((sender as Button).DataContext as Report));
        }


        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxInformation.AddInfo("Печать загружается");
            FormDocument();
            var wordProcess = Process.GetProcessesByName("winword").FirstOrDefault();
            if (wordProcess != null)
            {
                SetForegroundWindow(wordProcess.MainWindowHandle); // Приводим окно Word на передний план
            }
            document.Application.Dialogs[ Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint ].Show();
            document.Application.Quit();
            document = null;
        }

        /// <summary>
        /// Метод печати
        /// </summary>
        private void FormDocument()
        {
            try
            {

                var rows = DGridReports.ItemsSource.Cast<Report>().ToList();
                if (rows.Count == 0)
                {
                    MessageBox.Show("Нет выбранных книг", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var app = new Word.Application();
                document = app.Documents.Add();
                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table table = document.Tables.Add(tableRange, rows.Count + 1, 4);
                table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;
                cellRange = table.Cell(1, 1).Range;
                cellRange.Text = "Имя";
                cellRange = table.Cell(1, 2).Range;
                cellRange.Text = "Ценна";
                cellRange = table.Cell(1, 3).Range;
                cellRange.Text = "Описание";
                cellRange = table.Cell(1, 4).Range;
                cellRange.Text = "Покупатель";



                table.Rows[ 1 ].Range.Bold = 1;
                int currentRow = 1;
                foreach (var row in rows)
                {
                    currentRow++;
                    cellRange = table.Cell(currentRow, 1).Range;
                    cellRange.Text = row.Name.ToString();

                    cellRange = table.Cell(currentRow, 2).Range;
                    cellRange.Text = row.Price.ToString();

                    cellRange = table.Cell(currentRow, 3).Range;
                    cellRange.Text = row.Description.ToString();
                    cellRange = table.Cell(currentRow, 4).Range;
                    cellRange.Text = row.Buyer.ToString();

                }

                document.Paragraphs.Add();
                Word.Paragraph sum = document.Paragraphs.Add();
                sum.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                Word.Range sumRange = sum.Range;
                sumRange.Bold = 1;

            }
            catch
            {
                MessageBox.Show("Ошибка в формировании отчета", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridReports.ItemsSource = App.DataBase.Report.ToList();
        }
    }
}
