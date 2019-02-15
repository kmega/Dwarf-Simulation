using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThorinsCompany
{
    public class Mine
    {

        public List<Shaft> AllShafts = new List<Shaft>();
        public Foreman Foreman = new Foreman(); //it's supposed to be a kind of a parser.
        //It divides main list to smaller with that is of maximum count = 5;
        //it manages divided list of dwarves and sends them to each shaft;
        
        public Mine()
        {
            for (int i = 0; i < 2; i++)
            {
                AllShafts.Add(new Shaft());
            }
        }

        public void PerformMining(List<Dwarf> dwarves)
        {
            Foreman.ManageWorkingDwarves(dwarves, AllShafts);

            }
        }



    }

