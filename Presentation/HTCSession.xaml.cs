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
using MahApps.Metro.Controls.Dialogs;
using System.Data.SQLite;
using System.ComponentModel;

using Entity;

namespace Presentation
{
    /// <summary>
    /// Lógica de interacción para HTCSession.xaml
    /// </summary>
    public partial class HTCSession : MetroWindow
    {
        Database DatabaseObject = new Database();
        List<ePlayer> PlayerList = new List<ePlayer>();
        List<ePlayer> HTCPlayerList = new List<ePlayer>();
        List<eHTCSessionPoints> HTCPlayerPoints = new List<eHTCSessionPoints>();
        List<eHTCSessionPointsHistory> HTCPlayerPointsHistory = new List<eHTCSessionPointsHistory>();
        List<eHTCSessionPointsHistory> UndoHTCPlayerPointsHistory = new List<eHTCSessionPointsHistory>();
        List<eHTCSessionPointsHistory> RedoHTCPlayerPointsHistory = new List<eHTCSessionPointsHistory>();
        List<eHTCPlayerHistoryFlag> HTCPlayerHistoryFlag = new List<eHTCPlayerHistoryFlag>();             

        public HTCSession()
        {
            InitializeComponent();
            ShowCloseButton = false;
            CenterWindowOnScreen();
            Bindcombox_Players();
            datagrd_ParticipatingPlayers.ItemsSource = HTCPlayerList;
            datagrd_PointsEarned.ItemsSource = HTCPlayerPoints;
            datagrd_History.ItemsSource = HTCPlayerPointsHistory;            
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

        public void Bindcombox_Players()
        {
            ePlayer Player = null;
            eRank Rank = null;

            string query = "SELECT p.ID, p.Name, r.Value, r.Rank, p.HTCPoints FROM Player p INNER JOIN Rank r ON p.Rank = r.Value ORDER BY p.HTCPoints DESC";
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
                }
            }
            DatabaseObject.DisconnectDB();
            combox_Players.ItemsSource = PlayerList;
            combox_Players.DisplayMemberPath = "Name";
            combox_Players.SelectedValuePath = "ID";
        }

        private void tile_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (combox_Players.SelectedItem != null && combox_Players.SelectedIndex != -1)
            {
                if (!HTCPlayerList.Exists(delegate (ePlayer value) { return value == (ePlayer)combox_Players.SelectedItem; }))
                {
                    ePlayer Player = new ePlayer();
                    Player = (ePlayer)combox_Players.SelectedItem;
                    HTCPlayerList.Add(Player);

                    eHTCSessionPoints SessionPoints = new eHTCSessionPoints();
                    SessionPoints.IDPlayer = Player.ID;
                    SessionPoints.Score = 0;
                    HTCPlayerPoints.Add(SessionPoints);

                    eHTCSessionPointsHistory SessionPointsHistory = new eHTCSessionPointsHistory();
                    SessionPointsHistory.IDPlayer = Player.ID;
                    SessionPointsHistory.Score = null;
                    HTCPlayerPointsHistory.Add(SessionPointsHistory);

                    eHTCPlayerHistoryFlag HistoryFlag = new eHTCPlayerHistoryFlag();
                    HistoryFlag.IDPlayer = Player.ID;
                    HistoryFlag.AllowUndo = false;
                    HistoryFlag.AllowRedo = false;
                    HTCPlayerHistoryFlag.Add(HistoryFlag);

                    eHTCSessionPointsHistory htcUndo = new eHTCSessionPointsHistory();
                    htcUndo.IDPlayer = Player.ID;
                    UndoHTCPlayerPointsHistory.Add(htcUndo);

                    eHTCSessionPointsHistory htcRedo = new eHTCSessionPointsHistory();
                    htcRedo.IDPlayer = Player.ID;
                    RedoHTCPlayerPointsHistory.Add(htcRedo);

                    datagrd_ParticipatingPlayers.Items.Refresh();
                    datagrd_PointsEarned.Items.Refresh();
                    datagrd_History.Items.Refresh();
                    combox_Players.SelectedIndex = -1;
                }
                else
                {
                    this.ShowMessageAsync("", combox_Players.SelectedItem.ToString() + " was already inserted.");
                    combox_Players.SelectedIndex = -1;
                }
            }
        }

        private void btn_AddHTCPoints_Click(object sender, RoutedEventArgs e)
        {
            if (datagrd_ParticipatingPlayers.SelectedIndex != -1 && (ePlayer)datagrd_ParticipatingPlayers.SelectedItem != null && txtbx_PointsEarned.Text != "")
            {
                eHTCSessionPointsHistory htc = new eHTCSessionPointsHistory();
                htc.IDPlayer = ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer;
                htc.Score = ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).Score;

                UndoHTCPlayerPointsHistory.Find(delegate (eHTCSessionPointsHistory value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).Score = htc.Score;

                HTCPlayerPoints.Find(delegate (eHTCSessionPoints value) { return value.IDPlayer == ((eHTCSessionPoints)datagrd_PointsEarned.SelectedItem).IDPlayer; }).Score += Convert.ToInt32(txtbx_PointsEarned.Text);                
                HTCPlayerPointsHistory.Find(delegate (eHTCSessionPointsHistory value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).Score = Convert.ToInt32(txtbx_PointsEarned.Text);
                HTCPlayerHistoryFlag.Find(delegate (eHTCPlayerHistoryFlag value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).AllowUndo = true;
                HTCPlayerHistoryFlag.Find(delegate (eHTCPlayerHistoryFlag value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).AllowRedo = false;

                datagrd_PointsEarned.Items.Refresh();
                datagrd_History.Items.Refresh();
                txtbx_PointsEarned.Text = "";
            }
            else if (txtbx_PointsEarned.Text == "")
            {
                this.ShowMessageAsync("Error", "Please insert a number of points.");
            }
            else
            {
                this.ShowMessageAsync("Error", "Please select a player.");
            }
        }

        private void datagrd_ParticipatingPlayers_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("ID"))
                e.Cancel = true;
            if (e.PropertyName.StartsWith("ParticipationPoints"))
                e.Cancel = true;
            if (e.PropertyName.StartsWith("FlagPayment"))
                e.Cancel = true;
            if (e.PropertyName.StartsWith("HTCPoints"))
            {
                e.Cancel = true;
            }
            if (e.PropertyName.StartsWith("Name"))
                e.Column.Width = 155;
            if (e.PropertyName.StartsWith("Rank"))
            {
                e.Column.Width = 135;
            }            
        }

        private void datagrd_PointsEarned_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("IDPlayer"))
            {
                e.Cancel = true;
            }
            if (e.PropertyName.StartsWith("Score"))
            {
                e.Column.Width = 58;
            }
        }

        private void datagrd_History_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.StartsWith("IDPlayer"))
            {
                e.Cancel = true;
            }
            if (e.PropertyName.StartsWith("Score"))
            {
                e.Column.Width = 95;
                e.Column.Header = "Last Round";
            }
        }

        private void datagrd_ParticipatingPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datagrd_PointsEarned.SelectedIndex = datagrd_ParticipatingPlayers.SelectedIndex;
            datagrd_History.SelectedIndex = datagrd_ParticipatingPlayers.SelectedIndex;
            Keyboard.Focus(txtbx_PointsEarned);
        }

        private void datagrd_PointsEarned_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datagrd_ParticipatingPlayers.SelectedIndex = datagrd_PointsEarned.SelectedIndex;
            Keyboard.Focus(txtbx_PointsEarned);
            datagrd_History.SelectedIndex = datagrd_PointsEarned.SelectedIndex;
        }

        private void datagrd_History_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datagrd_ParticipatingPlayers.SelectedIndex = datagrd_History.SelectedIndex;
            datagrd_PointsEarned.SelectedIndex = datagrd_History.SelectedIndex;
            Keyboard.Focus(txtbx_PointsEarned);
        }

        private async void tile_Atras_Click(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateShow = true,
                AnimateHide = false
            };

            var result = await this.ShowMessageAsync("Caution", "Are you sure you want to end this HTC session? The data will be automatically saved.", MessageDialogStyle.AffirmativeAndNegative, mySettings);
            bool _shutdown = result == MessageDialogResult.Affirmative;

            if (_shutdown)
            {
                if (HTCPlayerPoints.Count > 0)
                {
                    int MaxPoints = HTCPlayerPoints.Max(obj => obj.Score);

                    List<string> Winners = new List<string>();

                    foreach (eHTCSessionPoints item in HTCPlayerPoints)
                    {
                        if (item.Score == MaxPoints && item.Score > 0)
                        {
                            Winners.Add(HTCPlayerList.Find(delegate (ePlayer value) { return value.ID == item.IDPlayer; }).Name);
                        }
                    }

                    if (Winners.Count > 0)
                    {
                        await this.ShowMessageAsync("", string.Join(Environment.NewLine, Winners.Where(x => x != null)) + "\nwon this session.");
                    }
                    else
                    {
                        await this.ShowMessageAsync("Well, this is embarrassing...", "Nobody earned points! There is no winner.");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Well, this is embarrassing...", "Nobody earned points! There is no winner.");
                }

                foreach (eHTCSessionPoints item in HTCPlayerPoints)
                {
                    string query = "UPDATE Player SET HTCPoints = HTCPoints + @Score WHERE ID = @CPlayer";
                    SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);
                    DatabaseObject.ConnectDB();
                    cmd.Parameters.AddWithValue("@CPlayer", item.IDPlayer);
                    cmd.Parameters.AddWithValue("@Score", item.Score);
                    cmd.ExecuteNonQuery();
                    DatabaseObject.DisconnectDB();
                }

                HTC Form_HTC = new HTC();
                Form_HTC.Show();
                this.Close();
            }
        }

        private async void btn_ProclaimWinner_Click(object sender, RoutedEventArgs e)
        {
            if (HTCPlayerPoints.Count > 0)
            {
                int MaxPoints = HTCPlayerPoints.Max(obj => obj.Score);

                List<string> Winners = new List<string>();

                foreach (eHTCSessionPoints item in HTCPlayerPoints)
                {
                    if (item.Score == MaxPoints && item.Score > 0)
                    {
                        Winners.Add(HTCPlayerList.Find(delegate (ePlayer value) { return value.ID == item.IDPlayer; }).Name);
                    }
                }

                if (Winners.Count > 0)
                {
                    await this.ShowMessageAsync("", string.Join(Environment.NewLine, Winners.Where(x => x != null)) + "\nwon this session.");
                }
                else
                {
                    await this.ShowMessageAsync("Well, this is embarrassing...", "Nobody earned points! There is no winner.");
                }
            }
            else
            {
                await this.ShowMessageAsync("Well, this is embarrassing...", "Nobody earned points! There is no winner.");
            }
        }

        private void tile_Undo_Click(object sender, RoutedEventArgs e)
        {
            if (datagrd_ParticipatingPlayers.SelectedIndex != -1 && (eHTCSessionPointsHistory)datagrd_History.SelectedItem != null && datagrd_History.HasItems == true && HTCPlayerHistoryFlag.Find(delegate (eHTCPlayerHistoryFlag value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).AllowUndo == true)
            {
                eHTCSessionPointsHistory htc = new eHTCSessionPointsHistory();
                htc.IDPlayer = ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer;
                htc.Score = ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).Score;

                RedoHTCPlayerPointsHistory.Find(delegate (eHTCSessionPointsHistory value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).Score = htc.Score;

                ePlayer Player = new ePlayer();
                Player = (ePlayer)datagrd_ParticipatingPlayers.SelectedItem;                

                HTCPlayerHistoryFlag.Find(delegate (eHTCPlayerHistoryFlag value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).AllowUndo = false;
                HTCPlayerHistoryFlag.Find(delegate (eHTCPlayerHistoryFlag value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).AllowRedo = true;

                HTCPlayerPoints.Find(delegate (eHTCSessionPoints value) { return value.IDPlayer == ((eHTCSessionPoints)datagrd_PointsEarned.SelectedItem).IDPlayer; }).Score -= Convert.ToInt32(HTCPlayerPointsHistory.Find(delegate (eHTCSessionPointsHistory value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).Score);
                HTCPlayerPointsHistory.Find(delegate (eHTCSessionPointsHistory value) { return value.IDPlayer == Player.ID; }).Score = UndoHTCPlayerPointsHistory.Find(delegate (eHTCSessionPointsHistory value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).Score;
                datagrd_PointsEarned.Items.Refresh();
                datagrd_History.Items.Refresh();
            }
            else if (!datagrd_ParticipatingPlayers.HasItems)
            {
                this.ShowMessageAsync("Error", "There are no participating players.");
            }
            else if (HTCPlayerHistoryFlag.Find(delegate (eHTCPlayerHistoryFlag value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).AllowUndo == false)
            {
                this.ShowMessageAsync("Error", "No more undos allowed.");
            }
            else
            {
                this.ShowMessageAsync("Error", "Please select a player.");
            }
        }

        private void tile_Redo_Click(object sender, RoutedEventArgs e)
        {
            if (datagrd_ParticipatingPlayers.SelectedIndex != -1 && (eHTCSessionPointsHistory)datagrd_History.SelectedItem != null && datagrd_History.HasItems == true && HTCPlayerHistoryFlag.Find(delegate (eHTCPlayerHistoryFlag value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).AllowRedo == true)
            {
                ePlayer Player = new ePlayer();
                Player = (ePlayer)datagrd_ParticipatingPlayers.SelectedItem;

                HTCPlayerHistoryFlag.Find(delegate (eHTCPlayerHistoryFlag value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).AllowUndo = true;
                HTCPlayerHistoryFlag.Find(delegate (eHTCPlayerHistoryFlag value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).AllowRedo = false;

                HTCPlayerPoints.Find(delegate (eHTCSessionPoints value) { return value.IDPlayer == ((eHTCSessionPoints)datagrd_PointsEarned.SelectedItem).IDPlayer; }).Score += Convert.ToInt32(RedoHTCPlayerPointsHistory.Find(delegate (eHTCSessionPointsHistory value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).Score);
                HTCPlayerPointsHistory.Find(delegate (eHTCSessionPointsHistory value) { return value.IDPlayer == Player.ID; }).Score = RedoHTCPlayerPointsHistory.Find(delegate (eHTCSessionPointsHistory value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).Score;
                datagrd_PointsEarned.Items.Refresh();
                datagrd_History.Items.Refresh();
            }
            else if (!datagrd_ParticipatingPlayers.HasItems)
            {
                this.ShowMessageAsync("Error", "There are no participating players.");
            }
            else if (HTCPlayerHistoryFlag.Find(delegate (eHTCPlayerHistoryFlag value) { return value.IDPlayer == ((eHTCSessionPointsHistory)datagrd_History.SelectedItem).IDPlayer; }).AllowRedo == false)
            {
                this.ShowMessageAsync("Error", "No more redos allowed.");
            }
            else
            {
                this.ShowMessageAsync("Error", "Please select a player.");
            }
        }

        private void txtbx_PointsEarned_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 87);
        }
    }
}

