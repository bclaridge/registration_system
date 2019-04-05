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
    public partial class Student_Update_Form : Form
    {
        public Student_Update_Form()
        {
            InitializeComponent();

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=registration_db;user=root"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT lname, fname, student_id FROM student_table ORDER BY lname, fname ASC;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(reader);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    comboBox1.Items.Add(table.Rows[i]["student_id"] + "," + table.Rows[i]["fname"] + " " + table.Rows[i]["lname"]);
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

                string student_id = comboBox1.Text;
                string[] words = student_id.Split(',');
                string student_id_num = words[0];

                string query2 = $"UPDATE student_table SET fname = '{textBox1.Text}', lname = '{textBox2.Text}', major = '{textBox3.Text}', degree = '{textBox4.Text}' WHERE student_id = {student_id_num};";
                MessageBox.Show(query2);
                MySqlCommand cmd = new MySqlCommand(query2, conn);
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

                string student_id = comboBox1.Text;
                string[] words = student_id.Split(',');
                string student_id_num = words[0];

                conn.Open();

                string query = $"SELECT * FROM student_table WHERE student_id = '{student_id_num}'";
                MessageBox.Show(query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(rdr);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    MessageBox.Show("Adding Student ID: " + table.Rows[i]["student_id"]);
                    textBox1.Text = table.Rows[i]["fname"].ToString();
                    textBox2.Text = table.Rows[i]["lname"].ToString();
                    textBox3.Text = table.Rows[i]["major"].ToString();
                    textBox4.Text = table.Rows[i]["degree"].ToString();
                }

                conn.Close();

            }




            }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
