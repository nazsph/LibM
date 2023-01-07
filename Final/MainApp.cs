using MetroFramework.Controls;
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
    public partial class MainApp : Form
    {
        public MainApp()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=LibraryDatabase;User ID=sa;Password=ab12AB34");
        private void MainApp_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'libraryDatabaseDataSet1.LibrariansTable' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.librariansTableTableAdapter.Fill(this.libraryDatabaseDataSet1.LibrariansTable);
            // TODO: Bu kod satırı 'libraryDatabaseDataSet1.BookTable' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.bookTableTableAdapter.Fill(this.libraryDatabaseDataSet1.BookTable);
            panel1.BackColor = Color.Transparent;
            panel.BackColor = Color.Transparent;
            tabPage1.BackColor = Color.PeachPuff;
            tabPage2.BackColor = Color.PeachPuff;
            tabPage3.BackColor = Color.PeachPuff;
            

        }

        public void ShowLibrarian()
        {
            conn.Open();
            String query = "Select * from LibrariansTable";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder(adp);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dgvLibrarian.DataSource = ds.Tables[0];

            conn.Close();
        }
        public void DeleteLibrarian()
        {
            conn.Open();
            String query = "delete from LibrariansTable where LibrarianID= '" + txtLibrarianID.Text + "' and LibrarianName= '" + txtLibrarianName.Text + "' and LibrarianLastName='" + txtLibrarianLastName.Text + "' ;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Account Deleted!");
            conn.Close();
            ShowLibrarian(); 
            txtSearch.Text = ""; txtBookName.Text = ""; txtBookAuthor.Text = ""; txtBookYear.Text = ""; txtBookCountry.Text = ""; txtBookPage.Text = ""; rbMale.Checked = false; rbFemale.Checked = false; cbBookGender.Text = "";
        }
        public void ChangePassword()
        {

            if (txtLibrarianPassword.Text == txtLibrarianPassword2.Text)
            {
                
                DialogResult res = MessageBox.Show("Are you sure you want to change your password?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    String query = "Update LibrariansTable set LibrarianPassword= '" + txtLibrarianPassword.Text + "' Where LibrarianID= '" + txtLibrarianID.Text + "' ";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password Changed");
                    conn.Close();
                    ShowLibrarian();
                }
                if (res == DialogResult.Cancel)
                {
                    
                }

            }
            else
            {
                MessageBox.Show("Check Passwords Again");
            }
           
        }
        public void ShowBook()
        {
            conn.Open();
            String query = "Select * from BookTable";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder(adp);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dgvSearchbar.DataSource = ds.Tables[0];
            dgvBookRegistiration.DataSource = ds.Tables[0];
            conn.Close();
        }
        public void Searchbar()
        {
            string keyword = txtSearch.Text;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM BookTable WHERE BookName LIKE '%" + keyword + "%' OR BookAuthor LIKE '%" + keyword + "%'  OR BookGender LIKE '%" + keyword + "%' OR BookCountry LIKE '%" + keyword + "%'   OR BookLanguage LIKE '%" + keyword + "%' OR BookYear LIKE '%" + keyword + "%' ", conn);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            dgvSearchbar.DataSource = dt;

        }
        public void AddBook()
        {
            try
            {
                if (txtBookPage.Text == "" || txtBookName.Text == "" || txtBookAuthor.Text == "" || txtBookYear.Text == "" || txtBookCountry.Text == "" || cbBookGender.Text == "")
                {
                    MessageBox.Show("Fill the blanks");
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into BookTable(BookName,BookAuthor,BookGender,BookYear,BookCountry,BookLanguage) values ('" + txtBookName.Text + "','" + txtBookAuthor.Text + "','" + cbBookGender.Text + "','" + txtBookYear.Text + "','" + txtBookCountry.Text + "','" + txtBookPage.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ShowBook();
                    txtBookPage.Text = ""; txtBookName.Text = ""; txtBookAuthor.Text = ""; txtBookYear.Text = ""; txtBookCountry.Text = ""; cbBookGender.Text = "";
                }
            }
            catch
            {
            }
        }
        public void UpdateBook()
        {
            String query = "Update BookTable set BookName=@BookName, BookAuthor=@BookAuthor,BookGender=@BookGender,BookYear=@BookYear,BookCountry=@BookCountry,BookLanguage=@BookLanguage Where BookName=@BookName";


            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BookName", txtBookName.Text);
            cmd.Parameters.AddWithValue("@BookAuthor", txtBookAuthor.Text);
            cmd.Parameters.AddWithValue("@BookGender", cbBookGender.Text);
            cmd.Parameters.AddWithValue("@BookYear", txtBookYear.Text);
            cmd.Parameters.AddWithValue("@BookCountry", txtBookCountry.Text);
            cmd.Parameters.AddWithValue("@BookLanguage", txtBookPage.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book Updated");
            conn.Close();
            ShowBook();
            txtBookName.Text = ""; txtBookAuthor.Text = ""; txtBookYear.Text = ""; txtBookCountry.Text = ""; txtBookPage.Text = ""; cbBookGender.Text = "";
        }
        public void DeleteBook()
        {
            conn.Open();
            String query = "delete from BookTable where BookName='" + txtBookName.Text + "' and BookAuthor= '" + txtBookAuthor.Text + "' and BookYear= '" + txtBookYear.Text + "' and BookGender= '" + cbBookGender.Text + "' and BookCountry= '" + txtBookCountry.Text + "' and BookLanguage= '" + txtBookPage.Text + "' ;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book Deleted!");
            conn.Close();
            ShowBook();
            txtBookName.Text = ""; txtBookAuthor.Text = ""; txtBookYear.Text = ""; txtBookCountry.Text = ""; txtBookPage.Text = "";
        }
        public void LogOut()
        {
            DialogResult res = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                AuthenticationPage page = new AuthenticationPage();
                this.Hide();
                page.ShowDialog();
            }
            if (res == DialogResult.Cancel)
            {
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Searchbar();
        }

        private void btnBookAdd_Click(object sender, EventArgs e)
        {
            AddBook();
        }

        private void btnBookUpdate_Click(object sender, EventArgs e)
        {
            UpdateBook();
        }

        private void btnBookDelete_Click(object sender, EventArgs e)
        {
            DeleteBook();
        }

        private void dgvBookRegistiration_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBookName.Text = dgvBookRegistiration.CurrentRow.Cells[0].Value.ToString();
            txtBookAuthor.Text = dgvBookRegistiration.CurrentRow.Cells[1].Value.ToString();
            cbBookGender.Text = dgvBookRegistiration.CurrentRow.Cells[2].Value.ToString();
            txtBookYear.Text = dgvBookRegistiration.CurrentRow.Cells[3].Value.ToString();
            txtBookCountry.Text = dgvBookRegistiration.CurrentRow.Cells[4].Value.ToString();
            txtBookPage.Text = dgvBookRegistiration.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnChangePw_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        private void btnLibDelete_Click(object sender, EventArgs e)
        {
            DeleteLibrarian();
        }

        private void dgvLibrarian_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLibrarianID.Text = dgvLibrarian.CurrentRow.Cells[0].Value.ToString();
            txtLibrarianName.Text = dgvLibrarian.CurrentRow.Cells[1].Value.ToString();
            txtLibrarianLastName.Text = dgvLibrarian.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Value = Convert.ToDateTime(dgvLibrarian.CurrentRow.Cells[4].Value.ToString());
            txtLibrarianUsername.Text = dgvLibrarian.CurrentRow.Cells[5].Value.ToString();
            txtLibrarianPassword.Text = dgvLibrarian.CurrentRow.Cells[6].Value.ToString();
            txtLibrarianPassword2.Text = dgvLibrarian.CurrentRow.Cells[6].Value.ToString();
            if (dgvLibrarian.CurrentRow.Cells[3].Value.ToString() == "Male")
            {
                rbMale.Checked = true;
                rbFemale.Checked = false;
            }
            else
            {
                rbFemale.Checked = true;
                rbMale.Checked = false;
            }
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
           LogOut();
        }

    }
}
