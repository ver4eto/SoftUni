using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : Collection, IMyList, IAddRemoveCollection
    {
        public int Used {
            get=> base.CollectedData.Count;
            set
            {

            }
        }

        public string Remove()
        {
            string remvedString = base.CollectedData[0];

            base.CollectedData.RemoveAt(0);

            return remvedString;
        }

        public override int Add(string item)
        {
            base.CollectedData.Insert(0, item);

            return 0;
        }
    }
}
