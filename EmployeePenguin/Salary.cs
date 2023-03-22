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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mostafa\source\repos\EmployeePenguin\EmployeePenguin\MyEmployeeDb.mdf;Integrated Security=True");

        private void FeatchData()
        {
            if (EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter Employee Id");
            }
            else
            {
                Con.Open();
                string query = "select * from EmployeeTbl where Empid='" + EmpIdTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    EmpIdTb.Text = dr["Empid"].ToString();
                    EmpNamelbl.Text = dr["EmpName"].ToString();
                    EmpPoslbl.Text = dr["EmpPos"].ToString();

                }
                Con.Close();
            }
            
        }
        private void EmpIdTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        double DalilyBase,Penlty,Montlysalary,Total;
        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpPoslbl.Text == "")
            {
                MessageBox.Show("Select an Employee");
            }
            else if (WorkTb.Text == "" || Convert.ToInt32(WorkTb.Text) > 30) 
            {
                MessageBox.Show("Enter valid numbers of Days");
            }
            else if (AdvanceTb.Text == "" || PenaltyTb.Text == "")
            {
                MessageBox.Show("fill all information");
            }
            else
            {
                if (EmpPoslbl.Text == "Accounting")
                {
                    DalilyBase =133.333333333;
                }
                else if (EmpPoslbl.Text == "Headwaiter")
                {
                    DalilyBase = 183.33333333;
                }
                else if (EmpPoslbl.Text == "Barista")
                {
                    DalilyBase = 116.66666667;
                }
                else if (EmpPoslbl.Text == "Exc-chef")
                {
                    DalilyBase = 400;
                }
                else if (EmpPoslbl.Text == "Ass-Headwaiter")
                {
                    DalilyBase = 133.333333333;
                    
                }
                else if (EmpPoslbl.Text == "Waiter")
                {
                    DalilyBase = 116.66666667;
                }
                else if (EmpPoslbl.Text == "BusBoy")
                {
                    DalilyBase = 50;
                }
                else if (EmpPoslbl.Text == "Chief")
                {
                    DalilyBase = 150;
                }
                else if (EmpPoslbl.Text == "Co-chief")
                {
                    DalilyBase = 100;
                }
                else
                {
                    DalilyBase = 93.33333333;
                }
                if (WorkTb.Text=="0")
                {
                    Penlty = 0;
                    Montlysalary = DalilyBase * 30;
                    Total = DalilyBase * Convert.ToInt32(WorkTb.Text) - Penlty - Convert.ToInt32(AdvanceTb.Text);
                    SalaryDisplay.Text = "Employee Id :" + EmpIdTb.Text + "\n" + "Employee Name :" + EmpNamelbl.Text + "\n" + "Employee Postion :" + EmpPoslbl.Text + "\n" + "Worked days :" + WorkTb.Text + "\n" + "Daliy Salary" + DalilyBase.ToString() + "\n" + "Monthly Salary" + Montlysalary.ToString() + "\n" + "" + "Penalty days :" + PenaltyTb.Text 
                   + "\n" + "Salary =(Daliy salary * Worked days)-(Penalty days*Daliy salary)" + "\n" + "" + "Advance :" + AdvanceTb.Text + "\n" + "" + "Total Salary :" + Total
                   ;
                }
                else
                {
                Penlty = DalilyBase * Convert.ToInt32(PenaltyTb.Text);
                    Montlysalary = DalilyBase * 30;
                    Total = DalilyBase*Convert.ToInt32(WorkTb.Text)-Penlty- Convert.ToInt32(AdvanceTb.Text);
                    SalaryDisplay.Text = "Employee Id :" + EmpIdTb.Text + "\n" + "Employee Name :" + EmpNamelbl.Text + "\n" + "Employee Postion :" + EmpPoslbl.Text + "\n" + "Worked days :" + WorkTb.Text + "\n" + "Daliy Salary" + DalilyBase + "\n" + "" + "Penalty days :" + PenaltyTb.Text
                       + "\n" + "Salary =(Daliybase * Worked days)-(Penalty days*Daliybase)" + "\n" + "" + "Advance :" + AdvanceTb.Text + "\n" + "" + "Total Salary :" + Total
                       ;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("=====Employee Sumarry=====", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(200));
            e.Graphics.DrawString("Employee Id            :  " + EmpIdTb.Text + "\t Employee Name  :" + EmpNamelbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 100));
            e.Graphics.DrawString("Employee Postion       :  " + EmpPoslbl.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 140));
            e.Graphics.DrawString("Employee Works day     :  " + WorkTb.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 180));
            e.Graphics.DrawString("Employee Daily salary  :  " + DalilyBase.ToString(), new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 220));
            e.Graphics.DrawString("Employee Penalty days  :  " + PenaltyTb.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 260));
            e.Graphics.DrawString("Employee advance       :  " + AdvanceTb.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 300));
            e.Graphics.DrawString("Total salary = (Daliybase * Worked days)-(Penalty days*Daliybase)  ", new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 340));
            e.Graphics.DrawString("Total salary           :  " + Total.ToString(), new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Blue, new Point(10, 380));

        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FeatchData();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
