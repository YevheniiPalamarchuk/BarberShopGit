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

namespace Barber
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lbLogin.ForeColor = Color.DarkRed;
            lbPassword.ForeColor = Color.DarkRed;
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == String.Empty)
            {
                MessageBox.Show("Wprowadź login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
                return;
            }
            if (txtPassword.Text == String.Empty)
            {
                MessageBox.Show("Wprodwadź Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            int klient_id = 0;
            String klient_login = txtLogin.Text.Trim();
            String klient_password = txtPassword.Text.Trim();

            Boolean flKlient = false;

            try
            {
                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(String.Format(@"
select klient_id 
from klient
where klient_login=@klient_login and klient_password=@klient_password
", klient_login, klient_password), con);
                    cmd.Parameters.Add("@klient_login", SqlDbType.Char);
                    cmd.Parameters.Add("@klient_password", SqlDbType.Char);
                    cmd.Parameters["@klient_login"].Value = klient_login;
                    cmd.Parameters["@klient_password"].Value = klient_password;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        flKlient = true;
                        klient_id = reader.GetInt32(0);
                    }
                    if (flKlient)
                    {
                        Program.pbKlient = null;
                        Program.pbKlient = new Program.KLIENT(klient_id);
                    }
                    con.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException error)
            {
                if (error.Source != null)
                {
                    MessageBox.Show(String.Format(@"Error DataBase!!! 
{0}", error.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (flKlient)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(String.Format(@"Nie znaleziono takiego loginu!!!"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
                return;
            }
        }
    }
}
