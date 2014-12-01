using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

using System.IO;


namespace DataRetriever
{
    public partial class Form1 : Form
    {
        static int slno = 0;
       

        public Form1()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TwitterData.Service1Client client = new TwitterData.Service1Client();
            TwitterData.TweetData tweets = client.getTwitterData(textBox1.Text, 1);

           

            DataTable data= new DataTable();
            data.Columns.Add("sl_no",typeof(int));
            data.Columns.Add("content",typeof(string));
            data.Columns.Add("author", typeof(string));
            data.Columns.Add("date", typeof(DateTime));
            slno = 0;

            if (tweets.response.list.Length == 0)
            {
                DataRow row = data.NewRow();
                row["content"] = "No tweets found.";
                data.Rows.Add(row);

            }
            else
            {

                label3.Text = tweets.response.list[0].trackback_author_nick;
                for (int i = 0; i < tweets.response.list.Length; i++)
                {
                    slno = slno + 1;
                    DataRow row = data.NewRow();
                    row["sl_no"] = slno;
                    row["content"] = tweets.response.list[i].content;
                    row["author"] = tweets.response.list[i].trackback_author_nick;
                    row["date"] = getTimeFromUnixTimeStamp(tweets.response.list[i].trackback_date);
                    data.Rows.Add(row);
                }

                if (tweets.response.total > 100)
                {
                    int k = tweets.response.total / 100;
                    for (int l = 2; l <= k + 1; l++)
                    {
                        TwitterData.TweetData additionalpages = client.getTwitterData(textBox1.Text, l);
                        for (int i = 0; i < additionalpages.response.list.Length; i++)
                        {
                            slno = slno + 1;
                            DataRow row = data.NewRow();
                            row["sl_no"] = slno;
                            row["content"] = additionalpages.response.list[i].content;
                            row["author"] = additionalpages.response.list[i].trackback_author_nick;
                            row["date"] = getTimeFromUnixTimeStamp(additionalpages.response.list[i].trackback_date);
                            data.Rows.Add(row);
                        }
                    }
                }

            }

            dataGridView1.DataSource = data;

            int x = dataGridView1.Rows.Count;

            
           
        }
        public DateTime getTimeFromUnixTimeStamp(int UnixTimeStamp)
        {
            //Function taken from stack overflow
            System.DateTime DateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime = DateTime.AddSeconds(UnixTimeStamp).ToLocalTime();
            return DateTime;
        }

        private void retrieve(string username, string bioid, string ipsr, string fname, string lname)
        {
            TwitterData.Service1Client client = new TwitterData.Service1Client();
            TwitterData.TweetData tweets = client.getTwitterData(username, 1);

            DataTable data = new DataTable();
            data.Columns.Add("sl_no", typeof(int));
            data.Columns.Add("content", typeof(string));
            data.Columns.Add("author", typeof(string));
            data.Columns.Add("date", typeof(DateTime));
            data.Columns.Add("bioid", typeof(string));
            data.Columns.Add("ipsr", typeof(string));
            data.Columns.Add("fname", typeof(string));
            data.Columns.Add("lname", typeof(string));
            slno = 0;

          
            if (tweets.response.list.Length == 0)
            {
                DataRow row = data.NewRow();
                row["content"] = "No tweets found.";
                row["author"] = username;
                data.Rows.Add(row);

            }
            else
            {

                label3.Text = tweets.response.list[0].trackback_author_nick;
                for (int i = 0; i < tweets.response.list.Length; i++)
                {
                    slno = slno + 1;
                    DataRow row = data.NewRow();
                    row["sl_no"] = slno;
                    row["content"] = tweets.response.list[i].content;
                    row["author"] = tweets.response.list[i].trackback_author_nick;
                    row["date"] = getTimeFromUnixTimeStamp(tweets.response.list[i].trackback_date);
                    row["bioid"] = bioid;
                    row["ipsr"] = ipsr;
                    row["fname"] = fname;
                    row["lname"] = lname;
                    data.Rows.Add(row);
                }

                if (tweets.response.total > 100)
                {
                    int k = tweets.response.total / 100;
                    for (int l = 2; l <= k + 1; l++)
                    {

                        TwitterData.TweetData additionalpages = client.getTwitterData(username, l);
                        k = additionalpages.response.total/100;
                        for (int i = 0; i < additionalpages.response.list.Length; i++)
                        {
                            slno = slno + 1;
                            DataRow row = data.NewRow();
                            row["sl_no"] = slno;
                            row["content"] = additionalpages.response.list[i].content;
                            row["author"] = additionalpages.response.list[i].trackback_author_nick;
                            row["date"] = getTimeFromUnixTimeStamp(additionalpages.response.list[i].trackback_date);
                            row["bioid"] = bioid;
                            row["ipsr"] = ipsr;
                            row["fname"] = fname;
                            row["lname"] = lname;
                            data.Rows.Add(row);
                        }
                    }
                }

            }

            dataGridView1.DataSource = data;
            

            if (dataGridView1.Rows.Count > 0)
            {
                //Function obtained from stackoverflow
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                
                XcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }


                XcelApp.Columns.AutoFit();
              
                
               // XcelApp.Visible = true;
                XcelApp.ActiveWorkbook.SaveAs("C:\\Users\\Kannan\\Desktop\\Topsy\\final\\"+username+".xls", Excel.XlFileFormat.xlWorkbookNormal,
    System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false,
    Excel.XlSaveAsAccessMode.xlShared, false, false, System.Reflection.Missing.Value,
    System.Reflection.Missing.Value, System.Reflection.Missing.Value);

               

            }
        }

        private void export_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //Function obtained from stackoverflow
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            //string str;
            int rCnt = 0;
            //int cCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\Kannan\Desktop\Topsy\input.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;

            DataTable input = new DataTable();
            input.Columns.Add("bioid", typeof(string));
            input.Columns.Add("ipsr", typeof(int));
            input.Columns.Add("fname", typeof(string));
            input.Columns.Add("lname", typeof(string));
            input.Columns.Add("name", typeof(string));

            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
               
                 DataRow row = input.NewRow();
                row["bioid"] =  (string)(range.Cells[rCnt, 1] as Excel.Range).Value2;;
                row["ipsr"] =  (string)(range.Cells[rCnt, 2] as Excel.Range).Value2.ToString();
                row["fname"] =  (string)(range.Cells[rCnt, 3] as Excel.Range).Value2;
                row["lname"] =  (string)(range.Cells[rCnt, 4] as Excel.Range).Value2;
                row["name"] =  (string)(range.Cells[rCnt, 5] as Excel.Range).Value2;
                input.Rows.Add(row);
                
            }
            dataGridView1.DataSource = input;

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            DataTable data = new DataTable();
            data.Columns.Add("sl_no", typeof(int));
            data.Columns.Add("content", typeof(string));
            data.Columns.Add("author", typeof(string));
            data.Columns.Add("date", typeof(DateTime));
            data.Columns.Add("bioid", typeof(string));
            data.Columns.Add("ipsr", typeof(string));
            data.Columns.Add("fname", typeof(string));
            data.Columns.Add("lname", typeof(string));

                for (int j = 0; j < 358; j++)
                {
                    string uname = input.Rows[j][4].ToString();
                    string bioid = input.Rows[j][0].ToString();
                    string ipsr= input.Rows[j][1].ToString();
                    string fname = input.Rows[j][2].ToString();
                    string lname = input.Rows[j][3].ToString();


                    TwitterData.Service1Client client = new TwitterData.Service1Client();
                    TwitterData.TweetData tweets = client.getTwitterData(uname, 1);
                    if (tweets.response.list.Length == 0)
                    {
                        DataRow row = data.NewRow();
                        row["content"] = "No tweets found.";
                        row["author"] = uname;
                        data.Rows.Add(row);

                    }
                    else
                    {

                        label3.Text = tweets.response.list[0].trackback_author_nick;
                        for (int i = 0; i < tweets.response.list.Length; i++)
                        {
                            slno = slno + 1;
                            DataRow row = data.NewRow();
                            row["sl_no"] = slno;
                            row["content"] = tweets.response.list[i].content;
                            row["author"] = tweets.response.list[i].trackback_author_nick;
                            row["date"] = getTimeFromUnixTimeStamp(tweets.response.list[i].trackback_date);
                            row["bioid"] = bioid;
                            row["ipsr"] = ipsr;
                            row["fname"] = fname;
                            row["lname"] = lname;
                            data.Rows.Add(row);
                        }

                        if (tweets.response.total > 100)
                        {
                            int k = tweets.response.total / 100;
                            for (int l = 2; l <= k + 1; l++)
                            {

                                TwitterData.TweetData additionalpages = client.getTwitterData(uname, l);
                                k = additionalpages.response.total / 100;
                                for (int i = 0; i < additionalpages.response.list.Length; i++)
                                {
                                    slno = slno + 1;
                                    DataRow row = data.NewRow();
                                    row["sl_no"] = slno;
                                    row["content"] = additionalpages.response.list[i].content;
                                    row["author"] = additionalpages.response.list[i].trackback_author_nick;
                                    row["date"] = getTimeFromUnixTimeStamp(additionalpages.response.list[i].trackback_date);
                                    row["bioid"] = bioid;
                                    row["ipsr"] = ipsr;
                                    row["fname"] = fname;
                                    row["lname"] = lname;
                                    data.Rows.Add(row);
                                }
                            }
                        }

                    }


                    //retrieve(uname, bioid1,ipsr1,fname1,lname1);
                }

              dataGridView1.DataSource = data;


              if (dataGridView1.Rows.Count > 0)
              {
                  //Function obtained from stackoverflow
                  Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

                  XcelApp.Application.Workbooks.Add(Type.Missing);

                  for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                  {
                      XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                  }

                  for (int i = 0; i < dataGridView1.Rows.Count; i++)
                  {
                      for (int j = 0; j < dataGridView1.Columns.Count; j++)
                      {
                          XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                      }
                  }


                  XcelApp.Columns.AutoFit();


                  // XcelApp.Visible = true;
      //            XcelApp.ActiveWorkbook.SaveAs("C:\\Users\\Kannan\\Desktop\\Topsy\\data.xlsx", Excel.XlFileFormat.xlWorkbookNormal,
      //System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false,
      //Excel.XlSaveAsAccessMode.xlShared, false, false, System.Reflection.Missing.Value,
      //System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                  XcelApp.ActiveWorkbook.SaveAs("C:\\Users\\Kannan\\Desktop\\Topsy\\data.xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
    Excel.XlSaveConflictResolution.xlUserResolution, true,
     System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

              }

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }

        }

      
    }
}
