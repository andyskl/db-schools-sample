﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCourseProject
{
    class EntitiesHolder
    {
        static SchoolEntities schoolsEntities;

        public static SchoolEntities Entities
        {
            get
            {
                if (schoolsEntities == null)
                    schoolsEntities = new SchoolEntities();
                return schoolsEntities;
            }
        }
    }
}
