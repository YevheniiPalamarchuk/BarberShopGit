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
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        private void richSERVICES_TextChanged(object sender, EventArgs e)
        {

        }

        private void Services_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.connectionString);
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(String.Format(@"
select s.service_name, s.service_comm, s.duration, c.category_name, p.cena
from SERVICE as S inner join CATEGORY as C on S.category_id = C.category_id 
inner join PRICE as P on s.category_id = p.category_id AND S.service_id=p.service_id
order by c.category_id
"), con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var service_name = reader.GetString(0).Trim();
                    var service_comm = reader.GetString(1).Trim();
                    var duration = reader.GetInt32(2);
                    var category_name = reader.GetString(3).Trim();
                    var cena = reader.GetDecimal(4);
                    richSERVICES.ForeColor = Color.DarkGreen;
                    richSERVICES.Text += service_name + "\n";
                    richSERVICES.Text += service_comm + "\n";
                    richSERVICES.Text += duration.ToString() + "\n";
                    richSERVICES.Text += category_name + "\n";
                    richSERVICES.Text += cena.ToString() + "\n";
                    richSERVICES.Text += "\n";
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
