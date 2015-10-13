using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class DistrictSimpleEntity : BasicSimpleEntity, ISimpleEntity
    {
        public int TextLength
        {
            get
            {
                return 50;
            }
        }

        protected override void AddValue(string value)
        {
            District d = new District();
            d.idDistrict = FreeIndex;
            d.nameDistrict = value;
            EntitiesHolder.Entities.District.AddObject(d);
        }

        protected override void SetValue(string oldValue, string newValue)
        {
            var d =
                (from entry in EntitiesHolder.Entities.District
                 where entry.nameDistrict == oldValue
                 select entry).First();
            d.nameDistrict = newValue;
        }

        protected override void DeleteValue(string value)
        {
            var d =
                (from entry in EntitiesHolder.Entities.District
                 where entry.nameDistrict == value
                 select entry).First();
            EntitiesHolder.Entities.District.DeleteObject(d);
        }

        public System.Linq.IQueryable<string> Values
        {
            get
            {
                return
                    (from entry in EntitiesHolder.Entities.District
                     select entry.nameDistrict);
            }
        }

        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from entry in EntitiesHolder.Entities.District
                 select entry.idDistrict);
        }

        protected override IQueryable<string> GetRawNameData()
        {
            return
                     (from entry in EntitiesHolder.Entities.District
                      select entry.nameDistrict);
        }

        protected override decimal Capacity
        {
            get
            {
                return 100;
            }
        }

        protected override decimal Length
        {
            get
            {
                return 50;
            }
        }
    }
}
