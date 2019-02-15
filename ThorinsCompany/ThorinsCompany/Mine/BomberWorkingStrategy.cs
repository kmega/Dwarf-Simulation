using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
   public class BomberWorkingStrategy : IWorkingStrategy
    {
        public void StartWorking(Shaft shaft)
        {
            shaft.Explode();
        }
    }
}
