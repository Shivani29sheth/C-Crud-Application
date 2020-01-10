using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InsertUpdateDeleteDemo
{
    public partial class frmMain : Form
    {
        SqlConnection con= new SqlConnection("Data Source=.;Initial Catalog=sampledb;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record
        int ID = 0;
        public frmMain()
        {
            InitializeComponent();
            DisplayData();
        }
        //Insert Data
        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text != "" && txt_State.Text != "" && txt_Pincode.Text!="" && txt_Gender.Text!="")
            {
                cmd = new SqlCommand("insert into tbl_record(Name,State,Pincode,Gender) values(@name,@state,@pincode,@gender)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                cmd.Parameters.AddWithValue("@state", txt_State.Text);
                cmd.Parameters.AddWithValue("@pincode", txt_Pincode.Text);
                cmd.Parameters.AddWithValue("@gender", txt_Gender.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }
        //Display Data in DataGridView
        private void DisplayData()
        {
            con.Open();
            DataTable dt=new DataTable();
            adapt=new SqlDataAdapter("select * from tbl_Record",con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Clear Data 
        private void ClearData()
        {
            txt_Name.Text = "";
            txt_State.Text = "";
            txt_Pincode.Text = "";
            txt_Gender.Text = "";
            ID = 0;
        }
        //dataGridView1 RowHeaderMouseClick Event
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_State.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Pincode.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Gender.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
        //Update Record
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text != "" && txt_State.Text != "" && txt_Pincode.Text != "" && txt_Gender.Text != "")
            {
                cmd = new SqlCommand("update tbl_Record set Name=@name,State=@state,Pincode=@pincode,Gender=@gender where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                cmd.Parameters.AddWithValue("@state", txt_State.Text);
                cmd.Parameters.AddWithValue("@pincode", txt_Pincode.Text);
                cmd.Parameters.AddWithValue("@gender", txt_Gender.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }
        //Delete Record
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if(ID!=0)
            {
                cmd = new SqlCommand("delete tbl_Record where ID=@id",con);
                con.Open();
                cmd.Parameters.AddWithValue("@id",ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
