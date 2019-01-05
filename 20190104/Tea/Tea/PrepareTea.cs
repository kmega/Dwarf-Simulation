using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea
{
   public  class PrepareTea
    {

        public string Result(List<TeaObj> tealist, string name, double temp, double time)
        {
            string result = "We don't have this tea";
            foreach (var item in tealist)
            {

                if (item.name == name)
                {

                    result = TeaMaker(temp, item.temp, time, item.time).ToString();


                }
            }
            return result;
        }
                public TeaResult TeaMaker(double tempgiven, double temptea, double timegiven, double timetea)
        {

            TeaResult resulttime = timecheck(timegiven, timetea);
            TeaResult resulttemp = tempcheck(tempgiven, temptea);

            if ((resulttime == TeaResult.yucky) || ( resulttemp == TeaResult.yucky))
            {
                return TeaResult.yucky;
            }
            else if ((resulttime == TeaResult.weak) || (resulttemp == TeaResult.weak))
            {
                return TeaResult.weak;
            }

            else
            {
                return TeaResult.perfect;
            }
            

        }

        public TeaResult tempcheck(double tempgiven, double temptea)
        {

            if ((temptea * 0.9) > tempgiven)
            {

                return TeaResult.weak;

            }
            else if ((temptea * 1.1) < tempgiven)
            {
                return TeaResult.yucky;
            }
            else
            {
                return TeaResult.perfect;
            }

        }

        public TeaResult timecheck(double timegiven, double timetea)
        {
            timetea = timetea * 60;

            if ((timetea * 0.9) > timegiven)
            {

                return TeaResult.weak;

            }
            else if ((timetea * 1.1) < timegiven)
            {
                return TeaResult.yucky;
            }
            else
            {
                return TeaResult.perfect;
            }

        }

        public enum TeaResult { perfect, yucky, weak };


    }
}
