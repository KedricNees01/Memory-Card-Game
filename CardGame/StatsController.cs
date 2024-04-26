using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CardGame
{
    internal class StatsController
    {
        private string[] mdata = new string[6];
        private string[] mlines;

        public string[] data
        {
            get
            {
                return mdata;
            }
        }

        public string[] lines
        {
            get
            {
                return mlines;
            }
        }

        public void InsertData()
        {
            try
            {
                mlines = File.ReadAllLines(@"gameData.txt");
                Array.Sort(mlines, (a, b) => int.Parse(a.Split(' ')[0]).CompareTo(int.Parse(b.Split(' ')[0])));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Trap: " + ex.ToString());
            }
        }
    }
}
