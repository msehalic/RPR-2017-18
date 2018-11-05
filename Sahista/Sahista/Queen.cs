using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahista
{
    class Queen : ChessPiece
    {
        public Queen(string pozicija, Color boja) : base(pozicija, boja)
        {
        }

        public override void move(string position)
        {
            if (position.Length != 2 || !IsEnglishLetter(position[0]) || position[1] < 1 || position[1] > 8) throw new Exception(); //IllegalArgumentException
            Pozicija = position;
        }
    }
}
