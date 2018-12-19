using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTask
{
    class Average_time_of_creating
    {
        public TimeSpan average_time(TimeSpan all_time, int number_people)
        {
            Double millisec = all_time.TotalMilliseconds / number_people;
            TimeSpan average = TimeSpan.FromMilliseconds(millisec);

            return average;
        }
    }
}
