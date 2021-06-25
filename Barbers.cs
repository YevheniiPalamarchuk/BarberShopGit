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
    public partial class Barbers : Form
    {
        public Barbers()
        {
            InitializeComponent();
        }

        private void Barbers_Load(object sender, EventArgs e)
        {
            lblMASTERS.Text = "Nasi mistrzowie: ";
            SqlConnection con = new SqlConnection(Program.connectionString);
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(String.Format(@"
select b.barber_name, b.barber_comm, c.category_name 
from BARBERS as B inner join CATEGORY as C ON B.category_id = c.category_id
order by c.category_id
"), con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var barber_name = reader.GetString(0).Trim();
                    var category_name = reader.GetString(2).Trim();
                    var barber_comm = reader.GetString(1).Trim();
                    richBARBERS.Text += barber_name + " " + category_name+ " " + barber_comm + "\n";
                    richBARBERS.Text += "\n";
                }
                con.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
