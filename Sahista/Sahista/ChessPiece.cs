using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahista
{
    abstract class ChessPiece
    {
        public enum Color { BLACK, WHITE }; //ovdje ne moze static u C#, valjda moze u Javi

        readonly string pozicija;
        readonly Color boja;
        public ChessPiece(string pozicija, Color boja)
        {
            if (pozicija[0]<'A' || pozicija[0]>'Z' || pozicija[1]<1 || pozicija[1]>8) throw new Exception(); //IllegalArgumentException
        }

        public string getPosition()
        {
            return pozicija;
        }
        public Color getColor()
        {
            return boja;
        }
        public abstract void move(string position);
    }
}
