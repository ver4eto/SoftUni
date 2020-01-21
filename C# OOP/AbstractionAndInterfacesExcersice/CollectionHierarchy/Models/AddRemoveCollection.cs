using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : Collection, IAddRemoveCollection
    {
        public virtual string Remove()
        {
            string removedString = base.CollectedData[base.CollectedData.Count - 1];

            base.CollectedData.RemoveAt(base.CollectedData.Count - 1);

            return removedString;
        }

        public override int Add(string item)
        {
            base.CollectedData.Insert(0, item);

            return 0;
        }
    }
}
