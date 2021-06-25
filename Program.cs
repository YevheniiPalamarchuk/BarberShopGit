using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Barber
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia do aplikacji.
        public static String connectionString = @"Data Source=LAPTOP-49SE81AP\SQLEXPRESS;Initial Catalog=barber_test1;Integrated Security=True";
        public static KLIENT pbKlient = new KLIENT(0);
        public class KLIENT
        {
            public int klient_id = 0;
            public String klient_name="";
            public String klient_email = "";
            public String klient_phone = "";
            public String klient_login = "";

            public KLIENT(int cls_klient_id)
            {
                klient_id = cls_klient_id;
                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"
select klient_name,klient_email,klient_phone,klient_login,klient_password
from klient
where klient_id={0}
",klient_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            klient_name = reader.GetString(0);
                            klient_email = reader.GetString(1);
                            klient_phone = reader.GetString(2);
                            klient_login = reader.GetString(3);
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

            }
        }
        
        
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainform());
        }
    }
}
