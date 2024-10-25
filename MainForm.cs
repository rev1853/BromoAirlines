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
    public partial class MainForm : Form
    {
        private bool isPanelOpen = true;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isPanelOpen)
            {
                panel2.Width = 85;
                isPanelOpen = false;
            } else
            {
                panel2.Width = 330;
                isPanelOpen = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var masterBandara = new MasterBandara();
            masterBandara.MdiParent = this;
            masterBandara.Dock = DockStyle.Fill;
            masterBandara.Show();
        }
    }
}
