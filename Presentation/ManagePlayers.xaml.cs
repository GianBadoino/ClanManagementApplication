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

using Entity;
using System.Data.SQLite;
using MahApps.Metro.Controls.Dialogs;

namespace Presentation
{
    /// <summary>
    /// Lógica de interacción para ManagePlayers.xaml
    /// </summary>
    public partial class ManagePlayers : MetroWindow
    {
        Database DatabaseObject = new Database();
        List<ePlayer> PlayerList = new List<ePlayer>();
        ePlayer SelectedPlayer = null;
        public ManagePlayers()
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

        private void tile_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Form_MainWindow = new MainWindow();
            Form_MainWindow.Show();
            Close();
        }

        private void tile_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddEditPlayer Form_AddEditPlayer = new AddEditPlayer();
            Form_AddEditPlayer.ShowDialog();
        }

        private void tile_EditPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPlayer != null)
            {
                AddEditPlayer Form_AddEditPlayer = new AddEditPlayer(SelectedPlayer);
                Form_AddEditPlayer.ShowDialog();
            }
            else
            {
                this.ShowMessageAsync("Error", "Please select a player.");
            }
        }

        private async void tile_DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPlayer != null)
            {
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Yes",
                    NegativeButtonText = "No",
                    AnimateShow = true,
                    AnimateHide = false
                };

                var result = await this.ShowMessageAsync("Caution", "Are you sure you want to delete " + SelectedPlayer.Name + "?", MessageDialogStyle.AffirmativeAndNegative, mySettings);
                bool Answer = result == MessageDialogResult.Affirmative;
                if (Answer)
                {
                    string query = "DELETE FROM Player WHERE ID = @CPlayer";
                    SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);
                    DatabaseObject.ConnectDB();
                    cmd.Parameters.AddWithValue("@CPlayer", SelectedPlayer.ID);
                    cmd.ExecuteNonQuery();
                    DatabaseObject.DisconnectDB();
                    ShowPlayers();
                    await this.ShowMessageAsync("", "Player succesfully deleted.");
                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Please select a player.");
            }
        }

        private void tile_Refresh_Click(object sender, RoutedEventArgs e)
        {
            datagrd_Players.Items.SortDescriptions.Clear();
            ShowPlayers();
        }

        private void ReadPlayers()
        {
            ePlayer Player = null;
            eRank Rank = null;

            string query = "SELECT p.ID, p.Name, r.Value, r.Rank, p.HTCPoints, p.ParticipationPoints, p.FlagPayment, p.JoinDate FROM Player p INNER JOIN Rank r ON p.Rank = r.Value ORDER BY r.Value DESC";
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
                    Player.ParticipationPoints = Convert.ToInt32(Reader["ParticipationPoints"]);
                    if (Convert.ToInt32(Reader["FlagPayment"]) == 1)
                    {
                        Player.FlagPayment = "Yes";
                    }
                    else
                    {
                        Player.FlagPayment = "No";
                    }                    
                    Player.JoinDate = Convert.ToDateTime(Reader["JoinDate"]);
                    Player.Rank = Rank;

                    PlayerList.Add(Player);
                }
            }
            DatabaseObject.DisconnectDB();
            datagrd_Players.ItemsSource = PlayerList;
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
            {
                e.Column.Header = "Participation Points";
            }
            if (e.PropertyName.StartsWith("FlagPayment"))
            {
                e.Column.Header = "Payment";
            } 
            if (e.PropertyName.StartsWith("HTCPoints"))
            {
                e.Column.Header = "HTC Points";
            }
            if (e.PropertyName.StartsWith("JoinDate"))
            {
                e.Column.Header = "Join Date (MM/DD/YYYY)";
            }
        }

        private void datagrd_Players_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPlayer = new ePlayer();
            SelectedPlayer = datagrd_Players.SelectedItem as ePlayer;
        }

        private void btn_AddParticipationPoints_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPlayer != null)
            {
                AddParticipationPoints Form_AddParticipationPoints = new AddParticipationPoints(SelectedPlayer);
                Form_AddParticipationPoints.ShowDialog();
            }
            else
            {
                this.ShowMessageAsync("Error", "Please select a player.");
            }
        }

        private void btn_Payments_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPlayer != null)
            {
                if (SelectedPlayer.FlagPayment == "Yes")
                {
                    Payments Form_Payments = new Payments(SelectedPlayer);
                    Form_Payments.ShowDialog();
                }
                else
                {
                    this.ShowMessageAsync("", SelectedPlayer.Name + "Is not eligible for payment.");
                }
            }
            else
            {
                this.ShowMessageAsync("Error", "Please select a player.");
            }
        }
    }
}
