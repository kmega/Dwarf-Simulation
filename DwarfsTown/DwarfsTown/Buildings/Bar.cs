using System;
using System.Collections.Generic;

namespace DwarfsTown
{
    public class Bar
    {
        public int feed;
        public Bar()
        {
            feed = 200;
        }

        

        public void FeedDwarfs(List<Dwarf> dwarfs)
        {
            if(dwarfs.Count == 0)
            {
                throw new Exception("Brak krasnoludów");    
            }
            
            foreach(var dwarft in dwarfs)
            {
                if(feed > 9)
                {
                    feed --;
                }
                else
                {   
                    throw new Exception("Order food, it's left ");
                }
            }
            //string textToNewsPaper = string.Format("Order food, it's left {0}", feed);
            //        City.newsPaper.Add(textToNewsPaper);
            
            
                
        }
    }
}