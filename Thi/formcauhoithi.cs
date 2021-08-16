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
    public partial class formcauhoithi : Form
    {               
        public int tongcauhoitrongbode = 35;
        public int tongcauhoi = 30;
        public int tongthoigian = 30;
        int Pos = 1;      
        DataTable dtTracNghiem = new DataTable();
        SqlConnection con = new SqlConnection();

        public formcauhoithi()
        {
            InitializeComponent();
        }      

        private void layrandomcauhoi()
        {
            int[] dscauhoi = new int[tongcauhoi];
            int Layso = 0;
            int i, j = 0;
            Boolean KTTrung = false;

            // sinh ra tập hợp các số ngẫu nhiên
            Random songaunhien = new Random();
            for ( i = 1; i <= tongcauhoi; i++)
            {
                while(true)
                {
                    KTTrung = false;
                    Layso = songaunhien.Next(1, tongcauhoitrongbode);
                    for (j = 0; j < i; j++)
                    {
                        if(dscauhoi[j] == Layso)
                        {
                            KTTrung = true;
                            break;
                        }
                        if(KTTrung == false)
                        {
                            break;
                        }
                    }
                    dscauhoi[i - 1] = Layso;
                }
                
                // lay danh sach cau hoi ngau nhien va dua vao datatable
                DataSetList.dscauhoi30 ds = new DataSetList.dscauhoi30();
                dtTracNghiem = ds.Tables[0];

                for ( i = 0; i < dscauhoi.Count(); i++)
                {
                    dtTracNghiem.Rows.Add();
                    dtTracNghiem.Rows[i]["ID"] = i + 1;
                    //dtTracNghiem.Rows[i][""] = dscauhoi[i];

                    // lấy data từ sever đưa vào datatable tracnghiem
                    using (SqlCommand cmd = new SqlCommand("select * from CAUHOI where ID =" + dscauhoi[i],con))
                    {
                        con.Open();
                        SqlDataReader rd = cmd.ExecuteReader();
                        while(rd.Read())
                        {
                            //dtTracNghiem.Rows[i]["NOIDUNGCAUHOI"] = con.
                        }



                        con.Close();    
                    }
                }
            }
        }

        private void formcauhoithi_Load(object sender, EventArgs e)
        {
            cbmamon.Select();
            txtrandom.Hide();
            btnnopbai.Hide();
            btncautiep.Hide();
            btncautruoc.Hide();
            grbketqua.Hide();
            btndong.Hide();
        }



        private void btn_batdauthi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc về những thông tin đã điền ??? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                btnnopbai.Show();
                btncautiep.Show();
                btncautruoc.Show();
                btnbatdauthi.Hide();
                txtrandom.Show();
                                                                         
                iPhut = tongthoigian - 1;
                iGiay = 59;
                timer1.Enabled = true;
                hienthithoigian();

                Random rd = new Random();
                txtrandom.Text = rd.Next(100, 200).ToString();              
            }

        }
        DataSet insertsvdk()
        {
            DataSet insert = new DataSet();
            string query = "INSERT SINHVIEN VALUES ('" + txtmasvdangky.Text + "',N'" + txthotendk.Text + "' ,'" + txtngsinhdk.Text + "' , '" + cbgioitinhdk.Text + "' , N'" + txtnoisinhdk.Text + "' , '" + cblopdk.Text + "')";
            using (SqlConnection con = new SqlConnection(Connectionstring.connectionstring))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(insert);
                con.Close();
            }
            return insert;
        }                

        private void hienthithoigian()
        {
            string sphut = "";
            string sgiay = "";

            if (iPhut < 10)
            {
                sphut = "0" + iPhut.ToString();
            } 
            else
            {
                sphut = iPhut.ToString();
            }
            if (iGiay < 10)
            {
                sgiay = "0" + iGiay.ToString();
            }
            else
            {
                sgiay = iGiay.ToString();
            }

            txtthoigiandiemnguoc.Text = sphut + ":" + sgiay;           

            // khi còn 10s của mỗi phút sẽ hiện phút lên
            /* if (iGiay < 10)
             {
                 sphut = iPhut.ToString();
             } 
             if (iGiay < 10)
             {
                 sgiay = "0" + iGiay.ToString();
             }
             else
             {
                 sgiay = iGiay.ToString();
             }

             this.txtthoigian.Text = sphut + ":" + sgiay;
             */
        }

        int iPhut = 0;
        int iGiay = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();

            iGiay--;

            if (iGiay == 0)
            {
                if (iPhut > 0)
                {
                    iPhut--;
                    iGiay = 60;
                }
                else
                {
                    iPhut = 0;
                    iGiay = 0;
                }
            }

            if ((iPhut == 0) && (iGiay == 0))
            {
                hienthithoigian();
                timer1.Enabled = false;
                MessageBox.Show("Hết Giờ.","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
               // KetThucThi();
            }
            else
            {
                hienthithoigian();
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            txtmasvdangky.Text = "";
            txthotendk.Text = "";
            txtngsinhdk.Text = "";
            cbgioitinhdk.SelectedItem = null;
            txtnoisinhdk.Text = "";
            cblanthidk.SelectedItem = null;
            cblopdk.SelectedItem = null;
            cblanthidk.SelectedItem = null;           
        }

        private void btnnopbai_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn nộp bài không ???","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK )
            {
               // dgvsv.DataSource = insertsvdk();
              //  dgvdethi.DataSource = insertdethi();
              //  dgvkq.DataSource = insertketqua();

                timer1.Enabled = false;
                btnnopbai.Hide();
                grbketqua.Show();
                btndong.Show();
            }
        }

        DataSet insertdethi()
        {
            DataSet insert = new DataSet();
            string query = "insert DETHI values ( '"+txtrandom.Text+"' , '"+txtthoigianthi.Text+"' , '"+txtsocauhoi.Text+"' , '"+dtpngaygiothi.Text+"' )";
            using (SqlConnection con = new SqlConnection(Connectionstring.connectionstring))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(insert);
                con.Close();
            }

                return insert;
        }

        DataSet insertketqua()
        {
            DataSet insert = new DataSet();
            string query = "insert KETQUA values ('" + txtmasvdangky.Text + "' , '" + cbmamon.Text + "' , '" + txtrandom.Text + "' , '" + cblanthidk.Text + "' , '" + txtdiem.Text + "' , '" + txtcaudung.Text + "' , '" + txtcausai.Text + "')";
            using (SqlConnection con = new SqlConnection(Connectionstring.connectionstring))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(insert);
                con.Close();
            }

            return insert;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
