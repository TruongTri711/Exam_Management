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
    public partial class formmain : Form
    {
        public formmain()
        {
            InitializeComponent();
        }

        private void mntrdangxuat_Click_1(object sender, EventArgs e)
        {           
            Close();
        }

        private void formmain_Load_1(object sender, EventArgs e)
        {          
            grbtimkiemmasv.Hide();
            grbtimkiemtensv.Hide();
            dgvketqua.Hide();
        }

        private void mntrthi_Click_1(object sender, EventArgs e)
        {
            formcauhoithi fm = new formcauhoithi();
            fm.ShowDialog();
        }

        private void mntrketqua_Click_1(object sender, EventArgs e)
        {
            grbtimkiemmasv.Show();
            grbtimkiemtensv.Show();
            dgvketqua.Show();
            lblthongbao.Hide();
        }

        private void btntimkiemtensv_Click_1(object sender, EventArgs e)
        {
            dgvketqua.DataSource = findtensv().Tables[0];
            txtfindtensv.Clear();
        }

        DataSet findtensv()
        {
            DataSet kq = new DataSet();
            string querry = "SELECT sv.MASV,sv.HOTEN,sv.NGAYSINH,sv.GIOITINH,lh.TENLOP,mh.TenMH,kq.LANTHI,kq.DIEM,dt.NGAYTHI FROM dbo.SINHVIEN sv , dbo.KETQUA kq , dbo.DETHI dt , dbo.MONHOC mh, dbo.LOPHOC lh WHERE sv.MASV = kq.MASV AND mh.MAMH = kq.MAMH AND kq.MADT = dt.MADT AND sv.MALOP = lh.MALOP AND HOTEN = N'" + txtfindtensv.Text + "' ";
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(querry, connection);
                adapter.Fill(kq);
                connection.Close();
            }

            return kq;
        }

        private void btntinkiemmasv_Click_1(object sender, EventArgs e)
        {
            dgvketqua.DataSource = findmasv().Tables[0];
            txtfindmasv.Clear();
        }

        DataSet findmasv()
        {
            DataSet kq = new DataSet();
            string i = txtfindmasv.Text;
            string querry = "SELECT sv.MASV,sv.HOTEN,sv.NGAYSINH,sv.GIOITINH,lh.TENLOP,mh.TenMH,kq.LANTHI,kq.DIEM,dt.NGAYTHI FROM dbo.SINHVIEN sv , dbo.KETQUA kq , dbo.DETHI dt , dbo.MONHOC mh, dbo.LOPHOC lh WHERE sv.MASV = kq.MASV AND mh.MAMH = kq.MAMH AND kq.MADT = dt.MADT AND sv.MALOP = lh.MALOP AND sv.MASV = '" + i + "' ";
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(querry, connection);
                adapter.Fill(kq);
                connection.Close();
            }

            return kq;
        }

        //   private void txtfindmasv_TextChanged(object sender, EventArgs e)
        //  {
        //     String find = txtfindmasv.Text;
        ////   if (!string.IsNullOrEmpty(find))
        //  {
        //     dgvketqua.DataSource = findmasv().Tables[0];
        // }
        // else
        // {
        //    dgvketqua.DataSource = getketqua().Tables[0];
        // }

        // }

        //    private void txttimkiem_TextChanged(object sender, EventArgs e)
        //  {
        //    String values = txtfindtensv.Text;
        //   if (!string.IsNullOrEmpty(values))
        //   {
        //      dgvketqua.DataSource = findtensv().Tables[0];
        // }
        //  else
        //  {
        //     dgvketqua.DataSource = getketqua().Tables[0];
        // }

        //}
        // }
    }
}
