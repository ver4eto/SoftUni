using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public abstract class Model
    {
        public string Id { get; private set; }
        public Model(string id)
        {
            this.Id = id;
        }

        public abstract bool LastDigitOfID(string lastDigit);

        public override string ToString()
        {
            return this.Id.ToString().TrimEnd();
        }
    }
}
