﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
  public abstract  class Bird : Animal
    {
        public Bird(string name, double weight,double wingSize)
            : base (name,weight)
        {
            this.WingSize = wingSize;
        }
        public double WingSize { get;private set; }

       
    }
}
