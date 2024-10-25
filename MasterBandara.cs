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
    public partial class MasterBandara : Form
    {
        public BromoAirlinesEntities Db = new BromoAirlinesEntities();
        public MasterBandara()
        {
            InitializeComponent();
        }

        private void MasterBandara_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = Db.Bandara.ToList();

            comboBox1.DataSource = Db.Negara.ToList();
            comboBox1.DisplayMember = "Nama";
            // comboBox1.ValueMember = "ID"; // opsional
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var baris = bindingSource1.List[e.RowIndex] as Bandara;

                if (e.ColumnIndex == negaraDataGridViewTextBoxColumn.Index)
                {
                    e.Value = baris.Negara.Nama;
                }
            }
            catch { 
            
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nama = textBox1.Text;
            var iata = textBox2.Text;
            var kota = textBox3.Text;
            var negara = comboBox1.SelectedItem as Negara;
            var jumlahTerminal = numericUpDown1.Value;
            var alamat = richTextBox1.Text;

            var bandara = new Bandara
            {
                Nama = nama,
                KodeIATA = iata,
                Kota = kota,
                Negara = negara,
                JumlahTerminal = (int)jumlahTerminal,
                Alamat = alamat
            };

            Db.Bandara.Add(bandara);

            Db.SaveChanges();
            OnLoad(e);
            MessageBox.Show("Data berhasil tersimpan");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var baris = bindingSource1.List[e.RowIndex] as Bandara;

                if (e.ColumnIndex == ubahColumn.Index)
                {
                    textBox1.Text = baris.Nama;
                    textBox2.Text = baris.KodeIATA;
                    textBox3.Text = baris.Kota;
                    comboBox1.SelectedItem = baris.Negara;
                    numericUpDown1.Value = baris.JumlahTerminal;
                }
            }
            catch
            {

            }
        }
    }
}
