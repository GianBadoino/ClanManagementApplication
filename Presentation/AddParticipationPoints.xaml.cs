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
    /// Lógica de interacción para AddParticipationPoints.xaml
    /// </summary>
    public partial class AddParticipationPoints : MetroWindow
    {
        Database DatabaseObject = new Database();
        ePlayer obj_Player = new ePlayer();
        int cnt = 0;
        public AddParticipationPoints(ePlayer Player)
        {
            InitializeComponent();
            CenterWindowOnScreen();

            obj_Player = Player;

            lbl_Name.Content = Player.Name;
            txtbx_Points.Text = cnt.ToString();
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

        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtbx_Points_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 87);
        }

        private void btn_PlussOne_Click(object sender, RoutedEventArgs e)
        {
            ++cnt;
            if (cnt <= 10)
            {
                string query = "UPDATE Player SET ParticipationPoints = ParticipationPoints + 1 WHERE ID = @ID";
                SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);

                DatabaseObject.ConnectDB();
                cmd.Parameters.AddWithValue("@ID", obj_Player.ID);

                cmd.ExecuteNonQuery();
                DatabaseObject.DisconnectDB();

                txtbx_Points.Text = cnt.ToString();
            }
            else
            {
                this.ShowMessageAsync("", obj_Player.Name + " has reached the point limit.");
            }
        }

        private void btn_MinusOne_Click(object sender, RoutedEventArgs e)
        {
            --cnt;
            string query = "UPDATE Player SET ParticipationPoints = ParticipationPoints - 1 WHERE ID = @ID";
            SQLiteCommand cmd = new SQLiteCommand(query, DatabaseObject.myConnection);

            DatabaseObject.ConnectDB();
            cmd.Parameters.AddWithValue("@ID", obj_Player.ID);

            cmd.ExecuteNonQuery();
            DatabaseObject.DisconnectDB();

            txtbx_Points.Text = cnt.ToString();
        }
    }
}
