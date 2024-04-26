using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stats Stats = new stats();
            Stats.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game Game = new game(textBox1.Text, textBox2.Text);
            Game.Show();
            textBox1.Text = "";
            textBox2.Text = "";
        }

   private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
