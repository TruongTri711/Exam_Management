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
    public partial class formdangnhap : Form
    {
        public formdangnhap()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string tksv = "0750070054";
            string mksv = "123456";
            string tkgv = "admin";
            string mkgv = "123456";
            try
            {
                if (txttk.Text == tksv && txtmk.Text == mksv)
                {
                    txttk.Select();
                    formmain sv = new formmain();
                    sv.ShowDialog();                   
                    txttk.Clear();
                    txtmk.Clear();
                }
                else if (txttk.Text == tkgv && txtmk.Text == mkgv)
                {
                    txttk.Select();
                    formgiaovien gv = new formgiaovien();
                    gv.ShowDialog();                    
                    txttk.Clear();
                    txtmk.Clear();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttk.Clear();
                    txtmk.Clear();
                    txttk.Select();
                }
            }
            catch
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void formdangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}
