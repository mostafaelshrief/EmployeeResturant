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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mostafa\source\repos\EmployeePenguin\EmployeePenguin\MyEmployeeDb.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpidTb.Text==""|| EmpNameTb.Text==""||EmpPhone.Text==""||EmpDobTb.Text==""||EmpPosTb.Text==""||EmpAddTb.Text==""||EmpStart.Text==""||EmpNational.Text=="")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query= "insert into EmployeeTbl values('" + EmpidTb.Text+"','"+EmpNameTb.Text+"','"+EmpAddTb.Text+"','"+EmpPosTb.SelectedItem.ToString()+"','"+EmpDobTb.Value.Date+"','"+EmpPhone.Text+"','"+EmpNational.Text+"','"+EmpStart.Value.Date+"')";                 
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee successfully Added");

                    Con.Close();
                    populate();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populate()
        {
            Con.Open();
            String query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder bulider = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (EmpidTb.Text=="")
            {
                MessageBox.Show("Seclect employee id");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "delete from EmployeeTbl where Empid='" + EmpidTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee deleteed successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void EmpPosTb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
