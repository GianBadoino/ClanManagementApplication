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
    /// Lógica de interacción para Payments.xaml
    /// </summary>
    public partial class Payments : MetroWindow
    {
        Database DatabaseObject = new Database();
        List<ePlayer> PlayerList = new List<ePlayer>();
        ePlayer obj_Player = new ePlayer();
        ePlayer Player = null;
        public Payments(ePlayer Player)
        {
            InitializeComponent();
            CenterWindowOnScreen();

            obj_Player = Player;

            lbl_Name.Content = Player.Name;
            GetFlagPayment();
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
        
        private void GetFlagPayment()
        {
            string query = "SELECT FlagPayment FROM Player WHERE ID = @ID";
            SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);
            DatabaseObject.ConnectDB();
            cmd.Parameters.AddWithValue("@ID", obj_Player.ID);
            SQLiteDataReader Reader = cmd.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Player = new ePlayer();
                    if (Convert.ToInt32(Reader["FlagPayment"]) == 1)
                    {
                        Player.FlagPayment = "Yes";
                    }
                    else
                    {
                        Player.FlagPayment = "No";
                    }
                }
            }

            if (Player.FlagPayment == "Yes")
            {
                rdbtn_Yes.IsChecked = true;
            }
            else
            {
                rdbtn_No.IsChecked = true;
            }
        }

        private async void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rdbtn_Yes.IsChecked)
            {
                string query = "UPDATE Player SET FlagPayment = 1 WHERE ID = @ID";
                SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);

                DatabaseObject.ConnectDB();
                cmd.Parameters.AddWithValue("@ID", obj_Player.ID);

                cmd.ExecuteNonQuery();
                DatabaseObject.DisconnectDB();

                await this.ShowMessageAsync("", "Player successfully edited.");

                Close();
            }
            else
            {
                string query = "UPDATE Player SET FlagPayment = 0 WHERE ID = @ID";
                SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);

                DatabaseObject.ConnectDB();
                cmd.Parameters.AddWithValue("@ID", obj_Player.ID);

                cmd.ExecuteNonQuery();
                DatabaseObject.DisconnectDB();

                await this.ShowMessageAsync("", "Player successfully edited.");

                Close();
            }
        }
    }
}
