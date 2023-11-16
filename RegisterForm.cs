using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileCreate
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verifications First
            try
            {
                // This section checks if all of the textbox have no valid input

                if (string.IsNullOrEmpty(studNoTB.Text))
                {
                    error.Text = "Student Number cannot be empty";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (progrmTB.SelectedItem == null)
                {
                    error.Text = "Select your Program";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (string.IsNullOrEmpty(lnameTB.Text))
                {
                    error.Text = "Enter your Last Name";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (string.IsNullOrEmpty(fnameTB.Text))
                {
                    error.Text = "Enter your First Name";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (string.IsNullOrEmpty(miniTB.Text))
                {
                    error.Text = "Enter your Middle Name";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (string.IsNullOrEmpty(ageTB.Text))
                {
                    error.Text = "Enter your Age";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (string.IsNullOrEmpty(miniTB.Text))
                {
                    error.Text = "Enter your Middle Name";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (string.IsNullOrEmpty(ageTB.Text))
                {
                    error.Text = "Enter your Age";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (ageTB.Text.Any(char.IsLetter))
                {
                    error.Text = "Age Cannot contain letters";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (gendTB.SelectedItem == null)
                {
                    error.Text = "Select your Gender";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (string.IsNullOrEmpty(contTB.Text))
                {
                    error.Text = "Enter your Contact Number";
                    error.ForeColor = Color.Red;
                    return;
                }

                // Short Names
                if (lnameTB.Text.Length > 15)
                {
                    error.Text = "Last Name is too long";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (fnameTB.Text.Length > 15)
                {
                    error.Text = "First Name is too long";
                    error.ForeColor = Color.Red;
                    return;
                }

                if (miniTB.Text.Length > 2)
                {
                    error.Text = "Middle Initial is too long";
                    error.ForeColor = Color.Red;
                    return;
                }


                // Symbols
                if (Regex.IsMatch(lnameTB.Text, "[0-9]+$"))
                {
                    error.Text = "Last Name cannot contain any number or Symbol!";
                    error.ForeColor = Color.Red;
                    return;
                }
                if (Regex.IsMatch(fnameTB.Text, "[0-9]+$"))
                {
                    error.Text = "First Name cannot contain any number or Symbol!";
                    error.ForeColor = Color.Red;
                    return;
                }
                if (Regex.IsMatch(miniTB.Text, "[0-9]"))
                {
                    error.Text = "Middle Initial cannot contain any number or Symbol!";
                    error.ForeColor = Color.Red;
                    return;
                }
                if (Regex.IsMatch(contTB.Text, "[a-zA-Z\\W_]+$"))
                {
                    error.Text = "Contact Number cannot contain any letter or Symbol!";
                    error.ForeColor = Color.Red;
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }

            // Path can be changed depends on the user preference
            // You can find this on this file folder (TextFileCreate\bin\Debug) likely in the bin Debug File
            string txtFilePath = "./FilesHere";

            // Note you may also use this Example here
            // string txtFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string txtFileName = fileNameTB.Text + ".txt";
            if (string.IsNullOrEmpty(txtFileName))
            {
                error.Text = "Enter a File name";
                return;
            }
            string sNum = studNoTB.Text;
            string fullName = fnameTB.Text + " " + miniTB.Text + " " + lnameTB.Text;
            string program = progrmTB.Text;
            string gender = gendTB.Text;
            string ages = ageTB.Text;
            string bday = dtPick.Value.ToString("yyyy-mm-dd");
            string contact = contTB.Text;

            string output = "Student No.: " + sNum +
                "\nFullname: " + fullName + 
                "\nProgram: " + program +
                "\nGender: " + gender +
                "\nAge: " + ages +
                "\nBirthday: " + bday +
                "\nContact Number: " + contact;

            // When there is no longer an error this runs
            error.Text = "Regisreted!";
            error.ForeColor = Color.Green;
            using (StreamWriter outputName = new StreamWriter(Path.Combine(txtFilePath, txtFileName)))
            {
                outputName.Write(output);
            };

            // Clears all the textbox and combo box
            studNoTB.Text = "";
            fnameTB.Text = "";
            miniTB.Text= ""; 
            lnameTB.Text = "";
            progrmTB.SelectedIndex = -1;
            gendTB.SelectedIndex = -1;
            ageTB.Text = "";
            contTB.Text = "";
        }

        private void fileNameTB_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileNameTB.Text))
            {
                error.Text = "Enter a File name";
                error.ForeColor = Color.Red;
            }
            else if (fileNameTB.Text.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                error.Text = "Cannot use special characters";
                error.ForeColor = Color.Red;
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            string[] ListOfGender = new string[]
            {
                "Male",
                "Female"
            };

            for (int i = 0; i < 6; i++)
            {
                progrmTB.Items.Add(ListOfProgram[i].ToString());
            }
            for (int i = 0; i < 2; i++)
            {
                gendTB.Items.Add(ListOfGender[i].ToString());
            }
        }
    }
}
