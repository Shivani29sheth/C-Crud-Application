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

namespace InsertUpdateDeleteDemo
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(@"Data Source=DESKTOP-T3GKEL1;Initial Catalog=sampledb;Integrated Security=True");
            string query = "select * from tbl_login where username='" + username.Text.Trim() + "'and password ='" + password.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlconn);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            if (dtb1.Rows.Count == 1)
            {
                frmMain objfrmMain = new frmMain();
                this.Hide();
                objfrmMain.Show();
            }
            else
            {
                MessageBox.Show("check your useraname and password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
