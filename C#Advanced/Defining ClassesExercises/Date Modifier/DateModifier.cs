using System;
using System.Collections.Generic;
using System.Text;

namespace Date_Modifier
{
    class DateModifier
    {
        private DateTime firstDate;
        private DateTime secondDate;

        //public DateModifier()
        //{

        //}
        //public DateTime FirstDate { get; set; }
        //public DateTime SecondDate { get; set; }

        public  int DifferenceBetweenTwoDates(string firstDate, string secondDate)
        {
            this.firstDate = DateTime.Parse(firstDate);
            this.secondDate = DateTime.Parse(secondDate);

            int result = (int)((this.firstDate - this.secondDate).TotalDays);

            return Math.Abs(result);
        }
        
    }
}
