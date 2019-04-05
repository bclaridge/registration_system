using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_System_Claridge
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student_Insert_Form sif = new Student_Insert_Form();
            sif.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher_Insert_Form tif = new Teacher_Insert_Form();
            tif.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class_Insert_Form cif = new Class_Insert_Form();
            cif.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Registration_Insert_Form rif = new Registration_Insert_Form();
            rif.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Student_Delete_Form sdf = new Student_Delete_Form();
            sdf.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Teacher_Delete_Form tdf = new Teacher_Delete_Form();
            tdf.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Class_Delete_Form cdf = new Class_Delete_Form();
            cdf.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Registration_Delete_Form rdf = new Registration_Delete_Form();
            rdf.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Student_Update_Form suf = new Student_Update_Form();
            suf.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Teacher_Update_Form tuf = new Teacher_Update_Form();
            tuf.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Class_Update_Form cuf = new Class_Update_Form();
            cuf.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Registration_Update_Form ruf = new Registration_Update_Form();
            ruf.Show();
        }
    }
}
