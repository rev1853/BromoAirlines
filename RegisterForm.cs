using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BromoAirlines
{
    public partial class RegisterForm : Form
    {
        private BromoAirlinesEntities Db = new BromoAirlinesEntities();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formLogin = new Form1();
            formLogin.Show();
            Hide();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var formLogin = new Form1();
            formLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var nama = textBox2.Text;
            var telp = textBox3.Text;
            var password = textBox4.Text;
            var tanggal = dateTimePicker1.Value;

            var usernameTelahDipakai = Db.Akun.Any(user => user.Username == username);
            if (usernameTelahDipakai)
            {
                MessageBox.Show("Username telah dipakai");
                return;
            }

            // "test1234".Length = 8
            if (int.TryParse(telp, out int _))
            {
                if (!(telp.Length >= 10 && telp.Length <= 15))
                {
                    MessageBox.Show("Telepon harus 10-15 digit");
                    return;
                }
            } else
            {
                MessageBox.Show("Telepon harus berupa digit");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password harus 8 karakter");
                return;
            }

            var akun = new Akun
            {
                MerupakanAdmin = false,
                Nama = nama,
                NomorTelepon = telp,
                Password = password,
                TanggalLahir = tanggal,
                Username = username
            };

            Db.Akun.Add(akun);
            Db.SaveChanges();

            MessageBox.Show("Register berhasil");
        }
    }
}
