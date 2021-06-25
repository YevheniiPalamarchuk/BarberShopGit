using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.Util.Collections;
using NPOI;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Data.SqlClient;


namespace Barber
{
    public partial class DataBase : Form
    {
        public DataBase()
        {
            InitializeComponent();
        }

        private void btnDATABASE_Click(object sender, EventArgs e)
        {
            //BARBERS
            if(chkBARBERS.Checked == true)
            {
                IWorkbook hssfwb = new HSSFWorkbook();

                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    //openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                    }
                }
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new HSSFWorkbook(file);
                }
                ISheet sheet = hssfwb.GetSheet("BARBERS");
                IRow rowObj;
                int barber_id;
                int category_id;
                String barber_name;
                String barber_comm;
                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    if (sheet.GetRow(row) != null)
                    {
                        rowObj = sheet.GetRow(row);
                        barber_id = (int)rowObj.GetCell(0).NumericCellValue;
                        category_id = (int)rowObj.GetCell(1).NumericCellValue;
                        barber_name = rowObj.GetCell(2).StringCellValue;
                        barber_comm = rowObj.GetCell(3).StringCellValue;
                        try
                        {
                            SqlConnection con = new SqlConnection(Program.connectionString);
                            using (con)
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE barbers as t_base
USING (select @barber_id as barber_id,@category_id as category_id,@barber_name as barber_name,@barber_comm as barber_comm) as t_source
ON (t_base.barber_id=t_source.barber_id)
WHEN MATCHED THEN update set barber_id=t_source.barber_id, category_id=t_source.category_id, barber_name = t_source.barber_name, barber_comm=t_source.barber_comm
WHEN NOT MATCHED THEN insert (barber_id,category_id,barber_name,barber_comm) values(t_source.barber_id,t_source.category_id,t_source.barber_name,t_source.barber_comm);"), con);
                                cmd.Parameters.Add("@barber_id", SqlDbType.Int);
                                cmd.Parameters.Add("@category_id", SqlDbType.Int);
                                cmd.Parameters.Add("@barber_name", SqlDbType.Char);
                                cmd.Parameters.Add("@barber_comm", SqlDbType.Char);
                                cmd.Parameters["@barber_id"].Value = barber_id;
                                cmd.Parameters["@category_id"].Value = category_id;
                                cmd.Parameters["@barber_name"].Value = barber_name;
                                cmd.Parameters["@barber_comm"].Value = barber_comm;
                                cmd.ExecuteNonQuery();
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
                MessageBox.Show("Load Complete");
            }
            //SERVICE
            if (chkSERVICE.Checked == true)
            {
                IWorkbook hssfwb = new HSSFWorkbook();

                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    //openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                    }
                }
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new HSSFWorkbook(file);
                }
                ISheet sheet = hssfwb.GetSheet("SERVICE");
                IRow rowObj;
                int category_id;
                int service_id;
                String service_name;
                String service_comm;
                int duration;
                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    if (sheet.GetRow(row) != null)
                    {
                        rowObj = sheet.GetRow(row);
                        category_id = (int)rowObj.GetCell(0).NumericCellValue;
                        service_id = (int)rowObj.GetCell(1).NumericCellValue;
                        service_name = rowObj.GetCell(2).StringCellValue;
                        service_comm = rowObj.GetCell(3).StringCellValue;
                        duration = (int)rowObj.GetCell(4).NumericCellValue;
                        try
                        {
                            SqlConnection con = new SqlConnection(Program.connectionString);
                            using (con)
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE service as t_base
USING (select @service_id as service_id,@category_id as category_id,@service_name as service_name,@service_comm as service_comm, @duration as duration) as t_source
ON (t_base.category_id=t_source.category_id AND t_base.service_id=t_source.service_id)
WHEN MATCHED THEN update set service_id=t_source.service_id, category_id=t_source.category_id, service_name = t_source.service_name, service_comm=t_source.service_comm, duration=t_source.duration
WHEN NOT MATCHED THEN insert (service_id,category_id,service_name,service_comm, duration) values(t_source.service_id,t_source.category_id,t_source.service_name,t_source.service_comm, t_source.duration);"), con);
                                cmd.Parameters.Add("@service_id", SqlDbType.Int);
                                cmd.Parameters.Add("@category_id", SqlDbType.Int);
                                cmd.Parameters.Add("@service_name", SqlDbType.Char);
                                cmd.Parameters.Add("@service_comm", SqlDbType.Char);
                                cmd.Parameters.Add("@duration", SqlDbType.Int);
                                cmd.Parameters["@service_id"].Value = service_id;
                                cmd.Parameters["@category_id"].Value = category_id;
                                cmd.Parameters["@service_name"].Value = service_name;
                                cmd.Parameters["@service_comm"].Value = service_comm;
                                cmd.Parameters["@duration"].Value = duration;
                                cmd.ExecuteNonQuery();
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
                MessageBox.Show("Load Complete");
            }
            //PRICE
            if (chkPRICE.Checked == true)
            {
                IWorkbook hssfwb = new HSSFWorkbook();

                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    //openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                    }
                }
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new HSSFWorkbook(file);
                }
                ISheet sheet = hssfwb.GetSheet("PRICE");
                IRow rowObj;
                int category_id;
                int service_id;
                int cena;
                String date_price;
                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    if (sheet.GetRow(row) != null)
                    {
                        rowObj = sheet.GetRow(row);
                        category_id = (int)rowObj.GetCell(0).NumericCellValue;
                        service_id = (int)rowObj.GetCell(1).NumericCellValue;
                        cena = (int)rowObj.GetCell(2).NumericCellValue;
                        date_price = rowObj.GetCell(3).StringCellValue;
                        try
                        {
                            SqlConnection con = new SqlConnection(Program.connectionString);
                            using (con)
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE price as t_base
USING (select @service_id as service_id,@category_id as category_id,@cena as cena,@date_price as date_price) as t_source
ON (t_base.category_id=t_source.category_id AND t_base.service_id=t_source.service_id)
WHEN MATCHED THEN update set service_id=t_source.service_id, category_id=t_source.category_id, cena = t_source.cena, date_price=t_source.date_price
WHEN NOT MATCHED THEN insert (service_id,category_id,cena,date_price) values(t_source.service_id,t_source.category_id,t_source.cena,t_source.date_price);"), con);
                                cmd.Parameters.Add("@service_id", SqlDbType.Int);
                                cmd.Parameters.Add("@category_id", SqlDbType.Int);
                                cmd.Parameters.Add("@cena", SqlDbType.Int);
                                cmd.Parameters.Add("@date_price", SqlDbType.DateTime);
                                cmd.Parameters["@service_id"].Value = service_id;
                                cmd.Parameters["@category_id"].Value = category_id;
                                cmd.Parameters["@cena"].Value = cena;
                                cmd.Parameters["@date_price"].Value = Convert.ToDateTime(date_price);
                                cmd.ExecuteNonQuery();
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
                MessageBox.Show("Load Complete");
            }
            //SCHEDULE
            if (chkSCHEDULE.Checked == true)
            {
                IWorkbook hssfwb = new HSSFWorkbook();

                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    //openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                    }
                }
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new HSSFWorkbook(file);
                }
                ISheet sheet = hssfwb.GetSheet("SCHEDULE");
                IRow rowObj;
                int barber_id;
                int schedule_id;
                String date_beg;
                String date_end;
                int pr_do;
                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    if (sheet.GetRow(row) != null)
                    {
                        rowObj = sheet.GetRow(row);
                        schedule_id = (int)rowObj.GetCell(0).NumericCellValue;
                        barber_id = (int)rowObj.GetCell(1).NumericCellValue;
                        date_beg = rowObj.GetCell(2).StringCellValue;
                        date_end = rowObj.GetCell(3).StringCellValue;
                        pr_do = (int)rowObj.GetCell(4).NumericCellValue;
                        try
                        {
                            SqlConnection con = new SqlConnection(Program.connectionString);
                            using (con)
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE schedule as t_base
USING (select @schedule_id as schedule_id,@barber_id as barber_id,@date_beg as date_beg,@date_end as date_end, @pr_do as pr_do) as t_source
ON (t_base.schedule_id=t_source.schedule_id)
WHEN MATCHED THEN update set schedule_id=t_source.schedule_id, barber_id=t_source.barber_id, date_beg = t_source.date_beg, date_end=t_source.date_end, pr_do=t_source.pr_do
WHEN NOT MATCHED THEN insert (schedule_id,barber_id,date_beg,date_end,pr_do) values(t_source.schedule_id,t_source.barber_id,t_source.date_beg,t_source.date_end, t_source.pr_do);"), con);
                                cmd.Parameters.Add("@schedule_id", SqlDbType.Int);
                                cmd.Parameters.Add("@barber_id", SqlDbType.Int);
                                cmd.Parameters.Add("@date_beg", SqlDbType.DateTime);
                                cmd.Parameters.Add("@date_end", SqlDbType.DateTime);
                                cmd.Parameters.Add("@pr_do", SqlDbType.Int);
                                cmd.Parameters["@schedule_id"].Value = schedule_id;
                                cmd.Parameters["@barber_id"].Value = barber_id;
                                cmd.Parameters["@date_beg"].Value = Convert.ToDateTime(date_beg);
                                cmd.Parameters["@date_end"].Value = Convert.ToDateTime(date_end);
                                cmd.Parameters["@pr_do"].Value = pr_do;
                                cmd.ExecuteNonQuery();
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
                MessageBox.Show("Load Complete");
            }

        }
    }
}
