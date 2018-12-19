using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTask
{
    class Cout_new_creating_time
    {
        public TimeSpan Cout_new_time(TimeSpan old_time, TimeSpan average_time, int nr_people_without_time)
        {
            TimeSpan new_time = old_time + TimeSpan.FromTicks(average_time.Ticks * nr_people_without_time);

            return new_time;

        }
    }
}
