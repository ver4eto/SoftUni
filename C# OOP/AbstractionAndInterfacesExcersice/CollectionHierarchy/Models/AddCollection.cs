using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : Collection

    {
        public override int Add(string item)
        {
            base.Add(item);
            return base.CollectedData.Count - 1;
        }
    }
}
