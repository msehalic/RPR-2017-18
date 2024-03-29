﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahista
{
    abstract class ChessPiece
    {
        public enum Color { BLACK, WHITE }; //ovdje ne moze static u C#, valjda moze u Javi

        private string pozicija;
         Color boja;

        protected string Pozicija { get => pozicija; set => pozicija = value; }
        internal Color Boja { get => boja; set => boja = value; }

        public bool IsEnglishLetter(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        public ChessPiece(string pozicija, Color boja)
        {
            if (pozicija.Length!=2 || !IsEnglishLetter(pozicija[0]) || pozicija[1]<1 || pozicija[1]>8) throw new Exception(); //IllegalArgumentException
        }

        public string getPosition()
        {
            return Pozicija;
        }
        public Color getColor()
        {
            return Boja;
        }
        public abstract void move(string position);
    }
}
