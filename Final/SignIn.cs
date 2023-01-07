using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=LibraryDatabase;User ID=sa;Password=ab12AB34");

        private void SignIn_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            String Gender;
            if (rbMale.Checked == true)
            {
                Gender = "Male";
            }
            else
            {
                Gender = "Female";
            }
            if (txtID.Text == "" || txtName.Text == "" || txtLastName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtPwAgain.Text == "" || (rbMale.Checked == false && rbFemale.Checked == false))
            {
                MessageBox.Show("Fill the blanks");
                if (txtPassword.Text != txtPwAgain.Text)
                {
                    MessageBox.Show("Check Your Password Again!");
                    
                    

                }
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into LibrariansTable(LibrarianID,LibrarianName,LibrarianLastName,LibrarianGender,LibrarianDOB,LibrarianUsername,LibrarianPassword) values ('" + txtID.Text + "','" + txtName.Text + "','" + txtLastName.Text + "','" + Gender + "','" + dateTimePicker2.Value + "','" + txtUsername.Text + "','" + txtPassword.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account succesfully created");
                conn.Close();
                txtID.Text = ""; txtName.Text = ""; txtLastName.Text = ""; txtUsername.Text = ""; txtPassword.Text = ""; txtPwAgain.Text = "";

                AuthenticationPage page = new AuthenticationPage();
                MainApp main = new MainApp();
                this.Hide();
                page.Hide();

                main.ShowDialog();

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuthenticationPage page = new AuthenticationPage();
            this.Hide();
            page.ShowDialog();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPwAgain.Text)
            {
                errorProvider1.SetError(txtPwAgain, "Check your passwords");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtPwAgain_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPwAgain.Text)
            {
                errorProvider1.SetError(txtPwAgain, "Check your passwords");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text.Length>11)
            {
                errorProvider2.SetError(txtID, "Less Character Needed");
            }
            else if (txtID.Text.Length < 11)
            {
                errorProvider2.SetError(txtID, "More Character Needed");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }


    }
}
