using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login_with_Database
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();

        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source = DESKTOP-71Q98DC; Initial Catalog = LoginScreen; Integrated Security = True";
        }

        private void tbUserEnter(object sender, EventArgs e)
        {
            if (tbUsername.Text.Equals(@"Username / Email"))
            {
                tbUsername.Text = "";
            }
        }

        private void tbUserLeave(object sender, EventArgs e)
        {
            if (tbUsername.Text.Equals(""))
            {
                tbUsername.Text = @"Username / Email";
            }
        }

        private void tbPassEnter(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals("Password"))
            {
                tbPassword.Text = "";
            }
        }

        private void tbPassLeave(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals(""))
            {
                tbPassword.Text = "Password";
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Authorization";
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                if (tbUsername.Text.Equals(dr["username"].ToString()) && tbPassword.Text.Equals(dr["password"].ToString()))
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            con.Close();
        }
    }
}
