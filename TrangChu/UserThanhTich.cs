using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Gaming_Dashboard
{
    public partial class UserThanhTich : UserControl
    {
        public UserThanhTich()
        {
            InitializeComponent();
        }
        private static UserThanhTich _instance;
        public static UserThanhTich Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserThanhTich();
                return _instance;
            }
        }

        public void DisplayHighestScores(string username)
        {
            // Create a connection to the database
            string connectionString = "Data Source=ROSIE-PHAM\\SQLEXPRESS;Initial Catalog=game_databaseA;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a command to retrieve the user's highest scores from the database
                string selectCommand = "SELECT g.GameName, MAX(gs.Score) as HighestScore FROM GameSessions gs JOIN Users u ON gs.UserID = u.UserID JOIN UserGames ug ON gs.GameID = ug.GameID JOIN Games g ON gs.GameID = g.GameID WHERE u.UserName = @UserName GROUP BY g.GameName ORDER BY HighestScore DESC";
                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    // Set the parameter value for the command
                    command.Parameters.AddWithValue("@UserName", username);

                    // Execute the command and retrieve the results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear the guna2Panel controls before displaying the new results
                        guna2Panel9.Controls.Clear();
                        guna2Panel2.Controls.Clear();
                        guna2Panel3.Controls.Clear();

                        // Add the results to the guna2Panel controls
                        int panelIndex = 0;
                        while (reader.Read())
                        {
                            // Create a new label for the game name and score
                            Label gameLabel = new Label();
                            gameLabel.Text = $"{reader["GameName"]}: {reader["HighestScore"]}";
                            gameLabel.AutoSize = true;
                            gameLabel.Location = new Point(10, 10 + (panelIndex * 20));

                            // Add the label to the appropriate guna2Panel control
                            switch (panelIndex)
                            {
                                case 0:
                                    guna2Panel9.Controls.Add(gameLabel);
                                    break;
                                case 1:
                                    guna2Panel2.Controls.Add(gameLabel);
                                    break;
                                case 2:
                                    guna2Panel3.Controls.Add(gameLabel);
                                    break;
                            }

                            // Increment the panel index
                            panelIndex++;
                        }
                    }
                }
            }
        }
    }
}