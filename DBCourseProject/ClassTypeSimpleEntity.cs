using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class ClassTypeSimpleEntity : BasicSimpleEntity, ISimpleEntity
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
            ClassType ct = new ClassType();
            ct.idClassType = FreeIndex;
            ct.nameClassType = value;
            EntitiesHolder.Entities.ClassType.AddObject(ct);
        }

        protected override void SetValue(string oldValue, string newValue)
        {
            var ct =
                (from entry in EntitiesHolder.Entities.ClassType
                 where entry.nameClassType == oldValue
                 select entry).First();
            ct.nameClassType = newValue;
        }

        protected override void DeleteValue(string value)
        {
            var ct =
                (from entry in EntitiesHolder.Entities.ClassType
                 where entry.nameClassType == value
                 select entry).First();
            EntitiesHolder.Entities.ClassType.DeleteObject(ct);
        }

        public System.Linq.IQueryable<string> Values
        {
            get
            {
                return
                    (from entry in EntitiesHolder.Entities.v_classNames
                     select entry.nameClassType);
            }
        }

        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from entry in EntitiesHolder.Entities.ClassType
                 select entry.idClassType);
        }

        protected override IQueryable<string> GetRawNameData()
        {
            return
                (from entry in EntitiesHolder.Entities.ClassType
                 select entry.nameClassType);
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
