using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace CardGame
{
    internal class ClsDeck1
    {
        private string[] mDeck = new string[52];
        private string[] mHand = new string[12];
        public string mCard = "";
        private Random random = new Random();


        private string[] Deck
        {
            get
            {
                return mDeck;
            }
        }

        public string[] Hand
        {
            get
            {
                return mHand;
            }
        }

        public string Card
        {
            get
            {
                return mCard;
            }
            set
            {
                mCard = value;
            }
        }

        public void FetchHandFromDeck()
        {

            int count = 0;
            for (int i = 0; i < 6; i++)
            {
                int tempRand = random.Next(0, mDeck.Length);
                mHand[count] = mDeck[tempRand];
                count++;
                mHand[count] = mDeck[tempRand];
                mDeck = mDeck.Except(mHand).ToArray();
                count++;
            }
            

            ShuffleHand();
        }
     
        public void ShuffleHand()
        {
            int n = mHand.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string temp = mHand[k];
                mHand[k] = mHand[n];
                mHand[n] = temp;
            }
        }

        public void DealFromHand(int index)
        {
            mCard = mHand[index];

        }

        public bool CheckHandForMatch(int index1, int index2)
        {
            string num1 = mHand[index1];
            string num2 = mHand[index2];

            if (num1 == num2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BuildDeck() 
        {                  
            int count = 0;
            for (int i = 1; i <= 13; i++)
            {
                if (i < 10)
                {
                    mDeck[count] = "0" + i.ToString() + "Diamonds.jpg";
                }
                else
                {
                    mDeck[count] = i.ToString() + "Diamonds.jpg";
                }
                count++;
            }

            for (int i = 1; i <= 13; i++)
            {
                if (i < 10)
                {
                    mDeck[count] = "0" + i.ToString() + "Hearts.jpg";
                }
                else
                {
                    mDeck[count] = i.ToString() + "Hearts.jpg";
                }
                count++;
            }

            for (int i = 1; i <= 13; i++)
            {
                if (i < 10)
                {
                    mDeck[count] = "0" + i.ToString() + "Clubs.jpg";
                }
                else
                {
                    mDeck[count] = i.ToString() + "Clubs.jpg";
                }
                count++;
            }

            for (int i = 1; i <= 13; i++)
            {
                if (i < 10)
                {
                    mDeck[count] = "0" + i.ToString() + "Spades.jpg";
                }
                else
                {
                    mDeck[count] = i.ToString() + "Spades.jpg";
                }
                count++;
            }
        }
    }
}
