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
    public partial class Class_Update_Form : Form
    {
        public Class_Update_Form()
        {
            InitializeComponent();

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=registration_db;user=root"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT course_name, section, section_id FROM section_table ORDER BY course_name, section ASC;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(reader);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    comboBox1.Items.Add(table.Rows[i]["section_id"] + "," + table.Rows[i]["course_name"] + " " + table.Rows[i]["section"]);
                }

                reader.Close();
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

                string section_id = comboBox1.Text;
                string[] words = section_id.Split(',');
                string section_id_num = words[0];

                string teacher_id = comboBox2.Text;
                string[] words2 = teacher_id.Split(',');
                string teacher_id_num = words2[0];

                string query = $"UPDATE section_table SET teacher_id = '{teacher_id_num}', course_name = '{textBox1.Text}', section = '{textBox2.Text}', days = '{textBox3.Text}', start_time = '{textBox4.Text}', end_time = '{textBox5.Text}' WHERE section_id = {section_id_num};";
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

                string section_id = comboBox1.Text;
                string[] words = section_id.Split(',');
                string section_id_num = words[0];

                conn.Open();

                string query = $"SELECT * FROM section_table WHERE section_id = '{section_id_num}'";
                MessageBox.Show(query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(rdr);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    MessageBox.Show("Adding Section ID: " + table.Rows[i]["section_id"]);
                    comboBox2.Text = getTeacherIds(table.Rows[i]["teacher_id"].ToString());
                    textBox1.Text = table.Rows[i]["course_name"].ToString();
                    textBox2.Text = table.Rows[i]["section"].ToString();
                    textBox3.Text = table.Rows[i]["days"].ToString();
                    textBox4.Text = table.Rows[i]["start_time"].ToString();
                    textBox5.Text = table.Rows[i]["end_time"].ToString();
                }

                conn.Close();

            }




        }

        private string getTeacherIds(string current_id)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=registration_db;user=root"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT lname, fname, teacher_id FROM teacher_table ORDER BY lname, fname ASC;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(reader);

                if (comboBox2.Items.Count == 0)
                {

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        comboBox2.Items.Add(table.Rows[i]["teacher_id"] + ", " + table.Rows[i]["fname"] + " " + table.Rows[i]["lname"]);
                    }

                }

                reader.Close();

                MySqlCommand current = new MySqlCommand($"SELECT t.teacher_id, t.fname, t.lname, s.teacher_id FROM teacher_table as t, section_table as s WHERE t.teacher_id = s.teacher_id AND t.teacher_id = '{current_id}';", conn);
                MySqlDataReader reader_current = current.ExecuteReader();

                DataTable table_current = new DataTable();

                table_current.Load(reader_current);

                string teacher_id_db = table_current.Rows[0]["teacher_id"] + ", " + table_current.Rows[0]["fname"] + " " + table_current.Rows[0]["lname"];

                reader_current.Close();
                conn.Close();

                return teacher_id_db;
            }

        }
    

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
