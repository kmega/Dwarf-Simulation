﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPlanes.Entities
{
    public class ControlTower
    {
        #region DO NOT TOUCH THIS CODE

        private Runway[] runways;

        public ControlTower(Runway[] runways)
        {
            this.runways = runways;
        }

        #endregion DO NOT TOUCH THIS CODE

        #region IMPLEMENT THIS CODE

        public Runway GetAvailableRunway()
        {
            throw new NotImplementedException();
        }

        #endregion IMPLEMENT THIS CODE
    }
}