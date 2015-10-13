using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class SchoolVehiclesCustomEntity
    {
        public void AddValue(decimal idSchool, decimal idVehicleType, decimal amount)
        {
            var sameVehicleTools =
                (from sv in EntitiesHolder.Entities.SchoolVehicles
                 where sv.idSchool == idSchool && sv.idVehicleType == idVehicleType
                 select sv).ToList();
            if (sameVehicleTools.Count > 0)
            {
                throw new ValueAlreadyExistsException();
            }
            SchoolVehicles schoolVehicles = new SchoolVehicles();
            schoolVehicles.idSchool = idSchool;
            schoolVehicles.idVehicleType = idVehicleType;
            schoolVehicles.amount = amount;
            EntitiesHolder.Entities.SchoolVehicles.AddObject(schoolVehicles);
            EntitiesHolder.Entities.SaveChanges();
        }

        public void SetValue(decimal idSchool, decimal idVehicleType, decimal amount)
        {
            var schoolVehicles =
                (from sv in EntitiesHolder.Entities.SchoolVehicles
                 where sv.idSchool == idSchool && sv.idVehicleType == idVehicleType
                 select sv).First();
            schoolVehicles.amount = amount;
            EntitiesHolder.Entities.SaveChanges();
        }

        public void DeleteValue(decimal idSchool, decimal idVehicleType)
        {
            var schoolVehicles =
                (from sv in EntitiesHolder.Entities.SchoolVehicles
                 where sv.idSchool == idSchool && sv.idVehicleType == idVehicleType
                 select sv).First();
            EntitiesHolder.Entities.SchoolVehicles.DeleteObject(schoolVehicles);
            EntitiesHolder.Entities.SaveChanges();
        }
    }
}
