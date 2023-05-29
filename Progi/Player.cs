using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progi
{
    abstract class Player
    {
        public abstract void Create();
        public abstract void Write();
        public abstract List<Card> Cards { get; set; }
		public abstract bool Eleg{get;set;}
        public abstract int Points { get; set; }
        public Player()
        {
            Create();
        }

        public abstract void CheckPoint(int i);
    }
}
