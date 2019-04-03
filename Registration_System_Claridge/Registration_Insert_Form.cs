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
    public partial class Registration_Insert_Form : Form
    {
        public Registration_Insert_Form()
        {
            InitializeComponent();

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=registration_db;user=root"))
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT student_id, fname, lname FROM student_table ORDER BY lname ASC;", conn);
                MySqlDataReader reader1 = cmd1.ExecuteReader();

                DataTable table1 = new DataTable();

                table1.Load(reader1);

                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    comboBox1.Items.Add(table1.Rows[i]["fname"] + " " + table1.Rows[i]["lname"] + "," + table1.Rows[i]["student_id"]);
                }

                reader1.Close();

                MySqlCommand cmd2 = new MySqlCommand("SELECT section_id, course_name, section FROM section_table ORDER BY course_name ASC;", conn);
                MySqlDataReader reader2 = cmd2.ExecuteReader();

                DataTable table2 = new DataTable();

                table2.Load(reader2);

                for (int i = 0; i < table2.Rows.Count; i++)
                {
                    comboBox2.Items.Add(table2.Rows[i]["course_name"] + "-" + table2.Rows[i]["section"] + "," + table2.Rows[i]["section_id"]);
                }

                reader2.Close();

                conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;database=registration_db;user=root";
            MySqlConnection conn = new MySqlConnection(connection);

            try
            {
                conn.Open();

                // split strings
                string student = comboBox1.Text;
                string[] part_student = student.Split(',');
                string section = comboBox2.Text;
                string[] part_section = section.Split(',');

                string query = $"INSERT INTO `registration_table` (`registration_id`,`student_id`,`section_id`,`date_registered`,`grade_earned`) VALUES (NULL, '{part_student[1]}', '{part_section[1]}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', NULL);";
                MessageBox.Show(query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int numRowsAffected = cmd.ExecuteNonQuery();
                long lastInserted = cmd.LastInsertedId;

                if (numRowsAffected >= 1)
                {
                    MessageBox.Show("Success! \nRows: " + numRowsAffected + "\nID Entered: " + lastInserted);
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
