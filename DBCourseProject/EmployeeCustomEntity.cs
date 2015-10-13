using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class EmployeeCustomEntity : CustomEntity
    {
        protected override IQueryable<decimal> GetRawIndexData()
        {
            return
                (from e in EntitiesHolder.Entities.Employee
                 select e.idEmployee);
        }

        protected override decimal Capacity
        {
            get
            {
                return 10000000;
            }
        }

        public void AddValue(decimal idSchool, decimal idEmployeeType, string name, decimal gender, string address, string education, decimal rank, decimal idSubject, decimal idDistrict)
        {            
            CheckCapacity();
            Employee emp = new Employee();
            emp.idEmployee = FreeIndex;
            emp.idSchool = idSchool;
            emp.idEmployeeType = idEmployeeType;
            emp.nameEmployee = name;
            emp.gender = gender;
            emp.address = address;
            emp.rank = rank;
            emp.education = education;
            emp.idSubject = idSubject;
            emp.idDistrict = idDistrict;
            EntitiesHolder.Entities.Employee.AddObject(emp);
            EntitiesHolder.Entities.SaveChanges();
        }

        public void SetValue(decimal idEmployee, decimal idSchool, decimal idEmployeeType, string name, decimal gender, string address, string education, decimal rank, decimal idSubject, decimal idDistrict)
        {                        
            Employee emp =
                (from e in EntitiesHolder.Entities.Employee
                 where e.idEmployee == idEmployee
                 select e).First();
            emp.idSchool = idSchool;
            emp.idEmployeeType = idEmployeeType;
            emp.nameEmployee = name;
            emp.gender = gender;
            emp.address = address;
            emp.rank = rank;
            emp.education = education;
            emp.idSubject = idSubject;
            emp.idDistrict = idDistrict;
            EntitiesHolder.Entities.SaveChanges();
        }

        public void DeleteValue(decimal idEmployee)
        {
            Employee emp =
                (from e in EntitiesHolder.Entities.Employee
                 where e.idEmployee == idEmployee
                 select e).First();
            EntitiesHolder.Entities.Employee.DeleteObject(emp);
            EntitiesHolder.Entities.SaveChanges();
        }
    }
}
