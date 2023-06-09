using System;
using System.Windows.Forms;

namespace Binance_Api_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            if (button6.Visible == false)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }
        private Form activeform = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeform != null)
            {
                activeform.Close();
            }
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelChildForm.Controls.Add(childForm);
            PanelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Trend());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormInstruction());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string symbol_name;
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Visible == false)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
            symbol_name = (sender as Button).Text.ToString();
            CryptoInfo crypto = new CryptoInfo();
            OpenChildForm(new CryptoInfo());
        }
    }
}
