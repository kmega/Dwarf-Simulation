﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SklepOdziezowy.Enums;

namespace SklepOdziezowy.Domena
{
    class Kurtki
    {
        public Kolor Kolor { get; set; }
        public short Rozmiar { get; set; }
        public decimal Cena { get; set; }
        public bool MaKaptur { get; set; }
        public bool Wodoodporna { get; set; }
        public bool Skorzana { get; set; }
    }
}