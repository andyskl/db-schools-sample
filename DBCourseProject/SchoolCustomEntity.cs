using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class SchoolCustomEntity : CustomEntity
    {
        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from s in EntitiesHolder.Entities.School
                 select s.idSchool);
        }

        protected override decimal Capacity
        {
            get
            {
                return 10000000000;
            }
        }

        public void AddValue(string schoolName, decimal idSPT, decimal idSBPT, decimal amount, string address, decimal idDistrict)
        {
            CheckCapacity();
            var sameSchools =
                (from sc in EntitiesHolder.Entities.School
                 where sc.nameSchool == schoolName
                 select sc).ToList();
            if (sameSchools.Count > 0)
            {
                throw new ValueAlreadyExistsException();
            }
            School s = new School();
            s.idSchool = FreeIndex;
            s.nameSchool = schoolName;
            s.idSchoolPropertyType = idSPT;
            s.idSchoolBuildingPropertyType = idSBPT;
            s.computersAmount = amount;
            s.address = address;
            s.idDistrict = idDistrict;
            EntitiesHolder.Entities.School.AddObject(s);
            EntitiesHolder.Entities.SaveChanges();
        }

        public void SetValue(decimal idSchool, string schoolName, decimal idSPT, decimal idSBPT, decimal amount, string address, decimal idDistrict)
        {
            var sameSchools =
                (from sc in EntitiesHolder.Entities.School
                 where sc.nameSchool == schoolName && sc.idSchool != idSchool
                 select sc).ToList();
            if (sameSchools.Count > 0)
            {
                throw new ValueAlreadyExistsException();
            }
            School s =
                (from sc in EntitiesHolder.Entities.School
                 where sc.idSchool == idSchool
                 select sc).First();
            s.nameSchool = schoolName;
            s.idSchoolPropertyType = idSPT;
            s.idSchoolBuildingPropertyType = idSBPT;
            s.computersAmount = amount;
            s.address = address;
            s.idDistrict = idDistrict;
            EntitiesHolder.Entities.SaveChanges();
        }

        public void DeleteValue(decimal idSchool)
        {
            School s =
                (from sc in EntitiesHolder.Entities.School
                 where sc.idSchool == idSchool
                 select sc).First();
            EntitiesHolder.Entities.School.DeleteObject(s);
            EntitiesHolder.Entities.SaveChanges();
        }
    }
}
