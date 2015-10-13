using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class PropertyTypeSimpleEntity : BasicSimpleEntity, ISimpleEntity
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
            PropertyType pt = new PropertyType();
            pt.idPropertyType = FreeIndex;
            pt.namePropertyType = value;
            EntitiesHolder.Entities.PropertyType.AddObject(pt);
        }

        protected override void SetValue(string oldValue, string newValue)
        {
            var pt =
                (from entry in EntitiesHolder.Entities.PropertyType
                 where entry.namePropertyType == oldValue
                 select entry).First();
            pt.namePropertyType = newValue;
        }

        protected override void DeleteValue(string value)
        {
            var pt =
                (from entry in EntitiesHolder.Entities.PropertyType
                 where entry.namePropertyType == value
                 select entry).First();
            EntitiesHolder.Entities.PropertyType.DeleteObject(pt);
        }

        public System.Linq.IQueryable<string> Values
        {
            get
            {
                return
                    (from entry in EntitiesHolder.Entities.v_propertyNames
                     select entry.namePropertyType);
            }
        }

        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from entry in EntitiesHolder.Entities.PropertyType
                 select entry.idPropertyType);
        }

        protected override IQueryable<string> GetRawNameData()
        {
            return
                (from entry in EntitiesHolder.Entities.PropertyType
                 select entry.namePropertyType);
        }

        protected override decimal Capacity
        {
            get
            {
                return 10;
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
