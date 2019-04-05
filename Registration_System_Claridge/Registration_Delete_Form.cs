using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Registration_System_Claridge
{
    public partial class Registration_Delete_Form : Form
    {
        public Registration_Delete_Form()
        {
            InitializeComponent();

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=registration_db;user=root"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT st.student_id, st.fname, st.lname, r.registration_id, se.section_id, se.course_name, se.section FROM student_table as st, registration_table as r, section_table as se WHERE st.student_id = r.student_id AND se.section_id = r.section_id ORDER BY st.lname ASC;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(reader);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    comboBox1.Items.Add(table.Rows[i]["course_name"] + " " + table.Rows[i]["section"] + "; " + table.Rows[i]["fname"] + " " + table.Rows[i]["lname"] + " ," + table.Rows[i]["registration_id"]);
                }

                reader.Close();
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;database=registration_db;user=root";
            MySqlConnection conn = new MySqlConnection(connection);

            try
            {
                conn.Open();

                string reg = comboBox1.Text;
                string[] part_reg = reg.Split(',');

                string query = $"DELETE FROM `registration_table` WHERE `registration_id` = {part_reg[1]}";
                MessageBox.Show("You are about to delete registration data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int numRowsAffected = cmd.ExecuteNonQuery();

                if (numRowsAffected >= 1)
                {
                    MessageBox.Show("Success! \nRows: " + numRowsAffected);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
