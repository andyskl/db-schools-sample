using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    public class CustomEntity
    {
        protected virtual IQueryable<decimal> GetRawIndexData() { return null; }

        protected decimal FreeIndex
        {
            get
            {
                var rawData = GetRawIndexData();
                var listData = rawData.ToList<decimal>();
                decimal index = listData.Find(
                    (id) => !listData.Contains(id + 1));
                return index + 1;
            }
        }

        protected virtual decimal Capacity
        {
            get
            {
                return 0;
            }
        }

        protected void CheckCapacity()
        {
            if (FreeIndex >= Capacity)
                throw new CapacityOverflowException();
        }
    }
}
