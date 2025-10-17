using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateFile_Fangon
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                string fileName = txtStudentNo.Text.Trim() + ".txt";
                string fullPath = Path.Combine(docPath, fileName);

                string studentNo = txtStudentNo.Text.Trim();
                string fullName = $"{txtLastName.Text.Trim()}, {txtFirstName.Text.Trim()}, {txtMiddleName.Text.Trim()}";
                string program = cmbProgram.Text;
                string gender = cmbGender.Text;
                string age = txtAge.Text.Trim();
                string birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");
                string contactNo = txtContactNo.Text.Trim();

                string[] lines =
                {
                    $"Student No.: {studentNo}",
                    $"Full Name: {fullName}",
                    $"Program: {program}",
                    $"Gender: {gender}",
                    $"Age: {age}",
                    $"Birthday: {birthday}",
                    $"Contact No.: {contactNo}"
                };

                using (StreamWriter outputFile = new StreamWriter(fullPath))
                {
                    foreach (string line in lines)
                    {
                        outputFile.WriteLine(line);
                    }
                }

                MessageBox.Show($"Registration saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
