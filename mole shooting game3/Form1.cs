using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mole_shooting_game3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random r = new Random();
        int score = 0;
        int miss_shot = 0;
        int total_shot = 0;
        int salise = 0;
        int saniye = 0;
        int dakika = 0;
        void fn_shot()
        {
            score++;
            total_shot++;

            label1.Text = "Score=" + score;
            label2.Text = "Total Shot=" + total_shot;


        }
        void fn_miss_shot()
        {
            miss_shot++;
            total_shot++;

            label3.Text = "Miss Shot=" + miss_shot;
            label2.Text = "Total Shot=" + total_shot;

        }
        void reset()
        {
            score = 0;
            miss_shot = 0;
            total_shot = 0;

            label1.Text = "Score=" + score;
            label2.Text = "Total Shot=" + total_shot;
            label3.Text = "Miss Shot=" + miss_shot;
            label4.Text = "";
            label5.Text = "00";
            label6.Text = "";
            label7.Text = "00";
            label8.Text = "00";
            saniye = 0;
            salise = 0;
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x, y;
            x = r.Next(0, 500);
            y = r.Next(200, 330);
            pictureBox1.Location = new Point(x, y);

            if (miss_shot >= 10)
            {
                timer1.Stop();
                label4.Text = "Game Over";
                label5.Text = "";
                label7.Text = "";
                label8.Text = "";
                label6.Text = dakika + "    " + saniye + "    " + salise;
                timer2.Stop();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fn_shot();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            fn_miss_shot();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            salise++;
            label8.Text = Convert.ToString(salise);
            if (salise == 60)
            {
                salise = 0;
                saniye++;
                label7.Text = Convert.ToString(saniye);
            }
            if(saniye == 60)
            {
                saniye = 0;
                dakika++;
                label5.Text = Convert.ToString(dakika);
            }
        }
    }
}
