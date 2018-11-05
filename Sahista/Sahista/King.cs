using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahista
{
    class King : ChessPiece
    {
        public King(string pozicija, Color boja) : base(pozicija, boja)
        {
        }

        public override void move(string position)
        {
            if (position.Length != 2 || !IsEnglishLetter(position[0]) || position[1] < 1 || position[1] > 8) throw new Exception(); //IllegalArgumentException
            if ((Math.Abs(position[0] - Pozicija[0]) + Math.Abs(position[1] - Pozicija[1])) > 1) throw new Exception();
            Pozicija = position;
        }
    }
}
