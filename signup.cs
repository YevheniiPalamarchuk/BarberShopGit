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
    public partial class signup : Form
    {
        public static int pbduration = 30;
        public gridSERVICE grdSERVICE;
        public gridBARBERS grdBARBERS;
        public List<BARBER> listBarber = new List<BARBER>();
        public List<SCHEDULE> listSchedule = new List<SCHEDULE>();
        public List<Label> listLabel = new List<Label>();
        
        public void schedule_clear()
        {
            pnlSCHEDULE.Visible = false;
            
            foreach (BARBER iDel in listBarber)
            {
                iDel.Clear();
            }
            listBarber.Clear();
            foreach (SCHEDULE iDel in listSchedule)
            {
                iDel.Clear();
            }
            listSchedule.Clear();
            foreach (Label iDel in listLabel)
            {
                iDel.Dispose();
            }
            listLabel.Clear();

            pnlSCHEDULE.Visible = true;
        }
        public void schedule_create()
        {
            pnlSCHEDULE.Visible = false;
            //DATE
            DateTime d_beg = date_beg.Value;
            DateTime d_end = date_end.Value;
            //SERVICE
            List<(int category_id,int service_id,String service_name,int duration,Double cena)> listService = new List<(int category_id, int service_id, String service_name, int duration, Double cena)>();
            foreach (DataGridViewRow rowService in grdSERVICE.Rows)
            {
                if (Int32.Parse(rowService.Cells["CHK"].Value.ToString()) == 1)
                {
                    int category_id = Int32.Parse(rowService.Cells["CATEGORY_ID"].Value.ToString());
                    int service_id = Int32.Parse(rowService.Cells["SERVICE_ID"].Value.ToString());
                    String service_name = rowService.Cells["SERVICE_NAME"].Value.ToString().Trim();
                    int duration = Int32.Parse(rowService.Cells["DURATION"].Value.ToString());
                    Double cena= Double.Parse(rowService.Cells["CENA"].Value.ToString());
                    listService.Add((category_id,service_id,service_name,duration,cena));
                }
            }
            int iTop = 0;
            int iLeft = 0;
            int barber_id;
            int iBarber = 0;
            foreach (DataGridViewRow rowBarber in grdBARBERS.Rows)
            {
                if (Int32.Parse(rowBarber.Cells["CHK"].Value.ToString()) == 1)
                {
                    barber_id = Int32.Parse(rowBarber.Cells["BARBER_ID"].Value.ToString());
                    BARBER barber = new BARBER(barber_id);
                    barber.lbBarber.Top = iTop;
                    barber.lbBarber.Left = 0;
                    this.pnlSCHEDULE.Controls.Add(barber.lbBarber);
                    listBarber.Add(barber);
                    iTop = iTop + barber.lbBarber.Height;
                    iLeft = 0;
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"
select barber_id,date_beg,date_end 
from schedule 
where barber_id={0} and date_beg between @d_beg and @d_end
", barber_id), con);
                        cmd.Parameters.Add("@d_beg", SqlDbType.DateTime);
                        cmd.Parameters.Add("@d_end", SqlDbType.DateTime);
                        cmd.Parameters["@d_beg"].Value = d_beg;
                        cmd.Parameters["@d_end"].Value = d_end;
                        SqlDataReader reader = cmd.ExecuteReader();
                        int iDate = 0;
                        Boolean flScedule = false;
                        while (reader.Read())
                        {
                            flScedule = true;
                            var date_beg = reader.GetDateTime(1);
                            var date_end = reader.GetDateTime(2);
                            SCHEDULE day_schedule = new SCHEDULE(barber_id, date_beg, date_end, listService);
                            day_schedule.lbSchedule.Top = iTop + 10;
                            day_schedule.lbSchedule.Left = 0;
                            this.pnlSCHEDULE.Controls.Add(day_schedule.lbSchedule);
                            iLeft = day_schedule.lbSchedule.Width + 5;
                            int iTime = 0;
                            foreach (DT_BARBER idt in day_schedule.listDT_barber)
                            {
                                idt.Top = iTop;
                                idt.Left = iLeft + iTime * idt.Width;
                                idt.Click += new EventHandler(DT_BARBER_ButtonClick);
                                idt.MouseEnter += new EventHandler(DT_BARBER_MouseEnter);
                                pnlSCHEDULE.Controls.Add(idt);
                                iTime++;
                            }
                            listSchedule.Add(day_schedule);
                            iDate++;
                            iTop += day_schedule.ScheduleHeight;
                        }
                        if (flScedule==false)
                        {
                            Label notSchedule = new Label();
                            notSchedule.Text = "Brak informacji dla tego okresu";
                            var currentSize = notSchedule.Font.Size;
                            currentSize += 2.0F;
                            notSchedule.Font = new Font(notSchedule.Font.Name, currentSize, notSchedule.Font.Style | FontStyle.Bold);
                            notSchedule.ForeColor = Color.DarkGreen;
                            notSchedule.AutoSize = true;
                            notSchedule.Left = 0;
                            notSchedule.Top = iTop;
                            iTop += notSchedule.Height + 10;
                            pnlSCHEDULE.Controls.Add(notSchedule);
                            listLabel.Add(notSchedule);
                        }
                        con.Close();
                    }
                    iBarber++;
                }
            }
            pnlSCHEDULE.Visible = true;
        }
        public void schedule_refresh()
        {
            schedule_clear();
            schedule_create();
        }
        public class BARBER
        {
            public int barber_id;
            public String barber_name;
            public String barber_comm;
            public Label lbBarber = new Label();
            public BARBER(int cls_barber_id)
            {
                barber_id = cls_barber_id;

                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"select barber_name, barber_comm from barbers where barber_id={0}", this.barber_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            barber_name = reader.GetString(0);
                            barber_comm = reader.GetString(1);
                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lbBarber.Text = barber_name.Trim();
                var currentSize = lbBarber.Font.Size;
                currentSize += 4.0F;
                lbBarber.Font = new Font(lbBarber.Font.Name, currentSize, lbBarber.Font.Style | FontStyle.Bold | FontStyle.Underline);
                lbBarber.ForeColor = Color.Red;
                lbBarber.AutoSize = true;
            }
            public void Clear()
            {
                lbBarber.Dispose();
            }

        }
        public class DT_BARBER:Button
        {
            public int barber_id;
            public DateTime dt;
            public int duration;
            public List<(int category_id, int service_id, String service_name, int duration, Double cena)> listService;
            public DateTime date_end;
            private int _status;
            public int status
            {
                get
                {
                    return _status;
                }
                set 
                {
                    _status = value;
                    OnStatusChanged();
                }
            }
            public ToolTip tt = new ToolTip();
            public String tt_text = "";
            protected void OnStatusChanged()
            {
                //FREE
                if (_status == 0)
                {
                    this.BackColor = Color.Green;
                    this.ForeColor = Color.Yellow;
                }
                //REZERV OTHER KLIENT
                if (_status == 1)
                {
                    this.BackColor = Color.Red;
                    this.ForeColor = Color.Yellow;
                }
                //REZERV OUR CLIENT
                if (_status == 2)
                {
                    this.BackColor = Color.Orange;
                    this.ForeColor = Color.White;
                }
                //REZERV not enough time
                if (_status == 3)
                {
                    this.BackColor = Color.Yellow;
                    this.ForeColor = Color.Red;
                }
            }
            public (Boolean rezerv, int klient_id) RezervTime(DateTime data)
            {
                Boolean rezerv = false;
                int klient_id = 0;

                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(String.Format(@"
select klient_id,barber_id,date_beg,date_end
from
(
select r.klient_id,r.barber_id,r.date_rezerv as date_beg,
DATEADD(minute,isnull((select sum(duration) from rezerv_services rs inner join service s on rs.category_id=s.category_id and rs.service_id=s.service_id where rs.rezerv_id=r.rezerv_id),0),r.date_rezerv) as date_end
from rezerv r
inner join barbers b on r.barber_id=b.barber_id
) a
where barber_id={0} and @data between date_beg and date_end
", barber_id), con);
                    cmd.Parameters.Add("@data", SqlDbType.DateTime);
                    cmd.Parameters["@data"].Value = data.AddMinutes(1);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        klient_id = reader.GetInt32(0);
                        rezerv = true;
                    }
                    con.Close();
                }
                return (rezerv, klient_id);
            }
            public DT_BARBER(int cls_barber_id, DateTime cls_dt, DateTime cls_date_end, List<(int category_id, int service_id, String service_name, int duration, Double cena)> cls_listService)
            {
                barber_id = cls_barber_id;
                dt = cls_dt;
                date_end = cls_date_end;
                listService = cls_listService;
                duration = listService.Select(x => x.duration).Sum();
                this.Width = 45;
                this.Height = 40;
                this.Text = dt.ToShortTimeString();
                status = 0;
                //REZERV
                (Boolean rezerv, int klient_id) chekRezerv = RezervTime(dt.AddMinutes(1));
                if (chekRezerv.rezerv == true)
                {
                    //NOT OUR REZERV
                    if (chekRezerv.klient_id!= Program.pbKlient.klient_id)
                    {
                        status = 1;
                    }
                    //OUR REZERV
                    else
                    {
                        status = 2;
                    }
                }
                //not enough time on schedule
                if (status == 0)
                {
                    if (dt > date_end.AddMinutes(-duration)) { status = 3; }
                }
                //not enough time
                if (status == 0)
                {
                    var date_beg = dt.AddMinutes(pbduration);
                    var date_end = dt.AddMinutes(duration);
                    var idate = date_beg;
                    while (idate < date_end)
                    {
                        if (RezervTime(idate.AddMinutes(1)).rezerv) { status = 3; }
                        idate = idate.AddMinutes(pbduration);
                    }
                }
                //TOOL_TIP
                tt_text = String.Format(@"Czas {0} - {1}
Cena {2}"
, dt.ToShortTimeString()
, dt.AddMinutes(duration).ToShortTimeString()
, listService.Select(x => x.cena).Sum()
);
            }

        }
        public void DT_BARBER_ButtonClick(object sender, EventArgs e)
        {
            DT_BARBER dt = sender as DT_BARBER;
            if (dt.status != 0)
            {
                return;
            }
            if(Program.pbKlient.klient_id==0)
            {
                MessageBox.Show(String.Format(@"Musisz zalogować się na swoje konto.
Jeśli nie masz konta, możesz się zarejestrować."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (dt.listService.Count() == 0)
            {
                MessageBox.Show(String.Format(@"Musisz wybrać usługi!"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            Rezerv formRezerv = new Rezerv(dt.barber_id, dt.dt, dt.listService);
            formRezerv.ShowDialog();
        }
        public void DT_BARBER_MouseEnter(object sender, EventArgs e)
        {
            DT_BARBER dt = (DT_BARBER)sender;
            dt.tt.Show(dt.tt_text, dt, 2000);
        }
        public class SCHEDULE
        {
            public int barber_id;
            public DateTime date_beg;
            public DateTime date_end;
            public List<(int category_id, int service_id, String service_name, int duration, Double cena)> listService;
            public Label lbSchedule = new Label();
            public List<DT_BARBER> listDT_barber = new List<DT_BARBER>();
            public int ScheduleHeight;
            public SCHEDULE(int cls_barber_id, DateTime cls_date_beg, DateTime cls_date_end, List<(int category_id, int service_id, String service_name, int duration, Double cena)> cls_listService)
            {
                barber_id = cls_barber_id; 
                date_beg = cls_date_beg;
                date_end = cls_date_end;
                listService = cls_listService;

                lbSchedule.Text = date_beg.Date.ToString("ddd").Trim() + " " + date_beg.Date.ToString("dd-MM-yy").Trim();
                lbSchedule.Font = new Font(lbSchedule.Font, lbSchedule.Font.Style | FontStyle.Bold);
                lbSchedule.ForeColor = Color.DarkGreen;
                lbSchedule.AutoSize = true;

                DateTime c_datetime = date_beg;
                while (c_datetime < date_end)
                {
                    var dt = new DT_BARBER(barber_id, c_datetime, date_end, listService);
                    listDT_barber.Add(dt);
                    c_datetime = c_datetime.AddMinutes(pbduration);
                    ScheduleHeight = Math.Max(dt.Height, lbSchedule.Height);
                }
            }
            public void Clear()
            {
                foreach (DT_BARBER iDel in listDT_barber)
                {
                    iDel.Dispose();
                }
                listDT_barber.Clear();
                lbSchedule.Dispose();
            }
        }
        public class rdbCATEGORY:RadioButton
        {
            public int category_id;
            public rdbCATEGORY(int cls_category_id)
            {
                category_id = cls_category_id;
            }
        }
        public void rdbCATEGORY_ChekedChanged(object sender, EventArgs e)
        {
            rdbCATEGORY rdb = sender as rdbCATEGORY;
            if (rdb.Checked)
            {
                if (grdSERVICE != null)
                {
                    grdSERVICE.Dispose();
                    grdSERVICE = null;
                }
                if (grdBARBERS != null)
                {
                    grdBARBERS.Dispose();
                    grdBARBERS = null;
                }
                grdSERVICE = new gridSERVICE(rdb.category_id);
                grdSERVICE.CurrentCellDirtyStateChanged += new EventHandler(gridSERVICE_CurrentCellDirtyStateChanged);
                grdSERVICE.CellValueChanged+= new DataGridViewCellEventHandler(gridSERVICE_CellValueChanged);
                this.pnlSERVICE.Controls.Add(grdSERVICE);
                grdBARBERS = new gridBARBERS(rdb.category_id);
                grdBARBERS.CurrentCellDirtyStateChanged += new EventHandler(gridBARBERS_CurrentCellDirtyStateChanged);
                grdBARBERS.CellValueChanged += new DataGridViewCellEventHandler(gridBARBERS_CellValueChanged);
                this.pnlBARBERS.Controls.Add(grdBARBERS);
                schedule_clear();
            }
        }
        public class gridSERVICE : DataGridView
        {
            int category_id;
            public gridSERVICE(int cls_category_id)
            {
                category_id = cls_category_id;

                this.ColumnCount = 6;
                this.Top = 5;
                this.Left = 5;
                this.Width = 370;
                this.Height = 225;
                this.RowHeadersVisible = false;
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.MultiSelect = false;
                this.AllowUserToAddRows = false;
                this.AllowUserToDeleteRows = false;
                this.AllowUserToResizeColumns = false;
                this.AllowUserToResizeRows = false;
                this.BackgroundColor = SystemColors.Control;
                this.BorderStyle = BorderStyle.None;

                this.Columns[0].HeaderText = "ID_CATEGORY";
                this.Columns[0].Name = "CATEGORY_ID";
                this.Columns[0].Visible = false;
                this.Columns[0].ReadOnly = true;
                this.Columns[1].HeaderText = "ID_SERVICE";
                this.Columns[1].Name = "SERVICE_ID";
                this.Columns[1].Visible = false;
                this.Columns[1].ReadOnly = true;
                this.Columns[2].HeaderText = "Nasze Usługi";
                this.Columns[2].Name = "SERVICE_NAME";
                this.Columns[2].Width = 240;
                this.Columns[2].ReadOnly = true;
                this.Columns[3].HeaderText = "Opis";
                this.Columns[3].Width = 200;
                this.Columns[3].Visible = false;
                this.Columns[3].ReadOnly = true;
                this.Columns[4].HeaderText = "minut";
                this.Columns[4].Name = "DURATION";
                this.Columns[4].Width = 40;
                this.Columns[4].ReadOnly = true;
                this.Columns[5].HeaderText = "Cena";
                this.Columns[5].Name = "CENA";
                this.Columns[5].Width = 50;
                this.Columns[5].ReadOnly = true;

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "CHK";
                chk.HeaderText = "V";
                chk.FalseValue = "0";
                chk.TrueValue = "1";
                chk.ReadOnly = false;
                chk.Width = 30;
                this.Columns.Insert(0, chk);

                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"
select s.category_id,s.service_id,s.service_name,s.service_comm,s.duration,p.cena
from service s
inner join price p on s.category_id=p.category_id and s.service_id=p.service_id
where s.category_id={0}
", this.category_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string[] row = new string[]
                            {
                                0.ToString(),
                            reader.GetInt32(0).ToString(),
                            reader.GetInt32(1).ToString(),
                            reader.GetString(2).Trim(),
                            reader.GetString(3).Trim(),
                            reader.GetInt32(4).ToString(),
                            reader.GetDecimal(5).ToString()
                            };
                            this.Rows.Add(row);
                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void gridSERVICE_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grdSERVICE.IsCurrentCellDirty)
            {
                grdSERVICE.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        public void gridSERVICE_CellValueChanged(object sender, EventArgs e)
        {
            schedule_refresh();
        }
        public class gridBARBERS : DataGridView
        {
            public int category_id;
            public gridBARBERS(int cls_category_id)
            {
                category_id = cls_category_id;

                this.ColumnCount = 4;
                this.Top = 5;
                this.Left = 5;
                this.Width = 340;
                this.Height = 225;
                this.RowHeadersVisible = false;
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.MultiSelect = false;
                this.AllowUserToAddRows = false;
                this.AllowUserToDeleteRows = false;
                this.AllowUserToResizeColumns = false;
                this.AllowUserToResizeRows = false;
                this.BackgroundColor = SystemColors.Control;
                this.BorderStyle = BorderStyle.None;

                this.Columns[0].HeaderText = "ID_BARBER";
                this.Columns[0].Name = "BARBER_ID";
                this.Columns[0].Visible = false;
                this.Columns[0].ReadOnly = true;
                this.Columns[1].HeaderText = "ID_CATEGORY";
                this.Columns[1].Name = "CATEGORY_ID";
                this.Columns[1].Visible = false;
                this.Columns[1].ReadOnly = true;
                this.Columns[2].HeaderText = "Nasi mistrzowie";
                this.Columns[2].Name = "BARBER_NAME";
                this.Columns[2].Width = 155;
                this.Columns[2].ReadOnly = true;
                this.Columns[3].HeaderText = "Opis";
                this.Columns[3].Name = "BARBER_COMM";
                this.Columns[3].Width = 150;
                this.Columns[3].ReadOnly = true;

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "CHK";
                chk.HeaderText = "V";
                chk.FalseValue = "0";
                chk.TrueValue = "1";
                chk.ReadOnly = false;
                chk.Width = 30;
                this.Columns.Insert(0, chk);

                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"
select b.barber_id,b.category_id,b.barber_name,b.barber_comm
from barbers b
inner join category c on b.category_id=c.category_id
where b.category_id={0}
", this.category_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string[] row = new string[]
                            {
                                0.ToString(),
                            reader.GetInt32(0).ToString(),
                            reader.GetInt32(1).ToString(),
                            reader.GetString(2).Trim(),
                            reader.GetString(3).Trim()
                            };
                            this.Rows.Add(row);
                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void gridBARBERS_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grdBARBERS.IsCurrentCellDirty)
            {
                grdBARBERS.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        public void gridBARBERS_CellValueChanged(object sender, EventArgs e)
        {
            schedule_refresh();
        }
        public signup()
        {
            InitializeComponent();
        }
        private void signup_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(String.Format(@"
select c.category_id,c.category_name
from category c
"), con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    RadioButton rdb;
                    int category_id;
                    int i = 0;
                    while (reader.Read())
                    {
                        category_id = reader.GetInt32(0);
                        rdb = new rdbCATEGORY(category_id);
                        rdb.Top = 5 + i * 20;
                        rdb.Left = 5;
                        rdb.AutoSize = true;
                        rdb.Text = reader.GetString(1).Trim();
                        rdb.CheckedChanged+= new EventHandler(rdbCATEGORY_ChekedChanged);
                        this.pnlCATEGORY.Controls.Add(rdb);
                        if (i == 0) { rdb.Checked = true; }
                        i++;
                    }

                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.pnlFREE.BackColor = Color.Green;
            this.lbFREE.Text = "Czas wolny, możesz się zapisać";
            this.pnlFREE_NOTIME.BackColor = Color.Yellow;
            this.lbFREE_NOTIME.Text = "Czas wolny, ale nie można się zapisać, ponieważ czas trwania wybranej sesji przekracza czas kolejnej sesji";
            this.pnlBUSY_OUR.BackColor = Color.Orange;
            this.lbBUSY_OUR.Text = "Zarezerwowane przez Ciebie, czekamy!!!";
            this.pnlBUSY_OTHER.BackColor = Color.Red;
            this.lbBUSY_OTHER.Text = "Zarezerwowane przez innych klientów";
        }
        private void signup_Activated(object sender, EventArgs e)
        {
            this.Text = "Zapisz się";
            if (Program.pbKlient.klient_id != 0)
            {
                this.Text += " (zarejestrowany " + Program.pbKlient.klient_name.Trim() + ")";
            }
            else
            {
                this.Text += " (nie zarejestrowany)";
            }
            schedule_refresh();
        }
        private void btnSCHEDULE_Click(object sender, EventArgs e)
        {
            schedule_refresh();
        }
        private void date_beg_ValueChanged(object sender, EventArgs e)
        {
            schedule_refresh();
        }
        private void date_end_ValueChanged(object sender, EventArgs e)
        {
            schedule_refresh();
        }
        private void btnREGISTER_Click(object sender, EventArgs e)
        {
            Register formRegister = new Register();
            formRegister.ShowDialog();
        }
        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            formLogin.ShowDialog();
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
    }
}
