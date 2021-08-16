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

namespace Thi
{
    public partial class formthemgv : Form
    {
        public formthemgv()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnthemgv_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn về những thông tin đã điền hay chưa ??? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                dgvgv.DataSource = addgv();
                Close();
            }
        }

        DataSet addgv()
        {
            DataSet insert = new DataSet();
            string query = "insert GIAOVIEN VALUES ('"+txtmagv.Text+"' , N'"+txttengv.Text+"' , '"+txtngsinhgv.Text+"' , '"+cbgioitinhgv.Text+"' , N'"+txtnoisinhgv.Text+"' , '"+cbmamh.Text+"')";
            using (SqlConnection con = new SqlConnection(Connectionstring.connectionstring))
            {
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query,con);
                adapter.Fill(insert);
                con.Close();
            }
             return insert;
        }

    }
}
