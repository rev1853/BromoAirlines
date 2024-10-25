using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoAirlines
{
    public partial class Form1 : Form
    {

        private BromoAirlinesEntities Db = new BromoAirlinesEntities();


        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "admin";
            textBox2.Text = "admin123";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formRegister = new RegisterForm();
            formRegister.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;

            var dataUser = Db.Akun.Where(user => user.Username == username && user.Password == password).FirstOrDefault();

            if (dataUser != default)
            {
                if (dataUser.MerupakanAdmin)
                {
                    Hide();
                    new MainForm().Show();
                } else
                {
                    MessageBox.Show("Anda bukan admin");
                }
            } else
            {
                MessageBox.Show("Username atau Password salah");
            }
        }
    }
}
