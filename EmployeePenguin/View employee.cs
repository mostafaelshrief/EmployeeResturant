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

namespace EmployeePenguin
{
    public partial class View_employee : Form
    {
        public View_employee()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mostafa\source\repos\EmployeePenguin\EmployeePenguin\MyEmployeeDb.mdf;Integrated Security=True");
        private void FeatchData()
        {
            Con.Open();
            string query = "select * from EmployeeTbl where Empid='"+EmpIdTb.Text+"'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda =new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                EmpIdlbl.Text = dr["Empid"].ToString();
                Empaddlbl.Text = dr["EmpAdd"].ToString();
                EmpPoslbl.Text = dr["EmpPos"].ToString();
                EmpPhonelbl.Text = dr["EmpPhone"].ToString();
                EmpDoblbl.Text = dr["EmpDOB"].ToString();
                EmpNamelbl.Text = dr["EmpName"].ToString();
                EmpNational.Text = dr["EmpNational"].ToString();
                EmpStart.Text = dr["EmpStart"].ToString();
                
                EmpIdlbl.Visible=true;
                Empaddlbl.Visible = true;
                EmpPoslbl.Visible = true;
                EmpPhonelbl.Visible = true;
                EmpDoblbl.Visible = true;
                EmpNamelbl.Visible = true;
                EmpNational.Visible = true;
                EmpStart.Visible = true;
                
            }
            Con.Close();
        }

        private void View_employee_Load(object sender, EventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            FeatchData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("=====Employee Sumarry=====",new Font("Century Gothic", 20,FontStyle.Bold),Brushes.Black,new Point(200));
            e.Graphics.DrawString("Employee Id            :  "+EmpIdlbl.Text+"\t Employee Name  :"+EmpNamelbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10,100));
            e.Graphics.DrawString("Employee Adress        :  "+Empaddlbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10,140));
            e.Graphics.DrawString("Employee Postion       :  "+ EmpPoslbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 180));
            e.Graphics.DrawString("Employee Phone         :  "+ EmpPhonelbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10,220));
            e.Graphics.DrawString("Employee Date Of Birth :  "+ EmpDoblbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 260));
            e.Graphics.DrawString("Employee Start at      :  "+ EmpNational.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 300));
            e.Graphics.DrawString("Employee National Id   :  "+ EmpStart.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10,340));
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
