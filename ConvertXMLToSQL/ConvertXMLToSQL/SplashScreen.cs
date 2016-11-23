using ConvertXMLToSQL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertXMLToSQL
{
    public partial class SplashScreen : Form
    {
        private int timeOver = 50;
        private int currentTime = 0;
        ConvertXMLToSQL frmMain;
        public SplashScreen()
        {
            InitializeComponent();
            // Load Images
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            //Hide our form from user
            Image img = Resources.loadcat;
            pictureBox1.Image = img;
            frmMain = new ConvertXMLToSQL(this);
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (currentTime <= timeOver)
            {
                currentTime++;
            }
            else
            {
                frmMain.Show();
                timer1.Enabled = false;
                this.Hide();
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
