using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class QuartersTypeSimpleEntity : BasicSimpleEntity, ISimpleEntity
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
            QuartersType qt = new QuartersType();
            qt.idQuartersType = FreeIndex;
            qt.nameQuartersType = value;
            EntitiesHolder.Entities.QuartersType.AddObject(qt);
        }

        protected override void SetValue(string oldValue, string newValue)
        {
            var qt =
                (from entry in EntitiesHolder.Entities.QuartersType
                 where entry.nameQuartersType == oldValue
                 select entry).First();
            qt.nameQuartersType = newValue;
        }

        protected override void DeleteValue(string value)
        {
            var qt =
                (from entry in EntitiesHolder.Entities.QuartersType
                 where entry.nameQuartersType == value
                 select entry).First();
            EntitiesHolder.Entities.QuartersType.DeleteObject(qt);
        }

        public System.Linq.IQueryable<string> Values
        {
            get
            {
                return
                    (from entry in EntitiesHolder.Entities.v_quartersNames
                     select entry.nameQuartersType);
            }
        }

        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from entry in EntitiesHolder.Entities.QuartersType
                 select entry.idQuartersType);
        }

        protected override IQueryable<string> GetRawNameData()
        {
            return
                (from entry in EntitiesHolder.Entities.QuartersType
                 select entry.nameQuartersType);
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
