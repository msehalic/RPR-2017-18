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
            throw new NotImplementedException();
        }
    }
}
