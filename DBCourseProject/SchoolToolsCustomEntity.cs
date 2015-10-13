using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class SchoolToolsCustomEntity
    {
        public void AddValue(decimal idSchool, decimal idToolType, decimal amount)
        {
            var sameSchoolTools =
                (from st in EntitiesHolder.Entities.SchoolTools
                 where st.idSchool == idSchool && st.idToolType == idToolType
                 select st).ToList();
            if (sameSchoolTools.Count > 0)
            {
                throw new ValueAlreadyExistsException();
            }
            SchoolTools schoolTools = new SchoolTools();
            schoolTools.idSchool = idSchool;
            schoolTools.idToolType = idToolType;
            schoolTools.amount = amount;
            EntitiesHolder.Entities.SchoolTools.AddObject(schoolTools);
            EntitiesHolder.Entities.SaveChanges();
        }

        public void SetValue(decimal idSchool, decimal idToolType, decimal amount)
        {
            var schoolTools =
                (from st in EntitiesHolder.Entities.SchoolTools
                 where st.idSchool == idSchool && st.idToolType == idToolType
                 select st).First();
            schoolTools.amount = amount;
            EntitiesHolder.Entities.SaveChanges();
        }

        public void DeleteValue(decimal idSchool, decimal idToolType)
        {
            var schoolTools =
                (from st in EntitiesHolder.Entities.SchoolTools
                 where st.idSchool == idSchool && st.idToolType == idToolType
                 select st).First();
            EntitiesHolder.Entities.SchoolTools.DeleteObject(schoolTools);
            EntitiesHolder.Entities.SaveChanges();
        }
    }
}
