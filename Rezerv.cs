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

using System.Net;
using System.Net.Mail;

namespace Barber
{
    public partial class Rezerv : Form
    {
        int barber_id;
        DateTime dt;
        List<(int category_id, int service_id, String service_name, int duration, Double cena)> listService;
        public Rezerv(int p_barber_id, DateTime p_dt, List<(int category_id, int service_id, String service_name, int duration, Double cena)> p_listService)
        {
            barber_id = p_barber_id;
            dt = p_dt;
            listService = p_listService;
            InitializeComponent();
        }

        private void Rezerv_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.connectionString);
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(String.Format(@"
select b.barber_name,b.barber_comm,c.category_name
from barbers b
inner join category c on b.category_id=c.category_id
where b.barber_id={0}
", barber_id), con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var barber_name = reader.GetString(0).Trim();
                    var category_name = reader.GetString(2).Trim();
                    var barber_comm = reader.GetString(1).Trim();
                    lbBARBER.ForeColor = Color.DarkRed;
                    lbBARBER.Text = String.Format(@"{0}
{1}
{2}
",barber_name,category_name,barber_comm);
                }
                con.Close();
            }
            richSERVICE.ForeColor = Color.DarkGreen;
            richSERVICE.Text += "Data " + dt.Date.ToString("ddd").Trim() + " " + dt.Date.ToString("dd-MM-yy").Trim() + "\n";
            richSERVICE.Text += "Czas " + dt.ToShortTimeString().Trim() + "\n" + "\n";
            richSERVICE.Text += "Wybrane usługi:" + "\n";
            foreach((int category_id, int service_id, String service_name, int duration, Double cena) item in listService)
            {
                richSERVICE.Text += item.service_name.Trim() + "\n";
            }
            richSERVICE.Text += "\n";
            var sum_duration = listService.Select(x => x.duration).Sum();
            richSERVICE.Text += "Trwanie: " + sum_duration.ToString().Trim() + " minut" + "\n";
            var sum_cena = listService.Select(x => x.cena).Sum();
            richSERVICE.Text += "Cena: " + sum_cena.ToString().Trim() + " " + "\n";
            richSERVICE.Text += "Chętnie Cię zobaczymy!!!!";
        }

        private void btnREZERV_Click(object sender, EventArgs e)
        {
            //REZERV
            
            try
            {
                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(String.Format(@"
insert into REZERV
(barber_id,klient_id,date_rezerv)
values(@barber_id,@klient_id,@date_rezerv);
SELECT CAST(scope_identity() AS int)"), con);
                    cmd.Parameters.Add("@barber_id", SqlDbType.Int);
                    cmd.Parameters.Add("@klient_id", SqlDbType.Int);
                    cmd.Parameters.Add("@date_rezerv", SqlDbType.DateTime);
                    cmd.Parameters["@barber_id"].Value = barber_id;
                    cmd.Parameters["@klient_id"].Value = Program.pbKlient.klient_id;
                    cmd.Parameters["@date_rezerv"].Value = dt;
                    int rezerv_id = (Int32)cmd.ExecuteScalar();

                    foreach ((int category_id, int service_id, String service_name, int duration, Double cena) item in listService)
                    {
                        cmd = new SqlCommand(String.Format(@"
insert into REZERV_SERVICES
(rezerv_id,category_id,service_id,cena)
values(@rezerv_id,@category_id,@service_id,@cena)
"), con);
                        cmd.Parameters.Add("@rezerv_id", SqlDbType.Int);
                        cmd.Parameters.Add("@category_id", SqlDbType.Int);
                        cmd.Parameters.Add("@service_id", SqlDbType.Int);
                        cmd.Parameters.Add("@cena", SqlDbType.Decimal);
                        cmd.Parameters["@rezerv_id"].Value = rezerv_id;
                        cmd.Parameters["@category_id"].Value = item.category_id;
                        cmd.Parameters["@service_id"].Value = item.service_id;
                        cmd.Parameters["@cena"].Value = item.cena;
                        cmd.ExecuteNonQuery();
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

            MessageBox.Show(String.Format(@"Jest!"), "Zapis", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Send();
            this.Close();

        }
        private void Send()
        {
            if (string.IsNullOrEmpty(Program.pbKlient.klient_email) == false)
            {
                try
                {
                    // nadawca - ustaw adres i nazwę wyświetlaną w liście
                    MailAddress from = new MailAddress("barbershop.razorblade@gmail.com", "BarberShop Razor-Blade");
                    // do kogo wysyłamy
                    MailAddress to = new MailAddress(Program.pbKlient.klient_email);
                    // nowy objekt
                    MailMessage m = new MailMessage(from, to);
                    // temat
                    m.Subject = "Zaproszenie";
                    // tekst
                    m.Body = String.Format(@"<h2>{0}{1}</h2>", lbBARBER.Text, richSERVICE.Text);
                    // html
                    m.IsBodyHtml = true;
                    // adres smtp-serwera i port
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    // login i hasło 
                    smtp.Credentials = new NetworkCredential("barbershop.razorblade@gmail.com", "razorblade1");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                }
                catch (System.Exception error)
                {
                    MessageBox.Show(String.Format(@"Error SendMail!  
{0}", error.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
