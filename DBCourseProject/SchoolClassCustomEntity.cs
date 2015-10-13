using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class SchoolClassCustomEntity : CustomEntity
    {
        decimal idSchool;

        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from sc in EntitiesHolder.Entities.SchoolClass
                 where sc.idSchool == idSchool
                 select sc.idClass);
        }

        protected override decimal Capacity
        {
            get
            {
                return 100;
            }
        }

        public void AddValue(decimal idSchool, decimal idClassType, string nameClass, decimal boysAmount, decimal girlsAmount)
        {
            this.idSchool = idSchool;
            CheckCapacity();
            CheckName(idSchool, nameClass, true);
            SchoolClass sc = new SchoolClass();
            sc.idClass = FreeIndex;
            sc.idSchool = idSchool;
            sc.idClassType = idClassType;
            sc.nameClass = nameClass;
            sc.boysAmount = boysAmount;
            sc.girlsAmount = girlsAmount;
            EntitiesHolder.Entities.SchoolClass.AddObject(sc);
            EntitiesHolder.Entities.SaveChanges();
        }

        public void SetValue(decimal idClass, decimal idSchool, decimal idClassType, string nameClass, decimal boysAmount, decimal girlsAmount)
        {
            CheckName(idSchool, nameClass, false, idClass);
            SchoolClass schoolClass =
                (from sc in EntitiesHolder.Entities.SchoolClass
                 where sc.idClass == idClass
                 select sc).First();
            schoolClass.idSchool = idSchool;
            schoolClass.idClassType = idClassType;
            schoolClass.nameClass = nameClass;
            schoolClass.boysAmount = boysAmount;
            schoolClass.girlsAmount = girlsAmount;
            EntitiesHolder.Entities.SaveChanges();
        }

        public void DeleteValue(decimal idClass)
        {
            SchoolClass schoolClass =
               (from sc in EntitiesHolder.Entities.SchoolClass
                where sc.idClass == idClass
                select sc).First();
            EntitiesHolder.Entities.DeleteObject(schoolClass);
            EntitiesHolder.Entities.SaveChanges();
        }

        private void CheckName(decimal idSchool, string nameClass, bool adding, decimal idClass = 0)
        {
            var sameNames =
                adding ?
                (from sc in EntitiesHolder.Entities.SchoolClass
                 where sc.idSchool == idSchool && sc.nameClass == nameClass
                 select sc) :
                (from sc in EntitiesHolder.Entities.SchoolClass
                 where sc.idSchool == idSchool && sc.nameClass == nameClass && sc.idClass != idClass
                 select sc);
            if (sameNames.Count() > 0)
                throw new ValueAlreadyExistsException();
        }
    }
}
