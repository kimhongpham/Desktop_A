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

namespace MEMORY_MATCH
{
    public partial class Record : Form
    {
        private MainOption mainoption;
        public Record(MainOption form)
        {
            InitializeComponent();
            this.mainoption = form;
        }

        private void btn_exit_record_Click(object sender, EventArgs e)
        {
            mainoption.EventClick();
            mainoption.SetButtonClickedStatus(false);
            Close();
        }

        private void lbl_score_Click(object sender, EventArgs e)
        {
            
        }

        private void Record_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = admin___tke.Kết_nối.getConnection())
            {
                sqlConnection.Open();
                // Lấy ra điểm số cao nhất (MaxScore) từ bảng GameSessions ứng với GameID=1
                string getMaxScoreQuery = "SELECT MAX(Score) FROM GameSessions WHERE GameID = 1";
                using (SqlCommand command = new SqlCommand(getMaxScoreQuery, sqlConnection))
                {
                    object maxScoreResult = command.ExecuteScalar();
                    int maxScore = maxScoreResult != DBNull.Value ? Convert.ToInt32(maxScoreResult) : 0;
                    lbl_score.Text = " Score: " + maxScore;
                    lbl_level.Text = "Score: 3";
                }

                sqlConnection.Close();
            }
        }
    }
}
