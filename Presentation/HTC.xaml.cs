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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Data.SQLite;
using System.ComponentModel;
using MahApps.Metro.Controls.Dialogs;

using Entity;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Presentation
{
    /// <summary>
    /// Lógica de interacción para HTC.xaml
    /// </summary>
    public partial class HTC : MetroWindow
    {
        Database DatabaseObject = new Database();
        List<ePlayer> PlayerList = new List<ePlayer>();
        int rows;
        public HTC()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            ShowPlayers();
        }
        private void CenterWindowOnScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = Width;
            double windowHeight = Height;
            Left = (screenWidth / 2) - (windowWidth / 2);
            Top = (screenHeight / 2) - (windowHeight / 2);
        }

        public void ReadPlayers()
        {
            ePlayer Player = null;
            eRank Rank = null;

            string query = "SELECT p.ID, p.Name, r.Value, r.Rank, p.HTCPoints FROM Player p INNER JOIN Rank r ON p.Rank = r.Value";
            SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);
            DatabaseObject.ConnectDB();
            SQLiteDataReader Reader = cmd.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Rank = new eRank();
                    Rank.Value = Convert.ToInt32(Reader["Value"]);
                    Rank.Rank = Reader["Rank"].ToString();

                    Player = new ePlayer();
                    Player.ID = Convert.ToInt32(Reader["ID"]);
                    Player.Name = Reader["Name"].ToString();
                    Player.HTCPoints = Convert.ToInt32(Reader["HTCPoints"]);
                    Player.Rank = Rank;

                    PlayerList.Add(Player);
                    ++rows;
                }
            }
            DatabaseObject.DisconnectDB();
            datagrd_Players.ItemsSource = PlayerList;
            datagrd_Players.Items.SortDescriptions.Add(new SortDescription("HTCPoints", ListSortDirection.Descending));
        }

        public void ShowPlayers()
        {
            PlayerList.Clear();
            ReadPlayers();
            datagrd_Players.Items.Refresh();
        }

        private void datagrd_Players_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("ID"))
                e.Cancel = true;
            if (e.PropertyName.StartsWith("ParticipationPoints"))
                e.Cancel = true;
            if (e.PropertyName.StartsWith("FlagPayment"))
                e.Cancel = true;
            if (e.PropertyName.StartsWith("JoinDate"))
                e.Cancel = true;
            if (e.PropertyName.StartsWith("HTCPoints"))
            {
                e.Column.Header = "Score";
                e.Column.Width = 90;
            }
            if (e.PropertyName.StartsWith("Name"))
                e.Column.Width = 255;
            if (e.PropertyName.StartsWith("Rank"))
            {
                e.Cancel = true;
            }
        }

        private void tile_Atras_Click(object sender, RoutedEventArgs e)//Back button
        {
            MainWindow Form_Main = new MainWindow();
            Form_Main.Show();
            Close();
        }

        private void tile_Editar_Click(object sender, RoutedEventArgs e)//Start HTC Session
        {
            HTCSession Form_HTCSession = new HTCSession();
            Form_HTCSession.Show();
            Close();
        }

        private async void tile_StartNewSeason_Click(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateShow = true,
                AnimateHide = false
            };

            var result = await this.ShowMessageAsync("Caution", "Are you sure you want to start a new HTC session? All the previous data will be overwritten.", MessageDialogStyle.AffirmativeAndNegative, mySettings);
            bool _shutdown = result == MessageDialogResult.Affirmative;

            if (_shutdown)
            {
                var result2 = await this.ShowMessageAsync("Caution", "Are you really sure you want to do this?", MessageDialogStyle.AffirmativeAndNegative, mySettings);
                bool _shutdown2 = result == MessageDialogResult.Affirmative;

                if (_shutdown2)
                {
                    string query = "UPDATE Player SET HTCPoints = 0";
                    SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);
                    DatabaseObject.ConnectDB();
                    cmd.ExecuteNonQuery();
                    DatabaseObject.DisconnectDB();
                }
            }
            ShowPlayers();
        }

        private void btn_SelectAll_Click(object sender, RoutedEventArgs e)
        {
            datagrd_Players.SelectAll();
            datagrd_Players.Focus();
        }

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            /*this.ShowMessageAsync("datagrd_Players.Columns.Count", datagrd_Players.Columns.Count.ToString());
            this.ShowMessageAsync("datagrd_Players.Items.Count", datagrd_Players.Items.Count.ToString());
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            if (datagrd_Players.HasItems)
            {
                for (int j = 0; j < datagrd_Players.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[1, j + 1];
                    sheet1.Cells[1, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 15;
                    myRange.Value2 = datagrd_Players.Columns[j].Header;
                }
                for (int i = 0; i < datagrd_Players.Columns.Count; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        TextBlock b = datagrd_Players.Columns[i].GetCellContent(datagrd_Players.Items[j]) as TextBlock;
                        if (b != null)
                        {
                            Range myRange = (Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value2 = b.Text;
                        }
                    }                    
                }
            }///////////////////////
            datagrd_Players.SelectAllCells();
            datagrd_Players.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, datagrd_Players);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            datagrd_Players.UnselectAllCells();
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\test.xls");
            file1.WriteLine(result.Replace(',', ' '));
            file1.Close();

            this.ShowMessageAsync("", "Exporting DataGrid data to Excel file created.xls");*/

            if (datagrd_Players.HasItems)
            {
                copyAlltoClipboard();
                Excel.Application xlexcel;
                Workbook xlWorkBook;
                Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Range CR1 = (Range)xlWorkSheet.Cells[1, 1];
                TextFrame a = (TextFrame)
                CR1.Select();
                xlWorkSheet.PasteSpecial(CR1, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            /*Excel.Range CR2 = (Excel.Range)xlWorkSheet.Cells[7, 1];
            CR2.Select();
            xlWorkSheet.PasteSpecial(CR2, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);*/
        }

        private void copyAlltoClipboard()
        {
            datagrd_Players.SelectAllCells();
            datagrd_Players.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, datagrd_Players);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            datagrd_Players.UnselectAllCells();
        }
    }
}