using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class stats : Form
    {
        private StatsController ObjStats = new StatsController();

        public stats()
        {
            InitializeComponent();
        }

        private void stats_Load(object sender, EventArgs e)
        {
            ObjStats.InsertData();

            int numLines = ObjStats.lines.Length;
            for (int i = 0; i < numLines; i++)
            {
                if (i >= 5) 
                {
                    break;
                }

                string[] data = ObjStats.lines[i].Split(' ');

                if (data != null && data.Length >= 4) 
                {
                    Label scoreLabel = Controls.Find("label" + (i * 3 + 2), true)[0] as Label;
                    scoreLabel.Text = data[0];

                    Label nameLabel = Controls.Find("label" + (i * 3 + 1), true)[0] as Label;
                    nameLabel.Text = data[1] + " " + data[2];

                    Label dateLabel = Controls.Find("label" + (i * 3 + 3), true)[0] as Label;
                    dateLabel.Text = data[3];
                }
                else
                {
                    Label scoreLabel = Controls.Find("label" + (i * 3 + 2), true)[0] as Label;
                    scoreLabel.Text = "";

                    Label nameLabel = Controls.Find("label" + (i * 3 + 1), true)[0] as Label;
                    nameLabel.Text = "";

                    Label dateLabel = Controls.Find("label" + (i * 3 + 3), true)[0] as Label;
                    dateLabel.Text = "";
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
