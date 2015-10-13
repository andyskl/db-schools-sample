using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class EmployeeTypeSimpleEntity : BasicSimpleEntity, ISimpleEntity
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
            EmployeeType et = new EmployeeType();
            et.idEmployeeType = FreeIndex;
            et.nameEmployeeType = value;
            EntitiesHolder.Entities.EmployeeType.AddObject(et);
        }

        protected override void SetValue(string oldValue, string newValue)
        {
            var et =
                (from entry in EntitiesHolder.Entities.EmployeeType
                 where entry.nameEmployeeType == oldValue
                 select entry).First();
            et.nameEmployeeType = newValue;
        }

        protected override void DeleteValue(string value)
        {
            var et =
                (from entry in EntitiesHolder.Entities.EmployeeType
                 where entry.nameEmployeeType == value
                 select entry).First();
            EntitiesHolder.Entities.EmployeeType.DeleteObject(et);
        }

        public System.Linq.IQueryable<string> Values
        {
            get
            {
                return
                    (from entry in EntitiesHolder.Entities.v_employeeTypeName
                     select entry.nameEmployeeType);
            }
        }

        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from entry in EntitiesHolder.Entities.EmployeeType
                 select entry.idEmployeeType);
        }

        protected override IQueryable<string> GetRawNameData()
        {
            return
                (from entry in EntitiesHolder.Entities.EmployeeType
                 select entry.nameEmployeeType);
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
