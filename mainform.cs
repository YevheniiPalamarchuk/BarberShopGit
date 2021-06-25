using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barber
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void btnSIGNUP_Click(object sender, EventArgs e)
        {
            signup formSIGNUP = new signup();
            formSIGNUP.ShowDialog();
        }

        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            formLogin.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register formRegister = new Register();
            formRegister.ShowDialog();
        }

        private void btnMyRezerv_Click(object sender, EventArgs e)
        {
            if (Program.pbKlient.klient_id != 0)
            {
                MyRezerv formMyRezerv = new MyRezerv();
                formMyRezerv.ShowDialog();
            }
            else
            {
                MessageBox.Show(String.Format(@"Zaloguj się (ACCOUNT) lub zarejestruj się. "), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainform_Activated(object sender, EventArgs e)
        {
            this.Text= @"Barbershop ""Razor Blade""";
            if (Program.pbKlient.klient_id != 0)
            {
                this.Text += " (zarejestrowany " + Program.pbKlient.klient_name.Trim() + ")";
            }
            else
            {
                this.Text += " (nie zarejestrowany)";
            }
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            lbBARBER1.Parent = pictureBARBER;
            lbBARBER1.Text = String.Format(@"""Razor Blade""
Barbershop
");
            lbBARBER1.Left = 10;
            lbBARBER1.Top = 10;
            lbBARBER1.BackColor = Color.Transparent;
            var currentSize = lbBARBER1.Font.Size;
            currentSize += 30.0F;
            lbBARBER1.Font = new Font(lbBARBER1.Font.Name, currentSize, lbBARBER1.Font.Style | FontStyle.Bold);
            lbBARBER1.ForeColor = Color.Yellow;
            lbBARBER1.AutoSize = true;

            lbBARBER2.Parent = pictureBARBER;
            lbBARBER2.Text = String.Format(@"
Zawsze cieszymy się,
że Cię widzimy!!!!
");
            lbBARBER2.Left = 10;
            lbBARBER2.Top = 150;
            lbBARBER2.BackColor = Color.Transparent;
            var currentSize2 = lbBARBER2.Font.Size;
            currentSize2 += 20.0F;
            lbBARBER2.Font = new Font(lbBARBER2.Font.Name, currentSize2, lbBARBER2.Font.Style | FontStyle.Bold);
            lbBARBER2.ForeColor = Color.Yellow;
            lbBARBER2.AutoSize = true;

            lbBARBER3.Parent = pictureBARBER;
            lbBARBER3.Text = String.Format(@"
""Razor Blade"" Barbershop 
To baza w samym sercu miasta, w której możesz ukryć się w dowolnej dogodnej dla siebie formie. 
Strzyżenie męskie, pielęgnacja brody, golenie klasyczne i rozmowa z osobami, którym zależy.
Nasze okna są zacienione, światło wyciszone, dźwięk dostrojony, nie oszczędzamy na tym.
Brak „właściwej atmosfery”, „pośpiesz się, aby się zarejestrować” i innych śmieci marketingowych.
Nasi ludzie i duch są tym, z czego jesteśmy dumni.
Czekamy na ciebie!!! 
");
            lbBARBER3.Left = 10;
            lbBARBER3.Top = 350;
            lbBARBER3.BackColor = Color.Transparent;
            var currentSize3 = lbBARBER3.Font.Size;
            currentSize3 += 2.0F;
            //lbBARBER3.Font = new Font(lbBARBER3.Font.Name, currentSize3, lbBARBER3.Font.Style | FontStyle.Bold);
            lbBARBER3.ForeColor = Color.Yellow;
            lbBARBER3.AutoSize = true;

        }

        private void btnDATABASE_Click(object sender, EventArgs e)
        {
            if (Program.pbKlient.klient_login.Trim() == "admin")
            {
                DataBase formDataBase = new DataBase();
                formDataBase.ShowDialog();
            }
            else
            {
                MessageBox.Show(String.Format(@"Wymagane uprawnienia administratora!"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnBARBERS_Click(object sender, EventArgs e)
        {
            Barbers formBarbers = new Barbers();
            formBarbers.ShowDialog();
        }

        private void btnSERVICE_Click(object sender, EventArgs e)
        {
            Services formServices = new Services();
            formServices.ShowDialog();
        }
    }
}
