using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThorinsCompany
{
    public class Mine
    {

        public Shaft[] allShafts;
        public Foreman Master; //it's supposed to be a kind of a parser.
        //It divides main list to smaller with that is of maximum count = 5;
        //it manages divided list of dwarves and sends them to each shaft;
        
        public Mine()
        {
            allShafts = new Shaft[2] { new Shaft(), new Shaft() };
            Master = new Foreman();
            

        }

        public void PerformMining(List<Dwarf> dwarves)
        {

            List<WorkingGroup> workingGroups = Master.DivideDwarvesIntoWorkingGroups(dwarves);

            // put groups to aviable shafts
            // do work in shafts
            // result


            }

        }
        

    }

