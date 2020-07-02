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

using Entity;
using MahApps.Metro.Controls.Dialogs;

namespace Presentation
{
    /// <summary>
    /// Lógica de interacción para AddEditPlayer.xaml
    /// </summary>
    public partial class AddEditPlayer : MetroWindow
    {
        Database DatabaseObject = new Database();
        List<eRank> RankList = new List<eRank>();
        DateTime localDate;
        ePlayer obj_Player = new ePlayer();
        bool Add;
        public AddEditPlayer()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            LoadRankCombobox();
            Title = "Add Player";
            btn_AddEdit.Content = "Register";
            Add = true;
            combox_Rank.SelectedIndex = 1;
            localDate = DateTime.Now;
            txtbx_YY.Text = localDate.Year.ToString();
            txtbx_MM.Text = localDate.Month.ToString();
            txtbx_DD.Text = localDate.Day.ToString();
            txtbx_Name.Focus();
            Keyboard.Focus(txtbx_Name);
        }

        public AddEditPlayer(ePlayer Player)
        {
            InitializeComponent();
            CenterWindowOnScreen();
            LoadRankCombobox();

            Title = "Edit Player";
            btn_AddEdit.Content = "Edit";
            Add = false;

            obj_Player = Player;
            
            txtbx_Name.Text = Player.Name;
            combox_Rank.SelectedIndex = Player.Rank.Value - 1;
            txtbx_ParticipationPoints.Text = Player.ParticipationPoints.ToString();
            txtbx_HTCPoints.Text = Player.HTCPoints.ToString();

            txtbx_YY.Text = Player.JoinDate.Year.ToString();
            txtbx_MM.Text = Player.JoinDate.Month.ToString();
            txtbx_DD.Text = Player.JoinDate.Day.ToString();
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

        private async void btn_AddEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Add == true)
            {
                if (txtbx_Name.Text != "" && combox_Rank.SelectedIndex != -1 && txtbx_HTCPoints.Text != "" && txtbx_ParticipationPoints.Text != "" && txtbx_YY.Text != "" && txtbx_MM.Text != "" && txtbx_DD.Text != "")
                {
                    DateTime temp;
                    string DateString = txtbx_YY.Text + "/" + txtbx_MM.Text + "/" + txtbx_DD.Text;

                    if (DateTime.TryParse(DateString, out temp))
                    {
                        obj_Player = new ePlayer();

                        string query = "INSERT INTO Player (Name, Rank, HTCPoints, ParticipationPoints, JoinDate) VALUES (@Name, @Rank, @HTCPoints, @ParticipationPoints, @JoinDate)";
                        SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);

                        DatabaseObject.ConnectDB();
                        cmd.Parameters.AddWithValue("@Name", txtbx_Name.Text);
                        cmd.Parameters.AddWithValue("@Rank", ((eRank)combox_Rank.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@HTCPoints", Convert.ToInt32(txtbx_HTCPoints.Text));
                        cmd.Parameters.AddWithValue("@ParticipationPoints", Convert.ToInt32(txtbx_ParticipationPoints.Text));
                        cmd.Parameters.AddWithValue("@JoinDate", DateString);


                        cmd.ExecuteNonQuery();
                        DatabaseObject.DisconnectDB();

                        await this.ShowMessageAsync("", "Player successfully inserted.");
                        txtbx_Name.Clear();
                        combox_Rank.SelectedIndex = 0;
                        txtbx_HTCPoints.Text = "0";
                        txtbx_ParticipationPoints.Text = "0";
                        txtbx_YY.Text = localDate.Year.ToString();
                        txtbx_MM.Text = localDate.Month.ToString();
                        txtbx_DD.Text = localDate.Day.ToString();
                        Keyboard.Focus(txtbx_Name);
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "Invalid date.");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Error", "There's one or more empty textboxes.");
                }
            }
            else
            {
                if (txtbx_Name.Text != "" && combox_Rank.SelectedIndex != -1 && txtbx_HTCPoints.Text != "" && txtbx_ParticipationPoints.Text != "" && txtbx_YY.Text != "" && txtbx_MM.Text != "" && txtbx_DD.Text != "")
                {
                    DateTime temp;
                    string DateString = txtbx_YY.Text + "/" + txtbx_MM.Text + "/" + txtbx_DD.Text;

                    if (DateTime.TryParse(DateString, out temp))
                    {
                        string query = "UPDATE Player SET Name = @Name, Rank = @Rank, HTCPoints = @HTCPoints, ParticipationPoints = @ParticipationPoints, JoinDate = @JoinDate WHERE ID = @ID";
                        SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);

                        DatabaseObject.ConnectDB();
                        cmd.Parameters.AddWithValue("@ID", obj_Player.ID);
                        cmd.Parameters.AddWithValue("@Name", txtbx_Name.Text);
                        cmd.Parameters.AddWithValue("@Rank", ((eRank)combox_Rank.SelectedItem).Value);
                        cmd.Parameters.AddWithValue("@HTCPoints", Convert.ToInt32(txtbx_HTCPoints.Text));
                        cmd.Parameters.AddWithValue("@ParticipationPoints", Convert.ToInt32(txtbx_ParticipationPoints.Text));
                        cmd.Parameters.AddWithValue("@JoinDate", DateString);

                        cmd.ExecuteNonQuery();
                        DatabaseObject.DisconnectDB();

                        await this.ShowMessageAsync("", "Player successfully edited.");

                        Close();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "Invalid date.");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Error", "There's one or more empty textboxes.");
                }
            }
        }

        private void LoadRankCombobox()
        {            
            eRank Rank = null;

            string query = "SELECT * FROM Rank ORDER BY Value ASC";
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

                    RankList.Add(Rank);
                }
            }
            DatabaseObject.DisconnectDB();
            combox_Rank.ItemsSource = RankList;
            combox_Rank.DisplayMemberPath = "Rank";
            combox_Rank.SelectedValuePath = "Value";
        }

        private void txtbx_ParticipationPoints_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 87);
        }

        private void txtbx_HTCPoints_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 87);
        }

        private void txtbx_YY_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2);
        }

        private void txtbx_MM_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2);
        }

        private void txtbx_DD_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2);
        }
    }
}
