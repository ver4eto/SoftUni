﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
   public abstract class Shape
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();

        public virtual string Draw()
        {
            string shape="Drawing";
            return shape;
        }
    }
}