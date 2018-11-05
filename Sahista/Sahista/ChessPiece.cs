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
        public bool IsEnglishLetter(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        public ChessPiece(string pozicija, Color boja)
        {
            if (pozicija.Length!=2 || !IsEnglishLetter(pozicija[0]) || pozicija[1]<1 || pozicija[1]>8) throw new Exception(); //IllegalArgumentException
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
