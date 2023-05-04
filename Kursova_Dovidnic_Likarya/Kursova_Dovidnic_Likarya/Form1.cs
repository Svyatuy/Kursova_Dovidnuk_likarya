using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kursova_Vitaliy;

namespace Kursova_Dovidnic_Likarya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            Data.Properties();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            // Якщо брано всі checkBox
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked
                && checkBox5.Checked && checkBox6.Checked && checkBox7.Checked && checkBox8.Checked
                && checkBox9.Checked && checkBox10.Checked)
            {
                panel4.Visible = true; // Корисна інформація ;)
            }
            else if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked
                || checkBox5.Checked || checkBox6.Checked || checkBox7.Checked || checkBox8.Checked
                || checkBox9.Checked || checkBox10.Checked)
            {
                Data.selected = new bool[10];
                Data.selected[0] = checkBox1.Checked;
                Data.selected[1] = checkBox2.Checked;
                Data.selected[2] = checkBox3.Checked;
                Data.selected[3] = checkBox4.Checked;
                Data.selected[4] = checkBox5.Checked;
                Data.selected[5] = checkBox6.Checked;
                Data.selected[6] = checkBox7.Checked;
                Data.selected[7] = checkBox8.Checked;
                Data.selected[8] = checkBox9.Checked;
                Data.selected[9] = checkBox10.Checked;

                int[] n = Data.Coincidence(Data.diseases, Data.selected);
                string[] output = new string[n.Length];
                double[] percent = new double[n.Length];
                int count = 0;

                for (int i = 0; i < n.Length; i++)
                {
                    count += n[i];
                }
                for (int i = 0; i < n.Length; i++)
                {
                    percent[i] = ((n[i] * 100) / count) * 4;

                    output[i] = n[i] + "|" + i;

                    //label2.Text = label2.Text +" "+ output[i];
                }

                Array.Sort(output);
                Array.Reverse(output);



                //label3.Text = "";

                for (int i = 0; i < output.Length; i++)
                {
                    //label3.Text = label3.Text + " " + output[i];
                    n[i] = Convert.ToInt32(output[i].Remove(0, output[i].IndexOf('|') + 1));
                }

                ShowDiseases(percent, n);

                Data.rotation = n;

                panel2.Visible = true;

            }
            else MessageBox.Show("Оберіть симптоми !", "Попереджнення");
        }

        void ShowDiseases(double[] per, int[] n)
        {
            label2.Text = Data.info[n[0]][0] + " " + per[n[0]] + "%";
            label3.Text = Data.info[n[1]][0] + " " + per[n[1]] + "%";
            label4.Text = Data.info[n[2]][0] + " " + per[n[2]] + "%";
            label5.Text = Data.info[n[3]][0] + " " + per[n[3]] + "%";
            label6.Text = Data.info[n[4]][0] + " " + per[n[4]] + "%";
            label7.Text = Data.info[n[5]][0] + " " + per[n[5]] + "%";
            label8.Text = Data.info[n[6]][0] + " " + per[n[6]] + "%";
            label9.Text = Data.info[n[7]][0] + " " + per[n[7]] + "%";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        void ShowExtendedInfo(int s)
        {
            label10.Text = Data.info[Data.rotation[s]][0];
            label11.Text = Data.info[Data.rotation[s]][1];
            label12.Text = Data.info[Data.rotation[s]][2];
            label13.Text = Data.info[Data.rotation[s]][3];
            label14.Text = Data.info[Data.rotation[s]][4];
            panel3.Visible = true;
            panel2.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ShowExtendedInfo(0);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ShowExtendedInfo(1);
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            ShowExtendedInfo(2);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ShowExtendedInfo(3);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ShowExtendedInfo(4);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ShowExtendedInfo(5);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ShowExtendedInfo(6);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ShowExtendedInfo(7);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        

    }
}
