using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progi
{
    internal class Self : Player
    {
		public override bool Eleg {get; set;}
        public override List<Card> Cards { get; set; }
        public override int Points { get; set; }
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
            Console.WriteLine("Az ön lapjai : " + this.ToString());
            Console.WriteLine("Az ön pontjai : " + Points);
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
		
		public void Emeles()
		{
			int points = 0;
			for (int i = 0; i < Cards.Count; i++)
			{
				points += int.Parse(Cards[i].Point);
			}
			
			//if (points > 21) break; Eleg = true;
			Console.WriteLine("Kérsz még lapot? (y / n)");
			string yesOrNO = Console.ReadLine();
			while (yesOrNO != "y" && yesOrNO != "n"){
				Console.Write("Add meg újra : ");
			}
			if (yesOrNO == "y")
			{
				Cards.Add(new Card());
			}
			//else break;
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

    }
}
