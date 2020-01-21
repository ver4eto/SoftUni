using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Models
{
    public abstract class Collection 
    {
        private const int MAX_CAPACITY_LIST = 100;
        public Collection()
        {
            this.CollectedData = new List<string>(MAX_CAPACITY_LIST);
        }

        public List<string> CollectedData { get; }

        public virtual int Add(string item)
        {
            this.CollectedData.Insert(0, item);
            return 0;
        }
    }
}
