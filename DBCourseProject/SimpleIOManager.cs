using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace DBCourseProject
{
    class SimpleIOManager
    {
        private static Dictionary<int, ISimpleEntity> simpleEntities
            = new Dictionary<int, ISimpleEntity>()
            {
                {(int)SimpleEntities.Subject, new SubjectSimpleEntity()},
                {(int)SimpleEntities.QuartersType, new QuartersTypeSimpleEntity()},
                {(int)SimpleEntities.ToolType, new ToolTypeSimpleEntity()},
                {(int)SimpleEntities.PropertyType, new PropertyTypeSimpleEntity()},
                {(int)SimpleEntities.ClassType, new ClassTypeSimpleEntity()},
                {(int)SimpleEntities.VehicleType, new VehicleTypeSimpleEntity()},
                {(int)SimpleEntities.EmployeeType, new EmployeeTypeSimpleEntity()},
                {(int)SimpleEntities.District, new DistrictSimpleEntity()}
            };

        static int currentEntityKey = (int)SimpleEntities.Subject;

        static ISimpleEntity currentEntity = simpleEntities[currentEntityKey];

        public enum SimpleEntities
        {
            Subject,
            QuartersType,
            ToolType,
            PropertyType,
            ClassType,
            VehicleType,
            EmployeeType,
            District
        }        

        public static SimpleEntities CurrentEntityType
        {
            set
            {
                currentEntityKey = (int)value;
                currentEntity = simpleEntities[currentEntityKey];
            }
        }

        public static ISimpleEntity CurrentEntity
        {
            get
            {
                return currentEntity;
            }
        }
    }
}
