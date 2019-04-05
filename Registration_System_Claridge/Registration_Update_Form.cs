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
    public partial class Registration_Update_Form : Form
    {
        public Registration_Update_Form()
        {
            InitializeComponent();

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=registration_db;user=root"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT r.student_id, r.section_id, r.registration_id, r.grade_earned, s.section_id, s.course_name, s.section FROM registration_table as r, section_table as s WHERE r.section_id = s.section_id ORDER BY r.registration_id DESC;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(reader);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    comboBox1.Items.Add(table.Rows[i]["registration_id"] + "," + table.Rows[i]["course_name"] + " " + table.Rows[i]["section"]);
                }

                reader.Close();
                conn.Close();
            }

            /* populate grade earned box using a plus-minus system */

            comboBox4.Items.Add("");
            comboBox4.Items.Add("A");
            comboBox4.Items.Add("A-");
            comboBox4.Items.Add("B+");
            comboBox4.Items.Add("B");
            comboBox4.Items.Add("B-");
            comboBox4.Items.Add("C+");
            comboBox4.Items.Add("C");
            comboBox4.Items.Add("C-");
            comboBox4.Items.Add("D+");
            comboBox4.Items.Add("D");
            comboBox4.Items.Add("D-");
            comboBox4.Items.Add("F");


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

                string registration_id = comboBox1.Text;
                string[] words = registration_id.Split(',');
                string registration_id_num = words[0];

                string student_id = comboBox2.Text;
                string[] words2 = student_id.Split(',');
                string student_id_num = words2[0];

                string section_id = comboBox3.Text;
                string[] words3 = section_id.Split(',');
                string section_id_num = words3[0];

                string query = $"UPDATE registration_table SET student_id = '{student_id_num}', section_id = '{section_id_num}', grade_earned = '{comboBox4.Text}' WHERE registration_id = '{registration_id_num}';";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=registration_db;user=root"))
            {
                // code to retrieve information from database will go here

                string registration_id = comboBox1.Text;
                string[] words = registration_id.Split(',');
                string registration_id_num = words[0];

                string student_id = comboBox2.Text;
                string[] words2 = student_id.Split(',');
                string student_id_num = words2[0];

                string section_id = comboBox3.Text;
                string[] words3 = section_id.Split(',');
                string section_id_num = words3[0];

                conn.Open();

                string query = $"SELECT * FROM registration_table WHERE registration_id = '{registration_id_num}'";
                MessageBox.Show(query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(rdr);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    MessageBox.Show("Adding Registration ID: " + table.Rows[i]["section_id"]);
                    comboBox2.Text = getStudentIds(table.Rows[i]["student_id"].ToString());
                    comboBox3.Text = getSectionIds(table.Rows[i]["section_id"].ToString());
                    comboBox4.Text = table.Rows[i]["grade_earned"].ToString();
                }

                conn.Close();

            }




        }

        private string getStudentIds(string current_id)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=registration_db;user=root"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT lname, fname, student_id FROM student_table ORDER BY lname, fname ASC;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(reader);

                if (comboBox2.Items.Count == 0)
                {

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        comboBox2.Items.Add(table.Rows[i]["student_id"] + ", " + table.Rows[i]["fname"] + " " + table.Rows[i]["lname"]);
                    }

                }

                reader.Close();

                MySqlCommand current = new MySqlCommand($"SELECT s.student_id, s.fname, s.lname, r.student_id FROM student_table as s, registration_table as r WHERE s.student_id = r.student_id AND s.student_id = '{current_id}';", conn);
                MySqlDataReader reader_current = current.ExecuteReader();

                DataTable table_current = new DataTable();

                table_current.Load(reader_current);

                string student_id_db = table_current.Rows[0]["student_id"] + ", " + table_current.Rows[0]["fname"] + " " + table_current.Rows[0]["lname"];

                reader_current.Close();
                conn.Close();

                return student_id_db;
            }

        }

        private string getSectionIds(string current_id)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=registration_db;user=root"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT course_name, section, section_id FROM section_table ORDER BY course_name, section ASC;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(reader);

                if (comboBox3.Items.Count == 0)
                {

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        comboBox3.Items.Add(table.Rows[i]["section_id"] + ", " + table.Rows[i]["course_name"] + " " + table.Rows[i]["section"]);
                    }

                }

                reader.Close();

                MySqlCommand current = new MySqlCommand($"SELECT s.section_id, s.course_name, s.section, r.section_id FROM section_table as s, registration_table as r WHERE s.section_id = r.section_id AND s.section_id = '{current_id}';", conn);
                MySqlDataReader reader_current = current.ExecuteReader();

                DataTable table_current = new DataTable();

                table_current.Load(reader_current);

                string section_id_db = table_current.Rows[0]["section_id"] + ", " + table_current.Rows[0]["course_name"] + " " + table_current.Rows[0]["section"];

                reader_current.Close();
                conn.Close();

                return section_id_db;
            }

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
