using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;



namespace Final
{
    public partial class AuthenticationPage : Form
    {
        public AuthenticationPage()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=LibraryDatabase;User ID=sa;Password=ab12AB34");

        private void AuthenticationPage_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel.BackColor = Color.Transparent;


        }

        public void LogIn()
        {
            conn.Open();
            String query = "Select * from LibrariansTable where LibrarianUsername=@LibrarianUsername AND LibrarianPassword=@LibrarianPassword";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);


            using (SqlCommand cmd = new SqlCommand("SELECT * FROM LibrariansTable WHERE  LibrarianUsername=@LibrarianUsername AND LibrarianPassword=@LibrarianPassword", conn))
            {
                cmd.Parameters.AddWithValue("@LibrarianUsername", txtUsername.Text);
                cmd.Parameters.AddWithValue("@LibrarianPassword", txtPassword.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    this.Hide();
                    MainApp mainApp= new MainApp();
                    mainApp.ShowDialog();
                    

                }
                else
                {
                    MessageBox.Show("Check Your Informations");

                }
            }
            conn.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn sign = new SignIn();
            this.Hide();
            sign.ShowDialog();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogIn();
            }
        }
    }
}
