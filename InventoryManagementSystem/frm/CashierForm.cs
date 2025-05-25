using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem.frm
{
    public partial class CashierForm : Form
    {
        public CashierForm()
        {
            InitializeComponent();
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void slide(Button button)
        {
            panelSlide.BackColor = Color.White;
            panelSlide.Height = button.Height;
            panelSlide.Top = button.Top;
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            slide(btnTrans);
            GetTransNo();
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            slide(btnProd);
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            slide(btnPayment);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            slide(btnLogout);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void gbbtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public void GetTransNo()
        {
            string sdate = DateTime.Now.ToString("yyyyMMdd");
            string transno = sdate + "1001";
            lblTransNo.Text = transno;
        }

    }
}
