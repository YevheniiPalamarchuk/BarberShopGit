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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Proszę wpisać Imie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtLogin.Text == String.Empty)
            {
                MessageBox.Show("Proszę wpisać Login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
                return;
            }
            if (txtPassword.Text == String.Empty)
            {
                MessageBox.Show("Proszę wpisać Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if (txtConfirm.Text == String.Empty)
            {
                MessageBox.Show("Proszę wpisać Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirm.Focus();
                return;
            }
            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Password oraz Confirm Password są różne", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirm.Focus();
                return;
            }

            String klient_name = txtName.Text.Trim();
            String klient_email = txtEmail.Text.Trim();
            String klient_phone = txtPhone.Text.Trim();
            String klient_login = txtLogin.Text.Trim();
            String klient_password = txtPassword.Text.Trim();

            //CHECK LOGIN
            Boolean flLogin = false;
            try
            {
                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(String.Format(@"
select klient_id
from klient
where klient_login=@klient_login"), con);
                    cmd.Parameters.Add("@klient_login", SqlDbType.Char);
                    cmd.Parameters["@klient_login"].Value = klient_login;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        flLogin = true;
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
            if (flLogin)
            {
                MessageBox.Show(String.Format(@"
Taki Login już istnieje. 
Proszę podać inny Login."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //REGISTER
            try
            {
                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(String.Format(@"
insert into KLIENT
(klient_name,klient_email,klient_phone,klient_login,klient_password)
values(@klient_name,@klient_email,@klient_phone,@klient_login,@klient_password);
SELECT CAST(scope_identity() AS int)"), con);
                    cmd.Parameters.Add("@klient_name", SqlDbType.Char);
                    cmd.Parameters.Add("@klient_email", SqlDbType.Char);
                    cmd.Parameters.Add("@klient_phone", SqlDbType.Char);
                    cmd.Parameters.Add("@klient_login", SqlDbType.Char);
                    cmd.Parameters.Add("@klient_password", SqlDbType.Char);
                    cmd.Parameters["@klient_name"].Value = klient_name;
                    cmd.Parameters["@klient_email"].Value = klient_email;
                    cmd.Parameters["@klient_phone"].Value = klient_phone;
                    cmd.Parameters["@klient_login"].Value = klient_login;
                    cmd.Parameters["@klient_password"].Value = klient_password;
                    int klient_id = (Int32)cmd.ExecuteScalar();

                    Program.pbKlient = null;
                    Program.pbKlient = new Program.KLIENT(klient_id);
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

            MessageBox.Show(String.Format(@"Rejestracja jest OK!"), "Rejestracja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void Register_Load(object sender, EventArgs e)
        {
            lbName.ForeColor = Color.DarkRed;
            lbLogin.ForeColor = Color.DarkRed;
            lbPassword.ForeColor = Color.DarkRed;
            lbConfirm.ForeColor = Color.DarkRed;
            txtPassword.PasswordChar = '*';
            txtConfirm.PasswordChar = '*';
        }
    }
}
