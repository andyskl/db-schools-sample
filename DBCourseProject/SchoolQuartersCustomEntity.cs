using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class SchoolQuartersCustomEntity
    {
        public void AddValue(decimal idSchool, decimal idQuartersType, decimal area)
        {
            var sameSchoolQuarters =
                (from sq in EntitiesHolder.Entities.SchoolQuarters
                 where sq.idSchool == idSchool && sq.idQuartersType == idQuartersType
                 select sq).ToList();
            if (sameSchoolQuarters.Count > 0)
            {
                throw new ValueAlreadyExistsException();
            }
            SchoolQuarters schoolQuarters = new SchoolQuarters();
            schoolQuarters.idSchool = idSchool;
            schoolQuarters.idQuartersType = idQuartersType;
            schoolQuarters.area = area;
            EntitiesHolder.Entities.SchoolQuarters.AddObject(schoolQuarters);
            EntitiesHolder.Entities.SaveChanges();
        }

        public void SetValue(decimal idSchool, decimal idQuartersType, decimal area)
        {
            var schoolQuarters =
                (from sq in EntitiesHolder.Entities.SchoolQuarters
                 where sq.idSchool == idSchool && sq.idQuartersType == idQuartersType
                 select sq).First();
            schoolQuarters.area = area;
            EntitiesHolder.Entities.SaveChanges();
        }

        public void DeleteValue(decimal idSchool, decimal idQuartersType)
        {
            var schoolQuarters =
               (from sq in EntitiesHolder.Entities.SchoolQuarters
                where sq.idSchool == idSchool && sq.idQuartersType == idQuartersType
                select sq).First();
            EntitiesHolder.Entities.SchoolQuarters.DeleteObject(schoolQuarters);
            EntitiesHolder.Entities.SaveChanges();
        }
    }
}
