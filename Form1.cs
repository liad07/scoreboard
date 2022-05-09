using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace scoreboard
{
    public partial class Form1 : Form
    {
        System.Timers.Timer t;
        int h, m, s, z;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string home = Microsoft.VisualBasic.Interaction.InputBox("הכנס לינק ללוגו של המארחת",
                       "Title",
                       "link",
                       0,
                       0);
            string homename = Microsoft.VisualBasic.Interaction.InputBox("הכנס שם של המארחת",
                     "Title",
                     "name",
                     0,
                     0);
            string away = Microsoft.VisualBasic.Interaction.InputBox("הכנס לינק ללוגו של האורחת",
            "Title",
            "link",
            0,
            0);
            string awayname = Microsoft.VisualBasic.Interaction.InputBox("הכנס שם של האורחת",
         "Title",
         "name",
         0,
         0);
            string staduim = Microsoft.VisualBasic.Interaction.InputBox("הכנס שם איצטדיון",
"Title",
"staduim name",
0,
0);
            string color = Microsoft.VisualBasic.Interaction.InputBox("הכנס צבע רקע",
"Title",
"color name",
0,
0);
            h = 0;
            z = 0;
            //מארחת
            pictureBox2.ImageLocation = home;
            label2.Text = homename;
            //אורחת
            pictureBox1.ImageLocation = away;
            label1.Text = awayname;

            //איצטדיון
            label4.Text = staduim;
            //צבע רקע
            this.BackColor = FromName(color);

            //timer
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            t.Start();
        
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                
                s += 1;
             
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (s <= 9)
                {
                    label3.Text = m.ToString() + ":0" + s.ToString();

                }
                if (m <= 9)
                {
                    label3.Text = "0" + m.ToString() + ":" + s.ToString();

                }
                if (s <= 9 && m <= 9)
                {
                    label3.Text = "0" + m.ToString() + ":0" + s.ToString();

                }

                if (s > 9 && m > 9)
                {
                    label3.Text = m.ToString() + ":" + s.ToString();

                }
                if (m == 45)
                {

                    label3.Text = "מחצית";


                }

                if (m == 90)
  {
      label3.Text = "game over";
                    t.Stop();
                }
            }));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                label5.Text = h++.ToString();
            }
            if (e.KeyCode == Keys.CapsLock)
            {
                label6.Text = z++.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        public static Color FromName(string name)
        {
            Color c = Color.FromName(name);

            return c;
        }

    }
}
