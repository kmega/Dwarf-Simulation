﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator2
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCalc stringcalculator = new StringCalc();
            stringcalculator.IgnoreMoreThan1000("1s,-2sdfg,3fd,-4\n5000");
            Console.ReadKey();
        }

    }
}