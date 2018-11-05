using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahista
{
    class Knight : ChessPiece
    {
        public Knight(string pozicija, Color boja) : base(pozicija, boja)
        {
        }

        public override void move(string position)
        {
            if (position.Length != 2 || !IsEnglishLetter(position[0]) || position[1] < 1 || position[1] > 8) throw new Exception(); //IllegalArgumentException
            if (position[0] == Pozicija[0] || position[1] == Pozicija[1]) throw new Exception();
            if (Math.Abs(position[0] - Pozicija[0]) == 1 && Math.Abs(position[1] - Pozicija[1])!=2) throw new Exception();
            if (Math.Abs(position[0] - Pozicija[0]) == 2 && Math.Abs(position[1] - Pozicija[1]) != 1) throw new Exception();
            Pozicija = position;
        }
    }
}
