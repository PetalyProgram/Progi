using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Progi
{
    internal class Opponent : Player
    {
        public override List<Card> Cards { get; set; }
        public override bool Eleg { get; set; }
        public override int Points { get; set; }
        public int Index { get; private set; }
        public Opponent(int index)
        {
            Index = index;
            Points = 0;
        }

        public override void CheckPoint(int i)
        {
            if (Cards[i].Point != "jumbó" && Cards[i].Point != "dáma" && Cards[i].Point != "király" && Cards[i].Point != "ász")
            {
                Points += int.Parse(Cards[i].Point);
            }

            else if (Cards[i].Point == "ász")
            {
                if (Points + 11 > 21)
                {
                    Points += 1;
                }

                else
                {
                    Points += 11;
                }
            }

            else
            {
                Points += 10;
            }
        }

        public override void Create()
        {
            Cards = new List<Card>();
            Cards.Add(new Card());
            Cards.Add(new Card());
            for (int i = 0; i < Cards.Count; i++)
            {
                CheckPoint(i);
            }
        }

        public override void Write()
        {
            Console.WriteLine($"A(z) {this.Index}. ellenfél lapjai : {this.ToString()}");
        }

        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < Cards.Count; i++)
            {
                result += Cards[i].Name + " " + Cards[i].Point + "; ";
            }
            result = result.Remove(result.Length - 2, 2);
            return result;
        }

        public void Ai()
        {
            int goodPoints = 0;
            for (int i = 0; i < 13; i++)
            {
                if (i < 9)
                {
                    if (Points + i <= 21)
                    {
                        goodPoints++;
                    }
                }

                else if (i < 12)
                {
                    if (Points + 10 <= 21)
                    {
                        goodPoints++;
                    }
                }

                else
                {
                    if (Points + 11 <= 21)
                    {
                        goodPoints++;
                    }
                }
            }

            float esely = (float)goodPoints / 13f * 100f;

            if (new Random().Next(100) < esely)
            {
                Cards.Add(new Card());
                CheckPoint(Cards.Count);
            }
        }
    }
}
