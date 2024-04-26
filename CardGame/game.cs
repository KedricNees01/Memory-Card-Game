using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CardGame
{
    public partial class game : Form
    {
        private int tickCount = 0;
        private int clickCount = 0;
        private int dealCount = 0;
        private PictureBox[] topPic = new PictureBox[12];
        private PictureBox[] botPic = new PictureBox[12];
        private string[] CardNames = new string[4];
        private int matchCount = 0;
        private int roundCount = 1;
        private string mName = "";
        private string mlName = "";
        private string final = "";



        private int TotalClicks = 0;
        private int Card1Indx = 0;
        private int Card2Indx = 0;

        private ClsDeck1 ObjDeck = new ClsDeck1();
        public game(string fName, string lName)
        {
            InitializeComponent();
            LoadStringArray();
            ObjDeck.BuildDeck();

            mName = fName;
            mlName = lName;



        }
        private void game_Load(object sender, EventArgs e)
        {
            LoadPicArray();
            LoadBackArray();
        }

        private void LoadBackArray()
        {
            int numPerRow = 6;
            int spacing = 10;
            int picBoxWidth = 154;
            int picBoxHeight = 239;
            int totalSpacingWidth = (numPerRow - 1) * spacing;
            int totalWidth = numPerRow * picBoxWidth + totalSpacingWidth;
            int xStart = (this.Width - totalWidth) / 2;

            for (int i = 0; i < 12; i++)
            {
                int row = i / numPerRow;
                int col = i % numPerRow;
                topPic[i] = new PictureBox();
                topPic[i].Left = xStart + col * (picBoxWidth + spacing);
                topPic[i].Top = 10 + row * (picBoxHeight + spacing);
                topPic[i].Width = picBoxWidth;
                topPic[i].Height = picBoxHeight;
                topPic[i].SizeMode = PictureBoxSizeMode.Zoom;
                topPic[i].Image = Image.FromFile("back.png");
                topPic[i].Visible = false;

                topPic[i].Tag = i;

                topPic[i].Click += new EventHandler(this.PicBoxArray_Click);
                this.Controls.Add(topPic[i]);
                topPic[i].BringToFront();
            }
        }
        private void LoadPicArray()
        {
            int numPerRow = 6;
            int spacing = 10;
            int picBoxWidth = 154;
            int picBoxHeight = 239;
            int totalSpacingWidth = (numPerRow - 1) * spacing;
            int totalWidth = numPerRow * picBoxWidth + totalSpacingWidth;
            int xStart = (this.Width - totalWidth) / 2; 

            for (int j = 0; j < 12; j++)
            {
                int row = j / numPerRow;
                int col = j % numPerRow;
                botPic[j] = new PictureBox();
                botPic[j].Left = xStart + col * (picBoxWidth + spacing);
                botPic[j].Top = 10 + row * (picBoxHeight + spacing);
                botPic[j].Width = picBoxWidth;
                botPic[j].Height = picBoxHeight;
                botPic[j].SizeMode = PictureBoxSizeMode.Zoom;
                botPic[j].Visible = true;

                botPic[j].Tag = j;

                this.Controls.Add(botPic[j]); 
            }
        }
        private void LoadStringArray()
        {
            CardNames[0] = "Ace";
            CardNames[1] = "Two";
            CardNames[2] = "Three";
            CardNames[3] = "Four";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ObjDeck.FetchHandFromDeck();

            for (int p = 0; p < 12; p++)
            {
                ObjDeck.DealFromHand(p);
                botPic[p].Image = Image.FromFile(ObjDeck.Card);
                topPic[p].Visible= true;

            }
            button1.Enabled= false;
            label1.Text = "Round " + roundCount + " Of 4";
            
        }
        private void reset()
        {
            timer1.Enabled = false;
            clickCount = 0;
            tickCount = 0;
            foreach (PictureBox i in topPic)
            {
                i.Click += PicBoxArray_Click;
            }

        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void PicBoxArray_Click(object sender, EventArgs e)
        {
            PictureBox alias = (PictureBox)sender;
            alias.Visible = false;
            clickCount++;

            if (clickCount == 1)
            {
                Card1Indx = (int)alias.Tag;
                TotalClicks++;
            }

            if (clickCount == 2)
            {
                foreach (PictureBox i in topPic)
                {
                    i.Click -= PicBoxArray_Click;
                }
                Card2Indx = (int)alias.Tag;
                timer1.Enabled = true;
                TotalClicks++;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            tickCount++;
            if (tickCount == 1)
            {
                reset();
            }
            if (ObjDeck.CheckHandForMatch(Card1Indx, Card2Indx))
            {
                botPic[Card1Indx].Visible = false;
                botPic[Card2Indx].Visible = false;
                matchCount++;

                if (matchCount == 6)
                {
                    ObjDeck.FetchHandFromDeck();
                    for (int q = 0; q < 12; q++)
                    {
                        ObjDeck.DealFromHand(q);
                        botPic[q].Image = Image.FromFile(ObjDeck.Card);
                        botPic[q].Visible = true;
                        topPic[q].Visible = true;

                    }
                    dealCount++;
                    roundCount++;
                    matchCount = 0;
                    if (roundCount < 5)
                    {
                        label1.Text = "Round " + roundCount + " Of 4";
                    }

                }

                if (dealCount == 4)
                {
                    MessageBox.Show("Game Over! Your score is " + TotalClicks);
                    final = TotalClicks.ToString() + " " + mName + " " + mlName + " " + DateTime.UtcNow.ToString("MM/dd/yyyy");

                    StreamWriter StreamOut = File.AppendText(@"gameData.txt");
                    StreamOut.WriteLine(final);
                    StreamOut.Close();
                    this.Close();
                }
            }
            else
            {
                topPic[Card1Indx].Visible = true;
                topPic[Card2Indx].Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
