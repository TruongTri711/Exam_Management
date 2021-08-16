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
    public partial class formgiaovien : Form
    {
        public formgiaovien()
        {
            InitializeComponent();
        }

        private void mntrdangxuat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvcauhoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvcauhoi.CurrentRow.Index; ;
            txtid.Text = dgvcauhoi.Rows[i].Cells[0].Value.ToString();
            txtcauhoi.Text = dgvcauhoi.Rows[i].Cells[1].Value.ToString();
            txtdapan1.Text = dgvcauhoi.Rows[i].Cells[2].Value.ToString();
            txtdapan2.Text = dgvcauhoi.Rows[i].Cells[3].Value.ToString();
            txtdapan3.Text = dgvcauhoi.Rows[i].Cells[4].Value.ToString();
            txtdapan4.Text = dgvcauhoi.Rows[i].Cells[5].Value.ToString();
            cbketqua1.Text = dgvcauhoi.Rows[i].Cells[6].Value.ToString();
            cbketqua2.Text = dgvcauhoi.Rows[i].Cells[7].Value.ToString();
            cbketqua3.Text = dgvcauhoi.Rows[i].Cells[8].Value.ToString();
            cbketqua4.Text = dgvcauhoi.Rows[i].Cells[9].Value.ToString();
            cbsocaudung.Text = dgvcauhoi.Rows[i].Cells[10].Value.ToString();
        }



        private void btnthemgv_Click(object sender, EventArgs e)
        {
            formthemgv gv = new formthemgv();
            gv.ShowDialog();
        }

        private void btntimkiemgv_Click(object sender, EventArgs e)
        {
            dgvsinhvien.DataSource = laysvtheomonhoc().Tables[0];
        }

        DataSet findgv()
        {
            DataSet findgv = new DataSet();
            string query = "select * from GIAOVIEN where MAGV = '" + txtfindtengv.Text + "'";
            using (SqlConnection con = new SqlConnection(Connectionstring.connectionstring))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(findgv);
                con.Close();
            }
            return findgv;
        }

        private void btnlammoicauhoi_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtcauhoi.Clear();
            txtdapan1.Clear();
            txtdapan2.Clear();
            txtdapan3.Clear();
            txtdapan4.Clear();
            cbketqua1.SelectedItem = null;
            cbketqua2.SelectedItem = null;
            cbketqua3.SelectedItem = null;
            cbketqua4.SelectedItem = null;
            cbsocaudung.SelectedItem = null;
        }

        private void btnlammoisv_Click(object sender, EventArgs e)
        {
            txtmasv.Clear();
            txthoten.Clear();
            txtngsinh.Clear();
            txtnoisinh.Clear();
            txtlop.Text = "";
            cbgioitinh.Text = "";
        }

        private void mntrdanhsachcauhoi_Click_1(object sender, EventArgs e)
        {
            dgvcauhoi.DataSource = getallcauhoi().Tables[0];

            txtid.Clear();
            txtcauhoi.Clear();
            txtdapan1.Clear();
            txtdapan2.Clear();
            txtdapan3.Clear();
            txtdapan4.Clear();
            cbketqua1.SelectedItem = null;
            cbketqua2.SelectedItem = null;
            cbketqua3.SelectedItem = null;
            cbketqua4.SelectedItem = null;
            cbsocaudung.SelectedItem = null;
            dgvdiem.Hide();
            grbtimkiem.Hide();
            dgvcauhoi.Show();
            dgvsinhvien.Hide();
            btncapnhatsv.Hide();
            btnxoasv.Hide();
            btnlammoisv.Hide();
            btnthemcauhoi.Show();
            btncapnhatcauhoi.Show();
            btnxoacauhoi.Show();
            btnlammoicauhoi.Show();
            grbthongtincauhoi.Show();
            grbthongtinsinhvien.Hide();        
        }

        DataSet getallcauhoi()
        {
            DataSet data = new DataSet();
            string querry = "select * from CAUHOI";
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(querry, connection);
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        private void mntrdanhsachsinhvien_Click(object sender, EventArgs e)
        {
            txtmasv.Clear();
            txthoten.Clear();
            txtngsinh.Clear();
            txtnoisinh.Clear();
            txtlop.Text = "";
            cbgioitinh.Text = "";
            dgvcauhoi.Hide();
            dgvdiem.Hide();
            dgvsinhvien.Show();
            grbthongtincauhoi.Hide();
            grbtimkiem.Hide();
            grbthongtinsinhvien.Show();

            dgvsinhvien.DataSource = laysvtheomonhoc().Tables[0];
        }

        DataSet laysvtheomonhoc()
        {
            DataSet data = new DataSet();
            string querry = " SELECT DISTINCT sv.MASV,sv.HOTEN,sv.NGAYSINH,sv.GIOITINH,sv.NOISINH,sv.MALOP FROM dbo.SINHVIEN sv , dbo.MONHOC mh, dbo.GIAOVIEN gv,dbo.KETQUA kq WHERE gv.MAMH = mh.MAMH AND kq.MAMH = mh.MAMH AND sv.MASV = kq.MASV and gv.TENGV = N'"+txtfindtengv.Text+"' ";
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(querry, connection);
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        private void dgvsinhvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvsinhvien.CurrentRow.Index;
            txtmasv.Text = dgvsinhvien.Rows[i].Cells[0].Value.ToString();
            txthoten.Text = dgvsinhvien.Rows[i].Cells[1].Value.ToString();
            txtngsinh.Text = dgvsinhvien.Rows[i].Cells[2].Value.ToString();
            cbgioitinh.Text = dgvsinhvien.Rows[i].Cells[3].Value.ToString();
            txtnoisinh.Text = dgvsinhvien.Rows[i].Cells[4].Value.ToString();
            txtlop.Text = dgvsinhvien.Rows[i].Cells[5].Value.ToString();

        }

        private void mntrdiemsinhvien_Click(object sender, EventArgs e)
        {
            dgvsinhvien.Hide();
            dgvcauhoi.Hide();
            dgvdiem.Show();
            grbtimkiem.Show();
            grbthongtinsinhvien.Hide();
            grbthongtincauhoi.Hide();
            btncapnhatsv.Hide();
            btnxoasv.Hide();
            btnlammoisv.Hide();
            btnthemcauhoi.Hide();
            btncapnhatcauhoi.Hide();
            btnxoacauhoi.Hide();
            btnlammoicauhoi.Hide();
            dgvdiem.DataSource = diemsinhvientheomonhoc().Tables[0];
        }

        DataSet diemsinhvientheomonhoc()
        {
            DataSet data = new DataSet();
            string querry = " SELECT SV.MASV,SV.HOTEN ,SV.NGAYSINH, LH.TENLOP,MH.TenMH,KQ.LANTHI,KQ.DIEM,DT.NGAYTHI  from SINHVIEN SV,KETQUA KQ , MONHOC MH , DETHI DT , LOPHOC LH,dbo.GIAOVIEN gv WHERE SV.MASV = KQ.MASV AND KQ.MAMH = MH.MAMH AND KQ.MADT = DT.MADT AND MH.MAMH = gv.MAMH AND SV.MALOP = LH.MALOP and gv.TENGV = N'"+txtfindtengv.Text+"' ";
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(querry, connection);
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        private void formgiaovien_Load(object sender, EventArgs e)
        {
            grbthongtinsinhvien.Show();
            dgvdiem.Hide();
            dgvcauhoi.Hide();
            dgvsinhvien.Show();
            grbtimkiem.Hide();
            grbthongtincauhoi.Hide();
            btnthemcauhoi.Hide();
            btncapnhatcauhoi.Hide();
            btnxoacauhoi.Hide();
            btnlammoicauhoi.Hide();
            btncapnhatsv.Show();
            btnxoasv.Show();
            btnlammoisv.Show();
            dgvsinhvien.Show();
            txtfindtengv.Select();
        }

        private void btnthemcauhoi_Click(object sender, EventArgs e)
        {           
            if (MessageBox.Show("Bạn đã chắc về những thông tin đã điền vào hay chưa ???", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                dgvcauhoi.DataSource = insertcauhoi();
                dgvcauhoi.DataSource = getallcauhoi().Tables[0];
            }

        }
        
        DataSet insertcauhoi()
        {
            DataSet insert = new DataSet();
            string query = "INSERT CAUHOI values('" + txtid.Text + "','" + txtcauhoi.Text + "' ,'" + txtdapan1.Text + "' , '" + txtdapan2.Text + "' , '" + txtdapan3.Text + "' , '" + txtdapan4.Text + "', '" + cbketqua1.Text + "'  , '" + cbketqua2.Text + "', '" + cbketqua3.Text + "' , '" + cbketqua4.Text + "' , '" + cbsocaudung.Text + "' )";
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(insert);
                connection.Close();
            }
            return insert;
        }

        private void btncapnhatcauhoi_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn cập nhật câu hỏi không ???", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                dgvcauhoi.DataSource = capnhatcauhoi();
                dgvcauhoi.DataSource = getallcauhoi().Tables[0];

                txtid.Clear();
                txtcauhoi.Clear();
                txtdapan1.Clear();
                txtdapan2.Clear();
                txtdapan3.Clear();
                txtdapan4.Clear();
                cbketqua1.SelectedItem = null;
                cbketqua2.SelectedItem = null;
                cbketqua3.SelectedItem = null;
                cbketqua4.SelectedItem = null;
                cbsocaudung.SelectedItem = null;             
            }

        }

        DataSet capnhatcauhoi()
        {
            DataSet update = new DataSet();
            string query = "UPDATE CAUHOI SET  NOIDUNGCAUHOI = N'" + txtcauhoi.Text + "' , DAPAN1 =N'" + txtdapan1.Text + "' , DAPAN2 = N'" + txtdapan2.Text + "' , DAPAN3 = N'" + txtdapan3.Text + "' , DAPAN4 = N'" + txtdapan4.Text + "', KETQUA1 = '" + cbketqua1.Text + "'  , KETQUA2 = '" + cbketqua2.Text + "', KETQUA3 = '" + cbketqua3.Text + "' , KETQUA4 = '" + cbketqua4.Text + "' , SOCAUDUNG = '" + cbsocaudung.Text + "' WHERE ID = '" + txtid.Text + "' ";
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(update);
                connection.Close();
            }
            return update;
        }

        private void btnxoacauhoi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa câu hỏi không ???", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                dgvcauhoi.DataSource = xoacauhoi();
                dgvcauhoi.DataSource = getallcauhoi().Tables[0];
                txtid.Clear();
                txtcauhoi.Clear();
                txtdapan1.Clear();
                txtdapan2.Clear();
                txtdapan3.Clear();
                txtdapan4.Clear();
                cbketqua1.SelectedItem = null;
                cbketqua2.SelectedItem = null;
                cbketqua3.SelectedItem = null;
                cbketqua4.SelectedItem = null;
                cbsocaudung.SelectedItem = null;
            }

        }
        DataSet xoacauhoi()
        {
            DataSet delete = new DataSet();
            string query = "DELETE CAUHOI WHERE ID = '" + txtid.Text + "'";
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(delete);
                connection.Close();
            }
            return delete;
        }

        private void btncapnhatsv_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật thông tin sinh viên không ???", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                dgvsinhvien.DataSource = capnhatsinhvien();
                dgvsinhvien.DataSource = laysvtheomonhoc().Tables[0];              
                txtmasv.Clear();
                txthoten.Clear();
                txtngsinh.Clear();
                txtnoisinh.Clear();

                cbgioitinh.Text = "";
                txtlop.Text = "";

            }

        }
        DataSet capnhatsinhvien()
        {
            string query = "UPDATE SINHVIEN SET HOTEN = N'" + txthoten.Text + "', NGAYSINH = '" + txtngsinh.Text + "', GIOITINH = '" + cbgioitinh.Text + "',NOISINH = N'" + txtnoisinh.Text + "' , MALOP = '" + txtlop.Text + "' WHERE MASV = '" + txtmasv.Text + "' ";
            DataSet update = new DataSet();
            using (SqlConnection connecion = new SqlConnection(Connectionstring.connectionstring))
            {
                connecion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connecion);
                adapter.Fill(update);
                connecion.Close();
            }
            return update;
        }

        private void btnxoasv_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa sinh viên không ???", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                dgvsinhvien.DataSource = xoasinhvienbangkq();
                dgvsinhvien.DataSource = xoasinhvienbangsv();              
                txtmasv.Clear();
                txthoten.Clear();
                txtngsinh.Clear();
                txtnoisinh.Clear();
                cbgioitinh.Text ="";
                txtlop.Text ="";
                dgvsinhvien.DataSource = laysvtheomonhoc().Tables[0];
            }

        }
        DataSet xoasinhvienbangsv()
        {          
            string query = "DELETE SINHVIEN WHERE MASV = '" + txtmasv.Text + "' ";
            DataSet xoa = new DataSet();
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(xoa);
                connection.Close();
            }
            return xoa;
        }
        DataSet xoasinhvienbangkq()
        {
            string query = "DELETE KETQUA WHERE MASV = '" + txtmasv.Text + "' ";
            DataSet xoa = new DataSet();
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(xoa);
                connection.Close();
            }
            return xoa;
        }

        private void btnthemgv_Click_1(object sender, EventArgs e)
        {
            formthemgv fm = new formthemgv();
            fm.ShowDialog();
        }

        private void txtfindmasv_TextChanged(object sender, EventArgs e)
        {
            String value = txtfindmasv.Text;
            if (!string.IsNullOrEmpty(value))
            {
                dgvdiem.DataSource = findsv().Tables[0];
            }
            else
            {
                dgvdiem.DataSource = diemsinhvientheomonhoc().Tables[0];
            }

        }
        DataSet findsv()
        {
            DataSet kq = new DataSet();
            string i = txtfindmasv.Text;
            string querry = " SELECT SV.MASV,SV.HOTEN ,SV.NGAYSINH, LH.TENLOP,MH.TenMH,KQ.LANTHI,KQ.DIEM,DT.NGAYTHI  from SINHVIEN SV,KETQUA KQ , MONHOC MH , DETHI DT , LOPHOC LH,dbo.GIAOVIEN gv WHERE SV.MASV = KQ.MASV AND KQ.MAMH = MH.MAMH AND KQ.MADT = DT.MADT AND MH.MAMH = gv.MAMH AND SV.MALOP = LH.MALOP and gv.TENGV = N'" + txtfindtengv.Text + "' AND sv.MASV = '" + i + "'   "; 
            using (SqlConnection connection = new SqlConnection(Connectionstring.connectionstring))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(querry, connection);
                adapter.Fill(kq);
                connection.Close();
            }

            return kq;
        }
    }
}
