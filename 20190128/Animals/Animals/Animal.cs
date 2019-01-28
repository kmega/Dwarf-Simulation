using Animals.Enums;
using Animals.Introduce;
using System;
using System.Collections.Generic;
using System.Text;
using WhatEat = Animals.Enums.WhatEat;

namespace Animals
{
   public class Animal
    {
       public HowMove HowIMove;
      public  WhatEat WhatIEat;
      public  string MyName;


        public void MyIntroduce()
        {
            new SayYourName().IntroduceYourself(MyName);
            new HowYouMove().IntroduceYourself(HowIMove.ToString());
            new WhatIEat().IntroduceYourself(WhatIEat.ToString());


        }


        
    }
}
