﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahista
{
    class Bishop : ChessPiece
    {
        public Bishop(string pozicija, Color boja) : base(pozicija, boja)
        {
        }

        public override void move(string position)
        {
            if (position.Length != 2 || !IsEnglishLetter(position[0]) || position[1] < 1 || position[1] > 8) throw new Exception(); //IllegalArgumentException
            if (Pozicija[0] != position[0] && Pozicija[1] != position[1]) throw new Exception();
        }
    }
}
