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
    public partial class Class_Delete_Form : Form
    {
        public Class_Delete_Form()
        {
            InitializeComponent();

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=registration_db;user=root"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT section_id, course_name, section FROM section_table ORDER BY course_name ASC;", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();

                table.Load(reader);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    comboBox1.Items.Add(table.Rows[i]["course_name"] + " " + table.Rows[i]["section"] + "," + table.Rows[i]["section_id"]);
                }

                reader.Close();
                conn.Close();
            }
        }


        /* private void button1_Click(object sender, EventArgs e)
        {
           string connection = "server=localhost;database=registration_db;user=root";
            MySqlConnection conn = new MySqlConnection(connection);

            try
            {
                conn.Open();

                string section = comboBox1.Text;
                string[] part_section = section.Split(',');

                string query = $"DELETE FROM `section_table` WHERE `section_id` = {part_section[1]}";
                MessageBox.Show("You are about to delete section data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        } */

        /* private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        } */

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

        private void Class_Delete_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connection = "server=localhost;database=registration_db;user=root";
            MySqlConnection conn = new MySqlConnection(connection);

            try
            {
                conn.Open();

                string section = comboBox1.Text;
                string[] part_section = section.Split(',');

                string query = $"DELETE FROM `section_table` WHERE `section_id` = {part_section[1]}";
                MessageBox.Show("You are about to delete section data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
