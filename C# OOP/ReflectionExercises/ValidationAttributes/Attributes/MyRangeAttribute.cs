﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        public MyRangeAttribute(int minVaue, int maxValue)
        {
            this.minValue = minVaue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            int value = Convert.ToInt32(obj);

            if (value<this.minValue || value>this.maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
