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
            throw new NotImplementedException();
        }
    }
}
