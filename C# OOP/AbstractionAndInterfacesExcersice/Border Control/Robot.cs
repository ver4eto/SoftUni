using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : Model
    {
        public Robot(string model,string id)
            :base (id)
        {
            this.Model = model;
           
        }
       
        public string Model { get; private set; }
        public override bool LastDigitOfID(string lastDigit)
        {
            if (this.Id.EndsWith(lastDigit))
            {
                return true;
            }
            return false;
        }
    }
}
