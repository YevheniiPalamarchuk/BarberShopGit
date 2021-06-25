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
    public partial class MyRezerv : Form
    {
        public MyRezerv()
        {
            InitializeComponent();
        }

        public void REZERV_refresh()
        {
            gridREZERV.Rows.Clear();
            try
            {
                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(String.Format(@"
select r.rezerv_id,b.barber_name,c.category_name,r.date_rezerv 
from rezerv r
inner join barbers b on r.barber_id=b.barber_id
inner join category c on b.category_id=c.category_id
where r.klient_id={0}
order by r.date_rezerv 
", Program.pbKlient.klient_id), con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] row = new string[]
                        {
                                0.ToString(),
                            reader.GetInt32(0).ToString(),
                            reader.GetString(1).Trim(),
                            reader.GetString(2).Trim(),
                            reader.GetDateTime(3).Date.ToString("ddd").Trim() + " " + reader.GetDateTime(3).Date.ToString("dd-MM-yy").Trim(),
                            reader.GetDateTime(3).ToShortTimeString().Trim()
                        };
                        gridREZERV.Rows.Add(row);
                    }
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MyRezerv_Load(object sender, EventArgs e)
        {
            //REZERV
            gridREZERV.ColumnCount = 5;
            gridREZERV.RowHeadersVisible = false;
            gridREZERV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridREZERV.MultiSelect = false;
            gridREZERV.AllowUserToAddRows = false;
            gridREZERV.AllowUserToDeleteRows = false;
            gridREZERV.AllowUserToResizeColumns = false;
            gridREZERV.AllowUserToResizeRows = false;
            gridREZERV.BackgroundColor = SystemColors.Control;
            gridREZERV.BorderStyle = BorderStyle.None;

            gridREZERV.Columns[0].HeaderText = "REZERV_ID";
            gridREZERV.Columns[0].Name = "REZERV_ID";
            gridREZERV.Columns[0].Visible = false;
            gridREZERV.Columns[0].ReadOnly = true;
            gridREZERV.Columns[1].HeaderText = "Mistrz";
            gridREZERV.Columns[1].Name = "BARBER_NAME";
            gridREZERV.Columns[1].Width = 155;
            gridREZERV.Columns[1].ReadOnly = true;
            gridREZERV.Columns[2].HeaderText = "Kategoria";
            gridREZERV.Columns[2].Name = "CATEGORY_NAME";
            gridREZERV.Columns[2].Width = 155;
            gridREZERV.Columns[2].ReadOnly = true;
            gridREZERV.Columns[3].HeaderText = "Data";
            gridREZERV.Columns[3].Name = "DATA";
            gridREZERV.Columns[3].Width = 100;
            gridREZERV.Columns[3].ReadOnly = true;
            gridREZERV.Columns[4].HeaderText = "Czas";
            gridREZERV.Columns[4].Name = "TIME";
            gridREZERV.Columns[4].Width = 50;
            gridREZERV.Columns[4].ReadOnly = true;
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Name = "CHK";
            chk.HeaderText = "V";
            chk.FalseValue = "0";
            chk.TrueValue = "1";
            chk.ReadOnly = false;
            chk.Width = 30;
            gridREZERV.Columns.Insert(0, chk);

            //REZERV_SERVICES
            gridREZERV_SERVICES.ColumnCount = 3;
            gridREZERV_SERVICES.RowHeadersVisible = false;
            gridREZERV_SERVICES.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridREZERV_SERVICES.MultiSelect = false;
            gridREZERV_SERVICES.AllowUserToAddRows = false;
            gridREZERV_SERVICES.AllowUserToDeleteRows = false;
            gridREZERV_SERVICES.AllowUserToResizeColumns = false;
            gridREZERV_SERVICES.AllowUserToResizeRows = false;
            gridREZERV_SERVICES.BackgroundColor = SystemColors.Control;
            gridREZERV_SERVICES.BorderStyle = BorderStyle.None;
            gridREZERV_SERVICES.ReadOnly = true;

            gridREZERV_SERVICES.Columns[0].HeaderText = "Usługa";
            gridREZERV_SERVICES.Columns[0].Name = "SERVICE_NAME";
            gridREZERV_SERVICES.Columns[0].Width = 250;
            gridREZERV_SERVICES.Columns[1].HeaderText = "Czas (minut)";
            gridREZERV_SERVICES.Columns[1].Name = "DURATION";
            gridREZERV_SERVICES.Columns[1].Width = 140;
            gridREZERV_SERVICES.Columns[2].HeaderText = "Cena";
            gridREZERV_SERVICES.Columns[2].Name = "CENA";
            gridREZERV_SERVICES.Columns[2].Width = 100;

            REZERV_refresh();

        }

        private void gridREZERV_SelectionChanged(object sender, EventArgs e)
        {
            if (gridREZERV.Rows.Count == 0 || gridREZERV.CurrentRow.Cells[0].Value == null)
            {
                return;
            }
            gridREZERV_SERVICES.Rows.Clear();

            int rezerv_id = Int32.Parse(gridREZERV.CurrentRow.Cells["REZERV_ID"].Value.ToString());
            try
            {
                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(String.Format(@"
select s.service_name, s.duration, rs.cena 
from rezerv_services rs
inner join rezerv r on r.rezerv_id=rs.rezerv_id
inner join service s on rs.category_id=s.category_id and rs.service_id=s.service_id
where rs.rezerv_id={0}
", rezerv_id), con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    string[] row = new string[]
                    {
                        reader.GetString(0).Trim(),
                        reader.GetInt32(1).ToString(),
                        reader.GetDecimal(2).ToString()
                        };
                        gridREZERV_SERVICES.Rows.Add(row);
                    }
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(String.Format(@"Czy na pewno chcesz anulować wybrane wpisy?"), "Anulować", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in gridREZERV.Rows)
                {
                    if (Int32.Parse(row.Cells["CHK"].Value.ToString()) == 1)
                    {
                        int rezerv_id = Int32.Parse(row.Cells["REZERV_ID"].Value.ToString());
                        try
                        {
                            SqlConnection con = new SqlConnection(Program.connectionString);
                            using (con)
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand(String.Format(@"
delete from rezerv_services where rezerv_id={0};
delete from rezerv where rezerv_id={0};
", rezerv_id), con);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                }
                REZERV_refresh();
            }
        }
    }
}

